using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
namespace Tartarus
{
    public partial class Main : MaterialForm
    {
        readonly Connection con = new Connection();
        int availableCredits = 0;
        string apps = "";
        readonly IniFile Settings = new IniFile("Settings.ini");
        int totalUsers = 0;
        int totalApps = 0;
        int totalKeys = 0;
        internal static readonly char[] chars =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        public Main()
        {
            InitializeComponent();
            this.Visible = false;
            this.FormBorderStyle = FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal800, Primary.Teal900, Primary.Teal300, Accent.Teal200, TextShade.WHITE);

            if (Settings.KeyExists("ThemeColor", "Theme"))
            {
                string theme = Settings.Read("ThemeColor", "Theme");

                if(theme == "Light")
                {
                    materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal800, Primary.Teal900, Primary.Teal300, Accent.Teal200, TextShade.WHITE);
                    ThemeBox.SelectedIndex = 1;
                }
            }

            string apiCredits = "";
            /*using (var client = new WebClient())
            {
                string url = string.Format("https://dynatyp.com/api/login.php?login={0}", loginUsernameTextbox.Text);
                apiCredits = client.DownloadString(url);
            }*/
            string[] apiCreditsResponse = apiCredits.Split('/');
            string appResponse = apiCreditsResponse[0];
            string[] appsList = appResponse.Split(',');


            if (appsList[0] != null)
            {
                foreach (string appName in appsList)
                {
                    totalApps += 1;
                    string appUsers = "";
                    /*using (var client = new WebClient())
                    {
                        string url = string.Format("https://dynatyp.com/api/login.php?login={0}", loginUsernameTextbox.Text);
                        appUsers = client.DownloadString(url);
                    }*/
                    totalUsers = Int32.Parse(appUsers);
                    //convert to webclient api request
                    string appKeys = "SELECT appkeys FROM "+  appName + " WHERE owner='" + UserData.name + "'";
                    string appKeyData = "";
                    /*if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            appKeyData = row["appkeys"].ToString();
                        }
                    }*/
                    
                    string[] keyArray = appKeyData.Split(',');
                    totalKeys += keyArray.Length;
                }
                AppKeysCount.Text = "" + totalKeys;
            }

            availableAppCredits.Text = "" + availableCredits;
            TotalUserCount.Text = "" + totalUsers;
            AppCount.Text = "" + totalApps;
            //Get apps
            if (apps[0] != null)
            {
                /*foreach (string appName in apps)
                {
                    appsList.Items.Add(new MaterialListBoxItem(appName));
                }*/
            }
            accountLabel.Text = "Account: " + UserData.name;
        }

        private void SeatCount_onValueChanged(object sender, int newValue)
        {
            if (seatCount.Value == 0)
            {
                seatCount.Value = 5;
            }
            if (seatCount.Value > 5)
                creditCost.Text = "Credit Cost: " + seatCount.Value / 5;
            else
            {
                creditCost.Text = "Credit Cost: 1";
            }
        }

        public void RefreshData()
        {
            con.Close();
            appsList.Clear();
            appUserListbox.Clear();
            //Get account data (credits and apps)
            con.Open();
            //Get credits
            string creditsAppSQL = "SELECT apps,credits FROM users WHERE username='" + UserData.name + "'";
            MySqlDataReader row;
            row = con.ExecuteReader(creditsAppSQL);
            string[] apps = new string[1];
            string rawApps = "";
            if (row.HasRows)
            {
                while (row.Read())
                {
                    rawApps = row["apps"].ToString();
                    availableCredits = Int32.Parse(row["credits"].ToString());
                }
            }
            if (rawApps != "")
                apps = rawApps.Split(',');
            row.Close();
            row.Dispose();
            if (apps[0] != null)
            {
                foreach (string appName in apps)
                {
                    string getAppDataSQL = "SELECT COUNT(*) FROM " + appName + "_users";
                    row = con.ExecuteReader(getAppDataSQL);
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            totalUsers += Int32.Parse(row[0].ToString());
                        }
                    }
                    row.Close();
                    row.Dispose();
                }
            }
            //userCount.Text = "" + totalUsers;
            availableAppCredits.Text = "" + availableCredits;

            //Get apps
            if (apps[0] != null)
            {
                foreach (string appName in apps)
                {
                    appsList.Items.Add(new MaterialListBoxItem(appName));
                }
            }
            ClearUserData();
            totalKeys = 0;
            totalUsers = 0;
            totalApps = 0;
            row = con.ExecuteReader(creditsAppSQL);
            if (row.HasRows)
            {
                while (row.Read())
                {
                    rawApps = row["apps"].ToString();
                    availableCredits = Int32.Parse(row["credits"].ToString());
                }
            }
            if (rawApps != "")
                apps = rawApps.Split(',');
            row.Close();
            row.Dispose();
            if (apps[0] != null)
            {
                foreach (string appName in apps)
                {
                    totalApps += 1;
                    string getAppDataSQL = "SELECT COUNT(*) FROM " + appName + "_users";
                    row = con.ExecuteReader(getAppDataSQL);
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            totalUsers += Int32.Parse(row[0].ToString());
                        }
                    }
                    row.Close();
                    row.Dispose();
                    string appKeys = "SELECT appkeys FROM " + appName + " WHERE owner='" + UserData.name + "'";
                    row = con.ExecuteReader(appKeys);
                    string appKeyData = "";
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            appKeyData = row["appkeys"].ToString();
                        }
                    }
                    row.Close();
                    row.Dispose();

                    string[] keyArray = appKeyData.Split(',');
                    totalKeys += keyArray.Length;
                }
                AppKeysCount.Text = "" + totalKeys;
            }

        }

        public void RefreshDataNoClose()
        {
            con.Close();
            appsList.Clear();
            appUserListbox.Clear();
            //Get account data (credits and apps)
            con.Open();
            //Get credits
            string creditsAppSQL = "SELECT apps,credits FROM users WHERE username='" + UserData.name + "'";
            MySqlDataReader row;
            row = con.ExecuteReader(creditsAppSQL);
            string[] apps = new string[1];
            string rawApps = "";
            if (row.HasRows)
            {
                while (row.Read())
                {
                    rawApps = row["apps"].ToString();
                    availableCredits = Int32.Parse(row["credits"].ToString());
                }
            }
            if (rawApps != "")
                apps = rawApps.Split(',');
            row.Close();
            row.Dispose();
            if (apps[0] != null)
            {
                foreach (string appName in apps)
                {
                    string getAppDataSQL = "SELECT COUNT(*) FROM " + appName + "_users";
                    row = con.ExecuteReader(getAppDataSQL);
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            totalUsers += Int32.Parse(row[0].ToString());
                        }
                    }
                    row.Close();
                    row.Dispose();
                }
            }
            //userCount.Text = "" + totalUsers;
            availableAppCredits.Text = "" + availableCredits;

            //Get apps
            if (apps[0] != null)
            {
                foreach (string appName in apps)
                {
                    appsList.Items.Add(new MaterialListBoxItem(appName));
                }
            }
            
        }

        public void ClearUserData()
        {
            appListName.Text = "";
            appSingleUserHWID.Text = "";
            appSingleUserIP.Text = "";
            appSingleUserKey.Text = "";
            BannedStatus.Text = "";
            registeredUserCount.Text = "";
            appUserTabControl.Visible = false;
            appUserTabSelector.TabIndex = 0;
            appUserTabSelector.Visible = false;
            AppKeyDisplay.Text = "";
        }

        private void CreateNewApp_Click(object sender, EventArgs e)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            MySqlDataReader row;
            bool exists = false;
            try
            {
                string appName = newAppNameTextbox.Text;
                if (!regexItem.IsMatch(appName))
                {
                    MessageBox.Show("Invalid Character(s)!");
                    Environment.Exit(0);
                }
                string sql = "SELECT COUNT(*) FROM " + appName;
                row = con.ExecuteReaderIgnore(sql);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        //appExists
                        MessageBox.Show("This application name has already been taken.");
                        exists = true;
                    }
                }
                row.Close();
            }
            catch
            {
                exists = false;
            }

            if (!exists)
            {
                con.Open();
                //Verify credits just in case of variable manipulation.
                string query = "SELECT credits,apps FROM users WHERE username='" + UserData.name + "'";
                row = con.ExecuteReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        apps = row["apps"].ToString();
                        availableCredits = Int32.Parse(row["credits"].ToString());
                    }
                }
                row.Close();
                int creditCostValue = seatCount.Value / 5;
                if (seatCount.Value > 5000 || seatCount.Value < 1)
                {
                    MessageBox.Show("Variable Manipulation Detected!");




                    //ban user
                    string banUser = "UPDATE users SET banned = '1' WHERE username = '" + UserData.name + "'";
                    con.ExecuteNonQuery(banUser);




                    Environment.Exit(1);
                }
                if (availableCredits < creditCostValue)
                {
                    MessageBox.Show("Insufficient credits! Purchase more on the dashboard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (newAppNameTextbox.Text != "")
                    {
                        try
                        {
                            //generate keys for the app
                            string generatedKeys = GenerateKeys(seatCount.Value);
                            //remove , from end of keys
                            generatedKeys = generatedKeys.TrimEnd(',');
                            string appName = newAppNameTextbox.Text;
                            if (!regexItem.IsMatch(appName))
                            {
                                MessageBox.Show("Invalid Character(s)!");
                                Environment.Exit(0);
                            }
                            //subtract credits for new app and update SQL record
                            availableCredits -= creditCostValue;
                            string updateCredits = "UPDATE users SET credits = '" + availableCredits + "' WHERE username = '" + UserData.name + "'";
                            con.ExecuteNonQuery(updateCredits);
                            //create app table for hub
                            string appTable = "CREATE TABLE " + appName + "(id int NOT NULL AUTO_INCREMENT,owner CHAR(255),appkeys LONGTEXT,seats INT(255), PRIMARY KEY (id))";
                            con.ExecuteNonQuery(appTable); //add keys here
                                                           //insert owner info
                            string insertAppTableData = "INSERT INTO " + appName + "(owner, seats, appkeys) VALUES('" + UserData.name + "','" + seatCount.Value + "','" + generatedKeys + "')";
                            con.ExecuteNonQuery(insertAppTableData);
                            //create users table for app
                            string appTableUsers = "CREATE TABLE " + appName + "_users(id int NOT NULL AUTO_INCREMENT,username CHAR(255),appkey CHAR(255),hwid TEXT(255),ip CHAR(255),banned INT(1) DEFAULT '0', PRIMARY KEY (id))";
                            con.ExecuteNonQuery(appTableUsers);
                            //create log table
                            string logTable = "CREATE TABLE " + appName + "_logs(date DATE,user CHAR(255),log CHAR(255))";
                            con.ExecuteNonQuery(logTable);
                            //insert log for app creation
                            DateTime myDateTime = DateTime.Now;
                            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");
                            string appLog = "INSERT INTO " + appName + "_logs(date,user,log) VALUES('" + sqlFormattedDate + "','" + UserData.name + "','CREATED APPLICATION!')";
                            con.ExecuteNonQuery(appLog);
                            //insert default user for app and generate admin key
                            string adminKey = GenerateKeys(1);
                            adminKey = adminKey.TrimEnd(',');
                            string appTableDefaultUser = "INSERT INTO " + appName + "_users(username,appkey,banned) VALUES('admin','" + adminKey + "','0')";
                            con.ExecuteNonQuery(appTableDefaultUser);
                            MessageBox.Show("App successfully created! Default username is admin\nAdmin Key: " + adminKey + "\nThe admin key has been copied to your clipboard.");
                            Clipboard.SetText(adminKey);
                            string newApps = "";
                            if (apps != "")
                            {
                                newApps = apps + "," + appName;
                            }
                            else
                            {
                                newApps = appName;
                            }
                            string updateApps = "UPDATE users SET apps = '" + newApps + "' WHERE username = '" + UserData.name + "'";
                            con.ExecuteNonQuery(updateApps);
                            RefreshData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to create new app ! \n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        availableAppCredits.Text = "" + availableCredits;
                    }
                }
            }
        }

        public string GenerateKeys(int amount)
        {
            string keys = "";
            for (int i = 0; i < amount; i++)
            {
                keys += GenerateKey();
            }
            return keys;
        }

        public string GenerateKey()
        {
            int size = 16; //length of key
            byte[] data = new byte[4 * size];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString() + ",";

        }

        private void UpSeat_Click(object sender, EventArgs e)
        {
            seatCount.Value += 1;
            if (seatCount.Value == 0)
            {
                seatCount.Value = 5;
            }
            if (seatCount.Value > 5)
                creditCost.Text = "Credit Cost: " + seatCount.Value / 5;
            else
            {
                creditCost.Text = "Credit Cost: 1";
            }
        }

        private void DownSeat_Click(object sender, EventArgs e)
        {
            seatCount.Value -= 1;
            if (seatCount.Value == 0)
            {
                seatCount.Value = 5;
            }
            if (seatCount.Value > 5)
                creditCost.Text = "Credit Cost: " + seatCount.Value / 5;
            else
            {
                creditCost.Text = "Credit Cost: 1";
            }
        }

        private void AppsList_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)
        {
            appUserListbox.Clear();
            //get appData
            if (appsList.SelectedItem.Text != "")
            {
                int totalSeats = 0;
                string getSeatCount = "SELECT seats FROM " + appsList.SelectedItem.Text;
                MySqlDataReader seat;
                seat = con.ExecuteReader(getSeatCount);
                if (seat.HasRows)
                {
                    while (seat.Read())
                    {
                        totalSeats = (Int32)seat["seats"];
                    }
                }
                seat.Close();
                seat.Dispose();

                string appUsersTableName = appsList.SelectedItem.Text + "_users";
                string getAppInfo = "SELECT username,appkey,hwid,ip FROM " + appUsersTableName;
                MySqlDataReader row;
                row = con.ExecuteReader(getAppInfo);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        appUserListbox.Items.Add(new MaterialListBoxItem(row["username"].ToString()));
                    }
                }
                row.Close();
                listedAppCard.Visible = true;
                appUserTabControl.Visible = true;
                appUserTabSelector.Visible = true;
                appUserTabControl.SendToBack();
                registeredUserCount.Text = appUserListbox.Items.Count.ToString() + "/" + totalSeats;
                registeredUserCount.Visible = true;
                string appTableName = appsList.SelectedItem.Text;
                appListName.Text = appTableName;
                listedAppCard.Visible = true;
            }
        }

        private void AppUserListbox_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)
        {

            string appUsersTableName = appsList.SelectedItem.Text + "_users";
            string getUserData = "SELECT username,appkey,hwid,ip,banned FROM " + appUsersTableName + " WHERE username= '" + appUserListbox.SelectedItem.Text + "'";
            int banned = 0;

            MySqlDataReader row;
            row = con.ExecuteReader(getUserData);
            if (row.HasRows)
            {
                while (row.Read())
                {
                    banned = Int32.Parse(row["banned"].ToString());
                    appSingleUserKey.Text = row["appkey"].ToString();
                    appSingleUserHWID.Text = row["hwid"].ToString();
                    appSingleUserIP.Text = row["ip"].ToString();
                }
            }
            row.Close();

            switch (banned)
            {
                case 0:
                    BannedStatus.Text = "False";
                    break;
                case 1:
                    BannedStatus.Text = "True";
                    break;
            }

            if (userDetails.Visible == false)
            {
                userDetails.Visible = true;
            }
        }

        private void GetActivationKeys_Click(object sender, EventArgs e)
        {
            if (appsList.SelectedItem != null)
            {
                con.Open();
                string appKeyString = "";
                string getAppKeys = "SELECT appkeys FROM " + appsList.SelectedItem.Text;
                MySqlDataReader row;
                row = con.ExecuteReader(getAppKeys);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        appKeyString = row["appkeys"].ToString();
                    }
                }
                row.Close();
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "keys.txt",
                      appKeyString);

                AppKeyDisplay.Text = appKeyString;
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");
                string appLog = "INSERT INTO " + appsList.SelectedItem.Text + "_logs(date,user,log) VALUES('" + sqlFormattedDate + "','" + UserData.name + "','GRABBED AUTHENTICATION KEYS!')";
                con.ExecuteNonQuery(appLog);
                MessageBox.Show("Your App Keys have been generated and placed in 'keys.txt' in the root directory.", "Your keys are generated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void creditCost_Click(object sender, EventArgs e)
        {

        }

        private void availableAppCredits_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Visible = true;
        }


        private void buyMoreCredits_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Auto-Buy has been disabled for further testing.\nPlease start a contract on HF, and your credits will be added shortly.\n\nThank you!", "Thank you for using Tartarus!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deleteApp_Click(object sender, EventArgs e)
        {
            if (appsList.SelectedItem != null)
            {
                string appName = appsList.SelectedItem.Text;
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this app!?\n\nYour credits will NOT be restored.", "Important", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //drop user and normal database and remove from users applist
                    con.Open();
                    //Verify credits just in case of variable manipulation.
                    string query = "SELECT apps FROM users WHERE username='" + UserData.name + "'";
                    string apps = "";
                    MySqlDataReader row;
                    row = con.ExecuteReader(query);
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            apps = row["apps"].ToString();
                        }
                    }
                    row.Close();

                    try
                    {
                        apps = apps.Replace(appName, "");

                        if (apps.Contains(",,"))
                        {
                            apps = apps.Replace(",,", ",");
                        }
                        if (apps.Contains(","))
                        {
                            if (apps.StartsWith(","))
                                apps = apps.TrimStart(',');
                            if (apps.EndsWith(","))
                                apps = apps.TrimEnd(',');
                        }

                        string updateApps = "UPDATE users SET apps = '" + apps + "' WHERE username = '" + UserData.name + "'";
                        con.ExecuteNonQuery(updateApps);

                        string dropMainTable = "DROP TABLE " + appName;
                        con.ExecuteNonQuery(dropMainTable);

                        string dropUserTable = "DROP TABLE " + appName + "_users";
                        con.ExecuteNonQuery(dropUserTable);

                        string dropLogsTable = "DROP TABLE " + appName + "_logs";
                        con.ExecuteNonQuery(dropLogsTable);

                        RefreshData();
                        ClearUserData();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to delete apps!\n\n" + ex);
                        Environment.Exit(0);
                    }

                }
            }
        }

        private void newAppCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BanUser_Click(object sender, EventArgs e)
        {
            con.Open();
            if (appsList.SelectedItem.Text != "")
            {
                if (appUserListbox.SelectedItem.Text != "")
                {
                    if (appUserListbox.SelectedItem.Text == "admin")
                    {
                        MessageBox.Show("You cannot ban the default admin account!");
                    }
                    else
                    {
                        string banUser = "UPDATE " + appsList.SelectedItem.Text + "_users SET banned = '1' WHERE username = '" + appUserListbox.SelectedItem.Text + "'";
                        con.ExecuteNonQuery(banUser);
                        MessageBox.Show("Banned " + appUserListbox.SelectedItem.Text + "!");

                        DateTime myDateTime = DateTime.Now;
                        string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");
                        string appLog = "INSERT INTO " + appsList.SelectedItem.Text + "_logs(date,user,log) VALUES('" + sqlFormattedDate + "','" + UserData.name + "','BANNED USER: " + appUserListbox.SelectedItem.Text + " FROM " + appsList.SelectedItem.Text +"!')";
                        con.ExecuteNonQuery(appLog);

                    }
                }
            }
        }

        private void newAppNameTextbox_TextChanged(object sender, EventArgs e)
        {
            string tString = newAppNameTextbox.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (char.IsNumber(tString[i]))
                {
                    MessageBox.Show("No numerical characters allowed!");
                    newAppNameTextbox.Text = "";
                    return;
                }

            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            ProcessStartInfo dInvite = new ProcessStartInfo("discord:///invite-proxy/AdRUSrQqfe");
            Process.Start(dInvite);
        }

        private void signOut_Click(object sender, EventArgs e)
        {
            UserData.name = "";
            UserData.password = "";
            UserData.plain = "";
            UserData.admin = false;
            try
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Settings.ini");
            }
            catch
            {

            }

            Environment.Exit(0);
        }

        private void HFPbox_MouseClick(object sender, MouseEventArgs e)
        {
            ProcessStartInfo hf = new ProcessStartInfo("https://hackforums.net/member.php?action=profile&uid=3479444");
            Process.Start(hf);
        }

        private void websitepbox_MouseClick(object sender, MouseEventArgs e)
        {
            ProcessStartInfo tart = new ProcessStartInfo("https://tartarus.gg");
            Process.Start(tart);
        }

        private void upSeat10_Click(object sender, EventArgs e)
        {
            seatCount.Value += 10;
            if (seatCount.Value <= 0)
            {
                seatCount.Value = 5;
            }
            if (seatCount.Value > 5)
                creditCost.Text = "Credit Cost: " + seatCount.Value / 5;
            else
            {
                creditCost.Text = "Credit Cost: 1";
            }
        }

        private void downSeat10_Click(object sender, EventArgs e)
        {
            seatCount.Value -= 10;
            if (seatCount.Value <= 0)
            {
                seatCount.Value = 5;
            }
            if (seatCount.Value > 5)
                creditCost.Text = "Credit Cost: " + seatCount.Value / 5;
            else
            {
                creditCost.Text = "Credit Cost: 1";
            }
        }

        private void ResetKeys_Click(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void UpSeatUpdate_Click(object sender, EventArgs e)
        {
            UpdateSeatsSlider.Value += 1;
            if (UpdateSeatsSlider.Value <= 0)
            {
                UpdateSeatsSlider.Value = 5;
            }
            if (UpdateSeatsSlider.Value > 5)
                UpdateSeatsLabel.Text = "Credit Cost: " + UpdateSeatsSlider.Value / 5;
            else
            {
                UpdateSeatsLabel.Text = "Credit Cost: 1";
            }
        }

        private void DownSeatUpdate_Click(object sender, EventArgs e)
        {
            UpdateSeatsSlider.Value -= 1;
            if (UpdateSeatsSlider.Value <= 0)
            {
                UpdateSeatsSlider.Value = 5;
            }
            if (UpdateSeatsSlider.Value > 5)
                UpdateSeatsLabel.Text = "Credit Cost: " + UpdateSeatsSlider.Value / 5;
            else
            {
                UpdateSeatsLabel.Text = "Credit Cost: 1";
            }
        }

        private void UpSeatTenUpdate_Click(object sender, EventArgs e)
        {
            UpdateSeatsSlider.Value += 10;
            if (UpdateSeatsSlider.Value <= 0)
            {
                UpdateSeatsSlider.Value = 5;
            }
            if (UpdateSeatsSlider.Value > 5)
                UpdateSeatsLabel.Text = "Credit Cost: " + UpdateSeatsSlider.Value / 5;
            else
            {
                UpdateSeatsLabel.Text = "Credit Cost: 1";
            }
        }

        private void DownSeatTenUpdate_Click(object sender, EventArgs e)
        {
            UpdateSeatsSlider.Value -= 10;
            if (UpdateSeatsSlider.Value <= 0)
            {
                UpdateSeatsSlider.Value = 5;
            }
            if (UpdateSeatsSlider.Value > 5)
                UpdateSeatsLabel.Text = "Credit Cost: " + UpdateSeatsSlider.Value / 5;
            else
            {
                UpdateSeatsLabel.Text = "Credit Cost: 1";
            }
        }

        private void UpdateSeats_Click(object sender, EventArgs e)
        {
            try
            {
                string appName = appsList.SelectedItem.Text;
                MaterialListBoxItem app = appsList.SelectedItem;
                con.Open();
                MySqlDataReader row;
                //Verify credits just in case of variable manipulation.
                string query = "SELECT credits,apps FROM users WHERE username='" + UserData.name + "'";
                row = con.ExecuteReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        apps = row["apps"].ToString();
                        availableCredits = Int32.Parse(row["credits"].ToString());
                    }
                }
                row.Close();
                int creditCostValue = UpdateSeatsSlider.Value / 5;
                availableCredits -= creditCostValue;

                string generatedKeys = GenerateKeys(UpdateSeatsSlider.Value);
                //remove , from end of keys
                generatedKeys = generatedKeys.TrimEnd(',');

                //set appkeys and update seats
                string clearAppKeys = "INSERT INTO " + appName + "(owner, seats, appkeys) VALUES('" + UserData.name + "','" + UpdateSeatsSlider.Value + "','" + generatedKeys + "')";
                con.ExecuteNonQuery(clearAppKeys);

                string updateCredits = "UPDATE users SET credits = '" + availableCredits + "' WHERE username = '" + UserData.name + "'";
                con.ExecuteNonQuery(updateCredits);

                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");
                string appLog = "INSERT INTO " + appsList.SelectedItem.Text + "_logs(date,user,log) VALUES('" + sqlFormattedDate + "','" + UserData.name + "','UPDATED USER SEATS!')";
                con.ExecuteNonQuery(appLog);

                RefreshData();
                ClearUserData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update user apps!\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string theme = ThemeBox.SelectedItem.ToString();
            switch (theme)
            {
                case "Dark":
                    Settings.Write("ThemeColor", "Dark", "Theme");
                    materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal800, Primary.Teal900, Primary.Teal300, Accent.Teal200, TextShade.WHITE);
                    break;
                case "Light":
                    Settings.Write("ThemeColor", "Light", "Theme");
                    materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal800, Primary.Teal900, Primary.Teal300, Accent.Teal200, TextShade.WHITE);
                    break;
            }
        }

        private void UpdateSeatsSlider_onValueChanged(object sender, int newValue)
        {
            if (UpdateSeatsSlider.Value == 0)
            {
                UpdateSeatsSlider.Value = 5;
            }

            if (UpdateSeatsSlider.Value > 5)
            {
                creditCost.Text = "Credit Cost: " + seatCount.Value / 5;
                UpdateSeatsLabel.Text = "Credit Cost: " + UpdateSeatsSlider.Value / 5;
            }
            else
            {
                creditCost.Text = "Credit Cost: 1";
                UpdateSeatsLabel.Text = "Credit Cost: 1";
            }
        }

        private void LogTextbox_GotFocus(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            HideCaret(this.Handle);
        }

        private void appUserTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (appUserTabControl.SelectedTab.Name == "Logs")
            {
                string log = "";
                con.Open();
                MySqlDataReader row;
                //Get log data
                string query = "SELECT date,user,log FROM " + appsList.SelectedItem.Text + "_logs";
                row = con.ExecuteReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        string date = row["date"].ToString();
                        log += date.Substring(0, 9);
                        log += " | ";
                        log += row["user"].ToString();
                        log += " | ";
                        log += row["log"].ToString();
                        log += "\n";
                    }
                }
                row.Close();
                LogTextbox.Text = log;
            }
        }

        private void LogTextbox_Enter(object sender, EventArgs e)
        {
            LogTextbox.Enabled = false;
            LogTextbox.Enabled = true;
        }

        private void materialCard12_Paint(object sender, PaintEventArgs e)
        {
                    }
    }

}