using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Vektor.Printer; 
using System.Printing;
using System.Net;
using System.Net.Mail;
using System.Globalization;

namespace Vektor
{
    public partial class FormMain : Form
    {
        public ProgAyarForm ProgAyarFrm;
        public Programming ProgrammingFrm;
        public Sifre SifreFrm;
        private IntPtr ShellHwnd;
        private Thread programingErrorTh = null;
        private Thread mp3ActionTh = null;
        private Thread mailSendTh = null;
        private Thread printerTh = null;

        string customMessageBoxTitle;
        int adminTimerCounter = 0;
        int loopTimerCounter = 0;

        int ictTimerCounter = 0;
        int totalICTCard = 0;
        public int errorICTCard = 0;

        int programingTimerCounter = 0;
        int totalprogramingCard = 0;
        public int errorprogramingCard = 0;

        int motorTimerCounter = 0;
        int totalMotorCard = 0;
        int errorMotorCard = 0;

        int outputWriteTimerCounter = 0;
        int totalMeasurementCard = 0;
        int errorMeasurementCard = 0;

        int kameraTimerCounter = 0;
        int totalKameraCard = 0;
        int errorKameraCard = 0;

        public int yetki;

        byte[] arrayRx = new byte[256];
        int counterRxByte = 0;
        string[] feedbackCare = new string[2];

        byte[] byteArray = new byte[8];
        int byteLenght = 0;
        byte[] feedback = new byte[256];
        string printerName;

        string cameraState = "";
        string oldCameraState = "";
        string ethernetState = "";
        string oldEthernetState = "";
        string componentOK = "";
        string componentNOK = "";
        string labelOK = "";
        string labelNOK = "";
        string processDone = "";
        string snapShot = "";

        bool ICTMailState = true;
        bool programingMailState = false;
        bool measurementMailState = true;
        bool motorMailState = false;
        bool kameraMailState = false;

        bool programingTimeoutState = false;
        bool motorTimeoutState = false;
        bool outputWriteTimeoutState = false;
        bool kameraTimeoutState = false;

        bool motorSpeedState = false;
        int motorSpeedCount = 0;
        int motorStartCount = 0;
        bool motorStartState = false;

        int kameraProcessCounter = 0;
        bool processControlState = true;
        string printerErrorCode = "";
        string fullProductCode = "";
        bool sqlTextOnOffState = false;
        int sqlTextOnOffCounter = 0;

        int verimCount = 0;

        bool mp3State = false;
        int mp3Count = 0;
        int mediaCounterLoop = 0;
        int stationLoopCount = 0;
        bool loopState = true;
        public bool tabRemove = false;

        string companyNo; //Barkoddan Karşılatırılan
        public string SAPNo;  //Barkoddan Karşılatırılan
        string productionDate;  //Barkoddan Alınan
        string indexNo; //Barkoddan Alınan
        string productionNo; //Barkoddan Alınan
        string cardNo;  //Barkoddan Karşılatırılan
        string gerberVer;  //Sabit
        string BOMVer;  //Sabit
        string ICTRev;  //Sabit
        string FCTRev;  //Sabit
        string softwareVer;  //Sabit
        string softwareRev;  //Sabit
        string barcode50 = "";
        bool printerError = false;
        string hafta = "";
        string yil = "";

        bool txtYazState = false;
        public class INIKaydet
        {
            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

            public INIKaydet(string dosyaYolu)
            {
                DOSYAYOLU = dosyaYolu;
            }
            private string DOSYAYOLU = String.Empty;
            public string Varsayilan { get; set; }
            public string Oku(string bolum, string ayaradi)
            {
                Varsayilan = Varsayilan ?? string.Empty;
                StringBuilder StrBuild = new StringBuilder(256);
                GetPrivateProfileString(bolum, ayaradi, Varsayilan, StrBuild, 255, DOSYAYOLU);
                return StrBuild.ToString();
            }
            public long Yaz(string bolum, string ayaradi, string deger)
            {
                return WritePrivateProfileString(bolum, ayaradi, deger, DOSYAYOLU);
            }
        }

        public FormMain()
        {
            this.ProgAyarFrm = new ProgAyarForm();
            this.ProgAyarFrm.MainFrm = this;
            this.SifreFrm = new Sifre();
            this.SifreFrm.MainFrm = this;
            this.ProgrammingFrm = new Programming();
            this.ProgrammingFrm.MainFrm = this;
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern byte ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string ClassName, string WindowName);
        bool flag = true;
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {/*
            if (flag == true)
            {
                FormData.Default.formSayac = 0;
                FormData.Default.Save();
            }
            else
            {*/
                nxCompoletBoolWrite("connectionStart", false);
                nxCompoletBoolWrite("cameraState", false);
                nxCompoletBoolWrite("ethernetState", false);
                closePythonBatchFile();
                loopTimer.Stop();
                loopTimer.Enabled = false;
                if (programingErrorTh != null)
                {
                    programingErrorTh.Abort();
                }
                if (mp3ActionTh != null)
                {
                    mp3ActionTh.Abort();
                }
                if (mailSendTh != null)
                {
                    mailSendTh.Abort();
                }
                if (printerTh != null)
                {
                    printerTh.Abort();
                }
           // }
        }

        public void runPythonBatchFile()
        {
            Process.Start(@"C:\\Users\\Ar-Ge\\Desktop\\pcb-component-inspection-master-Windows\\abra_kadabra_s.py");
            Process.Start(@"C:\\Users\\Ar-Ge\\Desktop\\pcb-component-inspection-master-Windows\\abra_kadabra_r.py");
            //Process.Start(@"C:\\Users\\Ar-Ge\\Desktop\\SQL-TEXT\\SQLTEXT\\bin\\Debug\\SQLTEXT.exe");
            //Process.Start(@"C:\Program Files (x86)\\AlpNext\\SQLSetup\\SQLTEXT.exe");
        }

        public void closePythonBatchFile()
        { 
            Process.Start(@"C:\\Users\\Ar-Ge\\Desktop\\pcb-component-inspection-master-Windows\\PYTHONEXIT.bat");
            //Process.Start(@"C:\\Users\\Ar-Ge\\Desktop\\Vektor-Programlama\\SQLTEXTEXIT.bat");
        }

        private void FormMain_Load(object sender, EventArgs e)  //FORM LOAD
        {
           /* FormData.Default.formSayac++;
            if (FormData.Default.formSayac == 1)
            {*/
                runPythonBatchFile();
                ProgrammingFrm.programingInit();
                formMainInit();

                nxCompoletBoolWrite("connectionStart", true);
                if (nxCompoletBoolRead("connectionStart"))
                {
                    lblStatusCom2.Text = "ON";
                    lblStatusCom2.BackColor = Color.Green;
                    loopTimer.Start();
                }
                else
                {
                    lblStatusCom2.Text = "OFF";
                    lblStatusCom2.BackColor = Color.Red;
                }
                DateTime dt = DateTime.Now;
                hafta = Convert.ToString(weekNum(dt));
                yil = Convert.ToString(dt.Year);
                yil = yil.Substring(2, 2);
            if (hafta.Length == 1)
                hafta = "0" + hafta;
                productionDate = hafta + yil;
                haftaLabel.Text = hafta;
                yilLabel.Text = yil;
                //sqlTxtOnOffYaz(1);  //TxtSqlOn      ??? SQL yok diye kapatıldı.  
              /*  flag = true;
            }
            if (FormData.Default.formSayac == 2)
            {
                this.Close();
                FormData.Default.formSayac = 1;
                flag = false;
            }
            FormData.Default.Save();*/
        }

        private void formMainInit()     //FORM INIT
        {
            this.ShellHwnd = FormMain.FindWindow("Shell TrayWnd", (string)null);
            IntPtr shellHwnd = this.ShellHwnd;
            int num1 = (int)FormMain.ShowWindow(this.ShellHwnd, 0);

            this.customMessageBoxTitle = Prog_Ayarlar.Default.projectName;
            this.projectNameTxt.Text = customMessageBoxTitle;
            this.Text = customMessageBoxTitle;

            this.cardPicture.ImageLocation = Prog_Ayarlar.Default.PNGdosyayolu;

            foreach (string portName in SerialPort.GetPortNames())
            {
                this.ProgAyarFrm.serialPort1Com.Items.Add((object)portName);
            }

            this.timerAdmin.Interval = Prog_Ayarlar.Default.timerAdmin;
            this.printerName = Prog_Ayarlar.Default.printerName;

            companyNo = Prog_Ayarlar.Default.companyNo;
            //SAPNo = Prog_Ayarlar.Default.SAPNo;  
            if (Prog_Ayarlar.Default.SAPNo == "2500001000")
            {
                SAPNo = "2849540300";
            }
            else if (Prog_Ayarlar.Default.SAPNo == "2446407000")
            {
                SAPNo = "2849540300";
            }
            else if (Prog_Ayarlar.Default.SAPNo == "1921403000")
            {
                SAPNo = "1921403000";
            }
            cardNo = Prog_Ayarlar.Default.cardNo;
            gerberVer = Prog_Ayarlar.Default.gerberVer;
            BOMVer = Prog_Ayarlar.Default.BOMVer;
            ICTRev = Prog_Ayarlar.Default.ICTRev;
            FCTRev = Prog_Ayarlar.Default.FCTRev;
            softwareVer = Prog_Ayarlar.Default.softwareVer;
            softwareRev = Prog_Ayarlar.Default.softwareRev;
            productionNo = Prog_Ayarlar.Default.productionNo;

            this.yetki = 0;
            this.yetkidegistir();
        }

        /****************************************** DENEME *************************************************/

        #region Events
        /****************************************** Compolet Fonksiyon *************************************************/
        public bool nxCompoletBoolWrite(string variable, bool value)  //NX WRITE
        {
            try
            {
                nxCompolet1.WriteVariable(variable, value);
                return true;
            }
            catch
            {
               // otherConsoleAppendLine("nxCompolet Hatası" + "\nKonum : BoolWrite" + "\nvariable = " + variable + "\nstate = " + value, Color.Red);
                // StopModBusThread();  // Haberleşme Hatası
                return false;
            }
        }

        public bool nxCompoletBoolRead(string variable)  //NX READ
        {
            try
            {
                return Convert.ToBoolean(nxCompolet1.ReadVariable(variable));
            }
            catch
            {
               // otherConsoleAppendLine("nxCompolet Hatası" + "\nKonum : BoolRead" + "\nvariable = " + variable, Color.Red);
                // StopModBusThread();  //Haberleşme Hatası
                return false;
            }
        }

        public string nxCompoletStringRead(string variable)  //NX STRING
        {
            try
            {
                return Convert.ToString(nxCompolet1.ReadVariable(variable));
            }
            catch
            {
               // otherConsoleAppendLine("nxCompolet Hatası" + "\nKonum : StringRead" + "\nvariable = " + variable, Color.Red);
                // StopModBusThread();  //Haberleşme Hatası
                return "error";
            }
        }

        void acilPress()
        {
            stationLoopCount++;
            if (stationLoopCount == 5)
            {
                stationLoopCount = 0;
                if (nxCompoletBoolRead("acilPress"))
                {
                    if (loopState)
                    {
                        programingRestart();
                        outputWriteRestart();
                        kameraRestart();
                        mp3Restart();
                    }
                    loopState = false;
                }
                else
                {
                    loopState = true;
                }
            }
        }

        /****************************************** LOOP *************************************************/
        private void loopTimer_Tick(object sender, EventArgs e)  //LOOP TIMER
        {
            loopTimerCounter++;
            if (loopTimerCounter == 1)
            {
                try
                {
                    loopTimerCounter = 0;
                    loopFunc();
                }
                catch (Exception ex)
                {
                    otherConsoleAppendLine("Thread Fonksiyonu Loop Hatası 2" + ex.Message, Color.Red);
                    // StopModBusThread();  //Loop Hatası
                }
            }
        }

        public void loopFunc()   //LOOP OTHER
        {
            try
            {
                acilPress();
                if (loopState)
                {
                    mediaCounterLoop++;
                    if (mediaCounterLoop == 5)  // 500 ms
                    {
                        mediaCounterLoop = 0;
                        mp3Loop();             // MP3 Çalıştır (1 Thread)
                        sqlTextNum();
                        firstFCTStation();     // Program ve Durdurma Batch Çalıştır (2 Thread)
                        cameraStation();
                        printerSqlStation();   // Printer Çalıştır (1 Thread)
                    }

                    verimCount++;
                    if (verimCount == 50)  // 5000 ms
                    {
                        verimCount = 0;
                        ictVerim();
                        programingVerim();
                        measurementVerim();
                        motorVerim();
                        kameraVerim();
                        //FCTVerimLoop();     // Mail Çalıştır (1 Thread)   ??? Hata Çok Diye Kapatıldı.
                    }
                }
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("Loop Hatası" + ex.Message, Color.Red);
                // StopModBusThread();  //Loop Hatası
            }
        }

        public void mp3Loop()  //MP3 Çalıştırma
        {
            try
            {
                if (nxCompoletBoolRead("mediaPlayerState") && mp3State == false)
                {
                    mp3State = true;
                    mp3Count = 0;
                    mp3ActionTh = new Thread(mp3ActionFunction);
                    mp3ActionTh.Start();
                }
                else if (nxCompoletBoolRead("mediaPlayerState") == false && mp3State == true)
                {
                    mp3State = false;
                    mp3Count = 0;
                    mp3ActionTh = new Thread(mp3ActionFunction);
                    mp3ActionTh.Start();
                }
                if (mp3State == true)
                {
                    mp3Count++;
                    if (mp3Count == 9)
                    {
                        mp3State = false;
                    }
                }
            }
            catch (Exception ex)
            {
                mp3Restart();
                otherConsoleAppendLine("mp3Loop: " + ex.Message, Color.Red);
            }
        }

        private void mp3ActionFunction()  //MP3 Çalıştırma
        {
            try
            {
                mediaPlayer.URL = "C:\\Users\\Ar-Ge\\Desktop\\hatali.mp3";
                if (mp3State == true)
                {
                    otherConsoleAppendLine("Ses Aç", Color.Red);
                    mediaPlayer.Ctlcontrols.play();
                }
                else if (mp3State == false)
                {
                    otherConsoleAppendLine("Ses Kapa", Color.Red);
                    mediaPlayer.Ctlcontrols.stop();
                }
            }
            catch (Exception ex)
            {
                mp3Restart();
                otherConsoleAppendLine("mp3ActionFunction: " + ex.Message, Color.Red);
            }
        }

        void mp3Restart()
        {
            mediaCounterLoop = 0;
            mp3State = false;
            mp3Count = 0;
        }

        public void sqlTextNum()  //SQL TEXT SAYISI
        {
            try
            {
                string filePath = Prog_Ayarlar.Default.txtSQLDosyaYolu;
                List<string> lines = new List<string>();
                if (File.Exists(filePath))
                {
                    lines = File.ReadAllLines(filePath).ToList();
                    sqlLabel.Invoke(new Action(delegate ()
                    {
                        sqlLabel.Text = Convert.ToString(lines.Count);
                        if (!nxCompoletBoolRead("sqlConnectionStop") && Convert.ToDouble(sqlLabel.Text) > 3000)  //PLC-ARAYÜZ-programing
                        {
                            nxCompoletBoolWrite("sqlConnectionStop", true);
                        }
                        else if (nxCompoletBoolRead("sqlConnectionStop"))  //PLC-ARAYÜZ-programing
                        {
                            nxCompoletBoolWrite("sqlConnectionStop", false);
                        }
                    }));
                }
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("sqlTextNum: " + ex.Message, Color.Red);
            }
        }

        public void FCTVerimLoop()  // İSTASYON VERİM MAIL
        {
            try
            {
                if ((Convert.ToDouble(verimICTTxt.Text) < 70) && (Convert.ToInt32(totalICTCardTxt.Text)) % 10 == 0 && ICTMailState && Convert.ToInt32(totalICTCardTxt.Text) != 0)
                {
                    //ICTMailState = false;
                    mailSend("Vektör Kartı ICT İstasyonu Verim Düşüklüğü", "Vektör Kartı ICT İstasyonunda Verim : " + verimICTTxt.Text);
                }
                if (Convert.ToDouble(verimProgramingTxt.Text) < 70 && (Convert.ToInt32(totalProgramingCardTxt.Text)) % 10 == 0 && programingMailState && Convert.ToInt32(totalProgramingCardTxt.Text) != 0)
                {
                    programingMailState = false;
                    mailSend("Vektör Kartı programing İstasyonu Verim Düşüklüğü", "Vektör Kartı programing İstasyonunda Verim : " + verimProgramingTxt.Text);
                }
                if (Convert.ToDouble(verimMeasurementTxt.Text) < 70 && (Convert.ToInt32(totalMeasurementCardTxt.Text)) % 10 == 0 && measurementMailState && Convert.ToInt32(totalMeasurementCardTxt.Text) != 0)
                {
                    // measurementMailState = false;
                    mailSend("Vektör Kartı Çıktılar İstasyonu Verim Düşüklüğü", "Vektör Kartı Çıktılar İstasyonunda Verim : " + verimMeasurementTxt.Text);
                }
                if (Convert.ToDouble(verimMotorTxt.Text) < 70 && (Convert.ToInt32(totalMotorCardTxt.Text)) % 10 == 0 && motorMailState && Convert.ToInt32(totalMotorCardTxt.Text) != 0)
                {
                    motorMailState = false;
                    mailSend("Vektör Kartı Motor İstasyonu Verim Düşüklüğü", "Vektör Kartı Motor İstasyonunda Verim : " + verimMotorTxt.Text);
                }
                if ((Convert.ToDouble(verimKameraTxt.Text) < 70) && (Convert.ToInt32(totalKameraCardTxt.Text)) % 10 == 0 && kameraMailState && Convert.ToInt32(totalKameraCardTxt.Text) != 0)
                {
                    kameraMailState = false;
                    mailSend("Vektör Kartı Kamera İstasyonu Verim Düşüklüğü", "Vektör Kartı Kamera İstasyonunda Verim : " + verimKameraTxt.Text);
                }
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("FCTVerimMail: " + ex.Message, Color.Red);
            }
        }

        /****************************************** 1.İstasyon *************************************************/
        public void firstFCTStation()  //FCT 1.İSTASYON  //Program At. Program Sonucunu haber ver.
        {
            try
            {
                if (nxCompoletBoolRead("programingStart"))  //PLC-ARAYÜZ-programing
                {
                    if (nxCompoletBoolWrite("programingStart", false))
                    {
                        programingTimeoutState = true;
                        nxCompoletBoolWrite("programingSuccess", false);
                        nxCompoletBoolWrite("programingFail", false);
                        ProgrammingFrm.ProgrammingStart();
                    }
                }
                if (programingTimeoutState == true)  //PROGRAMLAMA-TIMEOUT
                {
                    programingTimerCounter++;
                    ProgramingTimerTxt.Text = Convert.ToString(programingTimerCounter/10);
                    if (programingTimerCounter > Prog_Ayarlar.Default.programingTimeout * 10)
                    {
                        ProgrammingFrm.ProgramSonucFunction();  //DOLAYLI OLARAK ERROR
                    }
                }
            }
            catch (Exception ex)
            {
                programingError();
                otherConsoleAppendLine("FCTBirinciIstasyon: " + ex.Message, Color.Red);
            }
        }

        public void programingSuccess()  //PROGRAMLAMA BAŞARILI
        {
            try
            {
                if (nxCompoletBoolWrite("programingSuccess", true))
                {
                    programingRestart();
                }
                else
                {
                    programingError();
                }
            }
            catch(Exception ex)
            {
                programingError();
                otherConsoleAppendLine("programingSuccess: " + ex.Message, Color.Red);
            }
        }

        public void programingError()  //PROGRAMLAMA BAŞARISIZ
        {
            programingErrorTh = new Thread(programingErrorFunction);
            programingErrorTh.Start();
        }

        private void programingErrorFunction()  //PROGRAMLAMA BAŞARISIZ
        {
            try
            {
                String batchPath = Prog_Ayarlar.Default.vektorErrordosyayolu;
                Process processBatchVektor = new Process();
                processBatchVektor.StartInfo.UseShellExecute = false;
                processBatchVektor.StartInfo.RedirectStandardOutput = true;
                processBatchVektor.StartInfo.CreateNoWindow = true;
                processBatchVektor.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processBatchVektor.StartInfo.FileName = (string)batchPath;
                processBatchVektor.Start();

                nxCompoletBoolWrite("programingFail", true);
                otherConsoleAppendLine("programingFail Gönderildi: ", Color.Red);
                programingRestart();
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("programingError: " + ex.Message, Color.Red);
            }
        }

        public void programingRestart()  //PROGRAMLAMA RESTART
        {
            programingMailState = true;

            programingTimeoutState = false;
            programingTimerCounter = 0;
            ProgrammingFrm.programingThreadStop();
        }

        private void programingVerim()  //PROGRAMLAMA VERİM
        {
            if (nxCompoletBoolRead("programingStationState"))
            {
                errorProgramingCardTxt.Invoke(new Action(delegate ()
            {
                errorProgramingCardTxt.Text = nxCompoletStringRead("programingError");
                totalProgramingCardTxt.Text = nxCompoletStringRead("programingTotal");
                errorprogramingCard = Convert.ToInt32(errorProgramingCardTxt.Text);
                totalprogramingCard = Convert.ToInt32(totalProgramingCardTxt.Text);
                verimProgramingTxt.Text = Convert.ToString(100 - ((float)((float)errorprogramingCard / totalprogramingCard)) * 100);
            }));
            }
        }

        private void ictVerim()  //ICT VERİM
        {
            if (nxCompoletBoolRead("ictStationState"))
            {
                errorICTCardTxt.Invoke(new Action(delegate ()
                {
                    errorICTCardTxt.Text = nxCompoletStringRead("ictError");
                    totalICTCardTxt.Text = nxCompoletStringRead("ictTotal");
                    errorICTCard = Convert.ToInt32(errorICTCardTxt.Text);
                    totalICTCard = Convert.ToInt32(totalICTCardTxt.Text);
                    verimICTTxt.Text = Convert.ToString(100 - ((float)((float)errorICTCard / totalICTCard)) * 100);
                }));
            }
        }

        private void measurementVerim()  //MEASUREMENT VERİM
        {
            if (nxCompoletBoolRead("measurementStationState"))
            {
                errorMeasurementCardTxt.Invoke(new Action(delegate ()
                {
                    errorMeasurementCardTxt.Text = nxCompoletStringRead("measurementError");
                    totalMeasurementCardTxt.Text = nxCompoletStringRead("measurementTotal");
                    errorMeasurementCard = Convert.ToInt32(errorMeasurementCardTxt.Text);
                    totalMeasurementCard = Convert.ToInt32(totalMeasurementCardTxt.Text);
                    verimMeasurementTxt.Text = Convert.ToString(100 - ((float)((float)errorMeasurementCard / totalMeasurementCard)) * 100);
                }));
            }
        }

        /****************************************** 3.İstasyon *************************************************/
        private void motorVerim()  //MOTOR VERİM
        {
            if (nxCompoletBoolRead("motorStationState"))
            {
                errorMotorCardTxt.Invoke(new Action(delegate ()
                {
                    errorMotorCardTxt.Text = nxCompoletStringRead("motorError");
                    totalMotorCardTxt.Text = nxCompoletStringRead("motorTotal");
                    errorMotorCard = Convert.ToInt32(errorMotorCardTxt.Text);
                    totalMotorCard = Convert.ToInt32(totalMotorCardTxt.Text);
                    verimMotorTxt.Text = Convert.ToString(100 - ((float)((float)errorMotorCard / totalMotorCard)) * 100);
                }));
            }
        }

        /****************************************** Son İstasyon *************************************************/
        public void printerSqlStation() //FCT PRINTER-SQL //Sql için tüm lodu text'e yaz ve Yazıcıya çıktı gönder. Plc'ye haber ver.
        {
            try
            {
                if (nxCompoletBoolRead("allWriteOutputStart"))  //PLC-ARAYÜZ-YAZICI-SQL
                {
                    if (nxCompoletBoolWrite("allWriteOutputStart", false))
                    {
                        outputWriteTimeoutState = true;
                        fullProductCode = nxCompoletStringRead("fullProductCode");
                        string productCode = "";

                        for (int i = 0; i < fullProductCode.Length; i++)
                        {
                            if (fullProductCode.Substring(i, 1) == "/")
                            {
                                productCode = fullProductCode.Substring(i + 1, fullProductCode.Length - i - 1);
                            }
                        }

                        int basamak = productCode.Length;
                        if(basamak == 1)
                        {
                            productCode = "00000" + productCode;
                        }
                        else if (basamak == 2)
                        {
                            productCode = "0000" + productCode;
                        }
                        else if (basamak == 3)
                        {
                            productCode = "000" + productCode;
                        }
                        else if (basamak == 4)
                        {
                            productCode = "00" + productCode;
                        }
                        else if (basamak == 5)
                        {
                            productCode = "0" + productCode;
                        }

                        if (productCode == "050001")
                        {
                            printerErrorCode = "TRI Error";
                            printerError = true;
                        }
                        else if (productCode == "050002")
                        {
                            printerErrorCode = "FCT1 Error";
                            printerError = true;
                        }
                        else if (productCode == "050003")
                        {
                            printerErrorCode = "FCT2 Error";
                            printerError = true;
                        }
                        else if (productCode == "050004")
                        {
                            printerErrorCode = "FCT3 Error";
                            printerError = true;
                        }
                        else if (productCode == "050005")
                        {
                            printerErrorCode = "Kamera Error";
                            printerError = true;
                        }
                        else
                        {
                            printerErrorCode = "";                 //YENİ
                            printerError = false;
                        }
                        indexNo = productCode;

                        if (fullProductCode != "error" && printerErrorCode == "") //Doğru Ürün
                        {
                            //sqlTxtOnOffYaz(0);         //TxtSqlOff ??? SQL yok diye kapatıldı.
                            sqlTextOnOffState = true;   //1 sn sonra Yaz
                        }
                        else if (fullProductCode != "error") //Hatalı Ürün
                        {
                            if (printAction()) //50001 TRI //50002 FCT1 // 50003 FCT2 // 50004 FCT3 //50005 FCT4 //50006
                            {
                                outputWriteSuccess();
                            }
                            else
                            {
                                outputWriteError();
                            }
                        }
                    }
                }
                if (sqlTextOnOffState)      //SQL 1 Sn SONRA YAZ
                {
                    sqlTextOnOffCounter++;
                    //if (sqlTextOnOffCounter == 10)  //1sn sonra  ??? SQL yok diye kapatıldı.
                    //{
                    sqlTextOnOffState = false;
                    sqlTextOnOffCounter = 0;
                    if (printAction() /*&& sqlTextYaz()*/)
                    {
                        outputWriteSuccess();
                       // sqlTxtOnOffYaz(1);  //TxtSqlOn  ??? SQL yok diye kapatıldı.
                    }
                    else
                    {
                        outputWriteError();
                    }
                    //}
                }
                if (outputWriteTimeoutState == true)  //PRINTER-SQL-TIMEOUT
                {
                    outputWriteTimerCounter++;
                    MeasurementTimerTxt.Text = Convert.ToString(outputWriteTimerCounter/10);
                    if (outputWriteTimerCounter > Prog_Ayarlar.Default.outputWriteTimeout * 10)
                    {
                        outputWriteError();
                    }
                }
            }
            catch
            {
                outputWriteError();
                otherConsoleAppendLine("FCTSonIstasyon İçinde Output Hatası", Color.Red);
            }
        }

        private void sqlTxtOnOffYaz(int state)  //SQLTXTONOFF
        {
            try
            {
                if (Prog_Ayarlar.Default.txtSQLOnOffDosyaYolu != "")
                {
                    INIKaydet ini = new INIKaydet(Prog_Ayarlar.Default.txtSQLOnOffDosyaYolu);  // @"\Ayarlar.ini"
                    ini.Yaz("sqlOnOff", "Metin Kutusu", Convert.ToString(state));
                    otherConsoleAppendLine("sqlOnOff = " + ini.Oku("sqlOnOff", "Metin Kutusu"), Color.Green);
                }
                else
                {
                    otherConsoleAppendLine("Dosya Yolu Boş Kalamaz", Color.Red);
                }
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("sqlTxtOnOffYaz: " + ex.Message, Color.Red);
            }
        }

        private bool sqlTextYaz()  //fullProductCode SQLTEXT WRITE 
        {
            otherConsoleAppendLine("Girdi1", Color.Red);
            try
            {
                if (Prog_Ayarlar.Default.txtSQLDosyaYolu != "")  //Yolu değiştir
                {
                    otherConsoleAppendLine("Girdi Try Giriş", Color.Red);
                    string filePath = Prog_Ayarlar.Default.txtSQLDosyaYolu;
                    List<string> lines = new List<string>();
                    lines = File.ReadAllLines(filePath).ToList();
                    lines.Add(barcode50);
                    otherConsoleAppendLine(barcode50 + "Eklendi", Color.Green);
                    File.WriteAllLines(filePath, lines);
                    otherConsoleAppendLine("Girdi Try Son", Color.Red);
                    return true;
                }
                else
                {
                    otherConsoleAppendLine("Dosya Yolu Boş Kalamaz", Color.Red);
                    return false;
                }
            }
            catch (Exception ex)
            {
                // kameraError();
                otherConsoleAppendLine("Girdi Catch", Color.Red);
                otherConsoleAppendLine("sqlTextYaz: " + ex.Message, Color.Red);
                return false;
            }
        }
      
        private bool printAction()  //PRINTER AKSİYON
        {
            printerTh = new Thread(printerFunction);
            printerTh.Start();
            return true;
        }

        private void printerFunction()  //PRINTER AKSİYON
        {
            try
            { 
                string test = ""; 
                if (!printerError)
                {
                    barcode50 = companyNo + SAPNo + productionDate + indexNo + productionNo + cardNo + gerberVer + BOMVer + ICTRev + FCTRev + softwareVer + softwareRev;
                    sqlTextYaz();
                    string s1 = companyNo + indexNo.Substring(0, 2);
                    string s2 = indexNo.Substring(2, 4);
                    string s3 = productionNo.Substring(0, 4);
                    string s4 = productionNo.Substring(4, 4);
                    string s5 = productionNo.Substring(8, 4);
                    string s6 = productionNo.Substring(12, 2) + cardNo;
                    string start = "^XA" + "^LH0,15";
                    
                    string qr = "^BQN,3,3" + "^FDQA," + companyNo + SAPNo + productionDate + indexNo + productionNo + cardNo + gerberVer + BOMVer + ICTRev + FCTRev + softwareVer + softwareRev + "^FS";
                    
                    string veri1 = "^FO90,5" + "^A0,15,10" + "^FD" + "P/N: " + SAPNo + "^FS";   //İlki Pozisyon //İkincisi Boy-En
                    string veri2 = "^FO90,30" + "^A0,15,10" + "^FD" + "S/N: " + s1 + "-" + s2 + "-" + s3 + "^FS";   //İlki Pozisyon //İkincisi Boy-En
                    string veri3 = "^FO90,55" + "^A0,15,10" + "^FD" + "       " + s4 + "-" + s5 + "-" + s6 + "^FS";   //İlki Pozisyon //İkincisi Boy-En
                    string veri4 = "^FO90,80" + "^A0,15,10" + "^FD" + "VER: " + softwareVer + "." + softwareRev + " G:" + gerberVer + " B:" + BOMVer + " T:" + productionDate + "^FS";   //İlki Pozisyon //İkincisi Boy-En
                   string end = "^XZ";
                    test = start + qr + veri1 + veri2 + veri3 + veri4 + end;
                }
                else
                {
                    string start = "^XA" + "^LH5,15";
                    string veri0 = "^80,60" + "^A0,20,20" + "^FD" + printerErrorCode + "^FS";   //İlki Pozisyon //İkincisi Boy-En
                    string end = "^XZ";
                    test = start  + veri0 + end;
                }

                //Get local print server
                var server = new LocalPrintServer();

                //Load queue for correct printer
                PrintQueue pq = server.GetPrintQueue(printerName, new string[0] { });
                PrintJobInfoCollection jobs = pq.GetPrintJobInfoCollection();
                foreach (PrintSystemJobInfo job in jobs)
                {
                    job.Cancel();
                }

                if (!RawPrinterHelper.SendStringToPrinter(printerName, test))
                {
                    otherConsoleAppendLine("Printer Error1: ", Color.Red);
                }
            }
            catch (Exception ex)
            {
                outputWriteError();
                otherConsoleAppendLine("Printer Error2: " + ex.Message, Color.Red);
            }
        }

        public int weekNum(DateTime tarih)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(tarih);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                tarih = tarih.AddDays(3);
            }
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(tarih, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public void outputWriteSuccess()  //PRINTER-SQL BAŞARILI
        {
            try
            {
                if (nxCompoletBoolWrite("allWriteOutputSuccess", true))
                {
                    tbOtherState.Invoke(new Action(delegate ()
                    {
                        tbOtherState.BackColor = Color.Green;
                        tbOtherState.Text = "OUTPUT WRITE BAŞARILI";
                    }));
                }
                else
                {
                    outputWriteError();
                }
            }
            catch (Exception ex)
            {
                outputWriteError();
                otherConsoleAppendLine("outputWriteSuccess" + ex.Message, Color.Red);
            }
            outputWriteRestart();
        }

        public void outputWriteError()  //PRINTER-SQL BAŞARISIZ
        {
            try
            {
                nxCompoletBoolWrite("allWriteOutputFail", true);
                tbOtherState.Invoke(new Action(delegate ()
                {
                   tbOtherState.BackColor = Color.Red;
                   tbOtherState.Text = "OUTPUT WRITE BAŞARISIZ";
                }));
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("outputWriteError" + ex.Message, Color.Red);
            }
            outputWriteRestart();
        }

        public void outputWriteRestart()  //PRINTER-SQL RESTART
        {
            outputWriteTimeoutState = false;
            outputWriteTimerCounter = 0;
        }

        /****************************************** Kamera İstasyon *************************************************/
        public void cameraStation()  //FCT PLC-KAMERA KOMPONENT
        {
            kameraOku();
            try
            {
                if (nxCompoletBoolRead("snapShotOK")) //snapShotOK PLC üzerinden Kameraya Haber Ver.
                {
                    if (nxCompoletBoolWrite("snapShotOK", false))
                    {
                        kameraTimeoutState = true;
                        snapShot = "1";
                        kameraYaz();
                    }
                }
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("FCTKameraIstasyon(snapShotOK): " + ex.Message, Color.Red);
            }

            try
            {
                if (nxCompoletBoolRead("snapShotNOK"))  //snapShotNOK PLC üzerinden Kameraya Haber Ver.
                {
                    snapShot = "0";
                    kameraYaz();                   

                    kameraProcessCounter++;
                    if (kameraProcessCounter ==  10)  //1sn sonra
                    { 
                        if (nxCompoletBoolRead("componentOK"))
                        {
                            nxCompoletBoolWrite("componentOK", false);
                        }

                        if (nxCompoletBoolRead("componentNOK"))
                        {
                            nxCompoletBoolWrite("componentNOK", false);
                        }
                        if (nxCompoletBoolRead("processDone"))
                        {
                            nxCompoletBoolWrite("processDone", false);
                        }
                        nxCompoletBoolWrite("snapShotNOK", false);
                        processControlState = true;
                        kameraProcessCounter = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("FCTKameraIstasyon(snapShotNOK): " + ex.Message, Color.Red);
            }
            
            if (kameraTimeoutState == true)  //PLC-KAMERA-TIMEOUT
            {
                kameraTimerCounter++;
                kameraTimerTxt.Text = Convert.ToString(kameraTimerCounter/10);
                if (kameraTimerCounter > Prog_Ayarlar.Default.kameraTimeout * 10)
                {
                    kameraComponentError();
                }
            }
        }

        private void kameraYaz()  //PLC'DEN KAMERA İÇİN TEXT'E VERİ YAZ
        {
            try
            {
                if (Prog_Ayarlar.Default.iniKameraYazDosyaYolu != "")
                {
                    INIKaydet ini = new INIKaydet(Prog_Ayarlar.Default.iniKameraYazDosyaYolu);  
                    ini.Yaz("snapShot", "Metin Kutusu", Convert.ToString(snapShot));
                    snapShot = ini.Oku("snapShot", "Metin Kutusu");
                    otherConsoleAppendLine("snapShot = " + snapShot, Color.Green);
                }
                else
                {
                    otherConsoleAppendLine("Dosya Yolu Boş Kalamaz", Color.Red);
                }
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("kameraYaz: " + ex.Message, Color.Red);
            }
        }

        private void kameraOku()  //KAMERA'DAN PLC'YE VERİ GÖNDERMEK İÇİN TEXT OKU
        {
            try
            {
                if (Prog_Ayarlar.Default.iniKameraOkuDosyaYolu != "")
                {
                    if (File.Exists(Prog_Ayarlar.Default.iniKameraOkuDosyaYolu))
                    {
                        INIKaydet ini = new INIKaydet(Prog_Ayarlar.Default.iniKameraOkuDosyaYolu);

                        cameraState = ini.Oku("cameraState", "Metin Kutusu");
                        if (cameraState != oldCameraState)
                        {
                            if (cameraState == "1")
                            {
                                lblCameraState.Text = "ON";
                                lblCameraState.BackColor = Color.Green;
                                nxCompoletBoolWrite("cameraState", true);
                            }
                            else if(cameraState == "0")
                            {
                                lblCameraState.Text = "OFF";
                                lblCameraState.BackColor = Color.Red;
                                nxCompoletBoolWrite("cameraState", false);
                            }
                            else
                            {
                             //   otherConsoleAppendLine("cameraState = BOŞ", Color.Red);
                            }
                           // otherConsoleAppendLine("cameraState = " + cameraState, Color.Green);
                            oldCameraState = cameraState;
                        }

                        ethernetState = ini.Oku("ethernetState", "Metin Kutusu");
                        if (ethernetState != oldEthernetState)
                        {
                            if (ethernetState == "1")
                            {
                                lblEthernetState.Text = "ON";
                                lblEthernetState.BackColor = Color.Green;
                                nxCompoletBoolWrite("ethernetState", true);
                            }
                            else if (ethernetState == "0")
                            {
                                lblEthernetState.Text = "OFF";
                                lblEthernetState.BackColor = Color.Red;
                                nxCompoletBoolWrite("ethernetState", false);
                            }
                            else
                            {
                            //    otherConsoleAppendLine("ethernetState = BOŞ", Color.Red);
                            }
                           // otherConsoleAppendLine("ethernetState = " + ethernetState, Color.Green);
                            oldEthernetState = ethernetState;
                        }

                        processDone = ini.Oku("processDone", "Metin Kutusu");
                        if (processDone == "1" && processControlState == true)
                        {
                            if (processDone == "1")
                            {
                                nxCompoletBoolWrite("processDone", true);
                            }
                            else
                            {
                                nxCompoletBoolWrite("processDone", false);
                            }
                            otherConsoleAppendLine("processDone = " + processDone, Color.Green);

                            processControlState = false;
                            componentOK = ini.Oku("componentOK", "Metin Kutusu");
                            if (componentOK == "1")
                            {
                                kameraComponentSuccess();
                                nxCompoletBoolWrite("componentOK", true);
                            }
                            else if (componentOK == "0")
                            {
                                nxCompoletBoolWrite("componentOK", false);
                            }
                            else
                            {
                                processControlState = true;
                            }
                            otherConsoleAppendLine("componentOK = " + componentOK, Color.Green);

                            componentNOK = ini.Oku("componentNOK", "Metin Kutusu");
                            if (componentNOK == "1")
                            {
                                kameraComponentError();
                                nxCompoletBoolWrite("componentNOK", true);
                            }
                            else if (componentNOK == "0")
                            {
                                nxCompoletBoolWrite("componentNOK", false);
                            }
                            else
                            {
                                processControlState = true;
                            }
                            otherConsoleAppendLine("componentNOK = " + componentNOK, Color.Green);
                            
                        }
                    }
                }
                else
                {
                    otherConsoleAppendLine("Dosya Yolu Boş Kalamaz", Color.Red);
                }
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("kameraOku: " + ex.Message, Color.Red);
            }
        }

        public void kameraComponentSuccess()  //KAMERA-PLC KOMPONENT BAŞARILI
        {
            tbOtherState.Invoke(new Action(delegate ()
            {
                tbOtherState.BackColor = Color.Green;
                tbOtherState.Text = "KAMERA COMPONENT BAŞARILI";
            }));
            kameraRestart();
        }

        public void kameraComponentError()   //KAMERA-PLC KOMPONENT BAŞARISIZ
        {
            tbOtherState.Invoke(new Action(delegate ()
            {
                tbOtherState.BackColor = Color.Red;
                tbOtherState.Text = "KAMERA COMPONENT BAŞARISIZ";
            }));
            kameraRestart();
        }

        public void kameraRestart()   //KAMERA-PLC KOMPONENT RESTART
        {
            kameraMailState = true;

            kameraTimeoutState = false;
            kameraTimerCounter = 0;
        }

        private void kameraVerim()  //KAMERA VERİM
        {
            if (nxCompoletBoolRead("kameraStationState"))
            {
                errorKameraCardTxt.Invoke(new Action(delegate ()
                {
                    errorKameraCardTxt.Text = nxCompoletStringRead("kameraError");
                    totalKameraCardTxt.Text = nxCompoletStringRead("kameraTotal");
                    errorKameraCard = Convert.ToInt32(errorKameraCardTxt.Text);
                    totalKameraCard = Convert.ToInt32(totalKameraCardTxt.Text);
                    verimKameraTxt.Text = Convert.ToString(100 - ((float)((float)errorKameraCard / totalKameraCard)) * 100);
                }));
            }
        }

        /********************************************** Ortak Tüm Ana İşlemlerin Yönlendirilmesi************************************************/
        public void yetkidegistir()
        {
            if (this.yetki == 0)
            {
                this.btnCikis.Enabled = false;
                this.btnAyar.Enabled = false;
                btnCikis.BackColor = Color.Gray;
                btnAyar.BackColor = Color.Gray;
            }
            if (this.yetki == 1)
            {
                this.btnCikis.Enabled = true;
                this.btnAyar.Enabled = true;
                btnCikis.BackColor = Color.Red;
                btnAyar.BackColor = Color.Red;
                timerAdmin.Start();
            }
            if (this.yetki == 2)
            {
                this.btnCikis.Enabled = true;
                this.btnAyar.Enabled = true;
                btnCikis.BackColor = Color.Red;
                btnAyar.BackColor = Color.Red;
                timerAdmin.Start();
            }
        }

        private void btnAyar_Click(object sender, EventArgs e)
        {
            int num = (int)this.ProgAyarFrm.ShowDialog();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.L)
                return;
            if (this.yetki != 0)
            {
                timerAdmin.Stop();
                this.yetki = 0;
                this.yetkidegistir();
            }
            else
            {
                int num = (int)this.SifreFrm.ShowDialog();
                textBox1.Clear();
            }
        }

        private void timerAdmin_Tick(object sender, EventArgs e)
        {
            adminTimerCounter++;
            if (adminTimerCounter == 1)
            {
                adminTimerCounter = 0;
                timerAdmin.Stop();
                this.yetki = 0;
                this.yetkidegistir();
            }
        }

        private void rtbConsole_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtb1 = sender as RichTextBox;
            rtb1.SelectionStart = rtb1.Text.Length;
            rtb1.ScrollToCaret();
        }

        string mailSubject = "";
        string mailBody = "";
        public void mailSend(string subject, string body)
        {
            string mailSubject = subject;
            string mailBody = body;
            mailSendTh = new Thread(mailSendFunction);
            mailSendTh.Start();
        }

        public void mailSendFunction()
        {
            otherConsoleAppendLine("Mail Gönderiliyor", Color.Green);
            try
            {
                NetworkCredential basicCredential = new NetworkCredential("serkan.baki", "pepereina1");

                string from = "serkan.baki@alpplas.com";
                string to = "serkanbaki37@outlook.com";
                MailMessage message = new MailMessage(from, to);
                message.Subject = mailSubject;
                message.Body = @mailBody;

                SmtpClient client = new SmtpClient();

                client.Host = "smtp.alpplas.com";
                client.EnableSsl = false;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential;
                client.Send(message);
                otherConsoleAppendLine("Mail Gönderildi", Color.Green);
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("mailSend Error: " + ex.Message, Color.Red);
            }
        }

        /********************************************** Diğer Konsol ************************************************/
        private void rtbConsoleOther_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtb2 = sender as RichTextBox;
            rtb2.SelectionStart = rtb2.Text.Length;
            rtb2.ScrollToCaret();
        }

        /*Kullanıcı Arayüzüne Temizlenir*/
        public void otherConsoleClean()
        {
            if (rtbConsoleOther.InvokeRequired)
            {
                rtbConsoleOther.Invoke(new Action(delegate ()
                {
                    rtbConsoleOther.Text = "";
                    rtbConsoleOther.Select(rtbConsoleOther.TextLength, 0);
                    rtbConsoleOther.SelectionColor = Color.White;
                }));
            }
            else
            {
                rtbConsoleOther.Text = "";
                rtbConsoleOther.Select(rtbConsoleOther.TextLength, 0);
                rtbConsoleOther.SelectionColor = Color.White;
            }
        }

        /*Kullanıcı Arayüzüne Yazı Yazılır*/
        public void otherConsoleAppendLine(string text, Color color)
        {
            if (rtbConsoleOther.InvokeRequired)
            {
                rtbConsoleOther.Invoke(new Action(delegate ()
                {
                    rtbConsoleOther.Select(rtbConsoleOther.TextLength, 0);
                    rtbConsoleOther.SelectionColor = color;
                    rtbConsoleOther.AppendText(text + Environment.NewLine);
                    rtbConsoleOther.Select(rtbConsoleOther.TextLength, 0);
                    rtbConsoleOther.SelectionColor = Color.White;
                }));
            }
            else
            {
                rtbConsoleOther.Select(rtbConsoleOther.TextLength, 0);
                rtbConsoleOther.SelectionColor = color;
                rtbConsoleOther.AppendText(text + Environment.NewLine);
                rtbConsoleOther.Select(rtbConsoleOther.TextLength, 0);
                rtbConsoleOther.SelectionColor = Color.White;
            }
        }

        /*Kullanıcı Arayüzünde Bir Satır Boşluk Bırakılır*/
        public void otherConsoleNewLine()
        {
            if (rtbConsoleOther.InvokeRequired)
            {
                rtbConsoleOther.Invoke(new Action(delegate () { rtbConsoleOther.AppendText(Environment.NewLine); }));
            }
            else
            {
                rtbConsoleOther.AppendText(Environment.NewLine);
            }
        }
    }
}
#endregion
