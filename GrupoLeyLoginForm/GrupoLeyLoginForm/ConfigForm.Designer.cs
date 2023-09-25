namespace GrupoLeyLoginForm
{
    partial class ConfigForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            txtUrl = new TextBox();
            lbl_login = new Label();
            pic_url = new PictureBox();
            lbl_database = new Label();
            pic_db = new PictureBox();
            btn_save = new Button();
            btn_cancel = new Button();
            lbl_browser = new Label();
            pic_browser = new PictureBox();
            cbBrowsers = new ComboBox();
            cbDatabase = new ComboBox();
            btn_reload_db = new Button();
            odooDeviceBindingSource = new BindingSource(components);
            odooDeviceBindingSource1 = new BindingSource(components);
            dgvCredentials = new DataGridView();
            credential = new DataGridViewTextBoxColumn();
            dgvLogins = new DataGridView();
            login = new DataGridViewTextBoxColumn();
            lblCredentials = new Label();
            label1 = new Label();
            cbNetwork = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pic_url).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_db).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_browser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)odooDeviceBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)odooDeviceBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCredentials).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLogins).BeginInit();
            SuspendLayout();
            // 
            // txtUrl
            // 
            txtUrl.AccessibleName = "Url";
            txtUrl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtUrl.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtUrl.BackColor = Color.White;
            txtUrl.BorderStyle = BorderStyle.None;
            txtUrl.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtUrl.Location = new Point(34, 39);
            txtUrl.Name = "txtUrl";
            txtUrl.PlaceholderText = "URL";
            txtUrl.Size = new Size(413, 23);
            txtUrl.TabIndex = 1;
            txtUrl.TextChanged += TxtUrl_TextChanged;
            txtUrl.Validating += TxtConfig_validating;
            // 
            // lbl_login
            // 
            lbl_login.AutoSize = true;
            lbl_login.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_login.Location = new Point(24, 6);
            lbl_login.Name = "lbl_login";
            lbl_login.Size = new Size(39, 23);
            lbl_login.TabIndex = 17;
            lbl_login.Text = "Url:";
            // 
            // pic_url
            // 
            pic_url.Image = (Image)resources.GetObject("pic_url.Image");
            pic_url.Location = new Point(24, 32);
            pic_url.Name = "pic_url";
            pic_url.Size = new Size(440, 38);
            pic_url.TabIndex = 18;
            pic_url.TabStop = false;
            // 
            // lbl_database
            // 
            lbl_database.AutoSize = true;
            lbl_database.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_database.Location = new Point(24, 75);
            lbl_database.Name = "lbl_database";
            lbl_database.Size = new Size(127, 23);
            lbl_database.TabIndex = 20;
            lbl_database.Text = "Base de Datos:";
            // 
            // pic_db
            // 
            pic_db.Image = Properties.Resources.large_input_background;
            pic_db.Location = new Point(24, 101);
            pic_db.Name = "pic_db";
            pic_db.Size = new Size(440, 38);
            pic_db.TabIndex = 21;
            pic_db.TabStop = false;
            // 
            // btn_save
            // 
            btn_save.BackColor = Color.FromArgb(53, 151, 156);
            btn_save.FlatStyle = FlatStyle.Flat;
            btn_save.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_save.ForeColor = Color.White;
            btn_save.Location = new Point(247, 544);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(217, 50);
            btn_save.TabIndex = 22;
            btn_save.Text = "Guardar";
            btn_save.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_save.UseVisualStyleBackColor = false;
            btn_save.Click += BtnSave_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.BackColor = Color.White;
            btn_cancel.CausesValidation = false;
            btn_cancel.FlatStyle = FlatStyle.Flat;
            btn_cancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_cancel.ForeColor = Color.LightCoral;
            btn_cancel.Location = new Point(24, 544);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(217, 50);
            btn_cancel.TabIndex = 21;
            btn_cancel.Text = "Cerrar";
            btn_cancel.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_cancel.UseVisualStyleBackColor = false;
            btn_cancel.Click += BtnCancel_Click;
            // 
            // lbl_browser
            // 
            lbl_browser.AutoSize = true;
            lbl_browser.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_browser.Location = new Point(24, 144);
            lbl_browser.Name = "lbl_browser";
            lbl_browser.Size = new Size(104, 23);
            lbl_browser.TabIndex = 3;
            lbl_browser.Text = "Navegador:";
            // 
            // pic_browser
            // 
            pic_browser.Image = Properties.Resources.large_input_background;
            pic_browser.Location = new Point(24, 170);
            pic_browser.Name = "pic_browser";
            pic_browser.Size = new Size(440, 38);
            pic_browser.TabIndex = 34;
            pic_browser.TabStop = false;
            // 
            // cbBrowsers
            // 
            cbBrowsers.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBrowsers.FlatStyle = FlatStyle.Flat;
            cbBrowsers.ForeColor = Color.Black;
            cbBrowsers.FormattingEnabled = true;
            cbBrowsers.Items.AddRange(new object[] { "Edge", "Chrome", "Firefox" });
            cbBrowsers.Location = new Point(34, 175);
            cbBrowsers.Name = "cbBrowsers";
            cbBrowsers.Size = new Size(200, 28);
            cbBrowsers.TabIndex = 4;
            // 
            // cbDatabase
            // 
            cbDatabase.FlatStyle = FlatStyle.Flat;
            cbDatabase.FormattingEnabled = true;
            cbDatabase.Location = new Point(120, 106);
            cbDatabase.Name = "cbDatabase";
            cbDatabase.Size = new Size(327, 28);
            cbDatabase.TabIndex = 3;
            // 
            // btn_reload_db
            // 
            btn_reload_db.BackColor = Color.FromArgb(162, 70, 137);
            btn_reload_db.CausesValidation = false;
            btn_reload_db.Cursor = Cursors.Hand;
            btn_reload_db.FlatStyle = FlatStyle.Flat;
            btn_reload_db.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            btn_reload_db.ForeColor = Color.White;
            btn_reload_db.Location = new Point(27, 105);
            btn_reload_db.Name = "btn_reload_db";
            btn_reload_db.Size = new Size(87, 29);
            btn_reload_db.TabIndex = 2;
            btn_reload_db.Text = "Recargar";
            btn_reload_db.UseVisualStyleBackColor = false;
            btn_reload_db.Click += BtnReloadDB_click;
            // 
            // odooDeviceBindingSource
            // 
            odooDeviceBindingSource.DataSource = typeof(OdooDevice);
            // 
            // odooDeviceBindingSource1
            // 
            odooDeviceBindingSource1.DataSource = typeof(OdooDevice);
            // 
            // dgvCredentials
            // 
            dgvCredentials.BackgroundColor = Color.White;
            dgvCredentials.BorderStyle = BorderStyle.None;
            dgvCredentials.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvCredentials.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCredentials.Columns.AddRange(new DataGridViewColumn[] { credential });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvCredentials.DefaultCellStyle = dataGridViewCellStyle1;
            dgvCredentials.Location = new Point(24, 397);
            dgvCredentials.Name = "dgvCredentials";
            dgvCredentials.RowHeadersWidth = 51;
            dgvCredentials.RowTemplate.Height = 29;
            dgvCredentials.Size = new Size(440, 125);
            dgvCredentials.TabIndex = 7;
            // 
            // credential
            // 
            credential.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            credential.HeaderText = "Credencial";
            credential.MinimumWidth = 200;
            credential.Name = "credential";
            // 
            // dgvLogins
            // 
            dgvLogins.BackgroundColor = Color.White;
            dgvLogins.BorderStyle = BorderStyle.None;
            dgvLogins.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLogins.Columns.AddRange(new DataGridViewColumn[] { login });
            dgvLogins.GridColor = Color.Silver;
            dgvLogins.Location = new Point(24, 239);
            dgvLogins.Name = "dgvLogins";
            dgvLogins.RowHeadersWidth = 51;
            dgvLogins.RowTemplate.Height = 29;
            dgvLogins.Size = new Size(440, 125);
            dgvLogins.TabIndex = 6;
            // 
            // login
            // 
            login.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            login.HeaderText = "Usuario";
            login.MinimumWidth = 200;
            login.Name = "login";
            // 
            // lblCredentials
            // 
            lblCredentials.AutoSize = true;
            lblCredentials.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblCredentials.Location = new Point(24, 369);
            lblCredentials.Name = "lblCredentials";
            lblCredentials.Size = new Size(115, 23);
            lblCredentials.TabIndex = 47;
            lblCredentials.Text = "Credenciales:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(24, 213);
            label1.Name = "label1";
            label1.Size = new Size(82, 23);
            label1.TabIndex = 48;
            label1.Text = "Usuarios:";
            // 
            // cbNetwork
            // 
            cbNetwork.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNetwork.FlatStyle = FlatStyle.Flat;
            cbNetwork.ForeColor = Color.Black;
            cbNetwork.FormattingEnabled = true;
            cbNetwork.Location = new Point(247, 175);
            cbNetwork.Name = "cbNetwork";
            cbNetwork.Size = new Size(200, 28);
            cbNetwork.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(247, 144);
            label2.Name = "label2";
            label2.Size = new Size(134, 23);
            label2.TabIndex = 52;
            label2.Text = "Interfaz de red:";
            // 
            // ConfigForm
            // 
            AcceptButton = btn_save;
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.White;
            CancelButton = btn_cancel;
            ClientSize = new Size(488, 603);
            Controls.Add(label2);
            Controls.Add(cbNetwork);
            Controls.Add(label1);
            Controls.Add(lblCredentials);
            Controls.Add(dgvCredentials);
            Controls.Add(btn_reload_db);
            Controls.Add(cbDatabase);
            Controls.Add(cbBrowsers);
            Controls.Add(lbl_browser);
            Controls.Add(pic_browser);
            Controls.Add(btn_cancel);
            Controls.Add(btn_save);
            Controls.Add(lbl_database);
            Controls.Add(pic_db);
            Controls.Add(txtUrl);
            Controls.Add(lbl_login);
            Controls.Add(pic_url);
            Controls.Add(dgvLogins);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfigForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Configuración";
            ((System.ComponentModel.ISupportInitialize)pic_url).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_db).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_browser).EndInit();
            ((System.ComponentModel.ISupportInitialize)odooDeviceBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)odooDeviceBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCredentials).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLogins).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUrl;
        private Label lbl_login;
        private PictureBox pic_url;
        private Label lbl_database;
        private PictureBox pic_db;
        private Button btn_save;
        private Button btn_cancel;
        private Label lbl_browser;
        private PictureBox pic_browser;
        private ComboBox cbBrowsers;
        private ComboBox cbDatabase;
        private Button btn_reload_db;
        private BindingSource odooDeviceBindingSource;
        private BindingSource odooDeviceBindingSource1;
        private DataGridView dgvCredentials;
        private DataGridViewTextBoxColumn credential;
        private DataGridView dgvLogins;
        private DataGridViewTextBoxColumn login;
        private Label lblCredentials;
        private Label label1;
        private ComboBox cbNetwork;
        private Label label2;
    }
}