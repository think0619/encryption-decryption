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
    public partial class MainForm : Form
    {
        protected string selectPath = "C:\\";
        protected string descselectPath = "C:\\";

        string[] CipherModeArray = new[] { "CBC", "ECB", "CFB"  };
        string cipherFileType = ".wpl";

        private LongOperation _longOperation; 

        public MainForm()
        {
            InitializeComponent();
            _longOperation = new LongOperation(this, LongOperationSettings.Default);

            //给加密 解密模式下拉框赋值
            this.CipherModeComboBox.DataSource = CipherModeArray;
            this.CipherModeComboBox.SelectedIndex = 0;

            this.descCipherModeComboBox.DataSource = CipherModeArray;
            this.descCipherModeComboBox.SelectedIndex = 0; 
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            using (_longOperation.Start())
            {
                await Task.Run(() =>
                {
                    string filePath = this.encryFilePathTxt.Text.Trim();
                    string directoryPath = this.TargetDirectoryTxt.Text.Trim();

                    //检查是否选择了文件
                    if (filePath.Length == 0)
                    {
                        MessageBox.Show("Please select a file", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //检查选择文件是否存在
                        if (!File.Exists(filePath))
                        {
                            MessageBox.Show("Please select a valid file", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    //检查是否输入了输出目录
                    if (directoryPath.Length == 0)
                    {
                        MessageBox.Show("Please select target directory", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //检查输入的输出目录是否存在
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }
                    }
                    //检查是否输入了密码
                    if (this.passwordTxt.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Please input password", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //获取加密模式(因异步线程)
                    int CipherModeSelectedIndex = -1;
                    if (CipherModeComboBox.InvokeRequired)
                    {
                        CipherModeComboBox.Invoke(new MethodInvoker(delegate { CipherModeSelectedIndex = CipherModeComboBox.SelectedIndex; }));
                    } 
                    //选择值为-1则表示未选择
                    if (CipherModeSelectedIndex == -1) 
                    {
                        MessageBox.Show("Please select cipher mode", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //根据选择的加密模式设置RijndaelManaged算法所需的(enum枚举类型)
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
                    //获取选择的文件名（包含后缀名）
                    string sourcefileName = filePath.Remove(0, filePath.LastIndexOf("\\") + 1);
                    //获取选择的文件名（不包含后缀名）
                    string sourceFileNameWithoutType = sourcefileName.Remove(sourcefileName.LastIndexOf("."));
                    //获取选择的文件类型名（包含"." 比如".txt")
                    string sourceFileType = sourcefileName.Remove(0, sourcefileName.LastIndexOf(".")); 

                    string desFileName = String.Format(@"{0}\{1}", directoryPath, sourcefileName);
                    string tempFileName = sourceFileNameWithoutType;

                    //判断生成的加密文件是否存在，若存在则在文件名后加数字
                    bool needChangeFileName = true;
                    int fileIndex = 0;
                    while (needChangeFileName)
                    {
                        if (File.Exists(String.Format("{0}{1}", desFileName, cipherFileType)))
                        {
                            desFileName = String.Format("{0}_{1}{2}", tempFileName, ++fileIndex, sourceFileType);
                        }
                        else
                        {
                            needChangeFileName = false;
                        }
                    }
                    //此处已经设定好输出文件完整路径及名称
                    desFileName = String.Format("{0}{1}", desFileName, cipherFileType);

                    //实例化一个EncryptDecryptHelper对象
                    EncryptDecryptHelper edHelper = new EncryptDecryptHelper(filePath, desFileName, this.passwordTxt.Text.Trim(), cm);

                    //添加进程运行时间工具Stopwatch
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();//开始计时
                    // 加密运算。rm得到运算结果
                    ResultMsg rm = edHelper.DescryptEncryptHandler(DescrptAndEncrypt.Encrypt);
                    stopWatch.Stop();//运算结束
                    TimeSpan ts = stopWatch.Elapsed;//得到stopWatch所监测到的时间
                    StringBuilder sb = new StringBuilder();

                    //弹出消息框，告知用户结果
                    MessageBox.Show(rm.status ? "Succeed" : "Failure", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //以下是记录一些稍微详细的信息，记录在界面右侧Textbox中
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


       

        //加密选择文件选择框设置，并得到选择的文件路径
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
        //解密输出目录选择
        private void DesDireBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog path = new FolderBrowserDialog())
            {
                path.ShowDialog();
                this.TargetDirectoryTxt.Text = path.SelectedPath;
            }
        }

        //解密
        private async void button3_Click(object sender, EventArgs e)
        {
            using (_longOperation.Start())
            {
                await Task.Run(() =>
                {

                    string filePath = this.descryFilePathTxt.Text.Trim();
                    string directoryPath = this.descTargetDirectoryTxt.Text.Trim();

                    //判断是否选择了文件
                    if (filePath.Length == 0)
                    {
                        MessageBox.Show("Please select a file", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //判断选择文件是否存在
                        if (!File.Exists(filePath))
                        {
                            MessageBox.Show("Please select a valid file", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    //检查选择的输出目录
                    if (directoryPath.Length == 0)
                    {
                        MessageBox.Show("Please select target directory", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //不存在则创建
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }
                    }

                    //检查输入的密码
                    if (this.descpasswordTxt.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Please input password", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //检查选择的加密模式
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
                    //同解密，转换为RijndaelManaged所需要CipherMode的枚举类型
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
                    //得到被加密文件名（包含后缀
                    string sourcefileName = filePath.Remove(0, filePath.LastIndexOf("\\") + 1).Replace(cipherFileType, "");
                    //得到被加密文件的名称（不包含后缀
                    string sourceFileNameWithoutType = sourcefileName.Remove(sourcefileName.LastIndexOf("."));
                    //得到被加密文件的后缀（包含"."
                    string sourceFileType = sourcefileName.Remove(0, sourcefileName.LastIndexOf("."));

                    //设置输出文件完整路径，处理方式和加密运算一致，即存在则加数字
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
                    //此处得到解密后文件路径
                    desFileName = String.Format("{0}{1}", desFileName, sourceFileType);
                    //实例化EncryptDecryptHelper
                    EncryptDecryptHelper edHelper = new EncryptDecryptHelper(filePath, desFileName, this.descpasswordTxt.Text.Trim(),cm);
                    //添加Stopwatch监测运行时间
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();//stopWatch开始监测
                    //开始加密，并得到结果rm
                    ResultMsg rm = edHelper.DescryptEncryptHandler(DescrptAndEncrypt.Descrpt);
                    stopWatch.Stop();//stopWatch停止检测
                    TimeSpan ts = stopWatch.Elapsed;//得到stopWatch监测时间数据
                    StringBuilder sb = new StringBuilder();
                    //弹出消息框，告知运算结果
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

        //解密文件选择
        private void decSelectFileBtn_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = descselectPath;
                openFileDialog.Filter = "Encrypted files (*.wpl)|*.wpl";//代表只允许选择wpl文件
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
        //解密目录选择
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
