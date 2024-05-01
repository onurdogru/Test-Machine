using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.IO;

namespace Vektor
{
    public class Programming
    {
        public FormMain MainFrm;
        public ProgAyarForm ProgAyarFrm;
        string[] batchFileFeedback = new string[4];

        int versions_number = 0;
        string[] versionsBarcodName = new string[10];
        int[] stepProgJob = new int[10];
        string vektorBatchFileAdress;

        private Thread vektorBatchThread = null;
        Process processBatchVektor = new Process();
        bool vektorProgramSonuc = false;

        /********************************************** Programing Init ************************************************/
        public void programingInit()
        {
            if (Prog_Ayarlar.Default.rbProgramlama == "1")
            {
                vektorBatchFileAdress = Prog_Ayarlar.Default.vektorProgramlamaBatch1;
            }
            else if (Prog_Ayarlar.Default.rbProgramlama == "2")
            {
                vektorBatchFileAdress = Prog_Ayarlar.Default.vektorProgramlamaBatch2;
            }

            this.versions_number = Convert.ToInt16(Prog_Ayarlar.Default.barcodeNum);
            this.stepProgJob[1] = Convert.ToInt16(Prog_Ayarlar.Default.step1Job);
            this.stepProgJob[2] = Convert.ToInt16(Prog_Ayarlar.Default.step2Job);
            this.stepProgJob[3] = Convert.ToInt16(Prog_Ayarlar.Default.step3Job);
            this.stepProgJob[4] = Convert.ToInt16(Prog_Ayarlar.Default.step4Job);
            this.stepProgJob[5] = Convert.ToInt16(Prog_Ayarlar.Default.step5Job);
            this.stepProgJob[6] = Convert.ToInt16(Prog_Ayarlar.Default.step6Job);
            this.stepProgJob[7] = Convert.ToInt16(Prog_Ayarlar.Default.step7Job);
            this.stepProgJob[8] = Convert.ToInt16(Prog_Ayarlar.Default.step8Job);
            this.stepProgJob[9] = Convert.ToInt16(Prog_Ayarlar.Default.step9Job);
            this.versionsBarcodName[1] = Prog_Ayarlar.Default.barcode1;
            this.versionsBarcodName[2] = Prog_Ayarlar.Default.barcode2;
            this.versionsBarcodName[3] = Prog_Ayarlar.Default.barcode3;
            this.versionsBarcodName[4] = Prog_Ayarlar.Default.barcode4;
            this.versionsBarcodName[5] = Prog_Ayarlar.Default.barcode5;
            this.versionsBarcodName[6] = Prog_Ayarlar.Default.barcode6;
            this.versionsBarcodName[7] = Prog_Ayarlar.Default.barcode7;
            this.versionsBarcodName[8] = Prog_Ayarlar.Default.barcode8;
            this.versionsBarcodName[9] = Prog_Ayarlar.Default.barcode9;

            batchFileFeedback[0] = Prog_Ayarlar.Default.successBatch;
            batchFileFeedback[1] = Prog_Ayarlar.Default.error1Batch;
            batchFileFeedback[2] = Prog_Ayarlar.Default.error2Batch;
            batchFileFeedback[3] = Prog_Ayarlar.Default.error3Batch;
        }
        /********************************************** Programing Start ************************************************/
        public void ProgrammingStart()
        {
            this.MainFrm.tbProgramingState.BackColor = Color.Ivory;
            this.MainFrm.tbProgramingState.Text = "";
            // Clean console
            programingConsoleClean();

            string product_no = string.Empty;

            // Show message box
            if (Prog_Ayarlar.Default.chBoxSerial1)
            {
                product_no = Prog_Ayarlar.Default.SAPNo;
                if(product_no == "2500001000")
                {
                    this.MainFrm.SAPNo = "2849540300";
                }
                else if (product_no == "2446407000")
                {
                    this.MainFrm.SAPNo = "2849540300";
                }
                else if (product_no == "1921403000")
                {
                    this.MainFrm.SAPNo = "1921403000";
                }

                // 2500001000  = 2849540300
                // 1921403000  = 1921403000
                // 2446407000  = 2849540300
                programingConsoleAppendLine("Vektör Kartı: " + product_no, Color.White);
                programingConsoleNewLine();
                vektorProgramProduct(product_no);
            }
        }

        /*Barkoddan ayıklanan ürün için .bat Seçilir*/
        private void vektorProgramProduct(string product_no)
        {
            String batchPath = String.Empty;

            for (int i = 1; i <= versions_number; i++)
            {
                if (versionsBarcodName[i] == product_no)
                {
                    if (stepProgJob[i] == 1)
                    {
                        batchPath = vektorBatchFileAdress + product_no + ".bat";    // C:\Users\serkan.baki\Desktop\MIND-BATCH-FILES\
                        programingConsoleAppendLine(batchPath, Color.Orange);
                        vektorRunBatch(batchPath, this.MainFrm.projectNameTxt.Text);
                    }
                    break;
                }
            }
        }

        /*Seçilen .bat Çalıştırılır- Kontrol Edilir ve Kapatılır*/
        private void vektorRunBatch(string batch_path, string batch_name)
        {
            vektorBatchThread = new Thread(vektorBatchThreadFunction);
            vektorBatchThread.Start(batch_path);
        }

        private void vektorBatchThreadFunction(object batch_path)
        {
            processBatchVektor.StartInfo.UseShellExecute = false;
            processBatchVektor.StartInfo.RedirectStandardOutput = true;
            processBatchVektor.StartInfo.CreateNoWindow = true;
            processBatchVektor.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processBatchVektor.StartInfo.FileName = (string)batch_path;
            //processBatch.StartInfo.Arguments = string.Format("");
            processBatchVektor.Start();

            StreamReader strmReader = processBatchVektor.StandardOutput;
            string batchTempRow = string.Empty;
            // get all lines of batch
            while ((batchTempRow = strmReader.ReadLine()) != null)
            {
                // Write batch operation to the console
                programingConsoleAppendLine(batchTempRow, Color.White);

                // check programming is successful.
                // if succesfully finished.
                if (Prog_Ayarlar.Default.chBoxSuccess && ((batchTempRow.IndexOf("pause", StringComparison.OrdinalIgnoreCase) >= 0) || (batchTempRow.IndexOf(batchFileFeedback[0], StringComparison.OrdinalIgnoreCase) >= 0)))  // color ae
                {
                    programingConsoleNewLine();
                    programingConsoleAppendLine("Vektör Kartı:" + " programing İşlemi Başarıyla Tamamlanmıştır!", Color.Green);
                    vektorProgramSonuc = true;
                    break;
                }
                else if (Prog_Ayarlar.Default.chBoxError1 && ((batchTempRow.IndexOf("pause", StringComparison.OrdinalIgnoreCase) >= 0) || (batchTempRow.IndexOf(batchFileFeedback[1], StringComparison.OrdinalIgnoreCase) >= 0))) //Could not start CPU core.
                {
                    programingConsoleNewLine();
                    programingConsoleAppendLine("Vektör Kartı:" + " programing İşlemi Başarısız1.", Color.Red);  // programing Soketi Düzgün Takılı Değil!
                    vektorProgramSonuc = false;
                    break;
                }
                else if (Prog_Ayarlar.Default.chBoxError2 && ((batchTempRow.IndexOf("pause", StringComparison.OrdinalIgnoreCase) >= 0) || (batchTempRow.IndexOf(batchFileFeedback[2], StringComparison.OrdinalIgnoreCase) >= 0)))  // Cannot connect to target.
                {
                    programingConsoleNewLine();
                    programingConsoleAppendLine("Vektör Kartı:" + " programing İşlemi Başarısız2.", Color.Red); // programing Soketi Takılı Değil!
                    vektorProgramSonuc = false;
                    break;
                }
                else if (Prog_Ayarlar.Default.chBoxError3 && ((batchTempRow.IndexOf("pause", StringComparison.OrdinalIgnoreCase) >= 0) || (batchTempRow.IndexOf(batchFileFeedback[3], StringComparison.OrdinalIgnoreCase) >= 0))) //FAILED
                {
                    programingConsoleNewLine();
                    programingConsoleAppendLine("Vektör Kartı" + " programing İşlemi Başarısız3.", Color.Red);  //  USB Takılı Değil!
                    vektorProgramSonuc = false;
                    break;
                }
            }

            // if batch didn't closed kill it.
            if (!processBatchVektor.HasExited)
            {
                processBatchVektor.Kill();
            }
            ProgramSonucFunction();
        }

        public void ProgramSonucFunction()
        {
            if (vektorProgramSonuc)
            {
                this.MainFrm.tbProgramingState.Invoke(new Action(delegate ()
                {
                    this.MainFrm.tbProgramingState.BackColor = Color.Green;
                    this.MainFrm.tbProgramingState.Text = "PROGRAMLAMA BAŞARILI";
                    this.MainFrm.programingSuccess();
                }));
            }
            else
            {
                this.MainFrm.tbProgramingState.Invoke(new Action(delegate ()
                {
                    this.MainFrm.tbProgramingState.BackColor = Color.Red;
                    this.MainFrm.tbProgramingState.Text = "PROGRAMLAMA BAŞARISIZ";
                    this.MainFrm.programingError();
                }));
            }
            this.MainFrm.programingRestart();
        }

        public void programingThreadStop()   //???
        {
            if (vektorBatchThread != null)
            {
                vektorBatchThread.Abort();
                vektorProgramSonuc = false;
            }
        }

        /********************************************** Programing Konsol ************************************************/
        /*Kullanıcı Arayüzüne Temizlenir*/
        public void programingConsoleClean()
        {
            if (this.MainFrm.rtbConsolePrograming.InvokeRequired)
            {
                this.MainFrm.rtbConsolePrograming.Invoke(new Action(delegate ()
                {
                    this.MainFrm.rtbConsolePrograming.Text = "";
                    this.MainFrm.rtbConsolePrograming.Select(this.MainFrm.rtbConsolePrograming.TextLength, 0);
                    this.MainFrm.rtbConsolePrograming.SelectionColor = Color.White;
                }));
            }
            else
            {
                this.MainFrm.rtbConsolePrograming.Text = "";
                this.MainFrm.rtbConsolePrograming.Select(this.MainFrm.rtbConsolePrograming.TextLength, 0);
                this.MainFrm.rtbConsolePrograming.SelectionColor = Color.White;
            }
        }

        /*Kullanıcı Arayüzüne Yazı Yazılır*/
        public void programingConsoleAppendLine(string text, Color color)
        {
            if (this.MainFrm.rtbConsolePrograming.InvokeRequired)
            {
                this.MainFrm.rtbConsolePrograming.Invoke(new Action(delegate ()
                {
                    this.MainFrm.rtbConsolePrograming.Select(this.MainFrm.rtbConsolePrograming.TextLength, 0);
                    this.MainFrm.rtbConsolePrograming.SelectionColor = color;
                    this.MainFrm.rtbConsolePrograming.AppendText(text + Environment.NewLine);
                    this.MainFrm.rtbConsolePrograming.Select(this.MainFrm.rtbConsolePrograming.TextLength, 0);
                    this.MainFrm.rtbConsolePrograming.SelectionColor = Color.White;
                }));
            }
            else
            {
                this.MainFrm.rtbConsolePrograming.Select(this.MainFrm.rtbConsolePrograming.TextLength, 0);
                this.MainFrm.rtbConsolePrograming.SelectionColor = color;
                this.MainFrm.rtbConsolePrograming.AppendText(text + Environment.NewLine);
                this.MainFrm.rtbConsolePrograming.Select(this.MainFrm.rtbConsolePrograming.TextLength, 0);
                this.MainFrm.rtbConsolePrograming.SelectionColor = Color.White;
            }
        }

        /*Kullanıcı Arayüzünde Bir Satır Boşluk Bırakılır*/
        public void programingConsoleNewLine()
        {
            if (this.MainFrm.rtbConsolePrograming.InvokeRequired)
            {
                this.MainFrm.rtbConsolePrograming.Invoke(new Action(delegate () { this.MainFrm.rtbConsolePrograming.AppendText(Environment.NewLine); }));
            }
            else
            {
                this.MainFrm.rtbConsolePrograming.AppendText(Environment.NewLine);
            }
        }

    }
}
