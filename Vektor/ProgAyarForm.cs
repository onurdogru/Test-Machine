// Decompiled with JetBrains decompiler
// Type: EsdTurnikesi.AyarForm
// Assembly: EsdTurnikesi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C8099926-BBEB-495E-ADF6-36B4F5F75BE8
// Assembly location: C:\Users\serkan.baki\Desktop\esd-rar\ESD\Release\EsdTurnikesi.exe

using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Text;

namespace Vektor
{
    public class ProgAyarForm : Form
    {
        public FormMain MainFrm;
        private IContainer components;

        private Button btnKaydet;
        private TextBox txtKaliteSifre;
        private TextBox txtAdminSifre;
        private ComboBox barcodeNum;
        private TextBox barcode1;
        private TextBox barcode2;
        private TextBox barcode4;
        private TextBox barcode3;
        private TextBox barcode8;
        private TextBox barcode7;
        private TextBox barcode6;
        private TextBox barcode5;
        private TextBox barcode9;
        private TextBox txtTimerAdmin;
        private Label label12;
        private TextBox txtVektorProgramlamaBatch1;
        private Button btnVektor;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label11;
        private TextBox projectName;
        private Label label29;
        private GroupBox groupBox1;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        public ComboBox serialPort1Parity;
        public ComboBox serialPort1Stop;
        public ComboBox serialPort1Data;
        public ComboBox serialPort1Baud;
        public ComboBox serialPort1Com;
        private CheckBox chBoxSerial1;
        private PictureBox infoPicture1;
        private ComboBox feedback1;
        private Label label35;
        private ToolTip toolTip1;
        private Button btnIDsec;
        private TextBox txtINIdosya;
        private Label label220;
        private Button btnOkuIni;
        private Button btnKaydetIni;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btnPNGsec;
        private TextBox txtPNGdosya;
        private Label label36;
        private PictureBox infoPicture2;
        private ComboBox step9Job;
        private Label label69;
        private ComboBox step8Job;
        private Label label70;
        private ComboBox step7Job;
        private Label label71;
        private ComboBox step6Job;
        private Label label72;
        private ComboBox step5Job;
        private Label label37;
        private ComboBox step4Job;
        private Label label38;
        private ComboBox step3Job;
        private Label label39;
        private ComboBox step2Job;
        private Label label40;
        private ComboBox step1Job;
        private Label label41;
        private ToolTip toolTip2;
        private PictureBox infoPicture3;
        private ToolTip toolTip3;
        private ToolTip toolTip4;
        private CheckBox chBoxSuccess;
        private CheckBox chBoxError1;
        private CheckBox chBoxError2;
        private CheckBox chBoxError3;
        private GroupBox groupBox4;
        private TextBox txtError3Batch;
        private TextBox txtError2Batch;
        private TextBox txtError1Batch;
        private TextBox txtSuccessBatch;
        private TextBox timeoutProgramlama;
        private GroupBox groupBox9;
        private ComboBox printerName;
        private Label label62;
        private TextBox timeoutMotor;
        private Label label73;
        private TextBox timeoutOutputWrite;
        private GroupBox groupBox6;
        private Label label84;
        private Label label85;
        private Label label86;
        private Label label87;
        private Label label88;
        private CheckBox sifreChange;
        private Label label90;
        private Label label91;
        private Label label92;
        private Label label93;
        private Label label10;
        private Button btnKameraOkuIDsec;
        private TextBox txtKameraOkuINIdosya;
        private Label label13;
        private Button btnKameraYazIDsec;
        private TextBox txtKameraYazINIdosya;
        private Label label14;
        private TextBox txtVektorErrorBatchDosya;
        private Label label15;
        private Label label16;
        private TextBox timeoutKamera;
        private Label label17;
        private TextBox txtSQLDosya;
        private Button btnSQL;
        private Label label18;
        private TextBox txtSQLOnOffDosya;
        private Button btnSQLOnOff;
        private TextBox softwareRev;
        private Label label19;
        private Label label20;
        private TextBox FCTRev;
        private TextBox softwareVer;
        private Label label21;
        private Label label26;
        private TextBox BOMVer;
        private TextBox ICTRev;
        private Label label27;
        private Label label24;
        private TextBox cardNo;
        private TextBox gerberVer;
        private Label label25;
        private Label label23;
        private TextBox companyNo;
        private TextBox SAPNo;
        private Label label28;
        private TextBox productionNo;
        private Label label22;
        private Button resetProductionNo;
        private GroupBox groupBox5;
        public TabControl tabControl1;
        public TabPage tabPage1;
        private GroupBox groupBox7;
        public TabPage tabPage2;
        private Label label42;
        private TextBox txtVektorProgramlamaBatch2;
        private Button button1;
        private RadioButton rbProgramlama2;
        private RadioButton rbProgramlama1;
        private GroupBox groupBox8;
        public RadioButton rbPrograming3;
        public RadioButton rbPrograming2;
        public RadioButton rbPrograming1;
        private Button btnVektorError;

        public ProgAyarForm()
        {
            this.InitializeComponent();
        }

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


        private void AyarForm_Load(object sender, EventArgs e)
        {
            toolTip_Load();
            if (this.MainFrm.yetki == 1)
            {
                if (this.MainFrm.tabRemove)
                {
                    tabControl1.TabPages.Add(tabPage2);
                }
                this.MainFrm.tabRemove = false;
            }
            else
            {
                tabControl1.TabPages.Remove(tabPage2);
                this.MainFrm.tabRemove = true;
            }
            this.txtINIdosya.Text = Prog_Ayarlar.Default.iniDosyaYolu;
            this.txtKameraOkuINIdosya.Text = Prog_Ayarlar.Default.iniKameraOkuDosyaYolu;
            this.txtKameraYazINIdosya.Text = Prog_Ayarlar.Default.iniKameraYazDosyaYolu;
            this.projectName.Text = Prog_Ayarlar.Default.projectName;
            this.printerName.Text = Prog_Ayarlar.Default.printerName;
            this.txtVektorProgramlamaBatch1.Text = Prog_Ayarlar.Default.vektorProgramlamaBatch1;
            this.txtVektorProgramlamaBatch2.Text = Prog_Ayarlar.Default.vektorProgramlamaBatch2;
            this.txtVektorErrorBatchDosya.Text = Prog_Ayarlar.Default.vektorErrordosyayolu;
            this.txtSQLDosya.Text = Prog_Ayarlar.Default.txtSQLDosyaYolu;
            this.txtSQLOnOffDosya.Text = Prog_Ayarlar.Default.txtSQLOnOffDosyaYolu;
            this.txtPNGdosya.Text = Prog_Ayarlar.Default.PNGdosyayolu;
            this.txtAdminSifre.Text = Prog_Ayarlar.Default.adminSifre.ToString();
            this.txtKaliteSifre.Text = Prog_Ayarlar.Default.kaliteSifre.ToString();

            this.chBoxSerial1.Checked = Prog_Ayarlar.Default.chBoxSerial1;
            if (chBoxSerial1.Checked == true)
                groupBox1.Enabled = true;
            else
                groupBox1.Enabled = false;

            if (Prog_Ayarlar.Default.rbProgramlama == "1")
            {
                rbProgramlama1.Checked = true;
                rbProgramlama2.Checked = false;
                txtVektorProgramlamaBatch1.Enabled = true;
                txtVektorProgramlamaBatch2.Enabled = false;
            }
            else if (Prog_Ayarlar.Default.rbProgramlama == "2")
            {
                rbProgramlama2.Checked = true;
                rbProgramlama1.Checked = false;
                txtVektorProgramlamaBatch2.Enabled = true;
                txtVektorProgramlamaBatch1.Enabled = false;
            }

            this.serialPort1Com.Text = Prog_Ayarlar.Default.SerialPort1Com;
            this.serialPort1Baud.Text = Prog_Ayarlar.Default.SerialPort1Baud.ToString();
            this.serialPort1Data.Text = Prog_Ayarlar.Default.SerialPort1dataBits.ToString();
            this.serialPort1Stop.Text = Prog_Ayarlar.Default.SerialPort1stopBit.ToString();
            this.serialPort1Parity.Text = Prog_Ayarlar.Default.SerialPort1Parity.ToString();
            this.feedback1.Text = Prog_Ayarlar.Default.feedback1;
            this.txtTimerAdmin.Text = Prog_Ayarlar.Default.timerAdmin.ToString();
            this.timeoutProgramlama.Text = Prog_Ayarlar.Default.programingTimeout.ToString();
            this.timeoutMotor.Text = Prog_Ayarlar.Default.motorTimeout.ToString();
            this.timeoutOutputWrite.Text = Prog_Ayarlar.Default.outputWriteTimeout.ToString();
            this.timeoutKamera.Text = Prog_Ayarlar.Default.kameraTimeout.ToString();

            this.barcodeNum.Text = Prog_Ayarlar.Default.barcodeNum;
            this.step1Job.Text = Prog_Ayarlar.Default.step1Job;
            this.step2Job.Text = Prog_Ayarlar.Default.step2Job;
            this.step3Job.Text = Prog_Ayarlar.Default.step3Job;
            this.step4Job.Text = Prog_Ayarlar.Default.step4Job;
            this.step5Job.Text = Prog_Ayarlar.Default.step5Job;
            this.step6Job.Text = Prog_Ayarlar.Default.step6Job;
            this.step7Job.Text = Prog_Ayarlar.Default.step7Job;
            this.step8Job.Text = Prog_Ayarlar.Default.step8Job;
            this.step9Job.Text = Prog_Ayarlar.Default.step9Job;
            this.barcode1.Text = Prog_Ayarlar.Default.barcode1;
            this.barcode2.Text = Prog_Ayarlar.Default.barcode2;
            this.barcode3.Text = Prog_Ayarlar.Default.barcode3;
            this.barcode4.Text = Prog_Ayarlar.Default.barcode4;
            this.barcode5.Text = Prog_Ayarlar.Default.barcode5;
            this.barcode6.Text = Prog_Ayarlar.Default.barcode6;
            this.barcode7.Text = Prog_Ayarlar.Default.barcode7;
            this.barcode8.Text = Prog_Ayarlar.Default.barcode8;
            this.barcode9.Text = Prog_Ayarlar.Default.barcode9;

            this.companyNo.Text = Prog_Ayarlar.Default.companyNo;
            this.SAPNo.Text = Prog_Ayarlar.Default.SAPNo;
            this.productionNo.Text = Prog_Ayarlar.Default.productionNo;
            this.cardNo.Text = Prog_Ayarlar.Default.cardNo;
            this.gerberVer.Text = Prog_Ayarlar.Default.gerberVer;
            this.BOMVer.Text = Prog_Ayarlar.Default.BOMVer;
            this.ICTRev.Text = Prog_Ayarlar.Default.ICTRev;
            this.FCTRev.Text = Prog_Ayarlar.Default.FCTRev;
            this.softwareVer.Text = Prog_Ayarlar.Default.softwareVer;
            this.softwareRev.Text = Prog_Ayarlar.Default.softwareRev;

            this.rbPrograming1.Checked = Prog_Ayarlar.Default.rbPrograming1;
            this.rbPrograming2.Checked = Prog_Ayarlar.Default.rbPrograming2;
            this.rbPrograming3.Checked = Prog_Ayarlar.Default.rbPrograming3;

            this.chBoxSuccess.Checked = Prog_Ayarlar.Default.chBoxSuccess;
            if (chBoxSuccess.Checked == true)
                txtSuccessBatch.Enabled = true;
            else
                txtSuccessBatch.Enabled = false;

            this.chBoxError1.Checked = Prog_Ayarlar.Default.chBoxError1;
            if (chBoxError1.Checked == true)
                txtError1Batch.Enabled = true;
            else
                txtError1Batch.Enabled = false;

            this.chBoxError2.Checked = Prog_Ayarlar.Default.chBoxError2;
            if (chBoxError2.Checked == true)
                txtError2Batch.Enabled = true;
            else
                txtError2Batch.Enabled = false;

            this.chBoxError3.Checked = Prog_Ayarlar.Default.chBoxError3;
            if (chBoxError3.Checked == true)
                txtError3Batch.Enabled = true;
            else
                txtError3Batch.Enabled = false;

            this.txtSuccessBatch.Text = Prog_Ayarlar.Default.successBatch;
            this.txtError1Batch.Text = Prog_Ayarlar.Default.error1Batch;
            this.txtError2Batch.Text = Prog_Ayarlar.Default.error2Batch;
            this.txtError3Batch.Text = Prog_Ayarlar.Default.error3Batch;

            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                printerName.Items.Add(printer);
            }
        }
        private void toolTip_Load()
        {
            string[] toolTipTitle = new string[10];
            string[] toolTipTool = new string[10];
            toolTipTitle[1] = "Lütfen Gelecek Feedback Verisini Giriniz";
            toolTipTitle[2] = "Lütfen Programlama Türünü Belirleyiniz";
            toolTipTitle[3] = "Lütfen Barcode-Master Verisini Giriniz";
            toolTipTitle[4] = "Lütfen Slave Verisini Giriniz";

            toolTipTool[1] = "Örnek : data[2] = {180,75}; \n2,180,75";
            toolTipTool[2] = "1-) Sadece Master \n2-) Master ve Slave";
            toolTipTool[3] = "Örnek : 167000192 ya da 167000204m \nDikkat Barcode ve Master Batch File Aynı Olmalı";
            toolTipTool[4] = "Örnek : 167000204s";

            toolTip1.Active = true;
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 5000;
            toolTip1.IsBalloon = true;
            toolTip1.UseAnimation = true;
            toolTip1.UseFading = true;
            toolTip1.ShowAlways = true;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = toolTipTitle[1];
            toolTip1.SetToolTip(infoPicture1, toolTipTool[1]);

            toolTip2.Active = true;
            toolTip2.AutoPopDelay = 5000;
            toolTip2.InitialDelay = 1000;
            toolTip2.ReshowDelay = 5000;
            toolTip2.IsBalloon = true;
            toolTip2.UseAnimation = true;
            toolTip2.UseFading = true;
            toolTip2.ShowAlways = true;
            toolTip2.ToolTipIcon = ToolTipIcon.Info;
            toolTip2.ToolTipTitle = toolTipTitle[2];
            toolTip2.SetToolTip(infoPicture2, toolTipTool[2]);

            toolTip3.Active = true;
            toolTip3.AutoPopDelay = 5000;
            toolTip3.InitialDelay = 1000;
            toolTip3.ReshowDelay = 5000;
            toolTip3.IsBalloon = true;
            toolTip3.UseAnimation = true;
            toolTip3.UseFading = true;
            toolTip3.ShowAlways = true;
            toolTip3.ToolTipIcon = ToolTipIcon.Info;
            toolTip3.ToolTipTitle = toolTipTitle[3];
            toolTip3.SetToolTip(infoPicture3, toolTipTool[3]);

            toolTip4.Active = true;
            toolTip4.AutoPopDelay = 5000;
            toolTip4.InitialDelay = 1000;
            toolTip4.ReshowDelay = 5000;
            toolTip4.IsBalloon = true;
            toolTip4.UseAnimation = true;
            toolTip4.UseFading = true;
            toolTip4.ShowAlways = true;
            toolTip4.ToolTipIcon = ToolTipIcon.Info;
            toolTip4.ToolTipTitle = toolTipTitle[4];
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (feedback1.Text == "" && chBoxSerial1.Checked == true)
            {
                CustomMessageBox.ShowMessage("Feedback Boş Kalamaz", Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Error, Color.Red);
            }
            else
            {
                try
                {

                    Prog_Ayarlar.Default.iniDosyaYolu = this.txtINIdosya.Text;
                    Prog_Ayarlar.Default.iniKameraOkuDosyaYolu = this.txtKameraOkuINIdosya.Text;
                    Prog_Ayarlar.Default.iniKameraYazDosyaYolu = this.txtKameraYazINIdosya.Text;
                    Prog_Ayarlar.Default.projectName = this.projectName.Text;
                    Prog_Ayarlar.Default.printerName = this.printerName.Text;
                    Prog_Ayarlar.Default.vektorProgramlamaBatch1 = this.txtVektorProgramlamaBatch1.Text;
                    Prog_Ayarlar.Default.vektorProgramlamaBatch2 = this.txtVektorProgramlamaBatch2.Text;
                    Prog_Ayarlar.Default.vektorErrordosyayolu = this.txtVektorErrorBatchDosya.Text; 
                    Prog_Ayarlar.Default.txtSQLDosyaYolu = this.txtSQLDosya.Text;
                    Prog_Ayarlar.Default.txtSQLOnOffDosyaYolu = this.txtSQLOnOffDosya.Text;
                    Prog_Ayarlar.Default.PNGdosyayolu = this.txtPNGdosya.Text;

                    Prog_Ayarlar.Default.adminSifre = this.txtAdminSifre.Text;
                    Prog_Ayarlar.Default.kaliteSifre = this.txtKaliteSifre.Text;

                    Prog_Ayarlar.Default.chBoxSerial1 = this.chBoxSerial1.Checked;
                    
                    if (rbProgramlama1.Checked == true)
                    {
                        Prog_Ayarlar.Default.rbProgramlama = "1";
                    }
                    else if (rbProgramlama2.Checked == true)
                    {
                        Prog_Ayarlar.Default.rbProgramlama = "2";
                    }
                    Prog_Ayarlar.Default.SerialPort1Com = this.serialPort1Com.Text;
                    Prog_Ayarlar.Default.SerialPort1Baud = Convert.ToInt32(this.serialPort1Baud.Text);
                    Prog_Ayarlar.Default.SerialPort1dataBits = Convert.ToInt32(this.serialPort1Data.Text);
                    switch (this.serialPort1Stop.SelectedIndex)
                    {
                        case 0:
                            Prog_Ayarlar.Default.SerialPort1stopBit = StopBits.None;
                            break;
                        case 1:
                            Prog_Ayarlar.Default.SerialPort1stopBit = StopBits.One;
                            break;
                        case 2:
                            Prog_Ayarlar.Default.SerialPort1stopBit = StopBits.Two;
                            break;
                        case 3:
                            Prog_Ayarlar.Default.SerialPort1stopBit = StopBits.OnePointFive;
                            break;
                        default:
                            Prog_Ayarlar.Default.SerialPort1stopBit = StopBits.One;
                            break;
                    }
                    switch (this.serialPort1Parity.SelectedIndex)
                    {
                        case 0:
                            Prog_Ayarlar.Default.SerialPort1Parity = Parity.None;
                            break;
                        case 1:
                            Prog_Ayarlar.Default.SerialPort1Parity = Parity.Odd;
                            break;
                        case 2:
                            Prog_Ayarlar.Default.SerialPort1Parity = Parity.Even;
                            break;
                        case 3:
                            Prog_Ayarlar.Default.SerialPort1Parity = Parity.Mark;
                            break;
                        case 4:
                            Prog_Ayarlar.Default.SerialPort1Parity = Parity.Space;
                            break;
                        default:
                            Prog_Ayarlar.Default.SerialPort1Parity = Parity.None;
                            break;
                    }
                    Prog_Ayarlar.Default.timerAdmin = Convert.ToInt32(this.txtTimerAdmin.Text);
                    Prog_Ayarlar.Default.programingTimeout = Convert.ToInt32(this.timeoutProgramlama.Text);
                    Prog_Ayarlar.Default.motorTimeout = Convert.ToInt32(this.timeoutMotor.Text);
                    Prog_Ayarlar.Default.outputWriteTimeout = Convert.ToInt32(this.timeoutOutputWrite.Text);
                    Prog_Ayarlar.Default.kameraTimeout = Convert.ToInt32(this.timeoutKamera.Text);

                    Prog_Ayarlar.Default.barcodeNum = this.barcodeNum.Text;
                    Prog_Ayarlar.Default.step1Job = this.step1Job.Text;
                    Prog_Ayarlar.Default.step2Job = this.step2Job.Text;
                    Prog_Ayarlar.Default.step3Job = this.step3Job.Text;
                    Prog_Ayarlar.Default.step4Job = this.step4Job.Text;
                    Prog_Ayarlar.Default.step5Job = this.step5Job.Text;
                    Prog_Ayarlar.Default.step6Job = this.step6Job.Text;
                    Prog_Ayarlar.Default.step7Job = this.step7Job.Text;
                    Prog_Ayarlar.Default.step8Job = this.step8Job.Text;
                    Prog_Ayarlar.Default.step9Job = this.step9Job.Text;
                    Prog_Ayarlar.Default.barcode1 = this.barcode1.Text;
                    Prog_Ayarlar.Default.barcode2 = this.barcode2.Text;
                    Prog_Ayarlar.Default.barcode3 = this.barcode3.Text;
                    Prog_Ayarlar.Default.barcode4 = this.barcode4.Text;
                    Prog_Ayarlar.Default.barcode5 = this.barcode5.Text;
                    Prog_Ayarlar.Default.barcode6 = this.barcode6.Text;
                    Prog_Ayarlar.Default.barcode7 = this.barcode7.Text;
                    Prog_Ayarlar.Default.barcode8 = this.barcode8.Text;
                    Prog_Ayarlar.Default.barcode9 = this.barcode9.Text;
                    Prog_Ayarlar.Default.feedback1 = this.feedback1.Text;

                    Prog_Ayarlar.Default.companyNo = this.companyNo.Text;
                    Prog_Ayarlar.Default.SAPNo = this.SAPNo.Text;
                    Prog_Ayarlar.Default.productionNo = this.productionNo.Text;
                    Prog_Ayarlar.Default.cardNo = this.cardNo.Text;
                    Prog_Ayarlar.Default.gerberVer = this.gerberVer.Text;
                    Prog_Ayarlar.Default.BOMVer = this.BOMVer.Text;
                    Prog_Ayarlar.Default.ICTRev = this.ICTRev.Text;
                    Prog_Ayarlar.Default.FCTRev = this.FCTRev.Text;
                    Prog_Ayarlar.Default.softwareVer = this.FCTRev.Text;
                    Prog_Ayarlar.Default.softwareRev = this.softwareRev.Text;

                    Prog_Ayarlar.Default.rbPrograming1 = this.rbPrograming1.Checked;
                    Prog_Ayarlar.Default.rbPrograming2 = this.rbPrograming2.Checked;
                    Prog_Ayarlar.Default.rbPrograming3 = this.rbPrograming3.Checked;

                    Prog_Ayarlar.Default.chBoxSuccess = this.chBoxSuccess.Checked;
                    Prog_Ayarlar.Default.chBoxError1 = this.chBoxError1.Checked;
                    Prog_Ayarlar.Default.chBoxError2 = this.chBoxError2.Checked;
                    Prog_Ayarlar.Default.chBoxError3 = this.chBoxError3.Checked;
                    Prog_Ayarlar.Default.successBatch = this.txtSuccessBatch.Text;
                    Prog_Ayarlar.Default.error1Batch = this.txtError1Batch.Text;
                    Prog_Ayarlar.Default.error2Batch = this.txtError2Batch.Text;
                    Prog_Ayarlar.Default.error3Batch = this.txtError3Batch.Text;
                    Prog_Ayarlar.Default.Save();

                    CustomMessageBox.ShowMessage("Bütün Ayarlar Başarıyla Kaydedildi.", Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Information, Color.Yellow);
                    this.Close();

                   Application.Restart();
                }
                catch (Exception ex)
                {
                    CustomMessageBox.ShowMessage("Ayarlar Kayıt Hatası: " + ex.ToString(), Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Error, Color.Red);
                }
            }
        }

        private void chBoxSerial1_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxSerial1.Checked == true)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
            }
        }

        private void rbProgramlama1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProgramlama1.Checked == true)
            {
                txtVektorProgramlamaBatch1.Enabled = true;
                txtVektorProgramlamaBatch2.Enabled = false;
            }
            else
            {
                txtVektorProgramlamaBatch2.Enabled = true;
                txtVektorProgramlamaBatch1.Enabled = false;
            }
        }

        private void rbProgramlama2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProgramlama2.Checked == true)
            {
                txtVektorProgramlamaBatch2.Enabled = true;
                txtVektorProgramlamaBatch1.Enabled = false;
            }
            else
            {
                txtVektorProgramlamaBatch1.Enabled = true;
                txtVektorProgramlamaBatch2.Enabled = false;
            }
        }

        private void barcodeNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            step1Job.Enabled = false;
            step2Job.Enabled = false;
            step3Job.Enabled = false;
            step4Job.Enabled = false;
            step5Job.Enabled = false;
            step6Job.Enabled = false;
            step7Job.Enabled = false;
            step8Job.Enabled = false;
            step9Job.Enabled = false;
            barcode1.Enabled = false;
            barcode2.Enabled = false;
            barcode3.Enabled = false;
            barcode4.Enabled = false;
            barcode5.Enabled = false;
            barcode6.Enabled = false;
            barcode7.Enabled = false;
            barcode8.Enabled = false;
            barcode9.Enabled = false;

            if (Convert.ToInt32(barcodeNum.Text) >= 1)
            {
                step1Job.Enabled = true;
                barcode1.Enabled = true;
                this.Invoke(new EventHandler(step1Job_SelectedIndexChanged));
            }
            if (Convert.ToInt32(barcodeNum.Text) >= 2)
            {
                step2Job.Enabled = true;
                barcode2.Enabled = true;
                this.Invoke(new EventHandler(step2Job_SelectedIndexChanged));
            }
            if (Convert.ToInt32(barcodeNum.Text) >= 3)
            {
                step3Job.Enabled = true;
                barcode3.Enabled = true;
                this.Invoke(new EventHandler(step3Job_SelectedIndexChanged));
            }
            if (Convert.ToInt32(barcodeNum.Text) >= 4)
            {
                step4Job.Enabled = true;
                barcode4.Enabled = true;
                this.Invoke(new EventHandler(step4Job_SelectedIndexChanged));
            }
            if (Convert.ToInt32(barcodeNum.Text) >= 5)
            {
                step5Job.Enabled = true;
                barcode5.Enabled = true;
                this.Invoke(new EventHandler(step5Job_SelectedIndexChanged));
            }
            if (Convert.ToInt32(barcodeNum.Text) >= 6)
            {
                step6Job.Enabled = true;
                barcode6.Enabled = true;
                this.Invoke(new EventHandler(step6Job_SelectedIndexChanged));
            }
            if (Convert.ToInt32(barcodeNum.Text) >= 7)
            {
                step7Job.Enabled = true;
                barcode7.Enabled = true;
                this.Invoke(new EventHandler(step7Job_SelectedIndexChanged));
            }
            if (Convert.ToInt32(barcodeNum.Text) >= 8)
            {
                step8Job.Enabled = true;
                barcode8.Enabled = true;
                this.Invoke(new EventHandler(step8Job_SelectedIndexChanged));
            }
            if (Convert.ToInt32(barcodeNum.Text) >= 9)
            {
                step9Job.Enabled = true;
                barcode9.Enabled = true;
                this.Invoke(new EventHandler(step9Job_SelectedIndexChanged));
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.sifreChange.Checked)
            {
                this.txtAdminSifre.Enabled = true;
                this.txtKaliteSifre.Enabled = true;
                this.txtAdminSifre.PasswordChar = char.MinValue;
                this.txtKaliteSifre.PasswordChar = char.MinValue;
            }
            else
            {
                this.txtAdminSifre.Enabled = false;
                this.txtKaliteSifre.Enabled = false;
                this.txtAdminSifre.PasswordChar = '*';
                this.txtKaliteSifre.PasswordChar = '*';
            }
        }

        private void btnKaydetIni_Click(object sender, EventArgs e)
        {
            if (txtINIdosya.Text != "")
            {
                INIKaydet ini = new INIKaydet(txtINIdosya.Text);  // @"\Ayarlar.ini"
                ini.Yaz("timerAdmin", "Metin Kutusu", Convert.ToString(txtTimerAdmin.Text));
                ini.Yaz("timeoutProgramlama", "Metin Kutusu", Convert.ToString(timeoutProgramlama.Text));
                ini.Yaz("timeoutMotor", "Metin Kutusu", Convert.ToString(timeoutMotor.Text));
                ini.Yaz("timeoutOutputWrite", "Metin Kutusu", Convert.ToString(timeoutOutputWrite.Text));
                ini.Yaz("timeoutKamera", "Metin Kutusu", Convert.ToString(timeoutKamera.Text));
                ini.Yaz("barcodeNum", "Metin Kutusu", Convert.ToString(barcodeNum.Text));
                ini.Yaz("step1job", "Metin Kutusu", Convert.ToString(step1Job.Text));
                ini.Yaz("step2job", "Metin Kutusu", Convert.ToString(step2Job.Text));
                ini.Yaz("step3job", "Metin Kutusu", Convert.ToString(step3Job.Text));
                ini.Yaz("step4job", "Metin Kutusu", Convert.ToString(step4Job.Text));
                ini.Yaz("step5job", "Metin Kutusu", Convert.ToString(step5Job.Text));
                ini.Yaz("step6job", "Metin Kutusu", Convert.ToString(step6Job.Text));
                ini.Yaz("step7job", "Metin Kutusu", Convert.ToString(step7Job.Text));
                ini.Yaz("step8job", "Metin Kutusu", Convert.ToString(step8Job.Text));
                ini.Yaz("step9job", "Metin Kutusu", Convert.ToString(step9Job.Text));
                ini.Yaz("barcode1", "Metin Kutusu", Convert.ToString(barcode1.Text));
                ini.Yaz("barcode2", "Metin Kutusu", Convert.ToString(barcode2.Text));
                ini.Yaz("barcode3", "Metin Kutusu", Convert.ToString(barcode3.Text));
                ini.Yaz("barcode4", "Metin Kutusu", Convert.ToString(barcode4.Text));
                ini.Yaz("barcode5", "Metin Kutusu", Convert.ToString(barcode5.Text));
                ini.Yaz("barcode6", "Metin Kutusu", Convert.ToString(barcode6.Text));
                ini.Yaz("barcode7", "Metin Kutusu", Convert.ToString(barcode7.Text));
                ini.Yaz("barcode8", "Metin Kutusu", Convert.ToString(barcode8.Text));
                ini.Yaz("barcode9", "Metin Kutusu", Convert.ToString(barcode9.Text));
                ini.Yaz("kameraOkuINIdosya", "Metin Kutusu", Convert.ToString(txtKameraOkuINIdosya.Text));
                ini.Yaz("kameraYazINIdosya", "Metin Kutusu", Convert.ToString(txtKameraYazINIdosya.Text));
                ini.Yaz("vektorProgramlamaBatch1", "Metin Kutusu", Convert.ToString(txtVektorProgramlamaBatch1.Text));
                ini.Yaz("vektorProgramlamaBatch2", "Metin Kutusu", Convert.ToString(txtVektorProgramlamaBatch2.Text));
                ini.Yaz("vektorErrorBatchDosya", "Metin Kutusu", Convert.ToString(txtVektorErrorBatchDosya.Text)); 
                ini.Yaz("txtSQLDosya", "Metin Kutusu", Convert.ToString(txtSQLDosya.Text));
                ini.Yaz("txtSQLOnOffDosya", "Metin Kutusu", Convert.ToString(txtSQLOnOffDosya.Text));
                ini.Yaz("projectName", "Metin Kutusu", Convert.ToString(projectName.Text));
                ini.Yaz("companyNo", "Metin Kutusu", Convert.ToString(companyNo.Text));
                ini.Yaz("SAPNo", "Metin Kutusu", Convert.ToString(SAPNo.Text));
                ini.Yaz("productionNo", "Metin Kutusu", Convert.ToString(productionNo.Text));
                ini.Yaz("cardNo", "Metin Kutusu", Convert.ToString(cardNo.Text));
                ini.Yaz("gerberVer", "Metin Kutusu", Convert.ToString(gerberVer.Text));
                ini.Yaz("BOMVer", "Metin Kutusu", Convert.ToString(BOMVer.Text));
                ini.Yaz("ICTRev", "Metin Kutusu", Convert.ToString(ICTRev.Text));
                ini.Yaz("FCTRev", "Metin Kutusu", Convert.ToString(FCTRev.Text));
                ini.Yaz("softwareVer", "Metin Kutusu", Convert.ToString(softwareVer.Text));
                ini.Yaz("softwareRev", "Metin Kutusu", Convert.ToString(softwareRev.Text));
                ini.Yaz("printerName", "Metin Kutusu", Convert.ToString(printerName.Text));
                ini.Yaz("projectPNG", "Metin Kutusu", Convert.ToString(txtPNGdosya.Text));
                ini.Yaz("serialPort1Checked", "Metin Kutusu", Convert.ToString(chBoxSerial1.Checked));
                if (rbProgramlama1.Checked == true)
                {
                    ini.Yaz("programlamaChecked", "Metin Kutusu", "1");
                }
                else if (rbProgramlama2.Checked == true)
                {
                    ini.Yaz("programlamaChecked", "Metin Kutusu", "2");
                }
                ini.Yaz("serialPort1Com", "Metin Kutusu", Convert.ToString(serialPort1Com.Text));
                ini.Yaz("serialPort1Baud", "Metin Kutusu", Convert.ToString(serialPort1Baud.Text));
                ini.Yaz("serialPort1Data", "Metin Kutusu", Convert.ToString(serialPort1Data.Text));
                ini.Yaz("serialPort1Stop", "Metin Kutusu", Convert.ToString(serialPort1Stop.Text));
                ini.Yaz("serialPort1Parity", "Metin Kutusu", Convert.ToString(serialPort1Parity.Text));
                ini.Yaz("feedback1", "Metin Kutusu", Convert.ToString(feedback1.Text));

                ini.Yaz("rbPrograming1", "Metin Kutusu", Convert.ToString(rbPrograming1.Checked));
                ini.Yaz("rbPrograming2", "Metin Kutusu", Convert.ToString(rbPrograming2.Checked));
                ini.Yaz("rbPrograming3", "Metin Kutusu", Convert.ToString(rbPrograming3.Checked));

                ini.Yaz("successChecked", "Metin Kutusu", Convert.ToString(chBoxSuccess.Checked));
                ini.Yaz("error1Checked", "Metin Kutusu", Convert.ToString(chBoxError1.Checked));
                ini.Yaz("error2Checked", "Metin Kutusu", Convert.ToString(chBoxError2.Checked));
                ini.Yaz("error3Checked", "Metin Kutusu", Convert.ToString(chBoxError3.Checked));
                ini.Yaz("successBatch", "Metin Kutusu", Convert.ToString(txtSuccessBatch.Text));
                ini.Yaz("error1Batch", "Metin Kutusu", Convert.ToString(txtError1Batch.Text));
                ini.Yaz("error2Batch", "Metin Kutusu", Convert.ToString(txtError2Batch.Text));
                ini.Yaz("error3Batch", "Metin Kutusu", Convert.ToString(txtError3Batch.Text));

                CustomMessageBox.ShowMessage("Bütün Ayarlar Dosyaya Başarıyla Kaydedildi.", Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Information, Color.Yellow);
            }
            else
            {
                CustomMessageBox.ShowMessage("Dosya Yolu Boş Kalamaz", Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Error, Color.Red);
            }
        }

        private void btnOkuIni_Click(object sender, EventArgs e)
        {
            if (txtINIdosya.Text != "")
            {
                try
                {
                    if (File.Exists(txtINIdosya.Text))
                    {
                        INIKaydet ini = new INIKaydet(txtINIdosya.Text);
                        txtTimerAdmin.Text = ini.Oku("timerAdmin", "Metin Kutusu");
                        timeoutProgramlama.Text = ini.Oku("timeoutProgramlama", "Metin Kutusu");
                        timeoutMotor.Text = ini.Oku("timeoutMotor", "Metin Kutusu");
                        timeoutOutputWrite.Text = ini.Oku("timeoutOutputWrite", "Metin Kutusu");
                        timeoutKamera.Text = ini.Oku("timeoutKamera", "Metin Kutusu");
                        barcodeNum.Text = ini.Oku("barcodeNum", "Metin Kutusu");
                        step1Job.Text = ini.Oku("step1job", "Metin Kutusu");
                        step2Job.Text = ini.Oku("step2job", "Metin Kutusu");
                        step3Job.Text = ini.Oku("step3job", "Metin Kutusu");
                        step4Job.Text = ini.Oku("step4job", "Metin Kutusu");
                        step5Job.Text = ini.Oku("step5job", "Metin Kutusu");
                        step6Job.Text = ini.Oku("step6job", "Metin Kutusu");
                        step7Job.Text = ini.Oku("step7job", "Metin Kutusu");
                        step8Job.Text = ini.Oku("step8job", "Metin Kutusu");
                        step9Job.Text = ini.Oku("step9job", "Metin Kutusu");
                        barcode1.Text = ini.Oku("barcode1", "Metin Kutusu");
                        barcode2.Text = ini.Oku("barcode2", "Metin Kutusu");
                        barcode3.Text = ini.Oku("barcode3", "Metin Kutusu");
                        barcode4.Text = ini.Oku("barcode4", "Metin Kutusu");
                        barcode5.Text = ini.Oku("barcode5", "Metin Kutusu");
                        barcode6.Text = ini.Oku("barcode6", "Metin Kutusu");
                        barcode7.Text = ini.Oku("barcode7", "Metin Kutusu");
                        barcode8.Text = ini.Oku("barcode8", "Metin Kutusu");
                        barcode9.Text = ini.Oku("barcode9", "Metin Kutusu");
                        txtKameraOkuINIdosya.Text = ini.Oku("kameraOkuINIdosya", "Metin Kutusu");
                        txtKameraYazINIdosya.Text = ini.Oku("kameraYazINIdosya", "Metin Kutusu");
                        txtVektorProgramlamaBatch1.Text = ini.Oku("vektorProgramlamaBatch1", "Metin Kutusu");
                        txtVektorProgramlamaBatch2.Text = ini.Oku("vektorProgramlamaBatch2", "Metin Kutusu");
                        txtVektorErrorBatchDosya.Text = ini.Oku("vektorErrorBatchDosya", "Metin Kutusu");  
                        txtSQLDosya.Text = ini.Oku("txtSQLDosya", "Metin Kutusu");
                        txtSQLOnOffDosya.Text = ini.Oku("txtSQLOnOffDosya", "Metin Kutusu");
                        projectName.Text = ini.Oku("projectName", "Metin Kutusu");
                        companyNo.Text = ini.Oku("companyNo", "Metin Kutusu");
                        SAPNo.Text = ini.Oku("SAPNo", "Metin Kutusu");
                        productionNo.Text = ini.Oku("productionNo", "Metin Kutusu");
                        cardNo.Text = ini.Oku("cardNo", "Metin Kutusu");
                        gerberVer.Text = ini.Oku("gerberVer", "Metin Kutusu");
                        BOMVer.Text = ini.Oku("BOMVer", "Metin Kutusu");
                        ICTRev.Text = ini.Oku("ICTRev", "Metin Kutusu");
                        FCTRev.Text = ini.Oku("FCTRev", "Metin Kutusu");
                        softwareVer.Text = ini.Oku("softwareVer", "Metin Kutusu");
                        softwareRev.Text = ini.Oku("softwareRev", "Metin Kutusu");
                        printerName.Text = ini.Oku("printerName", "Metin Kutusu");
                        txtPNGdosya.Text = ini.Oku("projectPNG", "Metin Kutusu");
                        if (ini.Oku("serialPort1Checked", "Metin Kutusu") == "True")
                            chBoxSerial1.Checked = true;
                        else if (ini.Oku("serialPort1Checked", "Metin Kutusu") == "False")
                            chBoxSerial1.Checked = false;
                        if (ini.Oku("programlamaChecked", "Metin Kutusu") == "1")
                        {
                            rbProgramlama1.Checked = true;
                            rbProgramlama2.Checked = false;
                            txtVektorProgramlamaBatch1.Enabled = true;
                            txtVektorProgramlamaBatch2.Enabled = false;
                        }
                        else if (ini.Oku("programlamaChecked", "Metin Kutusu") == "2")
                        {
                            rbProgramlama2.Checked = true;
                            rbProgramlama1.Checked = false;
                            txtVektorProgramlamaBatch2.Enabled = true;
                            txtVektorProgramlamaBatch1.Enabled = false;
                        }
                        serialPort1Com.Text = ini.Oku("serialPort1Com", "Metin Kutusu");
                        serialPort1Baud.Text = ini.Oku("serialPort1Baud", "Metin Kutusu");
                        serialPort1Data.Text = ini.Oku("serialPort1Data", "Metin Kutusu");
                        serialPort1Stop.Text = ini.Oku("serialPort1Stop", "Metin Kutusu");
                        serialPort1Parity.Text = ini.Oku("serialPort1Parity", "Metin Kutusu");
                        feedback1.Text = ini.Oku("feedback1", "Metin Kutusu");

                        if (ini.Oku("rbPrograming1", "Metin Kutusu") == "True")
                            rbPrograming1.Checked = true;
                        else if (ini.Oku("rbPrograming1", "Metin Kutusu") == "False")
                            rbPrograming1.Checked = false;

                        if (ini.Oku("rbPrograming2", "Metin Kutusu") == "True")
                            rbPrograming2.Checked = true;
                        else if (ini.Oku("rbPrograming2", "Metin Kutusu") == "False")
                            rbPrograming2.Checked = false;

                        if (ini.Oku("rbPrograming3", "Metin Kutusu") == "True")
                            rbPrograming3.Checked = true;
                        else if (ini.Oku("rbPrograming3", "Metin Kutusu") == "False")
                            rbPrograming3.Checked = false;


                        if (ini.Oku("successChecked", "Metin Kutusu") == "True")
                            chBoxSuccess.Checked = true;
                        else if (ini.Oku("successChecked", "Metin Kutusu") == "False")
                            chBoxSuccess.Checked = false;

                        if (ini.Oku("error1Checked", "Metin Kutusu") == "True")
                            chBoxError1.Checked = true;
                        else if (ini.Oku("error1Checked", "Metin Kutusu") == "False")
                            chBoxError1.Checked = false;

                        if (ini.Oku("error2Checked", "Metin Kutusu") == "True")
                            chBoxError2.Checked = true;
                        else if (ini.Oku("error2Checked", "Metin Kutusu") == "False")
                            chBoxError2.Checked = false;

                        if (ini.Oku("error3Checked", "Metin Kutusu") == "True")
                            chBoxError3.Checked = true;
                        else if (ini.Oku("error3Checked", "Metin Kutusu") == "False")
                            chBoxError3.Checked = false;

                        txtSuccessBatch.Text = ini.Oku("successBatch", "Metin Kutusu");
                        txtError1Batch.Text = ini.Oku("error1Batch", "Metin Kutusu");
                        txtError2Batch.Text = ini.Oku("error2Batch", "Metin Kutusu");
                        txtError3Batch.Text = ini.Oku("error3Batch", "Metin Kutusu");

                        CustomMessageBox.ShowMessage("Bütün Ayarlar Dosyadan Başarıyla Okundu.", Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Information, Color.Yellow);
                    }
                }
                catch (Exception hata)
                {
                    CustomMessageBox.ShowMessage("ini Dosyası Hasarlı" + hata, Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Error, Color.Red);
                }
            }
            else
            {
                CustomMessageBox.ShowMessage("Dosya Yolu Boş Kalamaz", Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Error, Color.Red);
            }
        }

        private void btnIDsec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "|*.ini";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.txtINIdosya.Text = openFileDialog.FileName;
        }

        private void btnKameraOkuIDsec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "|*.ini";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.txtKameraOkuINIdosya.Text = openFileDialog.FileName;
        }

        private void btnKameraYazIDsec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "|*.ini";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.txtKameraYazINIdosya.Text = openFileDialog.FileName;
        }

        private void btnPNGsec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "|*.png||*.jpg|Tüm Dosyalar|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.txtPNGdosya.Text = openFileDialog.FileName;
        }

        private void btnVektor_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Database Dosyaları|*.bat|Tüm Dosyalar|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.txtVektorProgramlamaBatch1.Text = openFileDialog.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Database Dosyaları|*.bat|Tüm Dosyalar|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.txtVektorProgramlamaBatch2.Text = openFileDialog.FileName;
        }

        private void btnVektorError_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Database Dosyaları|*.bat|Tüm Dosyalar|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.txtVektorErrorBatchDosya.Text = openFileDialog.FileName;
        }

        private void btnSQL_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Database Dosyaları|*.txt|Tüm Dosyalar|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.txtSQLDosya.Text = openFileDialog.FileName;
        }

        private void btnSQLOnOff_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Database Dosyaları|*.txt|Tüm Dosyalar|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.txtSQLOnOffDosya.Text = openFileDialog.FileName;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgAyarForm));
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtKaliteSifre = new System.Windows.Forms.TextBox();
            this.txtAdminSifre = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.timeoutKamera = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.timeoutOutputWrite = new System.Windows.Forms.TextBox();
            this.label86 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.timeoutMotor = new System.Windows.Forms.TextBox();
            this.label88 = new System.Windows.Forms.Label();
            this.timeoutProgramlama = new System.Windows.Forms.TextBox();
            this.sifreChange = new System.Windows.Forms.CheckBox();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.txtTimerAdmin = new System.Windows.Forms.TextBox();
            this.label92 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.barcodeNum = new System.Windows.Forms.ComboBox();
            this.barcode1 = new System.Windows.Forms.TextBox();
            this.barcode2 = new System.Windows.Forms.TextBox();
            this.barcode4 = new System.Windows.Forms.TextBox();
            this.barcode3 = new System.Windows.Forms.TextBox();
            this.barcode8 = new System.Windows.Forms.TextBox();
            this.barcode7 = new System.Windows.Forms.TextBox();
            this.barcode6 = new System.Windows.Forms.TextBox();
            this.barcode5 = new System.Windows.Forms.TextBox();
            this.barcode9 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtVektorProgramlamaBatch1 = new System.Windows.Forms.TextBox();
            this.btnVektor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.projectName = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.infoPicture1 = new System.Windows.Forms.PictureBox();
            this.label30 = new System.Windows.Forms.Label();
            this.feedback1 = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.serialPort1Parity = new System.Windows.Forms.ComboBox();
            this.serialPort1Stop = new System.Windows.Forms.ComboBox();
            this.serialPort1Data = new System.Windows.Forms.ComboBox();
            this.serialPort1Baud = new System.Windows.Forms.ComboBox();
            this.serialPort1Com = new System.Windows.Forms.ComboBox();
            this.chBoxSerial1 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnIDsec = new System.Windows.Forms.Button();
            this.txtINIdosya = new System.Windows.Forms.TextBox();
            this.label220 = new System.Windows.Forms.Label();
            this.btnOkuIni = new System.Windows.Forms.Button();
            this.btnKaydetIni = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnKameraYazIDsec = new System.Windows.Forms.Button();
            this.txtKameraYazINIdosya = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnKameraOkuIDsec = new System.Windows.Forms.Button();
            this.txtKameraOkuINIdosya = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbProgramlama2 = new System.Windows.Forms.RadioButton();
            this.rbProgramlama1 = new System.Windows.Forms.RadioButton();
            this.label42 = new System.Windows.Forms.Label();
            this.txtVektorProgramlamaBatch2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSQLOnOffDosya = new System.Windows.Forms.TextBox();
            this.btnSQLOnOff = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSQLDosya = new System.Windows.Forms.TextBox();
            this.btnSQL = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtVektorErrorBatchDosya = new System.Windows.Forms.TextBox();
            this.btnVektorError = new System.Windows.Forms.Button();
            this.btnPNGsec = new System.Windows.Forms.Button();
            this.txtPNGdosya = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.resetProductionNo = new System.Windows.Forms.Button();
            this.productionNo = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.softwareRev = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.FCTRev = new System.Windows.Forms.TextBox();
            this.softwareVer = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.BOMVer = new System.Windows.Forms.TextBox();
            this.ICTRev = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cardNo = new System.Windows.Forms.TextBox();
            this.gerberVer = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.companyNo = new System.Windows.Forms.TextBox();
            this.SAPNo = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.infoPicture2 = new System.Windows.Forms.PictureBox();
            this.step9Job = new System.Windows.Forms.ComboBox();
            this.label69 = new System.Windows.Forms.Label();
            this.step8Job = new System.Windows.Forms.ComboBox();
            this.label70 = new System.Windows.Forms.Label();
            this.step7Job = new System.Windows.Forms.ComboBox();
            this.label71 = new System.Windows.Forms.Label();
            this.step6Job = new System.Windows.Forms.ComboBox();
            this.label72 = new System.Windows.Forms.Label();
            this.step5Job = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.step4Job = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.step3Job = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.step2Job = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.step1Job = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.infoPicture3 = new System.Windows.Forms.PictureBox();
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.chBoxSuccess = new System.Windows.Forms.CheckBox();
            this.chBoxError1 = new System.Windows.Forms.CheckBox();
            this.chBoxError2 = new System.Windows.Forms.CheckBox();
            this.chBoxError3 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtError3Batch = new System.Windows.Forms.TextBox();
            this.txtError2Batch = new System.Windows.Forms.TextBox();
            this.txtError1Batch = new System.Windows.Forms.TextBox();
            this.txtSuccessBatch = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.printerName = new System.Windows.Forms.ComboBox();
            this.label62 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rbPrograming3 = new System.Windows.Forms.RadioButton();
            this.rbPrograming2 = new System.Windows.Forms.RadioButton();
            this.rbPrograming1 = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoPicture1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoPicture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoPicture3)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Aqua;
            this.btnKaydet.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.ForeColor = System.Drawing.Color.Black;
            this.btnKaydet.Location = new System.Drawing.Point(6, 643);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(841, 82);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "Ayarları Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtKaliteSifre
            // 
            this.txtKaliteSifre.Enabled = false;
            this.txtKaliteSifre.Location = new System.Drawing.Point(84, 82);
            this.txtKaliteSifre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKaliteSifre.Name = "txtKaliteSifre";
            this.txtKaliteSifre.PasswordChar = '*';
            this.txtKaliteSifre.Size = new System.Drawing.Size(85, 24);
            this.txtKaliteSifre.TabIndex = 0;
            // 
            // txtAdminSifre
            // 
            this.txtAdminSifre.Enabled = false;
            this.txtAdminSifre.Location = new System.Drawing.Point(84, 48);
            this.txtAdminSifre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAdminSifre.Name = "txtAdminSifre";
            this.txtAdminSifre.PasswordChar = '*';
            this.txtAdminSifre.Size = new System.Drawing.Size(84, 24);
            this.txtAdminSifre.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.timeoutKamera);
            this.groupBox6.Controls.Add(this.label73);
            this.groupBox6.Controls.Add(this.label84);
            this.groupBox6.Controls.Add(this.label85);
            this.groupBox6.Controls.Add(this.timeoutOutputWrite);
            this.groupBox6.Controls.Add(this.label86);
            this.groupBox6.Controls.Add(this.label87);
            this.groupBox6.Controls.Add(this.timeoutMotor);
            this.groupBox6.Controls.Add(this.label88);
            this.groupBox6.Controls.Add(this.timeoutProgramlama);
            this.groupBox6.Controls.Add(this.sifreChange);
            this.groupBox6.Controls.Add(this.label90);
            this.groupBox6.Controls.Add(this.txtAdminSifre);
            this.groupBox6.Controls.Add(this.txtKaliteSifre);
            this.groupBox6.Controls.Add(this.label91);
            this.groupBox6.Controls.Add(this.txtTimerAdmin);
            this.groupBox6.Controls.Add(this.label92);
            this.groupBox6.Controls.Add(this.label93);
            this.groupBox6.Location = new System.Drawing.Point(648, 14);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(203, 270);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Şifre Ayarları:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(175, 243);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 17);
            this.label15.TabIndex = 36;
            this.label15.Text = "S";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(0, 243);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 17);
            this.label16.TabIndex = 35;
            this.label16.Text = "K. Timeout:";
            // 
            // timeoutKamera
            // 
            this.timeoutKamera.Location = new System.Drawing.Point(84, 240);
            this.timeoutKamera.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.timeoutKamera.Name = "timeoutKamera";
            this.timeoutKamera.Size = new System.Drawing.Size(85, 24);
            this.timeoutKamera.TabIndex = 37;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(174, 212);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(14, 17);
            this.label73.TabIndex = 33;
            this.label73.Text = "S";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(-1, 212);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(86, 17);
            this.label84.TabIndex = 32;
            this.label84.Text = "OW. Timeout:";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(174, 180);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(14, 17);
            this.label85.TabIndex = 33;
            this.label85.Text = "S";
            // 
            // timeoutOutputWrite
            // 
            this.timeoutOutputWrite.Location = new System.Drawing.Point(84, 209);
            this.timeoutOutputWrite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.timeoutOutputWrite.Name = "timeoutOutputWrite";
            this.timeoutOutputWrite.Size = new System.Drawing.Size(84, 24);
            this.timeoutOutputWrite.TabIndex = 34;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(-1, 180);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(78, 17);
            this.label86.TabIndex = 29;
            this.label86.Text = "M. Timeout:";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(174, 149);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(14, 17);
            this.label87.TabIndex = 30;
            this.label87.Text = "S";
            // 
            // timeoutMotor
            // 
            this.timeoutMotor.Location = new System.Drawing.Point(84, 177);
            this.timeoutMotor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.timeoutMotor.Name = "timeoutMotor";
            this.timeoutMotor.Size = new System.Drawing.Size(84, 24);
            this.timeoutMotor.TabIndex = 31;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(-1, 149);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(71, 17);
            this.label88.TabIndex = 26;
            this.label88.Text = "P. Timeout:";
            // 
            // timeoutProgramlama
            // 
            this.timeoutProgramlama.Location = new System.Drawing.Point(84, 146);
            this.timeoutProgramlama.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.timeoutProgramlama.Name = "timeoutProgramlama";
            this.timeoutProgramlama.Size = new System.Drawing.Size(84, 24);
            this.timeoutProgramlama.TabIndex = 28;
            // 
            // sifreChange
            // 
            this.sifreChange.AutoSize = true;
            this.sifreChange.Location = new System.Drawing.Point(9, 21);
            this.sifreChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sifreChange.Name = "sifreChange";
            this.sifreChange.Size = new System.Drawing.Size(99, 21);
            this.sifreChange.TabIndex = 3;
            this.sifreChange.Text = "Şifre Değiştir";
            this.sifreChange.UseVisualStyleBackColor = true;
            this.sifreChange.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(-1, 55);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(70, 17);
            this.label90.TabIndex = 1;
            this.label90.Text = "Adm. Şifre:";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(-3, 85);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(72, 17);
            this.label91.TabIndex = 1;
            this.label91.Text = "Kalite Şifre:";
            // 
            // txtTimerAdmin
            // 
            this.txtTimerAdmin.Location = new System.Drawing.Point(84, 115);
            this.txtTimerAdmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimerAdmin.Name = "txtTimerAdmin";
            this.txtTimerAdmin.Size = new System.Drawing.Size(84, 24);
            this.txtTimerAdmin.TabIndex = 25;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(-1, 118);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(61, 17);
            this.label92.TabIndex = 23;
            this.label92.Text = "T. Admin:";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(174, 118);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(25, 17);
            this.label93.TabIndex = 24;
            this.label93.Text = "mS";
            // 
            // barcodeNum
            // 
            this.barcodeNum.FormattingEnabled = true;
            this.barcodeNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.barcodeNum.Location = new System.Drawing.Point(98, 23);
            this.barcodeNum.Name = "barcodeNum";
            this.barcodeNum.Size = new System.Drawing.Size(115, 23);
            this.barcodeNum.TabIndex = 12;
            this.barcodeNum.SelectedIndexChanged += new System.EventHandler(this.barcodeNum_SelectedIndexChanged);
            // 
            // barcode1
            // 
            this.barcode1.Location = new System.Drawing.Point(270, 72);
            this.barcode1.Name = "barcode1";
            this.barcode1.Size = new System.Drawing.Size(115, 24);
            this.barcode1.TabIndex = 13;
            // 
            // barcode2
            // 
            this.barcode2.Location = new System.Drawing.Point(270, 107);
            this.barcode2.Name = "barcode2";
            this.barcode2.Size = new System.Drawing.Size(115, 24);
            this.barcode2.TabIndex = 14;
            // 
            // barcode4
            // 
            this.barcode4.Location = new System.Drawing.Point(270, 177);
            this.barcode4.Name = "barcode4";
            this.barcode4.Size = new System.Drawing.Size(115, 24);
            this.barcode4.TabIndex = 16;
            // 
            // barcode3
            // 
            this.barcode3.Location = new System.Drawing.Point(270, 142);
            this.barcode3.Name = "barcode3";
            this.barcode3.Size = new System.Drawing.Size(115, 24);
            this.barcode3.TabIndex = 15;
            // 
            // barcode8
            // 
            this.barcode8.Location = new System.Drawing.Point(270, 317);
            this.barcode8.Name = "barcode8";
            this.barcode8.Size = new System.Drawing.Size(115, 24);
            this.barcode8.TabIndex = 20;
            // 
            // barcode7
            // 
            this.barcode7.Location = new System.Drawing.Point(270, 282);
            this.barcode7.Name = "barcode7";
            this.barcode7.Size = new System.Drawing.Size(115, 24);
            this.barcode7.TabIndex = 19;
            // 
            // barcode6
            // 
            this.barcode6.Location = new System.Drawing.Point(270, 247);
            this.barcode6.Name = "barcode6";
            this.barcode6.Size = new System.Drawing.Size(115, 24);
            this.barcode6.TabIndex = 18;
            // 
            // barcode5
            // 
            this.barcode5.Location = new System.Drawing.Point(270, 212);
            this.barcode5.Name = "barcode5";
            this.barcode5.Size = new System.Drawing.Size(115, 24);
            this.barcode5.TabIndex = 17;
            // 
            // barcode9
            // 
            this.barcode9.Location = new System.Drawing.Point(270, 352);
            this.barcode9.Name = "barcode9";
            this.barcode9.Size = new System.Drawing.Size(115, 24);
            this.barcode9.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(168, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Vektör Programlama Batch1";
            // 
            // txtVektorProgramlamaBatch1
            // 
            this.txtVektorProgramlamaBatch1.Location = new System.Drawing.Point(177, 20);
            this.txtVektorProgramlamaBatch1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVektorProgramlamaBatch1.Name = "txtVektorProgramlamaBatch1";
            this.txtVektorProgramlamaBatch1.Size = new System.Drawing.Size(151, 24);
            this.txtVektorProgramlamaBatch1.TabIndex = 1;
            // 
            // btnVektor
            // 
            this.btnVektor.BackColor = System.Drawing.Color.Aqua;
            this.btnVektor.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnVektor.Location = new System.Drawing.Point(336, 20);
            this.btnVektor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVektor.Name = "btnVektor";
            this.btnVektor.Size = new System.Drawing.Size(66, 24);
            this.btnVektor.TabIndex = 2;
            this.btnVektor.Text = "Seç";
            this.btnVektor.UseVisualStyleBackColor = false;
            this.btnVektor.Click += new System.EventHandler(this.btnVektor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Barcode1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Barcode2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "Barcode3:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "Barcode6:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 30;
            this.label5.Text = "Barcode5:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Barcode4:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(189, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 34;
            this.label7.Text = "Barcode9:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 319);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 17);
            this.label8.TabIndex = 33;
            this.label8.Text = "Barcode8:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(189, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "Barcode7:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 17);
            this.label11.TabIndex = 36;
            this.label11.Text = "Barcode S.:";
            // 
            // projectName
            // 
            this.projectName.Location = new System.Drawing.Point(177, 212);
            this.projectName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(151, 24);
            this.projectName.TabIndex = 62;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(3, 216);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(89, 17);
            this.label29.TabIndex = 61;
            this.label29.Text = "Project Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.infoPicture1);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.feedback1);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.serialPort1Parity);
            this.groupBox1.Controls.Add(this.serialPort1Stop);
            this.groupBox1.Controls.Add(this.serialPort1Data);
            this.groupBox1.Controls.Add(this.serialPort1Baud);
            this.groupBox1.Controls.Add(this.serialPort1Com);
            this.groupBox1.Location = new System.Drawing.Point(446, 40);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(185, 244);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port1 Com Ayar:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(11, 194);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(65, 17);
            this.label35.TabIndex = 457;
            this.label35.Text = "Feedback:";
            // 
            // infoPicture1
            // 
            this.infoPicture1.Image = ((System.Drawing.Image)(resources.GetObject("infoPicture1.Image")));
            this.infoPicture1.Location = new System.Drawing.Point(122, 171);
            this.infoPicture1.Name = "infoPicture1";
            this.infoPicture1.Size = new System.Drawing.Size(20, 20);
            this.infoPicture1.TabIndex = 456;
            this.infoPicture1.TabStop = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(11, 145);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(45, 17);
            this.label30.TabIndex = 3;
            this.label30.Text = "Parity:";
            // 
            // feedback1
            // 
            this.feedback1.FormattingEnabled = true;
            this.feedback1.Location = new System.Drawing.Point(85, 191);
            this.feedback1.Name = "feedback1";
            this.feedback1.Size = new System.Drawing.Size(94, 23);
            this.feedback1.TabIndex = 455;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(11, 115);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 17);
            this.label31.TabIndex = 3;
            this.label31.Text = "StopBit:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(11, 85);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(61, 17);
            this.label32.TabIndex = 3;
            this.label32.Text = "DataBits:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(11, 55);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(68, 17);
            this.label33.TabIndex = 3;
            this.label33.Text = "BaudRate:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(11, 25);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(72, 17);
            this.label34.TabIndex = 3;
            this.label34.Text = "FCTStation:";
            // 
            // serialPort1Parity
            // 
            this.serialPort1Parity.FormattingEnabled = true;
            this.serialPort1Parity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.serialPort1Parity.Location = new System.Drawing.Point(85, 143);
            this.serialPort1Parity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.serialPort1Parity.Name = "serialPort1Parity";
            this.serialPort1Parity.Size = new System.Drawing.Size(94, 23);
            this.serialPort1Parity.TabIndex = 2;
            // 
            // serialPort1Stop
            // 
            this.serialPort1Stop.FormattingEnabled = true;
            this.serialPort1Stop.Items.AddRange(new object[] {
            "None",
            "One",
            "Two",
            "OnePointFive"});
            this.serialPort1Stop.Location = new System.Drawing.Point(85, 113);
            this.serialPort1Stop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.serialPort1Stop.Name = "serialPort1Stop";
            this.serialPort1Stop.Size = new System.Drawing.Size(94, 23);
            this.serialPort1Stop.TabIndex = 2;
            // 
            // serialPort1Data
            // 
            this.serialPort1Data.FormattingEnabled = true;
            this.serialPort1Data.Items.AddRange(new object[] {
            "8",
            "7"});
            this.serialPort1Data.Location = new System.Drawing.Point(85, 83);
            this.serialPort1Data.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.serialPort1Data.Name = "serialPort1Data";
            this.serialPort1Data.Size = new System.Drawing.Size(94, 23);
            this.serialPort1Data.TabIndex = 2;
            // 
            // serialPort1Baud
            // 
            this.serialPort1Baud.FormattingEnabled = true;
            this.serialPort1Baud.Items.AddRange(new object[] {
            "2400",
            "4800",
            "7200",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.serialPort1Baud.Location = new System.Drawing.Point(85, 53);
            this.serialPort1Baud.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.serialPort1Baud.Name = "serialPort1Baud";
            this.serialPort1Baud.Size = new System.Drawing.Size(94, 23);
            this.serialPort1Baud.TabIndex = 2;
            // 
            // serialPort1Com
            // 
            this.serialPort1Com.FormattingEnabled = true;
            this.serialPort1Com.Location = new System.Drawing.Point(85, 23);
            this.serialPort1Com.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.serialPort1Com.Name = "serialPort1Com";
            this.serialPort1Com.Size = new System.Drawing.Size(94, 23);
            this.serialPort1Com.TabIndex = 2;
            // 
            // chBoxSerial1
            // 
            this.chBoxSerial1.AutoSize = true;
            this.chBoxSerial1.Location = new System.Drawing.Point(472, 14);
            this.chBoxSerial1.Name = "chBoxSerial1";
            this.chBoxSerial1.Size = new System.Drawing.Size(125, 21);
            this.chBoxSerial1.TabIndex = 64;
            this.chBoxSerial1.Text = "Serial1 Aktif/Pasif";
            this.chBoxSerial1.UseVisualStyleBackColor = true;
            this.chBoxSerial1.CheckedChanged += new System.EventHandler(this.chBoxSerial1_CheckedChanged);
            // 
            // btnIDsec
            // 
            this.btnIDsec.BackColor = System.Drawing.Color.Aqua;
            this.btnIDsec.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIDsec.Location = new System.Drawing.Point(312, 22);
            this.btnIDsec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIDsec.Name = "btnIDsec";
            this.btnIDsec.Size = new System.Drawing.Size(89, 24);
            this.btnIDsec.TabIndex = 587;
            this.btnIDsec.Text = "Seç";
            this.btnIDsec.UseVisualStyleBackColor = false;
            this.btnIDsec.Click += new System.EventHandler(this.btnIDsec_Click);
            // 
            // txtINIdosya
            // 
            this.txtINIdosya.Location = new System.Drawing.Point(131, 22);
            this.txtINIdosya.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtINIdosya.Name = "txtINIdosya";
            this.txtINIdosya.Size = new System.Drawing.Size(172, 24);
            this.txtINIdosya.TabIndex = 586;
            // 
            // label220
            // 
            this.label220.AutoSize = true;
            this.label220.Location = new System.Drawing.Point(9, 22);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(116, 17);
            this.label220.TabIndex = 585;
            this.label220.Text = "Ayarlar Dosya Yolu:";
            // 
            // btnOkuIni
            // 
            this.btnOkuIni.BackColor = System.Drawing.Color.Aqua;
            this.btnOkuIni.Location = new System.Drawing.Point(217, 55);
            this.btnOkuIni.Name = "btnOkuIni";
            this.btnOkuIni.Size = new System.Drawing.Size(80, 30);
            this.btnOkuIni.TabIndex = 584;
            this.btnOkuIni.Text = "Oku";
            this.btnOkuIni.UseVisualStyleBackColor = false;
            this.btnOkuIni.Click += new System.EventHandler(this.btnOkuIni_Click);
            // 
            // btnKaydetIni
            // 
            this.btnKaydetIni.BackColor = System.Drawing.Color.Aqua;
            this.btnKaydetIni.Location = new System.Drawing.Point(131, 55);
            this.btnKaydetIni.Name = "btnKaydetIni";
            this.btnKaydetIni.Size = new System.Drawing.Size(80, 30);
            this.btnKaydetIni.TabIndex = 583;
            this.btnKaydetIni.Text = "Kaydet";
            this.btnKaydetIni.UseVisualStyleBackColor = false;
            this.btnKaydetIni.Click += new System.EventHandler(this.btnKaydetIni_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btnKameraYazIDsec);
            this.groupBox2.Controls.Add(this.txtKameraYazINIdosya);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnKameraOkuIDsec);
            this.groupBox2.Controls.Add(this.txtKameraOkuINIdosya);
            this.groupBox2.Controls.Add(this.label220);
            this.groupBox2.Controls.Add(this.btnOkuIni);
            this.groupBox2.Controls.Add(this.btnIDsec);
            this.groupBox2.Controls.Add(this.btnKaydetIni);
            this.groupBox2.Controls.Add(this.txtINIdosya);
            this.groupBox2.Location = new System.Drawing.Point(444, 416);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 162);
            this.groupBox2.TabIndex = 588;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ini Dosyası Ayarları:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(15, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 13);
            this.label13.TabIndex = 591;
            this.label13.Text = "Kamera Dosya Yaz Yolu:";
            // 
            // btnKameraYazIDsec
            // 
            this.btnKameraYazIDsec.BackColor = System.Drawing.Color.Aqua;
            this.btnKameraYazIDsec.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKameraYazIDsec.Location = new System.Drawing.Point(312, 128);
            this.btnKameraYazIDsec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKameraYazIDsec.Name = "btnKameraYazIDsec";
            this.btnKameraYazIDsec.Size = new System.Drawing.Size(89, 24);
            this.btnKameraYazIDsec.TabIndex = 593;
            this.btnKameraYazIDsec.Text = "Seç";
            this.btnKameraYazIDsec.UseVisualStyleBackColor = false;
            this.btnKameraYazIDsec.Click += new System.EventHandler(this.btnKameraYazIDsec_Click);
            // 
            // txtKameraYazINIdosya
            // 
            this.txtKameraYazINIdosya.Location = new System.Drawing.Point(137, 127);
            this.txtKameraYazINIdosya.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKameraYazINIdosya.Name = "txtKameraYazINIdosya";
            this.txtKameraYazINIdosya.Size = new System.Drawing.Size(167, 24);
            this.txtKameraYazINIdosya.TabIndex = 592;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(14, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 13);
            this.label10.TabIndex = 588;
            this.label10.Text = "Kamera Dosya Oku Yolu:";
            // 
            // btnKameraOkuIDsec
            // 
            this.btnKameraOkuIDsec.BackColor = System.Drawing.Color.Aqua;
            this.btnKameraOkuIDsec.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKameraOkuIDsec.Location = new System.Drawing.Point(311, 93);
            this.btnKameraOkuIDsec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKameraOkuIDsec.Name = "btnKameraOkuIDsec";
            this.btnKameraOkuIDsec.Size = new System.Drawing.Size(90, 24);
            this.btnKameraOkuIDsec.TabIndex = 590;
            this.btnKameraOkuIDsec.Text = "Seç";
            this.btnKameraOkuIDsec.UseVisualStyleBackColor = false;
            this.btnKameraOkuIDsec.Click += new System.EventHandler(this.btnKameraOkuIDsec_Click);
            // 
            // txtKameraOkuINIdosya
            // 
            this.txtKameraOkuINIdosya.Location = new System.Drawing.Point(136, 92);
            this.txtKameraOkuINIdosya.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKameraOkuINIdosya.Name = "txtKameraOkuINIdosya";
            this.txtKameraOkuINIdosya.Size = new System.Drawing.Size(167, 24);
            this.txtKameraOkuINIdosya.TabIndex = 589;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbProgramlama2);
            this.groupBox3.Controls.Add(this.rbProgramlama1);
            this.groupBox3.Controls.Add(this.label42);
            this.groupBox3.Controls.Add(this.txtVektorProgramlamaBatch2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.txtSQLOnOffDosya);
            this.groupBox3.Controls.Add(this.btnSQLOnOff);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.txtSQLDosya);
            this.groupBox3.Controls.Add(this.btnSQL);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtVektorErrorBatchDosya);
            this.groupBox3.Controls.Add(this.btnVektorError);
            this.groupBox3.Controls.Add(this.btnPNGsec);
            this.groupBox3.Controls.Add(this.txtPNGdosya);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtVektorProgramlamaBatch1);
            this.groupBox3.Controls.Add(this.btnVektor);
            this.groupBox3.Controls.Add(this.projectName);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Location = new System.Drawing.Point(6, 396);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(434, 242);
            this.groupBox3.TabIndex = 589;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Proje Ayarları:";
            // 
            // rbProgramlama2
            // 
            this.rbProgramlama2.AutoSize = true;
            this.rbProgramlama2.Location = new System.Drawing.Point(408, 56);
            this.rbProgramlama2.Name = "rbProgramlama2";
            this.rbProgramlama2.Size = new System.Drawing.Size(14, 13);
            this.rbProgramlama2.TabIndex = 79;
            this.rbProgramlama2.TabStop = true;
            this.rbProgramlama2.UseVisualStyleBackColor = true;
            this.rbProgramlama2.CheckedChanged += new System.EventHandler(this.rbProgramlama2_CheckedChanged);
            // 
            // rbProgramlama1
            // 
            this.rbProgramlama1.AutoSize = true;
            this.rbProgramlama1.Location = new System.Drawing.Point(408, 26);
            this.rbProgramlama1.Name = "rbProgramlama1";
            this.rbProgramlama1.Size = new System.Drawing.Size(14, 13);
            this.rbProgramlama1.TabIndex = 78;
            this.rbProgramlama1.TabStop = true;
            this.rbProgramlama1.UseVisualStyleBackColor = true;
            this.rbProgramlama1.CheckedChanged += new System.EventHandler(this.rbProgramlama1_CheckedChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(3, 56);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(168, 17);
            this.label42.TabIndex = 75;
            this.label42.Text = "Vektör Programlama Batch2";
            // 
            // txtVektorProgramlamaBatch2
            // 
            this.txtVektorProgramlamaBatch2.Location = new System.Drawing.Point(177, 51);
            this.txtVektorProgramlamaBatch2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVektorProgramlamaBatch2.Name = "txtVektorProgramlamaBatch2";
            this.txtVektorProgramlamaBatch2.Size = new System.Drawing.Size(151, 24);
            this.txtVektorProgramlamaBatch2.TabIndex = 76;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Aqua;
            this.button1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(336, 51);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 24);
            this.button1.TabIndex = 77;
            this.button1.Text = "Seç";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 153);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(136, 17);
            this.label18.TabIndex = 72;
            this.label18.Text = "SQL On-Off Dosya Yolu:";
            // 
            // txtSQLOnOffDosya
            // 
            this.txtSQLOnOffDosya.Location = new System.Drawing.Point(177, 148);
            this.txtSQLOnOffDosya.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSQLOnOffDosya.Name = "txtSQLOnOffDosya";
            this.txtSQLOnOffDosya.Size = new System.Drawing.Size(151, 24);
            this.txtSQLOnOffDosya.TabIndex = 73;
            // 
            // btnSQLOnOff
            // 
            this.btnSQLOnOff.BackColor = System.Drawing.Color.Aqua;
            this.btnSQLOnOff.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSQLOnOff.Location = new System.Drawing.Point(336, 148);
            this.btnSQLOnOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSQLOnOff.Name = "btnSQLOnOff";
            this.btnSQLOnOff.Size = new System.Drawing.Size(92, 24);
            this.btnSQLOnOff.TabIndex = 74;
            this.btnSQLOnOff.Text = "Seç";
            this.btnSQLOnOff.UseVisualStyleBackColor = false;
            this.btnSQLOnOff.Click += new System.EventHandler(this.btnSQLOnOff_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 121);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 17);
            this.label17.TabIndex = 69;
            this.label17.Text = "SQL Dosya Yolu:";
            // 
            // txtSQLDosya
            // 
            this.txtSQLDosya.Location = new System.Drawing.Point(177, 116);
            this.txtSQLDosya.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSQLDosya.Name = "txtSQLDosya";
            this.txtSQLDosya.Size = new System.Drawing.Size(151, 24);
            this.txtSQLDosya.TabIndex = 70;
            // 
            // btnSQL
            // 
            this.btnSQL.BackColor = System.Drawing.Color.Aqua;
            this.btnSQL.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSQL.Location = new System.Drawing.Point(336, 116);
            this.btnSQL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSQL.Name = "btnSQL";
            this.btnSQL.Size = new System.Drawing.Size(92, 24);
            this.btnSQL.TabIndex = 71;
            this.btnSQL.Text = "Seç";
            this.btnSQL.UseVisualStyleBackColor = false;
            this.btnSQL.Click += new System.EventHandler(this.btnSQL_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(159, 17);
            this.label14.TabIndex = 66;
            this.label14.Text = "Vektör E.Batch Dosya Yolu:";
            // 
            // txtVektorErrorBatchDosya
            // 
            this.txtVektorErrorBatchDosya.Location = new System.Drawing.Point(177, 83);
            this.txtVektorErrorBatchDosya.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVektorErrorBatchDosya.Name = "txtVektorErrorBatchDosya";
            this.txtVektorErrorBatchDosya.Size = new System.Drawing.Size(151, 24);
            this.txtVektorErrorBatchDosya.TabIndex = 67;
            // 
            // btnVektorError
            // 
            this.btnVektorError.BackColor = System.Drawing.Color.Aqua;
            this.btnVektorError.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnVektorError.Location = new System.Drawing.Point(336, 83);
            this.btnVektorError.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVektorError.Name = "btnVektorError";
            this.btnVektorError.Size = new System.Drawing.Size(92, 24);
            this.btnVektorError.TabIndex = 68;
            this.btnVektorError.Text = "Seç";
            this.btnVektorError.UseVisualStyleBackColor = false;
            this.btnVektorError.Click += new System.EventHandler(this.btnVektorError_Click);
            // 
            // btnPNGsec
            // 
            this.btnPNGsec.BackColor = System.Drawing.Color.Aqua;
            this.btnPNGsec.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPNGsec.Location = new System.Drawing.Point(336, 177);
            this.btnPNGsec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPNGsec.Name = "btnPNGsec";
            this.btnPNGsec.Size = new System.Drawing.Size(92, 24);
            this.btnPNGsec.TabIndex = 65;
            this.btnPNGsec.Text = "Seç";
            this.btnPNGsec.UseVisualStyleBackColor = false;
            this.btnPNGsec.Click += new System.EventHandler(this.btnPNGsec_Click);
            // 
            // txtPNGdosya
            // 
            this.txtPNGdosya.Location = new System.Drawing.Point(177, 179);
            this.txtPNGdosya.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPNGdosya.Name = "txtPNGdosya";
            this.txtPNGdosya.Size = new System.Drawing.Size(151, 24);
            this.txtPNGdosya.TabIndex = 64;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(3, 184);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(109, 17);
            this.label36.TabIndex = 63;
            this.label36.Text = "Resim Dosya Yolu:";
            // 
            // resetProductionNo
            // 
            this.resetProductionNo.BackColor = System.Drawing.Color.Aqua;
            this.resetProductionNo.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.resetProductionNo.Location = new System.Drawing.Point(341, 95);
            this.resetProductionNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resetProductionNo.Name = "resetProductionNo";
            this.resetProductionNo.Size = new System.Drawing.Size(65, 24);
            this.resetProductionNo.TabIndex = 95;
            this.resetProductionNo.Text = "Sıfırla";
            this.resetProductionNo.UseVisualStyleBackColor = false;
            this.resetProductionNo.Click += new System.EventHandler(this.resetProductionNo_Click);
            // 
            // productionNo
            // 
            this.productionNo.Location = new System.Drawing.Point(171, 95);
            this.productionNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.productionNo.Name = "productionNo";
            this.productionNo.Size = new System.Drawing.Size(162, 24);
            this.productionNo.TabIndex = 94;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(11, 98);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(92, 17);
            this.label22.TabIndex = 93;
            this.label22.Text = "Production No:";
            // 
            // softwareRev
            // 
            this.softwareRev.Location = new System.Drawing.Point(171, 349);
            this.softwareRev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.softwareRev.Name = "softwareRev";
            this.softwareRev.Size = new System.Drawing.Size(162, 24);
            this.softwareRev.TabIndex = 92;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 352);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 17);
            this.label19.TabIndex = 91;
            this.label19.Text = "Software Rev:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 280);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 17);
            this.label20.TabIndex = 87;
            this.label20.Text = "FCT Rev:";
            // 
            // FCTRev
            // 
            this.FCTRev.Location = new System.Drawing.Point(171, 277);
            this.FCTRev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FCTRev.Name = "FCTRev";
            this.FCTRev.Size = new System.Drawing.Size(162, 24);
            this.FCTRev.TabIndex = 88;
            // 
            // softwareVer
            // 
            this.softwareVer.Location = new System.Drawing.Point(171, 313);
            this.softwareVer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.softwareVer.Name = "softwareVer";
            this.softwareVer.Size = new System.Drawing.Size(162, 24);
            this.softwareVer.TabIndex = 90;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 316);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 17);
            this.label21.TabIndex = 89;
            this.label21.Text = "Software Ver:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(11, 207);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(63, 17);
            this.label26.TabIndex = 83;
            this.label26.Text = "BOM Ver:";
            // 
            // BOMVer
            // 
            this.BOMVer.Location = new System.Drawing.Point(171, 204);
            this.BOMVer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BOMVer.Name = "BOMVer";
            this.BOMVer.Size = new System.Drawing.Size(162, 24);
            this.BOMVer.TabIndex = 84;
            // 
            // ICTRev
            // 
            this.ICTRev.Location = new System.Drawing.Point(171, 240);
            this.ICTRev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ICTRev.Name = "ICTRev";
            this.ICTRev.Size = new System.Drawing.Size(162, 24);
            this.ICTRev.TabIndex = 86;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(11, 243);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(54, 17);
            this.label27.TabIndex = 85;
            this.label27.Text = "ICT Rev:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(11, 135);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(57, 17);
            this.label24.TabIndex = 79;
            this.label24.Text = "Card No:";
            // 
            // cardNo
            // 
            this.cardNo.Location = new System.Drawing.Point(171, 132);
            this.cardNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cardNo.Name = "cardNo";
            this.cardNo.Size = new System.Drawing.Size(162, 24);
            this.cardNo.TabIndex = 80;
            // 
            // gerberVer
            // 
            this.gerberVer.Location = new System.Drawing.Point(171, 168);
            this.gerberVer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gerberVer.Name = "gerberVer";
            this.gerberVer.Size = new System.Drawing.Size(162, 24);
            this.gerberVer.TabIndex = 82;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(11, 171);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(74, 17);
            this.label25.TabIndex = 81;
            this.label25.Text = "Gerber Ver:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(11, 25);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(83, 17);
            this.label23.TabIndex = 75;
            this.label23.Text = "Company No:";
            // 
            // companyNo
            // 
            this.companyNo.Location = new System.Drawing.Point(171, 22);
            this.companyNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.companyNo.Name = "companyNo";
            this.companyNo.Size = new System.Drawing.Size(162, 24);
            this.companyNo.TabIndex = 76;
            // 
            // SAPNo
            // 
            this.SAPNo.Location = new System.Drawing.Point(171, 58);
            this.SAPNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SAPNo.Name = "SAPNo";
            this.SAPNo.Size = new System.Drawing.Size(162, 24);
            this.SAPNo.TabIndex = 78;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(11, 61);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(52, 17);
            this.label28.TabIndex = 77;
            this.label28.Text = "SAP No:";
            // 
            // infoPicture2
            // 
            this.infoPicture2.Image = ((System.Drawing.Image)(resources.GetObject("infoPicture2.Image")));
            this.infoPicture2.Location = new System.Drawing.Point(119, 52);
            this.infoPicture2.Name = "infoPicture2";
            this.infoPicture2.Size = new System.Drawing.Size(20, 20);
            this.infoPicture2.TabIndex = 630;
            this.infoPicture2.TabStop = false;
            // 
            // step9Job
            // 
            this.step9Job.FormattingEnabled = true;
            this.step9Job.Items.AddRange(new object[] {
            "1",
            "2"});
            this.step9Job.Location = new System.Drawing.Point(101, 352);
            this.step9Job.Name = "step9Job";
            this.step9Job.Size = new System.Drawing.Size(58, 23);
            this.step9Job.TabIndex = 607;
            this.step9Job.SelectedIndexChanged += new System.EventHandler(this.step9Job_SelectedIndexChanged);
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(40, 354);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(44, 17);
            this.label69.TabIndex = 606;
            this.label69.Text = "Step9:";
            // 
            // step8Job
            // 
            this.step8Job.FormattingEnabled = true;
            this.step8Job.Items.AddRange(new object[] {
            "1",
            "2"});
            this.step8Job.Location = new System.Drawing.Point(101, 317);
            this.step8Job.Name = "step8Job";
            this.step8Job.Size = new System.Drawing.Size(58, 23);
            this.step8Job.TabIndex = 605;
            this.step8Job.SelectedIndexChanged += new System.EventHandler(this.step8Job_SelectedIndexChanged);
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(40, 319);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(44, 17);
            this.label70.TabIndex = 604;
            this.label70.Text = "Step8:";
            // 
            // step7Job
            // 
            this.step7Job.FormattingEnabled = true;
            this.step7Job.Items.AddRange(new object[] {
            "1",
            "2"});
            this.step7Job.Location = new System.Drawing.Point(101, 282);
            this.step7Job.Name = "step7Job";
            this.step7Job.Size = new System.Drawing.Size(58, 23);
            this.step7Job.TabIndex = 603;
            this.step7Job.SelectedIndexChanged += new System.EventHandler(this.step7Job_SelectedIndexChanged);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(40, 284);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(44, 17);
            this.label71.TabIndex = 602;
            this.label71.Text = "Step7:";
            // 
            // step6Job
            // 
            this.step6Job.FormattingEnabled = true;
            this.step6Job.Items.AddRange(new object[] {
            "1",
            "2"});
            this.step6Job.Location = new System.Drawing.Point(101, 247);
            this.step6Job.Name = "step6Job";
            this.step6Job.Size = new System.Drawing.Size(58, 23);
            this.step6Job.TabIndex = 601;
            this.step6Job.SelectedIndexChanged += new System.EventHandler(this.step6Job_SelectedIndexChanged);
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(40, 249);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(44, 17);
            this.label72.TabIndex = 600;
            this.label72.Text = "Step6:";
            // 
            // step5Job
            // 
            this.step5Job.FormattingEnabled = true;
            this.step5Job.Items.AddRange(new object[] {
            "1",
            "2"});
            this.step5Job.Location = new System.Drawing.Point(101, 212);
            this.step5Job.Name = "step5Job";
            this.step5Job.Size = new System.Drawing.Size(58, 23);
            this.step5Job.TabIndex = 599;
            this.step5Job.SelectedIndexChanged += new System.EventHandler(this.step5Job_SelectedIndexChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(40, 214);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(44, 17);
            this.label37.TabIndex = 598;
            this.label37.Text = "Step5:";
            // 
            // step4Job
            // 
            this.step4Job.FormattingEnabled = true;
            this.step4Job.Items.AddRange(new object[] {
            "1",
            "2"});
            this.step4Job.Location = new System.Drawing.Point(101, 177);
            this.step4Job.Name = "step4Job";
            this.step4Job.Size = new System.Drawing.Size(58, 23);
            this.step4Job.TabIndex = 597;
            this.step4Job.SelectedIndexChanged += new System.EventHandler(this.step4Job_SelectedIndexChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(40, 179);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(44, 17);
            this.label38.TabIndex = 596;
            this.label38.Text = "Step4:";
            // 
            // step3Job
            // 
            this.step3Job.FormattingEnabled = true;
            this.step3Job.Items.AddRange(new object[] {
            "1",
            "2"});
            this.step3Job.Location = new System.Drawing.Point(101, 142);
            this.step3Job.Name = "step3Job";
            this.step3Job.Size = new System.Drawing.Size(58, 23);
            this.step3Job.TabIndex = 595;
            this.step3Job.SelectedIndexChanged += new System.EventHandler(this.step3Job_SelectedIndexChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(40, 144);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(44, 17);
            this.label39.TabIndex = 594;
            this.label39.Text = "Step3:";
            // 
            // step2Job
            // 
            this.step2Job.FormattingEnabled = true;
            this.step2Job.Items.AddRange(new object[] {
            "1",
            "2"});
            this.step2Job.Location = new System.Drawing.Point(101, 107);
            this.step2Job.Name = "step2Job";
            this.step2Job.Size = new System.Drawing.Size(58, 23);
            this.step2Job.TabIndex = 593;
            this.step2Job.SelectedIndexChanged += new System.EventHandler(this.step2Job_SelectedIndexChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(40, 109);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(44, 17);
            this.label40.TabIndex = 592;
            this.label40.Text = "Step2:";
            // 
            // step1Job
            // 
            this.step1Job.FormattingEnabled = true;
            this.step1Job.Items.AddRange(new object[] {
            "1",
            "2"});
            this.step1Job.Location = new System.Drawing.Point(101, 72);
            this.step1Job.Name = "step1Job";
            this.step1Job.Size = new System.Drawing.Size(58, 23);
            this.step1Job.TabIndex = 591;
            this.step1Job.SelectedIndexChanged += new System.EventHandler(this.step1Job_SelectedIndexChanged);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(40, 74);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(44, 17);
            this.label41.TabIndex = 590;
            this.label41.Text = "Step1:";
            // 
            // infoPicture3
            // 
            this.infoPicture3.Image = ((System.Drawing.Image)(resources.GetObject("infoPicture3.Image")));
            this.infoPicture3.Location = new System.Drawing.Point(317, 52);
            this.infoPicture3.Name = "infoPicture3";
            this.infoPicture3.Size = new System.Drawing.Size(20, 20);
            this.infoPicture3.TabIndex = 671;
            this.infoPicture3.TabStop = false;
            // 
            // chBoxSuccess
            // 
            this.chBoxSuccess.AutoSize = true;
            this.chBoxSuccess.Location = new System.Drawing.Point(10, 18);
            this.chBoxSuccess.Name = "chBoxSuccess";
            this.chBoxSuccess.Size = new System.Drawing.Size(69, 21);
            this.chBoxSuccess.TabIndex = 673;
            this.chBoxSuccess.Text = "Success";
            this.chBoxSuccess.UseVisualStyleBackColor = true;
            this.chBoxSuccess.CheckedChanged += new System.EventHandler(this.chBoxSuccess_CheckedChanged);
            // 
            // chBoxError1
            // 
            this.chBoxError1.AutoSize = true;
            this.chBoxError1.Location = new System.Drawing.Point(10, 43);
            this.chBoxError1.Name = "chBoxError1";
            this.chBoxError1.Size = new System.Drawing.Size(63, 21);
            this.chBoxError1.TabIndex = 674;
            this.chBoxError1.Text = "Error1";
            this.chBoxError1.UseVisualStyleBackColor = true;
            this.chBoxError1.CheckedChanged += new System.EventHandler(this.chBoxError1_CheckedChanged);
            // 
            // chBoxError2
            // 
            this.chBoxError2.AutoSize = true;
            this.chBoxError2.Location = new System.Drawing.Point(10, 68);
            this.chBoxError2.Name = "chBoxError2";
            this.chBoxError2.Size = new System.Drawing.Size(63, 21);
            this.chBoxError2.TabIndex = 675;
            this.chBoxError2.Text = "Error2";
            this.chBoxError2.UseVisualStyleBackColor = true;
            this.chBoxError2.CheckedChanged += new System.EventHandler(this.chBoxError2_CheckedChanged);
            // 
            // chBoxError3
            // 
            this.chBoxError3.AutoSize = true;
            this.chBoxError3.Location = new System.Drawing.Point(10, 93);
            this.chBoxError3.Name = "chBoxError3";
            this.chBoxError3.Size = new System.Drawing.Size(63, 21);
            this.chBoxError3.TabIndex = 676;
            this.chBoxError3.Text = "Error3";
            this.chBoxError3.UseVisualStyleBackColor = true;
            this.chBoxError3.CheckedChanged += new System.EventHandler(this.chBoxError3_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtError3Batch);
            this.groupBox4.Controls.Add(this.txtError2Batch);
            this.groupBox4.Controls.Add(this.txtError1Batch);
            this.groupBox4.Controls.Add(this.txtSuccessBatch);
            this.groupBox4.Controls.Add(this.chBoxError3);
            this.groupBox4.Controls.Add(this.chBoxSuccess);
            this.groupBox4.Controls.Add(this.chBoxError2);
            this.groupBox4.Controls.Add(this.chBoxError1);
            this.groupBox4.Location = new System.Drawing.Point(446, 290);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(407, 120);
            this.groupBox4.TabIndex = 677;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Batch Error Name";
            // 
            // txtError3Batch
            // 
            this.txtError3Batch.Location = new System.Drawing.Point(85, 90);
            this.txtError3Batch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtError3Batch.Name = "txtError3Batch";
            this.txtError3Batch.Size = new System.Drawing.Size(316, 24);
            this.txtError3Batch.TabIndex = 680;
            // 
            // txtError2Batch
            // 
            this.txtError2Batch.Location = new System.Drawing.Point(85, 65);
            this.txtError2Batch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtError2Batch.Name = "txtError2Batch";
            this.txtError2Batch.Size = new System.Drawing.Size(316, 24);
            this.txtError2Batch.TabIndex = 679;
            // 
            // txtError1Batch
            // 
            this.txtError1Batch.Location = new System.Drawing.Point(85, 40);
            this.txtError1Batch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtError1Batch.Name = "txtError1Batch";
            this.txtError1Batch.Size = new System.Drawing.Size(316, 24);
            this.txtError1Batch.TabIndex = 678;
            // 
            // txtSuccessBatch
            // 
            this.txtSuccessBatch.Location = new System.Drawing.Point(85, 15);
            this.txtSuccessBatch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSuccessBatch.Name = "txtSuccessBatch";
            this.txtSuccessBatch.Size = new System.Drawing.Size(316, 24);
            this.txtSuccessBatch.TabIndex = 677;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.printerName);
            this.groupBox9.Controls.Add(this.label62);
            this.groupBox9.Location = new System.Drawing.Point(444, 582);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(407, 56);
            this.groupBox9.TabIndex = 678;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Yazıcı Ayarları:";
            // 
            // printerName
            // 
            this.printerName.FormattingEnabled = true;
            this.printerName.Location = new System.Drawing.Point(140, 19);
            this.printerName.Name = "printerName";
            this.printerName.Size = new System.Drawing.Size(185, 23);
            this.printerName.TabIndex = 586;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(9, 22);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(64, 17);
            this.label62.TabIndex = 585;
            this.label62.Text = "Yazıcı Adı:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.barcodeNum);
            this.groupBox5.Controls.Add(this.barcode1);
            this.groupBox5.Controls.Add(this.barcode2);
            this.groupBox5.Controls.Add(this.barcode3);
            this.groupBox5.Controls.Add(this.infoPicture3);
            this.groupBox5.Controls.Add(this.barcode4);
            this.groupBox5.Controls.Add(this.infoPicture2);
            this.groupBox5.Controls.Add(this.barcode5);
            this.groupBox5.Controls.Add(this.step9Job);
            this.groupBox5.Controls.Add(this.barcode6);
            this.groupBox5.Controls.Add(this.label69);
            this.groupBox5.Controls.Add(this.barcode7);
            this.groupBox5.Controls.Add(this.step8Job);
            this.groupBox5.Controls.Add(this.barcode8);
            this.groupBox5.Controls.Add(this.label70);
            this.groupBox5.Controls.Add(this.barcode9);
            this.groupBox5.Controls.Add(this.step7Job);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label71);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.step6Job);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label72);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.step5Job);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label37);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.step4Job);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label38);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.step3Job);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label39);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.step2Job);
            this.groupBox5.Controls.Add(this.label41);
            this.groupBox5.Controls.Add(this.label40);
            this.groupBox5.Controls.Add(this.step1Job);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(434, 384);
            this.groupBox5.TabIndex = 679;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Barcode";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(862, 761);
            this.tabControl1.TabIndex = 680;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(854, 733);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Operatör";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.rbPrograming3);
            this.groupBox8.Controls.Add(this.rbPrograming2);
            this.groupBox8.Controls.Add(this.rbPrograming1);
            this.groupBox8.Location = new System.Drawing.Point(6, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(314, 393);
            this.groupBox8.TabIndex = 60;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "SAP NO";
            // 
            // rbPrograming3
            // 
            this.rbPrograming3.AutoSize = true;
            this.rbPrograming3.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold);
            this.rbPrograming3.ForeColor = System.Drawing.Color.Black;
            this.rbPrograming3.Location = new System.Drawing.Point(14, 337);
            this.rbPrograming3.Name = "rbPrograming3";
            this.rbPrograming3.Size = new System.Drawing.Size(256, 45);
            this.rbPrograming3.TabIndex = 2;
            this.rbPrograming3.Text = "1921403000";
            this.rbPrograming3.UseVisualStyleBackColor = true;
            this.rbPrograming3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rbPrograming2
            // 
            this.rbPrograming2.AutoSize = true;
            this.rbPrograming2.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold);
            this.rbPrograming2.ForeColor = System.Drawing.Color.Black;
            this.rbPrograming2.Location = new System.Drawing.Point(14, 177);
            this.rbPrograming2.Name = "rbPrograming2";
            this.rbPrograming2.Size = new System.Drawing.Size(256, 45);
            this.rbPrograming2.TabIndex = 1;
            this.rbPrograming2.Text = "2500001000";
            this.rbPrograming2.UseVisualStyleBackColor = true;
            this.rbPrograming2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbPrograming1
            // 
            this.rbPrograming1.AutoSize = true;
            this.rbPrograming1.Checked = true;
            this.rbPrograming1.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold);
            this.rbPrograming1.ForeColor = System.Drawing.Color.Black;
            this.rbPrograming1.Location = new System.Drawing.Point(14, 19);
            this.rbPrograming1.Name = "rbPrograming1";
            this.rbPrograming1.Size = new System.Drawing.Size(256, 45);
            this.rbPrograming1.TabIndex = 0;
            this.rbPrograming1.TabStop = true;
            this.rbPrograming1.Text = "2446407000";
            this.rbPrograming1.UseVisualStyleBackColor = true;
            this.rbPrograming1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.resetProductionNo);
            this.groupBox7.Controls.Add(this.companyNo);
            this.groupBox7.Controls.Add(this.gerberVer);
            this.groupBox7.Controls.Add(this.productionNo);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.cardNo);
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Controls.Add(this.softwareRev);
            this.groupBox7.Controls.Add(this.SAPNo);
            this.groupBox7.Controls.Add(this.label27);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.label28);
            this.groupBox7.Controls.Add(this.ICTRev);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.BOMVer);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Controls.Add(this.FCTRev);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Controls.Add(this.softwareVer);
            this.groupBox7.Location = new System.Drawing.Point(423, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(411, 390);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Operatör Kontrol";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox9);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.btnKaydet);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.chBoxSerial1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(854, 733);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Admin";
            // 
            // ProgAyarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(874, 772);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProgAyarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.AyarForm_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoPicture1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoPicture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoPicture3)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void step1Job_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void step2Job_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void step3Job_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void step4Job_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void step5Job_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void step6Job_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void step7Job_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void step8Job_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void step9Job_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void chBoxSuccess_CheckedChanged(object sender, EventArgs e)
        {
            txtSuccessBatch.Enabled = chBoxSuccess.Checked;
        }

        private void chBoxError1_CheckedChanged(object sender, EventArgs e)
        {
            txtError1Batch.Enabled = chBoxError1.Checked;
        }

        private void chBoxError2_CheckedChanged(object sender, EventArgs e)
        {
            txtError2Batch.Enabled = chBoxError2.Checked;
        }

        private void chBoxError3_CheckedChanged(object sender, EventArgs e)
        {
            txtError3Batch.Enabled = chBoxError3.Checked;
        }

        private void resetProductionNo_Click(object sender, EventArgs e)
        {
            try
            {
                this.MainFrm.nxCompoletBoolWrite("productionNoReset", true);
            }
            catch (Exception ex)
            {
                this.MainFrm.otherConsoleAppendLine("resetProductionNo_Click: " + ex.Message, Color.Red);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SAPNo.Text = rbPrograming1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SAPNo.Text = rbPrograming2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SAPNo.Text = rbPrograming3.Text;
        }
    }
}
