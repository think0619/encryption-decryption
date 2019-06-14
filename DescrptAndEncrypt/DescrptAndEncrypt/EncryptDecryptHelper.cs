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
        public byte[] salt
        {
            get
            {
                return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };// Must be at least eight bytes.  
            }
        }
        public int iterations
        {
            get
            {
                return 1042;
            }
        }  

        public string sourceFilename { get; set; }
        public string destinationFilename { get; set; }
        public string password { get; set; }

        public EncryptDecryptHelper(string _sourceFilename,string _destinationFilename,string _password)
        {
            this.sourceFilename = _sourceFilename;
            this.destinationFilename = _destinationFilename;
            this.password = _password;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherMode"></param>
        /// <returns></returns>
        public ResultMsg descryptFile(CipherMode cipherMode)
        {
            ResultMsg rm = new ResultMsg()
            {
                status = true,
                msg = ""
            };
            RijndaelManaged aes = new RijndaelManaged();
            aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
            aes.KeySize = aes.LegalKeySizes[0].MaxSize; 
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            aes.Mode = cipherMode;
            ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);

            try
            {
                using (FileStream destination = new FileStream(destinationFilename, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(destination, transform, CryptoStreamMode.Write))
                    {

                        using (FileStream source = new FileStream(sourceFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            source.CopyTo(cryptoStream);
                            rm.msg = "Decrypted successfully";
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


        public ResultMsg encryptFile(CipherMode cipherMode)
        {
            ResultMsg rm = new ResultMsg()
            {
                status = true,
                msg = ""
            };

            RijndaelManaged aes = new RijndaelManaged();
            aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
            aes.KeySize = aes.LegalKeySizes[0].MaxSize; 
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            aes.Mode = cipherMode;
            ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);

            using (FileStream destination = new FileStream(destinationFilename, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                using (CryptoStream cryptoStream = new CryptoStream(destination, transform, CryptoStreamMode.Write))
                {
                    try
                    {
                        using (FileStream source = new FileStream(sourceFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            source.CopyTo(cryptoStream);
                        }
                    }
                    catch (Exception ex)
                    {
                        rm.status = false;
                        rm.msg = ex.Message;
                    }
                }
            }
            return rm;
        } 
    }
}

 
