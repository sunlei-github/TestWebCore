using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace WebApi.Common.Utitly
{
    public class EncryptUtitly
    {
        /// <summary>
        /// MD5 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CreateMD5Encrypt(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                byte[] newBuffer = md5.ComputeHash(buffer);

                for (int i = 0; i < newBuffer.Length; i++)
                {
                    stringBuilder.Append(newBuffer[i].ToString("x2"));
                }
            }

            return stringBuilder.ToString();
        }
    }
}
