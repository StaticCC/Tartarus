namespace Tartarus
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.loginTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.loginPage = new System.Windows.Forms.TabPage();
            this.rememberLoginCheckbox = new MaterialSkin.Controls.MaterialCheckbox();
            this.passwordLabel = new MaterialSkin.Controls.MaterialLabel();
            this.usernameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.loginPasswordTextbox = new MaterialSkin.Controls.MaterialTextBox();
            this.loginUsernameTextbox = new MaterialSkin.Controls.MaterialTextBox();
            this.loginButton = new MaterialSkin.Controls.MaterialButton();
            this.registerPage = new System.Windows.Forms.TabPage();
            this.confirmPasswordRegLabel = new MaterialSkin.Controls.MaterialLabel();
            this.passwordConfirmTextbox = new MaterialSkin.Controls.MaterialTextBox();
            this.passwordRegisterLabel = new MaterialSkin.Controls.MaterialLabel();
            this.usernameRegisterLabel = new MaterialSkin.Controls.MaterialLabel();
            this.passwordRegisterTextBox = new MaterialSkin.Controls.MaterialTextBox();
            this.registerUsernameTextbox = new MaterialSkin.Controls.MaterialTextBox();
            this.registerButton = new MaterialSkin.Controls.MaterialButton();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.loginTabControl.SuspendLayout();
            this.loginPage.SuspendLayout();
            this.registerPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginTabControl
            // 
            this.loginTabControl.Controls.Add(this.loginPage);
            this.loginTabControl.Controls.Add(this.registerPage);
            this.loginTabControl.Depth = 0;
            this.loginTabControl.Location = new System.Drawing.Point(4, 86);
            this.loginTabControl.Margin = new System.Windows.Forms.Padding(2);
            this.loginTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.loginTabControl.Multiline = true;
            this.loginTabControl.Name = "loginTabControl";
            this.loginTabControl.SelectedIndex = 0;
            this.loginTabControl.Size = new System.Drawing.Size(361, 252);
            this.loginTabControl.TabIndex = 0;
            // 
            // loginPage
            // 
            this.loginPage.Controls.Add(this.rememberLoginCheckbox);
            this.loginPage.Controls.Add(this.passwordLabel);
            this.loginPage.Controls.Add(this.usernameLabel);
            this.loginPage.Controls.Add(this.loginPasswordTextbox);
            this.loginPage.Controls.Add(this.loginUsernameTextbox);
            this.loginPage.Controls.Add(this.loginButton);
            this.loginPage.Location = new System.Drawing.Point(4, 22);
            this.loginPage.Margin = new System.Windows.Forms.Padding(2);
            this.loginPage.Name = "loginPage";
            this.loginPage.Padding = new System.Windows.Forms.Padding(2);
            this.loginPage.Size = new System.Drawing.Size(353, 226);
            this.loginPage.TabIndex = 0;
            this.loginPage.Text = "Login";
            this.loginPage.UseVisualStyleBackColor = true;
            // 
            // rememberLoginCheckbox
            // 
            this.rememberLoginCheckbox.AutoSize = true;
            this.rememberLoginCheckbox.Depth = 0;
            this.rememberLoginCheckbox.Location = new System.Drawing.Point(5, 138);
            this.rememberLoginCheckbox.Margin = new System.Windows.Forms.Padding(0);
            this.rememberLoginCheckbox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rememberLoginCheckbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.rememberLoginCheckbox.Name = "rememberLoginCheckbox";
            this.rememberLoginCheckbox.ReadOnly = false;
            this.rememberLoginCheckbox.Ripple = true;
            this.rememberLoginCheckbox.Size = new System.Drawing.Size(137, 37);
            this.rememberLoginCheckbox.TabIndex = 5;
            this.rememberLoginCheckbox.Text = "Remember Me";
            this.rememberLoginCheckbox.UseVisualStyleBackColor = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Depth = 0;
            this.passwordLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.passwordLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.SubtleEmphasis;
            this.passwordLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.passwordLabel.Location = new System.Drawing.Point(6, 79);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 14);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Depth = 0;
            this.usernameLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.usernameLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.SubtleEmphasis;
            this.usernameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.usernameLabel.Location = new System.Drawing.Point(6, 21);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(53, 14);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username";
            // 
            // loginPasswordTextbox
            // 
            this.loginPasswordTextbox.AnimateReadOnly = false;
            this.loginPasswordTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginPasswordTextbox.Depth = 0;
            this.loginPasswordTextbox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.loginPasswordTextbox.LeadingIcon = null;
            this.loginPasswordTextbox.Location = new System.Drawing.Point(4, 93);
            this.loginPasswordTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.loginPasswordTextbox.MaxLength = 50;
            this.loginPasswordTextbox.MouseState = MaterialSkin.MouseState.OUT;
            this.loginPasswordTextbox.Multiline = false;
            this.loginPasswordTextbox.Name = "loginPasswordTextbox";
            this.loginPasswordTextbox.Password = true;
            this.loginPasswordTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.loginPasswordTextbox.Size = new System.Drawing.Size(353, 36);
            this.loginPasswordTextbox.TabIndex = 2;
            this.loginPasswordTextbox.Text = "";
            this.loginPasswordTextbox.TrailingIcon = null;
            this.loginPasswordTextbox.UseTallSize = false;
            this.loginPasswordTextbox.WordWrap = false;
            this.loginPasswordTextbox.TextChanged += new System.EventHandler(this.LoginPasswordTextbox_TextChanged);
            // 
            // loginUsernameTextbox
            // 
            this.loginUsernameTextbox.AnimateReadOnly = false;
            this.loginUsernameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginUsernameTextbox.Depth = 0;
            this.loginUsernameTextbox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.loginUsernameTextbox.LeadingIcon = null;
            this.loginUsernameTextbox.Location = new System.Drawing.Point(4, 36);
            this.loginUsernameTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.loginUsernameTextbox.MaxLength = 12;
            this.loginUsernameTextbox.MouseState = MaterialSkin.MouseState.OUT;
            this.loginUsernameTextbox.Multiline = false;
            this.loginUsernameTextbox.Name = "loginUsernameTextbox";
            this.loginUsernameTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.loginUsernameTextbox.Size = new System.Drawing.Size(353, 36);
            this.loginUsernameTextbox.TabIndex = 1;
            this.loginUsernameTextbox.Text = "";
            this.loginUsernameTextbox.TrailingIcon = null;
            this.loginUsernameTextbox.UseTallSize = false;
            this.loginUsernameTextbox.TextChanged += new System.EventHandler(this.loginUsernameTextbox_TextChanged);
            // 
            // loginButton
            // 
            this.loginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loginButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.loginButton.Depth = 0;
            this.loginButton.HighEmphasis = true;
            this.loginButton.Icon = null;
            this.loginButton.Location = new System.Drawing.Point(293, 138);
            this.loginButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.loginButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.loginButton.Name = "loginButton";
            this.loginButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.loginButton.Size = new System.Drawing.Size(64, 36);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.loginButton.UseAccentColor = false;
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // registerPage
            // 
            this.registerPage.Controls.Add(this.confirmPasswordRegLabel);
            this.registerPage.Controls.Add(this.passwordConfirmTextbox);
            this.registerPage.Controls.Add(this.passwordRegisterLabel);
            this.registerPage.Controls.Add(this.usernameRegisterLabel);
            this.registerPage.Controls.Add(this.passwordRegisterTextBox);
            this.registerPage.Controls.Add(this.registerUsernameTextbox);
            this.registerPage.Controls.Add(this.registerButton);
            this.registerPage.Location = new System.Drawing.Point(4, 22);
            this.registerPage.Margin = new System.Windows.Forms.Padding(2);
            this.registerPage.Name = "registerPage";
            this.registerPage.Padding = new System.Windows.Forms.Padding(2);
            this.registerPage.Size = new System.Drawing.Size(353, 226);
            this.registerPage.TabIndex = 1;
            this.registerPage.Text = "Register";
            this.registerPage.UseVisualStyleBackColor = true;
            // 
            // confirmPasswordRegLabel
            // 
            this.confirmPasswordRegLabel.AutoSize = true;
            this.confirmPasswordRegLabel.Depth = 0;
            this.confirmPasswordRegLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.confirmPasswordRegLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.SubtleEmphasis;
            this.confirmPasswordRegLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.confirmPasswordRegLabel.Location = new System.Drawing.Point(5, 132);
            this.confirmPasswordRegLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.confirmPasswordRegLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.confirmPasswordRegLabel.Name = "confirmPasswordRegLabel";
            this.confirmPasswordRegLabel.Size = new System.Drawing.Size(98, 14);
            this.confirmPasswordRegLabel.TabIndex = 13;
            this.confirmPasswordRegLabel.Text = "Confirm Password";
            // 
            // passwordConfirmTextbox
            // 
            this.passwordConfirmTextbox.AnimateReadOnly = false;
            this.passwordConfirmTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordConfirmTextbox.Depth = 0;
            this.passwordConfirmTextbox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.passwordConfirmTextbox.LeadingIcon = null;
            this.passwordConfirmTextbox.Location = new System.Drawing.Point(4, 147);
            this.passwordConfirmTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.passwordConfirmTextbox.MaxLength = 50;
            this.passwordConfirmTextbox.MouseState = MaterialSkin.MouseState.OUT;
            this.passwordConfirmTextbox.Multiline = false;
            this.passwordConfirmTextbox.Name = "passwordConfirmTextbox";
            this.passwordConfirmTextbox.Password = true;
            this.passwordConfirmTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.passwordConfirmTextbox.Size = new System.Drawing.Size(353, 36);
            this.passwordConfirmTextbox.TabIndex = 12;
            this.passwordConfirmTextbox.Text = "";
            this.passwordConfirmTextbox.TrailingIcon = null;
            this.passwordConfirmTextbox.UseTallSize = false;
            this.passwordConfirmTextbox.WordWrap = false;
            // 
            // passwordRegisterLabel
            // 
            this.passwordRegisterLabel.AutoSize = true;
            this.passwordRegisterLabel.Depth = 0;
            this.passwordRegisterLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.passwordRegisterLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.SubtleEmphasis;
            this.passwordRegisterLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.passwordRegisterLabel.Location = new System.Drawing.Point(6, 79);
            this.passwordRegisterLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordRegisterLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.passwordRegisterLabel.Name = "passwordRegisterLabel";
            this.passwordRegisterLabel.Size = new System.Drawing.Size(53, 14);
            this.passwordRegisterLabel.TabIndex = 10;
            this.passwordRegisterLabel.Text = "Password";
            // 
            // usernameRegisterLabel
            // 
            this.usernameRegisterLabel.AutoSize = true;
            this.usernameRegisterLabel.Depth = 0;
            this.usernameRegisterLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.usernameRegisterLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.SubtleEmphasis;
            this.usernameRegisterLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.usernameRegisterLabel.Location = new System.Drawing.Point(6, 21);
            this.usernameRegisterLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameRegisterLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.usernameRegisterLabel.Name = "usernameRegisterLabel";
            this.usernameRegisterLabel.Size = new System.Drawing.Size(53, 14);
            this.usernameRegisterLabel.TabIndex = 9;
            this.usernameRegisterLabel.Text = "Username";
            // 
            // passwordRegisterTextBox
            // 
            this.passwordRegisterTextBox.AnimateReadOnly = false;
            this.passwordRegisterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordRegisterTextBox.Depth = 0;
            this.passwordRegisterTextBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.passwordRegisterTextBox.LeadingIcon = null;
            this.passwordRegisterTextBox.Location = new System.Drawing.Point(4, 93);
            this.passwordRegisterTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.passwordRegisterTextBox.MaxLength = 50;
            this.passwordRegisterTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.passwordRegisterTextBox.Multiline = false;
            this.passwordRegisterTextBox.Name = "passwordRegisterTextBox";
            this.passwordRegisterTextBox.Password = true;
            this.passwordRegisterTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.passwordRegisterTextBox.Size = new System.Drawing.Size(353, 36);
            this.passwordRegisterTextBox.TabIndex = 8;
            this.passwordRegisterTextBox.Text = "";
            this.passwordRegisterTextBox.TrailingIcon = null;
            this.passwordRegisterTextBox.UseTallSize = false;
            this.passwordRegisterTextBox.WordWrap = false;
            // 
            // registerUsernameTextbox
            // 
            this.registerUsernameTextbox.AnimateReadOnly = false;
            this.registerUsernameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerUsernameTextbox.Depth = 0;
            this.registerUsernameTextbox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.registerUsernameTextbox.LeadingIcon = null;
            this.registerUsernameTextbox.Location = new System.Drawing.Point(4, 36);
            this.registerUsernameTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.registerUsernameTextbox.MaxLength = 12;
            this.registerUsernameTextbox.MouseState = MaterialSkin.MouseState.OUT;
            this.registerUsernameTextbox.Multiline = false;
            this.registerUsernameTextbox.Name = "registerUsernameTextbox";
            this.registerUsernameTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.registerUsernameTextbox.Size = new System.Drawing.Size(353, 36);
            this.registerUsernameTextbox.TabIndex = 7;
            this.registerUsernameTextbox.Text = "";
            this.registerUsernameTextbox.TrailingIcon = null;
            this.registerUsernameTextbox.UseTallSize = false;
            this.registerUsernameTextbox.TextChanged += new System.EventHandler(this.registerUsernameTextbox_TextChanged);
            // 
            // registerButton
            // 
            this.registerButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.registerButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.registerButton.Depth = 0;
            this.registerButton.HighEmphasis = true;
            this.registerButton.Icon = null;
            this.registerButton.Location = new System.Drawing.Point(268, 196);
            this.registerButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.registerButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.registerButton.Name = "registerButton";
            this.registerButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.registerButton.Size = new System.Drawing.Size(89, 36);
            this.registerButton.TabIndex = 6;
            this.registerButton.Text = "Register";
            this.registerButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.registerButton.UseAccentColor = false;
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.loginTabControl;
            this.materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTabSelector1.Location = new System.Drawing.Point(-2, 57);
            this.materialTabSelector1.Margin = new System.Windows.Forms.Padding(2);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(375, 39);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "loginPanelSelector";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 343);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.loginTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(370, 343);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(370, 288);
            this.Name = "Login";
            this.Padding = new System.Windows.Forms.Padding(2, 52, 2, 2);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tartarus";
            this.loginTabControl.ResumeLayout(false);
            this.loginPage.ResumeLayout(false);
            this.loginPage.PerformLayout();
            this.registerPage.ResumeLayout(false);
            this.registerPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl loginTabControl;
        private System.Windows.Forms.TabPage loginPage;
        private System.Windows.Forms.TabPage registerPage;
        private MaterialSkin.Controls.MaterialTextBox loginPasswordTextbox;
        private MaterialSkin.Controls.MaterialTextBox loginUsernameTextbox;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialLabel usernameLabel;
        private MaterialSkin.Controls.MaterialLabel passwordLabel;
        private MaterialSkin.Controls.MaterialCheckbox rememberLoginCheckbox;
        private MaterialSkin.Controls.MaterialButton loginButton;
        private MaterialSkin.Controls.MaterialLabel passwordRegisterLabel;
        private MaterialSkin.Controls.MaterialLabel usernameRegisterLabel;
        private MaterialSkin.Controls.MaterialTextBox passwordRegisterTextBox;
        private MaterialSkin.Controls.MaterialTextBox registerUsernameTextbox;
        private MaterialSkin.Controls.MaterialButton registerButton;
        private MaterialSkin.Controls.MaterialLabel confirmPasswordRegLabel;
        private MaterialSkin.Controls.MaterialTextBox passwordConfirmTextbox;
    }
}

