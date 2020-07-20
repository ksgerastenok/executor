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

            try
            {
                Result = Encoding.Default.GetString(this.rc2.CreateEncryptor().TransformFinalBlock(Encoding.Default.GetBytes(toEncrypt), 0, Encoding.Default.GetBytes(toEncrypt).Length));
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

            try
            {
                Result = Encoding.Default.GetString(this.rc2.CreateDecryptor().TransformFinalBlock(Encoding.Default.GetBytes(toDecrypt), 0, Encoding.Default.GetBytes(toDecrypt).Length));
            }
            catch (Exception ex)
            {
                Result = String.Empty;
            }

            return Result;
        }
    }
}
