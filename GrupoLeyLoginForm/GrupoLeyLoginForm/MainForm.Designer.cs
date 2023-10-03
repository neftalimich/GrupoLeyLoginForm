namespace GrupoLeyLoginForm
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnLogin = new Button();
            lbl_login = new Label();
            lbl_password = new Label();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            lbl_nip = new Label();
            company_logo = new PictureBox();
            pbUser = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            lblEmployeeName = new Label();
            lblMessage = new Label();
            txtCredential = new TextBox();
            lbl_credential = new Label();
            pictureBox4 = new PictureBox();
            txtNip = new TextBox();
            btn_config = new Button();
            btnViewPassword = new Button();
            btnViewNip = new Button();
            chKiosk = new CheckBox();
            lblIdentifier = new Label();
            lblVersion = new Label();
            txtIdentifier = new TextBox();
            ((System.ComponentModel.ISupportInitialize)company_logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(53, 151, 156);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Image = Properties.Resources.edge_logo;
            btnLogin.Location = new Point(24, 460);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(440, 50);
            btnLogin.TabIndex = 10;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btn_login_Click;
            // 
            // lbl_login
            // 
            lbl_login.AutoSize = true;
            lbl_login.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_login.ForeColor = SystemColors.WindowText;
            lbl_login.Location = new Point(24, 150);
            lbl_login.Name = "lbl_login";
            lbl_login.Size = new Size(89, 28);
            lbl_login.TabIndex = 1;
            lbl_login.Text = "Usuario:";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_password.ForeColor = SystemColors.WindowText;
            lbl_password.Location = new Point(24, 225);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(123, 28);
            lbl_password.TabIndex = 2;
            lbl_password.Text = "Contraseña:";
            // 
            // txtLogin
            // 
            txtLogin.AccessibleName = "Usuario";
            txtLogin.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtLogin.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtLogin.BackColor = Color.White;
            txtLogin.BorderStyle = BorderStyle.None;
            txtLogin.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtLogin.ForeColor = SystemColors.WindowText;
            txtLogin.Location = new Point(30, 187);
            txtLogin.Name = "txtLogin";
            txtLogin.PlaceholderText = "Correo electrónico";
            txtLogin.Size = new Size(405, 25);
            txtLogin.TabIndex = 1;
            txtLogin.Validating += txtLogin_Validating;
            // 
            // txtPassword
            // 
            txtPassword.AccessibleName = "Contraseña";
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.ForeColor = SystemColors.WindowText;
            txtPassword.Location = new Point(30, 262);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Contraseña";
            txtPassword.Size = new Size(405, 25);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.KeyDown += txt_KeyDown;
            txtPassword.Validating += txtLogin_Validating;
            // 
            // lbl_nip
            // 
            lbl_nip.AutoSize = true;
            lbl_nip.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_nip.ForeColor = SystemColors.WindowText;
            lbl_nip.Location = new Point(24, 375);
            lbl_nip.Name = "lbl_nip";
            lbl_nip.Size = new Size(51, 28);
            lbl_nip.TabIndex = 8;
            lbl_nip.Text = "NIP:";
            // 
            // company_logo
            // 
            company_logo.Image = Properties.Resources.odoo_logo;
            company_logo.Location = new Point(24, 0);
            company_logo.Margin = new Padding(0);
            company_logo.Name = "company_logo";
            company_logo.Size = new Size(437, 114);
            company_logo.SizeMode = PictureBoxSizeMode.Zoom;
            company_logo.TabIndex = 14;
            company_logo.TabStop = false;
            // 
            // pbUser
            // 
            pbUser.Image = Properties.Resources.large_input_background;
            pbUser.Location = new Point(24, 180);
            pbUser.Name = "pbUser";
            pbUser.Size = new Size(440, 38);
            pbUser.TabIndex = 15;
            pbUser.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.large_input_background;
            pictureBox2.Location = new Point(24, 255);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(440, 38);
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.large_input_background;
            pictureBox3.Location = new Point(24, 405);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(440, 38);
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.AutoSize = true;
            lblEmployeeName.BackColor = Color.White;
            lblEmployeeName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmployeeName.ForeColor = Color.MediumPurple;
            lblEmployeeName.Location = new Point(24, 536);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(77, 20);
            lblEmployeeName.TabIndex = 22;
            lblEmployeeName.Text = "Empleado";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.BackColor = Color.White;
            lblMessage.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblMessage.ForeColor = Color.SteelBlue;
            lblMessage.Location = new Point(24, 566);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(52, 20);
            lblMessage.TabIndex = 23;
            lblMessage.Text = "Sesión";
            // 
            // txtCredential
            // 
            txtCredential.AccessibleName = "Credencial";
            txtCredential.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCredential.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCredential.BackColor = Color.White;
            txtCredential.BorderStyle = BorderStyle.None;
            txtCredential.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtCredential.ForeColor = SystemColors.WindowText;
            txtCredential.Location = new Point(30, 337);
            txtCredential.Name = "txtCredential";
            txtCredential.PlaceholderText = "Credencial";
            txtCredential.Size = new Size(405, 25);
            txtCredential.TabIndex = 4;
            txtCredential.Validating += txtLogin_Validating;
            // 
            // lbl_credential
            // 
            lbl_credential.AutoSize = true;
            lbl_credential.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_credential.ForeColor = SystemColors.WindowText;
            lbl_credential.Location = new Point(24, 300);
            lbl_credential.Name = "lbl_credential";
            lbl_credential.Size = new Size(110, 28);
            lbl_credential.TabIndex = 25;
            lbl_credential.Text = "Empleado:";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.large_input_background;
            pictureBox4.Location = new Point(24, 330);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(440, 38);
            pictureBox4.TabIndex = 26;
            pictureBox4.TabStop = false;
            // 
            // txtNip
            // 
            txtNip.AccessibleName = "Nip";
            txtNip.BorderStyle = BorderStyle.None;
            txtNip.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtNip.Location = new Point(30, 412);
            txtNip.Name = "txtNip";
            txtNip.PlaceholderText = "NIP";
            txtNip.Size = new Size(405, 25);
            txtNip.TabIndex = 5;
            txtNip.UseSystemPasswordChar = true;
            txtNip.KeyDown += txt_KeyDown;
            txtNip.Validating += txtLogin_Validating;
            // 
            // btn_config
            // 
            btn_config.BackColor = Color.White;
            btn_config.BackgroundImage = Properties.Resources.cogwheel;
            btn_config.BackgroundImageLayout = ImageLayout.Zoom;
            btn_config.CausesValidation = false;
            btn_config.Cursor = Cursors.Hand;
            btn_config.FlatStyle = FlatStyle.Flat;
            btn_config.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_config.ForeColor = Color.White;
            btn_config.Location = new Point(436, 4);
            btn_config.Name = "btn_config";
            btn_config.Size = new Size(28, 28);
            btn_config.TabIndex = 20;
            btn_config.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_config.UseVisualStyleBackColor = false;
            btn_config.Click += btnConfig_Click;
            // 
            // btnViewPassword
            // 
            btnViewPassword.BackColor = Color.White;
            btnViewPassword.CausesValidation = false;
            btnViewPassword.FlatAppearance.BorderColor = Color.White;
            btnViewPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnViewPassword.ForeColor = Color.DimGray;
            btnViewPassword.Location = new Point(428, 258);
            btnViewPassword.Name = "btnViewPassword";
            btnViewPassword.Size = new Size(34, 32);
            btnViewPassword.TabIndex = 3;
            btnViewPassword.Text = "👁";
            btnViewPassword.UseVisualStyleBackColor = true;
            btnViewPassword.Click += btnViewPassword_Click;
            // 
            // btnViewNip
            // 
            btnViewNip.CausesValidation = false;
            btnViewNip.ForeColor = Color.DimGray;
            btnViewNip.Location = new Point(428, 408);
            btnViewNip.Name = "btnViewNip";
            btnViewNip.Size = new Size(34, 32);
            btnViewNip.TabIndex = 6;
            btnViewNip.Text = "👁";
            btnViewNip.UseVisualStyleBackColor = true;
            btnViewNip.Click += btnViewNip_Click;
            // 
            // chKiosk
            // 
            chKiosk.AutoSize = true;
            chKiosk.CausesValidation = false;
            chKiosk.Checked = true;
            chKiosk.CheckState = CheckState.Checked;
            chKiosk.ForeColor = Color.SlateBlue;
            chKiosk.Location = new Point(386, 117);
            chKiosk.Name = "chKiosk";
            chKiosk.Size = new Size(75, 24);
            chKiosk.TabIndex = 31;
            chKiosk.Text = "Kiosko";
            chKiosk.UseVisualStyleBackColor = true;
            // 
            // lblIdentifier
            // 
            lblIdentifier.AutoSize = true;
            lblIdentifier.BackColor = Color.White;
            lblIdentifier.CausesValidation = false;
            lblIdentifier.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblIdentifier.ForeColor = Color.SlateBlue;
            lblIdentifier.Location = new Point(24, 118);
            lblIdentifier.Name = "lblIdentifier";
            lblIdentifier.Size = new Size(44, 20);
            lblIdentifier.TabIndex = 30;
            lblIdentifier.Text = "WI-FI";
            lblIdentifier.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.BackColor = Color.White;
            lblVersion.Cursor = Cursors.Hand;
            lblVersion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblVersion.ForeColor = Color.DarkSlateBlue;
            lblVersion.Location = new Point(404, 574);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(57, 20);
            lblVersion.TabIndex = 32;
            lblVersion.Text = "v1.0.1.2";
            lblVersion.TextAlign = ContentAlignment.MiddleRight;
            lblVersion.Click += lblVersion_Click;
            // 
            // txtIdentifier
            // 
            txtIdentifier.BorderStyle = BorderStyle.None;
            txtIdentifier.CausesValidation = false;
            txtIdentifier.ForeColor = Color.SlateBlue;
            txtIdentifier.Location = new Point(182, 118);
            txtIdentifier.Name = "txtIdentifier";
            txtIdentifier.Size = new Size(150, 20);
            txtIdentifier.TabIndex = 33;
            txtIdentifier.Text = "00:1A:2B:3C:4D:5E";
            // 
            // MainForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(488, 603);
            Controls.Add(txtIdentifier);
            Controls.Add(lblVersion);
            Controls.Add(lblIdentifier);
            Controls.Add(chKiosk);
            Controls.Add(btnViewNip);
            Controls.Add(btnViewPassword);
            Controls.Add(btn_config);
            Controls.Add(txtNip);
            Controls.Add(txtCredential);
            Controls.Add(lbl_credential);
            Controls.Add(pictureBox4);
            Controls.Add(lblMessage);
            Controls.Add(lblEmployeeName);
            Controls.Add(lbl_nip);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(lbl_password);
            Controls.Add(lbl_login);
            Controls.Add(btnLogin);
            Controls.Add(pbUser);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(company_logo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de Sesión";
            ((System.ComponentModel.ISupportInitialize)company_logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label lbl_login;
        private Label lbl_password;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Label lbl_nip;
        private PictureBox pictureBox2;
        private PictureBox company_logo;
        private PictureBox pbUser;
        private PictureBox pictureBox3;
        private Label lblEmployeeName;
        private Label lblMessage;
        private TextBox txtCredential;
        private Label lbl_credential;
        private PictureBox pictureBox4;
        private TextBox txtNip;
        private Button btn_config;
        private Button btnViewPassword;
        private Button btnViewNip;
        private CheckBox chKiosk;
        private Label lblIdentifier;
        private Label lblVersion;
        private Label lblBrowserVersion;
        private TextBox txtIdentifier;
    }
}