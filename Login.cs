using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using AutoUpdaterDotNET;
using System.Collections.Specialized;
using System.Net;
using System.IO;

namespace Tartarus
{
    public partial class Login : MaterialForm
    {
        Connection con = new Connection();
        IniFile Settings = new IniFile("Settings.ini");
        MyWebClient api = new MyWebClient();
        NameValueCollection data = new NameValueCollection();
        public Login()
        {
            InitializeComponent();
            AutoUpdater.Start("https://tartarus.gg/updates/update.xml");
            this.Shown += new System.EventHandler(this.Login_Shown);

            if (Settings.KeyExists("Username", "Login"))
            {
                UserData.name = Settings.Read("Username", "Login");
                UserData.plain = Settings.Read("Password", "Login");
                AutoLogin();
            }
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal800, Primary.Teal900, Primary.Teal300, Accent.Teal200, TextShade.WHITE);
        }

        private void Login_Shown(object sender, EventArgs e)
        {

        }

        public string GetMachineGuid()
        {
            string location = @"SOFTWARE\Microsoft\Cryptography";
            string name = "MachineGuid";

            using RegistryKey localMachineX64View =
              RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            using RegistryKey rk = localMachineX64View.OpenSubKey(location);
            if (rk == null)
                throw new KeyNotFoundException(
                  string.Format("Key Not Found: {0}", location));

            object machineGuid = rk.GetValue(name);
            if (machineGuid == null)
                throw new IndexOutOfRangeException(
                  string.Format("Index Not Found: {0}", name));

            return machineGuid.ToString();
        }

        private void LoginPasswordTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        public string GetIP()
        {
            string url = "http://checkip.dyndns.org";
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];
            return a4;
        }
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "TARTARUSNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "TARTARUSNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string ip = GetIP();
            //MessageBox.Show(ip);
            string hwid = GetMachineGuid();
            
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (passwordRegisterTextBox.Text == passwordConfirmTextbox.Text)
            {

                if (!regexItem.IsMatch(registerUsernameTextbox.Text) || !regexItem.IsMatch(passwordRegisterTextBox.Text) || !regexItem.IsMatch(passwordConfirmTextbox.Text))
                {
                    MessageBox.Show("Please remove all special characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //textboxes are not free of special characters
                }
                else
                {
                    if (registerUsernameTextbox.Text != "" && passwordRegisterTextBox.Text != "" && passwordConfirmTextbox.Text != "")
                    {
                        try
                        {
                            string savedPasswordHash = passwordRegisterTextBox.Text;
                            savedPasswordHash = Encrypt(savedPasswordHash);
                            using (var client = new WebClient())
                            {
                                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                                //https://dynatyp.com/api/createdash.php?username=Static&password=Pooks&hwid=hwid&ip=0.0.0.0&admin=0&salt=salt&banned=0
                                string url = string.Format("https://dynatyp.com/api/createdash.php?username={0}&password={1}&admin={2}&banned={3}&salt={4}&hwid={5}&ip={6}", registerUsernameTextbox.Text, savedPasswordHash, 0, 0, "", hwid, ip);
                                MessageBox.Show(url);
                                var result = client.DownloadString(url);
                                MessageBox.Show(result);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to register! Error: \n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Passwords don't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void AutoLogin()
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (!regexItem.IsMatch(UserData.name) || !regexItem.IsMatch(UserData.plain))
            {
                MessageBox.Show("Please remove all special characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //textboxes are not free of special characters
            }
            else
            {
                try
                {
                    //Default Response
                    //Static / 0 / 5 / 0 / ZpqI4tGdZDM LqTZ19RYvFu1ipmaHwTRtQ q7xnSwj4AnSzV / 07890f5e-2868-45e2-a1d2-e7472947b228 / 
                    //string query = "SELECT username,password,admin,banned FROM users WHERE username='" + UserData.name + "'";
                    string api_Login = "";
                    using (var client = new WebClient())
                    {
                        string url = string.Format("https://dynatyp.com/api/read.php?loginusername={0}", loginUsernameTextbox.Text);
                        api_Login = client.DownloadString(url);
                    }
                    string[] api_Response = api_Login.Split('/');
                    UserData.name = api_Response[0];
                    UserData.admin = false;
                    UserData.password = api_Response[1];
                    int banned = Int32.Parse(api_Response[4]);
                    int pass = 1;

                    string attemptPassword = loginPasswordTextbox.Text;
                    attemptPassword = Encrypt(attemptPassword);

                    string sqlPass = Decrypt(UserData.password);
                    if(attemptPassword != sqlPass)
                    {
                        pass = 0;
                    }
                    

                    if (banned == 1)
                    {
                        pass = 0;
                        MessageBox.Show("You have been banned. \n\nIf you feel like this was a false ban, please contact Static on Discord.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(1);
                    }

                    if (pass == 1)
                    {
                        //MessageBox.Show("We successfully logged in!");
                        Main main = new Main();
                        this.Hide();
                        main.ShowDialog();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("We failed to login (incorrect password)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ecx)
                {
                    MessageBox.Show("Failed to login ! " + ecx, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {

            try
            {
                //Default Response
                //Static / 0 / 5 / 0 / ZpqI4tGdZDM LqTZ19RYvFu1ipmaHwTRtQ q7xnSwj4AnSzV / 07890f5e-2868-45e2-a1d2-e7472947b228 / 73.218.115.92
                //string query = "SELECT username,password,admin,banned FROM users WHERE username='" + UserData.name + "'";
                string api_Login = "";
                using (var client = new WebClient())
                {
                    string url = string.Format("https://dynatyp.com/api/login.php?login={0}", loginUsernameTextbox.Text);
                    api_Login = client.DownloadString(url);
                }
                string[] api_Response = api_Login.Split('/');
                if(api_Response.Length == 0)
                {
                    MessageBox.Show("API Empty!");
                }
                //MessageBox.Show(api_Login);
                UserData.name = api_Response[0];
                UserData.admin = false;
                UserData.password = api_Response[1]; //invalid length!?!? why god why
                int banned = 0;
                int pass = 1;
                string sqlHwid = api_Response[5];
                string sqlIp = api_Response[6];
                string systemHwid = GetMachineGuid();
                string currentIp = GetIP();


                string attemptPassword = loginPasswordTextbox.Text;
                attemptPassword = Encrypt(attemptPassword);
                string sqlPass = UserData.password;
                if (attemptPassword != sqlPass)
                {
                    pass = 0;
                }


                if (sqlHwid != systemHwid || currentIp != sqlIp)
                {
                    pass = 0;
                }

                if (banned == 1)
                {
                    pass = 0;
                    MessageBox.Show("You have been banned. \n\nIf you feel like this was a false ban, please contact Static on Discord.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }

                if (pass == 1)
                {
                    MessageBox.Show("We successfully logged in!");
                    if (rememberLoginCheckbox.Checked)
                    {
                        Settings.Write("Username", UserData.name, "Login");
                        Settings.Write("Password", loginPasswordTextbox.Text, "Login");
                    }
                    Main main = new Main();
                    this.Hide();
                    main.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to login!\nHWID/IP/Password Mismatch.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ecx)
            {
                MessageBox.Show("Failed to login ! " + ecx, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (!regexItem.IsMatch(loginUsernameTextbox.Text) || !regexItem.IsMatch(loginPasswordTextbox.Text))
            {
                MessageBox.Show("Please remove all special characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //textboxes are not free of special characters
            } 
            else
            {
                if(loginUsernameTextbox.Text != "" && loginPasswordTextbox.Text != "")
                {
                    try
                    {
                        con.Open();
                        string query = "SELECT username,password,admin,hwid,ip,banned FROM users WHERE username='" + loginUsernameTextbox.Text +"'";
                        MySqlDataReader row;
                        row = con.ExecuteReader(query);
                        int banned = 0;
                        if (row.HasRows)
                        {
                            string sqlHwid = "";
                            string sqlIp = "";
                            while (row.Read())
                            {
                                banned = Int32.Parse(row["banned"].ToString());
                                sqlHwid = row["hwid"].ToString();
                                sqlIp = row["ip"].ToString();
                                UserData.name = row["username"].ToString();
                                UserData.admin = Convert.ToBoolean(row["admin"]);
                                UserData.password = row["password"].ToString();
                            }
                            byte[] hashBytes = Convert.FromBase64String(UserData.password);

                            byte[] salt = new byte[16];
                            Array.Copy(hashBytes, 0, salt, 0, 16);
                            var pbkdf2 = new Rfc2898DeriveBytes(loginPasswordTextbox.Text, salt, 10000);
                            byte[] hash = pbkdf2.GetBytes(20);
                            int pass = 1;
                            for (int i = 0; i < 20; i++)
                            {
                                if (hashBytes[i + 16] != hash[i])
                                    pass = 0;
                            }
                            string systemHwid = GetMachineGuid();
                            string currentIp = GetIP();
                            if (sqlHwid != systemHwid || currentIp != sqlIp)
                            {
                                pass = 0;
                            }

                            if(banned == 1)
                            {
                                pass = 0;
                                MessageBox.Show("You have been banned. \n\nIf you feel like this was a false ban, please contact Static on Discord.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Environment.Exit(1);
                            }

                            if(pass == 1)
                            {
                                //MessageBox.Show("We successfully logged in!");
                                if (rememberLoginCheckbox.Checked)
                                {
                                    Settings.Write("Username", UserData.name, "Login");
                                    Settings.Write("Password", loginPasswordTextbox.Text, "Login");
                                }
                                Main main = new Main();
                                this.Hide();
                                main.ShowDialog();
                                Close();
                            } else
                            {
                                MessageBox.Show("Failed to login!\nHWID/IP/Password Mismatch.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Data not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ecx)
                    {
                        MessageBox.Show("Failed to login ! " + ecx, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }*/
        }

        private void loginUsernameTextbox_TextChanged(object sender, EventArgs e)
        {
            string tString = loginUsernameTextbox.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (char.IsNumber(tString[i]))
                {
                    MessageBox.Show("No numerical characters allowed!");
                    loginUsernameTextbox.Text = "";
                    return;
                }

            }
        }

        private void registerUsernameTextbox_TextChanged(object sender, EventArgs e)
        {
            string tString = registerUsernameTextbox.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (char.IsNumber(tString[i]))
                {
                    MessageBox.Show("No numerical characters allowed!");
                    registerUsernameTextbox.Text = "";
                    return;
                }

            }
        }
    }
}
