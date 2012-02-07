/******************************************************************************************
 * 
 * Copyright (c) 2012 WU WAI FAN DENNIS
 * 
 * 
 * Permission is hereby granted, free of charge, to any person obtaining 
 * a copy of this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation 
 * the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the Software 
 * is furnished to do so, subject to the following conditions:
 * 
 * 
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software.
 * 
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS 
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN 
 * AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
******************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Cryptography;

namespace CallFlowUpgrader
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = null;
            MemoryStream ms = new MemoryStream();

            if (File.Exists(args[0]))
            {
                TextReader reader = new StreamReader(args[0]);
                TextWriter mw = new StreamWriter(ms);

                string strIn = reader.ReadLine();

                while (strIn != null)
                {
                    mw.WriteLine(Encrypt(strIn, "bet$win$"));
                    strIn = reader.ReadLine();
                }

                mw.Flush();
                reader.Close();

                ms.Seek(0, SeekOrigin.Begin);
                TextReader memrdr = new StreamReader(ms);

                if (File.Exists("out.cfd"))
                {
                    fs = new FileStream("out.cfd", FileMode.Truncate);
                }
                else
                {
                    fs = new FileStream("out.cfd", FileMode.CreateNew);
                }
                TextWriter w = new StreamWriter(fs);
                string strOut = memrdr.ReadLine();
                while (strOut != null)
                {
                    w.WriteLine(strOut);
                    strOut = memrdr.ReadLine();
                }

                w.Flush();
                w.Close();

                memrdr.Close();
                memrdr = null;


            }
        }

        private static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            byte[] encryptedData = null;

            MemoryStream ms = new MemoryStream();

            Rijndael alg = Rijndael.Create();

            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();

            encryptedData = ms.ToArray();

            return encryptedData;
        }

        private static string Encrypt(string clearText, string Password)
        {
            byte[] encryptedData = null;

            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
            byte[] bytSalt = System.Text.Encoding.ASCII.GetBytes("salt_denniswu");

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, bytSalt);

            encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return Convert.ToBase64String(encryptedData);
        }

        private static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();

            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();

            byte[] decryptedData = ms.ToArray();

            return decryptedData;
        }

        private static string Decrypt(string cipherText, string Password)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] bytSalt = System.Text.Encoding.ASCII.GetBytes("salt_denniswu");

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, bytSalt);

            byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }
    }
}
