using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;
using LoadingIndicator.WinForms;

namespace DescrptAndEncrypt
{
    public partial class Form1 : Form
    {
        protected string selectPath = "C:\\";
        protected string descselectPath = "C:\\";

        string[] CipherModeArray = new[] { "CBC", "ECB", "CFB"  };
        string cipherFileType = ".wpl";

        private LongOperation _longOperation;
        private object textBox1;

        public Form1()
        {
            InitializeComponent();
            _longOperation = new LongOperation(this, LongOperationSettings.Default);

            this.CipherModeComboBox.DataSource = CipherModeArray;
            //this.CipherModeComboBox.SelectedIndex = 0;

            this.descCipherModeComboBox.DataSource = CipherModeArray;
           // this.descCipherModeComboBox.SelectedIndex = 0; 
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            using (_longOperation.Start())
            {
                await Task.Run(() =>
                {
                    string filePath = this.encryFilePathTxt.Text.Trim();
                    string directoryPath = this.TargetDirectoryTxt.Text.Trim();

                    if (filePath.Length == 0)
                    {
                        MessageBox.Show("Please select a file", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (!File.Exists(filePath))
                        {
                            MessageBox.Show("Please select a valid file", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    if (directoryPath.Length == 0)
                    {
                        MessageBox.Show("Please select target directory", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }
                    }
                    if (this.passwordTxt.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Please input password", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int CipherModeSelectedIndex = -1;
                    if (CipherModeComboBox.InvokeRequired)
                    {
                        CipherModeComboBox.Invoke(new MethodInvoker(delegate { CipherModeSelectedIndex = CipherModeComboBox.SelectedIndex; }));
                    } 

                    if (CipherModeSelectedIndex == -1) 
                    {
                        MessageBox.Show("Please select cipher mode", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    CipherMode cm = CipherMode.CBC;
                    switch (CipherModeArray[CipherModeSelectedIndex])
                    {
                        case "CBC":
                            cm = CipherMode.CBC;
                            break;
                        case "ECB":
                            cm = CipherMode.ECB;
                            break;
                        case "CFB":
                            cm = CipherMode.CFB;
                            break;
                    }
                    //filePath
                    string sourcefileName = filePath.Remove(0, filePath.LastIndexOf("\\") + 1);
                    string desFileName = String.Format(@"{0}\{1}", directoryPath, sourcefileName);
                    string tempFileName = desFileName;
                    bool needChangeFileName = true;
                    int fileIndex = 0;
                    while (needChangeFileName)
                    {
                        if (File.Exists(String.Format("{0}{1}", desFileName, cipherFileType)))
                        {
                            desFileName = String.Format("{0}_{1}", tempFileName, ++fileIndex);
                        }
                        else
                        {
                            needChangeFileName = false;
                        }
                    }
                    desFileName = String.Format("{0}{1}", desFileName, cipherFileType);

                    EncryptDecryptHelper edHelper = new EncryptDecryptHelper(filePath, desFileName, this.passwordTxt.Text.Trim());

                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    ResultMsg rm = edHelper.encryptFile(cm);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    StringBuilder sb = new StringBuilder();
                    MessageBox.Show(rm.status ? "Succeed" : "Failure", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (rm.status)
                    {
                        sb.Append(String.Format("{4}{5}Source Filename:{0}\r\nEncrypted Filename:{1}\r\nCipherMode:{2}\r\nOperation time:{3}ms", sourcefileName, desFileName, CipherModeArray[CipherModeSelectedIndex], ts.TotalMilliseconds, this.ResultTxt.Text.Length == 0 ? "" : "\r\n\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    }
                    else
                    {
                        sb.Append(String.Format("{0}{1}\r\n{2}", this.ResultTxt.Text.Length == 0 ? "" : "\r\n\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), rm.msg));
                    }
                    if (ResultTxt.InvokeRequired)
                    {
                        ResultTxt.Invoke(new MethodInvoker(delegate { this.ResultTxt.Text += sb.ToString(); }));
                    }
                    
                });
            } 
        }


       


        private void selectFileBtn_Click(object sender, EventArgs e)
        { 
            string filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = selectPath;
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    encryFilePathTxt.Text = filePath;
                    selectPath = filePath.Remove(filePath.LastIndexOf("\\") + 1);
                }
            }
        }

        private void DesDireBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog path = new FolderBrowserDialog())
            {
                path.ShowDialog();
                this.TargetDirectoryTxt.Text = path.SelectedPath;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            using (_longOperation.Start())
            {
                await Task.Run(() =>
                {

                    string filePath = this.descryFilePathTxt.Text.Trim();
                    string directoryPath = this.descTargetDirectoryTxt.Text.Trim();

                    if (filePath.Length == 0)
                    {
                        MessageBox.Show("Please select a file", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (!File.Exists(filePath))
                        {
                            MessageBox.Show("Please select a valid file", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    if (directoryPath.Length == 0)
                    {
                        MessageBox.Show("Please select target directory", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }
                    }
                    if (this.descpasswordTxt.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Please input password", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int CipherModeSelectedIndex = -1;
                    if (CipherModeComboBox.InvokeRequired)
                    {
                        CipherModeComboBox.Invoke(new MethodInvoker(delegate { CipherModeSelectedIndex = CipherModeComboBox.SelectedIndex; }));
                    }


                    if (CipherModeSelectedIndex == -1)
                    {
                        MessageBox.Show("Please select cipher mode", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    CipherMode cm = CipherMode.CBC;
                    switch (CipherModeArray[CipherModeSelectedIndex])
                    {
                        case "CBC":
                            cm = CipherMode.CBC;
                            break;
                        case "ECB":
                            cm = CipherMode.ECB;
                            break;
                        case "CFB":
                            cm = CipherMode.CFB;
                            break;
                    }
                    //filePath
                    string sourcefileName = filePath.Remove(0, filePath.LastIndexOf("\\") + 1).Replace(cipherFileType, "");

                    var x = filePath.LastIndexOf(".");
                    string sourceFileNameWithoutType = sourcefileName.Remove(sourcefileName.LastIndexOf("."));
                    string sourceFileType = sourcefileName.Remove(0, sourcefileName.LastIndexOf("."));

                    string desFileName = String.Format(@"{0}\{1}", directoryPath, sourceFileNameWithoutType);
                    string tempFileName = desFileName;
                    bool needChangeFileName = true;
                    int fileIndex = 0;
                    while (needChangeFileName)
                    {
                        if (File.Exists(String.Format("{0}{1}", desFileName, sourceFileNameWithoutType)))
                        {
                            desFileName = String.Format("{0}_{1}", tempFileName, ++fileIndex);
                        }
                        else
                        {
                            needChangeFileName = false;
                        }
                    }
                    desFileName = String.Format("{0}{1}", desFileName, sourceFileType);

                    EncryptDecryptHelper edHelper = new EncryptDecryptHelper(filePath, desFileName, this.descpasswordTxt.Text.Trim());

                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    ResultMsg rm = edHelper.descryptFile(cm);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    StringBuilder sb = new StringBuilder();
                    MessageBox.Show(rm.status ? "Succeed" : "Failure", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (rm.status)
                    {
                        sb.Append(String.Format("{4}{5}\r\nSource Filename:{0}\r\nDescrypted Filename:{1}\r\nCipherMode:{2}\r\nOperation time:{3}ms", sourcefileName, desFileName, CipherModeArray[CipherModeSelectedIndex], ts.TotalMilliseconds, this.ResultTxt.Text.Length == 0 ? "" : "\r\n\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    }
                    else
                    {
                        sb.Append(String.Format("{0}{1}\r\n{2}", this.ResultTxt.Text.Length == 0 ? "" : "\r\n\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), rm.msg));
                    }
                    if (ResultTxt.InvokeRequired)
                    {
                        ResultTxt.Invoke(new MethodInvoker(delegate { this.ResultTxt.Text += sb.ToString(); }));
                    }
                });
            }
        }

        private void decSelectFileBtn_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = descselectPath;
                openFileDialog.Filter = "All files (*.wpl)|*.wpl";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    descryFilePathTxt.Text = filePath;
                    descselectPath = filePath.Remove(filePath.LastIndexOf("\\") + 1);
                }
            }
        }

        private void decSelectDirectoryBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog path = new FolderBrowserDialog())
            {
                path.ShowDialog();
                this.descTargetDirectoryTxt.Text = path.SelectedPath;
            }
        }
    }
}
