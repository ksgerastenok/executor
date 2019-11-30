using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace AutoRun
{
    public partial class CRYUtil : Object
    {
        private RC2CryptoServiceProvider rc2;
        private static CRYUtil instance;

        static CRYUtil()
        {
            CRYUtil.instance = new CRYUtil();

            return;
        }

        private CRYUtil()
        {
            this.rc2 = new RC2CryptoServiceProvider();

            this.rc2.Mode = CipherMode.ECB;
            this.rc2.Padding = PaddingMode.PKCS7;
            this.rc2.Key = Encoding.Default.GetBytes("super");

            return;
        }

        public static CRYUtil Instance
        {
            get
            {
                return CRYUtil.instance;
            }
        }

        public String Encrypt(String toEncrypt)
        {
            String Result;
            Byte[] buffer;

            buffer = Encoding.Default.GetBytes(toEncrypt);
            try
            {
                Result = Encoding.Default.GetString(this.rc2.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception ex)
            {
                Result = String.Empty;
            }

            return Result;
        }

        public String Decrypt(String toDecrypt)
        {
            String Result;
            Byte[] buffer;

            buffer = Encoding.Default.GetBytes(toDecrypt);
            try
            {
                Result = Encoding.Default.GetString(this.rc2.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception ex)
            {
                Result = String.Empty;
            }

            return Result;
        }
    }
}
