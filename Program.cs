using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tartarus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            byte[] key = { 0x02, 0x03, 0x01, 0x03, 0x03, 0x07, 0x07, 0x08, 0x09, 0x09, 0x11, 0x11, 0x16, 0x17, 0x19, 0x16 };

            //Get ConnectionData
            try
            {
                // create file stream
                using FileStream myStream = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "Tartarus.dll", FileMode.Open);

                // create instance
                using Aes aes = Aes.Create();

                // reads IV value
                byte[] iv = new byte[aes.IV.Length];
                myStream.Read(iv, 0, iv.Length);

                // decrypt data
                using CryptoStream cryptStream = new CryptoStream(
                   myStream,
                   aes.CreateDecryptor(key, iv),
                   CryptoStreamMode.Read);

                // read stream
                using StreamReader sReader = new StreamReader(cryptStream);

                string rawConnectionData = sReader.ReadLine();

                string[] connectionDataArray = rawConnectionData.Split();
                ServerData.host = connectionDataArray[0];
                ServerData.sqlDb = connectionDataArray[1];
                ServerData.sqlUser = connectionDataArray[2];
                ServerData.sqlPass = connectionDataArray[3];
            }
            catch
            {
                // error
                MessageBox.Show("Missing core app depend(s). Are all neccessary files in this directory?", "Severe Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                throw;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
