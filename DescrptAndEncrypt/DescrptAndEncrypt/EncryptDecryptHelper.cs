using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DescrptAndEncrypt
{
    class EncryptDecryptHelper
    {
        /// <summary>
        /// salt属性
        /// </summary>
        public byte[] salt
        {
            get
            {
                return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };// Must be at least eight bytes.  
            }
        }
        /// <summary>
        /// 向量
        /// </summary>
        public int iterations
        {
            get
            {
                return 1042;
            }
        }
        /// <summary> 
        //加密模式
        /// </summary>
        public CipherMode cipherMode { get; set; } 

        /// <summary>
        /// 源文件名，包含完整路劲(fullpath)
        /// </summary>
        public string sourceFilename { get; set; }

        /// <summary>
        /// 目标文件名，包含完整路劲(fullpath)
        /// </summary>
        public string destinationFilename { get; set; }

        /// <summary>
        /// 加密所需的key
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 实例化EncryptDecryptHelper
        /// </summary>
        /// <param name="_sourceFilename">源文件</param>
        /// <param name="_destinationFilename">目标为念</param>
        /// <param name="_password">key</param>
        /// <param name="_cipherMode">加密模式</param>
        public EncryptDecryptHelper(string _sourceFilename,string _destinationFilename,string _password, CipherMode _cipherMode)
        {
            this.sourceFilename = _sourceFilename;
            this.destinationFilename = _destinationFilename;
            this.password = _password;
            this.cipherMode = _cipherMode;
        }

        /// <summary>
        /// 加解密函数
        /// </summary>
        /// <param name="_deMode">加密还是解密</param>
        /// <returns>输出结果</returns>
        public ResultMsg DescryptEncryptHandler(DescrptAndEncrypt _deMode)
        {
            //设置默认返回结果
            ResultMsg rm = new ResultMsg()
            {
                status = true,
                msg = ""
            };
            //实例化RijndaelManaged
            RijndaelManaged aes = new RijndaelManaged();
            //设置BlockSize
            aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
            //设置KeySize
            aes.KeySize = aes.LegalKeySizes[0].MaxSize; 
            //生成Key
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            //设置加解密模式
            aes.Mode = cipherMode; 

            try
            {
                //输出文件流
                using (FileStream destination = new FileStream(destinationFilename, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                {
                    //根据参数_deMode 判断此操作是加密还是解密，
                    //下面意思是如果_deMode为解密，则aes.CreateDecryptor(aes.Key, aes.IV)，否则 aes.CreateEncryptor(aes.Key, aes.IV) 
                    //(_deMode == DescrptAndEncrypt.Descrpt) ? aes.CreateDecryptor(aes.Key, aes.IV) : aes.CreateEncryptor(aes.Key, aes.IV) 
                    using (CryptoStream cryptoStream = new CryptoStream(destination, (_deMode == DescrptAndEncrypt.Descrpt) ? aes.CreateDecryptor(aes.Key, aes.IV) : aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write))
                    {
                        //输入文件流
                        using (FileStream source = new FileStream(sourceFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            //写入
                            source.CopyTo(cryptoStream);
                            //得到运算结果
                            rm.msg = String.Format("{0} successfully", (_deMode == DescrptAndEncrypt.Descrpt) ? "Descpt" : "Encrpt");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.Delete(destinationFilename);
                rm.status = false;
                rm.msg = ex.Message;
            }
            return rm;
        } 
    }
}

 
