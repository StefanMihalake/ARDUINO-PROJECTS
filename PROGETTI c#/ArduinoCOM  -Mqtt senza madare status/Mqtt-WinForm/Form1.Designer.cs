
namespace Mqtt_WinForm
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabPages = new ReaLTaiizor.Controls.AirTabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.connectionStatusLabel = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.connectButton = new ReaLTaiizor.Controls.AirButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bigLabel4 = new ReaLTaiizor.Controls.BigLabel();
            this.deviceLabel = new ReaLTaiizor.Controls.BigLabel();
            this.slaveLabel = new ReaLTaiizor.Controls.BigLabel();
            this.dimLabel = new ReaLTaiizor.Controls.BigLabel();
            this.ledOnButton = new ReaLTaiizor.Controls.AirButton();
            this.ledOffButton = new ReaLTaiizor.Controls.AirButton();
            this.SlaveId = new ReaLTaiizor.Controls.CrownNumeric();
            this.dimNum = new ReaLTaiizor.Controls.CrownNumeric();
            this.deviceId = new ReaLTaiizor.Controls.CrownNumeric();
            this.adminpage = new System.Windows.Forms.TabPage();
            this.passLabel = new ReaLTaiizor.Controls.BigLabel();
            this.passErrorLabel = new ReaLTaiizor.Controls.BigLabel();
            this.loginButton = new ReaLTaiizor.Controls.AirButton();
            this.passwordTextbox = new ReaLTaiizor.Controls.AloneTextBox();
            this.setMaxNumeric = new ReaLTaiizor.Controls.CrownNumeric();
            this.setMinNumeric = new ReaLTaiizor.Controls.CrownNumeric();
            this.logOutButton = new ReaLTaiizor.Controls.AirButton();
            this.setMaxButton = new ReaLTaiizor.Controls.AirButton();
            this.setMinButton = new ReaLTaiizor.Controls.AirButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.bigLabel3 = new ReaLTaiizor.Controls.BigLabel();
            this.pixelBrightnessNum = new ReaLTaiizor.Controls.CrownNumeric();
            this.pixelOffButton = new ReaLTaiizor.Controls.AirButton();
            this.pixelOnButton = new ReaLTaiizor.Controls.AirButton();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.colorPicker = new ReaLTaiizor.Controls.ParrotColorPicker();
            this.tabPages.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlaveId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceId)).BeginInit();
            this.adminpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setMaxNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setMinNumeric)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBrightnessNum)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPages
            // 
            this.tabPages.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabPages.Controls.Add(this.tabPage1);
            this.tabPages.Controls.Add(this.tabPage2);
            this.tabPages.Controls.Add(this.adminpage);
            this.tabPages.Controls.Add(this.tabPage3);
            this.tabPages.ItemSize = new System.Drawing.Size(30, 115);
            this.tabPages.Location = new System.Drawing.Point(12, 12);
            this.tabPages.Multiline = true;
            this.tabPages.Name = "tabPages";
            this.tabPages.SelectedIndex = 0;
            this.tabPages.ShowOuterBorders = false;
            this.tabPages.Size = new System.Drawing.Size(806, 415);
            this.tabPages.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabPages.SquareColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(87)))), ((int)(((byte)(100)))));
            this.tabPages.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.connectionStatusLabel);
            this.tabPage1.Controls.Add(this.bigLabel2);
            this.tabPage1.Controls.Add(this.bigLabel1);
            this.tabPage1.Controls.Add(this.connectButton);
            this.tabPage1.Location = new System.Drawing.Point(119, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(683, 407);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.connectionStatusLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectionStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.connectionStatusLabel.Location = new System.Drawing.Point(248, 315);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(165, 28);
            this.connectionStatusLabel.TabIndex = 3;
            this.connectionStatusLabel.Text = "connection status";
            // 
            // bigLabel2
            // 
            this.bigLabel2.AutoSize = true;
            this.bigLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel2.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel2.Location = new System.Drawing.Point(275, 79);
            this.bigLabel2.Name = "bigLabel2";
            this.bigLabel2.Size = new System.Drawing.Size(111, 46);
            this.bigLabel2.TabIndex = 2;
            this.bigLabel2.Text = "TOPIC";
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel1.Location = new System.Drawing.Point(30, 138);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(607, 37);
            this.bigLabel1.TabIndex = 1;
            this.bigLabel1.Text = "Mosaico/UffProgrammazione/PrimePc11/Arduino";
            // 
            // connectButton
            // 
            this.connectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connectButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.connectButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectButton.Image = null;
            this.connectButton.Location = new System.Drawing.Point(248, 236);
            this.connectButton.Name = "connectButton";
            this.connectButton.NoRounding = false;
            this.connectButton.Size = new System.Drawing.Size(165, 67);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "CONNECT";
            this.connectButton.Transparent = false;
            this.connectButton.Click += new System.EventHandler(this.Connect_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.bigLabel4);
            this.tabPage2.Controls.Add(this.deviceLabel);
            this.tabPage2.Controls.Add(this.slaveLabel);
            this.tabPage2.Controls.Add(this.dimLabel);
            this.tabPage2.Controls.Add(this.ledOnButton);
            this.tabPage2.Controls.Add(this.ledOffButton);
            this.tabPage2.Controls.Add(this.SlaveId);
            this.tabPage2.Controls.Add(this.dimNum);
            this.tabPage2.Controls.Add(this.deviceId);
            this.tabPage2.Location = new System.Drawing.Point(119, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(683, 407);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "User";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Location = new System.Drawing.Point(0, 371);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(683, 38);
            this.panel2.TabIndex = 9;
            // 
            // bigLabel4
            // 
            this.bigLabel4.AutoSize = true;
            this.bigLabel4.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel4.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel4.Location = new System.Drawing.Point(279, 183);
            this.bigLabel4.Name = "bigLabel4";
            this.bigLabel4.Size = new System.Drawing.Size(140, 46);
            this.bigLabel4.TabIndex = 8;
            this.bigLabel4.Text = "Dimmer";
            // 
            // deviceLabel
            // 
            this.deviceLabel.AutoSize = true;
            this.deviceLabel.BackColor = System.Drawing.Color.Transparent;
            this.deviceLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deviceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.deviceLabel.Location = new System.Drawing.Point(168, 13);
            this.deviceLabel.Name = "deviceLabel";
            this.deviceLabel.Size = new System.Drawing.Size(65, 19);
            this.deviceLabel.TabIndex = 7;
            this.deviceLabel.Text = "Device Id";
            // 
            // slaveLabel
            // 
            this.slaveLabel.AutoSize = true;
            this.slaveLabel.BackColor = System.Drawing.Color.Transparent;
            this.slaveLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.slaveLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.slaveLabel.Location = new System.Drawing.Point(18, 13);
            this.slaveLabel.Name = "slaveLabel";
            this.slaveLabel.Size = new System.Drawing.Size(56, 19);
            this.slaveLabel.TabIndex = 6;
            this.slaveLabel.Text = "Slave Id";
            // 
            // dimLabel
            // 
            this.dimLabel.AutoSize = true;
            this.dimLabel.BackColor = System.Drawing.Color.Transparent;
            this.dimLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dimLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.dimLabel.Location = new System.Drawing.Point(47, 270);
            this.dimLabel.Name = "dimLabel";
            this.dimLabel.Size = new System.Drawing.Size(58, 19);
            this.dimLabel.TabIndex = 5;
            this.dimLabel.Text = "Dimmer";
            // 
            // ledOnButton
            // 
            this.ledOnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ledOnButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.ledOnButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ledOnButton.Image = null;
            this.ledOnButton.Location = new System.Drawing.Point(288, 276);
            this.ledOnButton.Name = "ledOnButton";
            this.ledOnButton.NoRounding = false;
            this.ledOnButton.Size = new System.Drawing.Size(120, 45);
            this.ledOnButton.TabIndex = 4;
            this.ledOnButton.Text = "ON";
            this.ledOnButton.Transparent = false;
            this.ledOnButton.Click += new System.EventHandler(this.ledOnButton_Click);
            // 
            // ledOffButton
            // 
            this.ledOffButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ledOffButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.ledOffButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ledOffButton.Image = null;
            this.ledOffButton.Location = new System.Drawing.Point(513, 276);
            this.ledOffButton.Name = "ledOffButton";
            this.ledOffButton.NoRounding = false;
            this.ledOffButton.Size = new System.Drawing.Size(120, 45);
            this.ledOffButton.TabIndex = 3;
            this.ledOffButton.Text = "OFF";
            this.ledOffButton.Transparent = false;
            this.ledOffButton.Click += new System.EventHandler(this.ledOffButton_Click);
            // 
            // SlaveId
            // 
            this.SlaveId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SlaveId.Location = new System.Drawing.Point(18, 35);
            this.SlaveId.Name = "SlaveId";
            this.SlaveId.Size = new System.Drawing.Size(120, 29);
            this.SlaveId.TabIndex = 2;
            // 
            // dimNum
            // 
            this.dimNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dimNum.Location = new System.Drawing.Point(47, 292);
            this.dimNum.Name = "dimNum";
            this.dimNum.Size = new System.Drawing.Size(120, 29);
            this.dimNum.TabIndex = 1;
            this.dimNum.ValueChanged += new System.EventHandler(this.numDim_ValueChanged);
            // 
            // deviceId
            // 
            this.deviceId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deviceId.Location = new System.Drawing.Point(168, 35);
            this.deviceId.Name = "deviceId";
            this.deviceId.Size = new System.Drawing.Size(120, 29);
            this.deviceId.TabIndex = 0;
            // 
            // adminpage
            // 
            this.adminpage.BackColor = System.Drawing.Color.White;
            this.adminpage.Controls.Add(this.passLabel);
            this.adminpage.Controls.Add(this.passErrorLabel);
            this.adminpage.Controls.Add(this.loginButton);
            this.adminpage.Controls.Add(this.passwordTextbox);
            this.adminpage.Controls.Add(this.setMaxNumeric);
            this.adminpage.Controls.Add(this.setMinNumeric);
            this.adminpage.Controls.Add(this.logOutButton);
            this.adminpage.Controls.Add(this.setMaxButton);
            this.adminpage.Controls.Add(this.setMinButton);
            this.adminpage.Location = new System.Drawing.Point(119, 4);
            this.adminpage.Name = "adminpage";
            this.adminpage.Padding = new System.Windows.Forms.Padding(3);
            this.adminpage.Size = new System.Drawing.Size(683, 407);
            this.adminpage.TabIndex = 2;
            this.adminpage.Text = "Admin";
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.BackColor = System.Drawing.Color.Transparent;
            this.passLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.passLabel.Location = new System.Drawing.Point(50, 13);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(67, 19);
            this.passLabel.TabIndex = 8;
            this.passLabel.Text = "Password";
            // 
            // passErrorLabel
            // 
            this.passErrorLabel.AutoSize = true;
            this.passErrorLabel.BackColor = System.Drawing.Color.Transparent;
            this.passErrorLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passErrorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.passErrorLabel.Location = new System.Drawing.Point(178, 35);
            this.passErrorLabel.Name = "passErrorLabel";
            this.passErrorLabel.Size = new System.Drawing.Size(140, 19);
            this.passErrorLabel.TabIndex = 7;
            this.passErrorLabel.Text = "password not corrent";
            // 
            // loginButton
            // 
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.loginButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginButton.Image = null;
            this.loginButton.Location = new System.Drawing.Point(38, 86);
            this.loginButton.Name = "loginButton";
            this.loginButton.NoRounding = false;
            this.loginButton.Size = new System.Drawing.Size(97, 28);
            this.loginButton.TabIndex = 6;
            this.loginButton.Text = "LOGIN";
            this.loginButton.Transparent = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.BackColor = System.Drawing.Color.White;
            this.passwordTextbox.EnabledCalc = true;
            this.passwordTextbox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.passwordTextbox.Location = new System.Drawing.Point(16, 35);
            this.passwordTextbox.MaxLength = 32767;
            this.passwordTextbox.MultiLine = false;
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.ReadOnly = false;
            this.passwordTextbox.Size = new System.Drawing.Size(139, 29);
            this.passwordTextbox.TabIndex = 5;
            this.passwordTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordTextbox.UseSystemPasswordChar = true;
            // 
            // setMaxNumeric
            // 
            this.setMaxNumeric.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.setMaxNumeric.Location = new System.Drawing.Point(397, 234);
            this.setMaxNumeric.Name = "setMaxNumeric";
            this.setMaxNumeric.Size = new System.Drawing.Size(120, 29);
            this.setMaxNumeric.TabIndex = 4;
            // 
            // setMinNumeric
            // 
            this.setMinNumeric.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.setMinNumeric.Location = new System.Drawing.Point(397, 106);
            this.setMinNumeric.Name = "setMinNumeric";
            this.setMinNumeric.Size = new System.Drawing.Size(120, 29);
            this.setMinNumeric.TabIndex = 3;
            // 
            // logOutButton
            // 
            this.logOutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logOutButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.logOutButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logOutButton.Image = null;
            this.logOutButton.Location = new System.Drawing.Point(38, 356);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.NoRounding = false;
            this.logOutButton.Size = new System.Drawing.Size(97, 29);
            this.logOutButton.TabIndex = 2;
            this.logOutButton.Text = "LOG OUT";
            this.logOutButton.Transparent = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // setMaxButton
            // 
            this.setMaxButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setMaxButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.setMaxButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.setMaxButton.Image = null;
            this.setMaxButton.Location = new System.Drawing.Point(194, 234);
            this.setMaxButton.Name = "setMaxButton";
            this.setMaxButton.NoRounding = false;
            this.setMaxButton.Size = new System.Drawing.Size(100, 41);
            this.setMaxButton.TabIndex = 1;
            this.setMaxButton.Text = "SET MAX";
            this.setMaxButton.Transparent = false;
            // 
            // setMinButton
            // 
            this.setMinButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setMinButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.setMinButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.setMinButton.Image = null;
            this.setMinButton.Location = new System.Drawing.Point(194, 106);
            this.setMinButton.Name = "setMinButton";
            this.setMinButton.NoRounding = false;
            this.setMinButton.Size = new System.Drawing.Size(100, 45);
            this.setMinButton.TabIndex = 0;
            this.setMinButton.Text = "SET MIN";
            this.setMinButton.Transparent = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.bigLabel3);
            this.tabPage3.Controls.Add(this.pixelBrightnessNum);
            this.tabPage3.Controls.Add(this.pixelOffButton);
            this.tabPage3.Controls.Add(this.pixelOnButton);
            this.tabPage3.Controls.Add(this.colorPanel);
            this.tabPage3.Controls.Add(this.colorPicker);
            this.tabPage3.Location = new System.Drawing.Point(119, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(683, 407);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Neo Pixel";
            // 
            // bigLabel3
            // 
            this.bigLabel3.AutoSize = true;
            this.bigLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel3.Location = new System.Drawing.Point(373, 239);
            this.bigLabel3.Name = "bigLabel3";
            this.bigLabel3.Size = new System.Drawing.Size(96, 19);
            this.bigLabel3.TabIndex = 5;
            this.bigLabel3.Text = "Set Brightness";
            // 
            // pixelBrightnessNum
            // 
            this.pixelBrightnessNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pixelBrightnessNum.Location = new System.Drawing.Point(373, 261);
            this.pixelBrightnessNum.Name = "pixelBrightnessNum";
            this.pixelBrightnessNum.Size = new System.Drawing.Size(100, 29);
            this.pixelBrightnessNum.TabIndex = 4;
            this.pixelBrightnessNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pixelBrightnessNum.ValueChanged += new System.EventHandler(this.pixelBrightnessNum_ValueChanged);
            // 
            // pixelOffButton
            // 
            this.pixelOffButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pixelOffButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.pixelOffButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pixelOffButton.Image = null;
            this.pixelOffButton.Location = new System.Drawing.Point(373, 163);
            this.pixelOffButton.Name = "pixelOffButton";
            this.pixelOffButton.NoRounding = false;
            this.pixelOffButton.Size = new System.Drawing.Size(100, 45);
            this.pixelOffButton.TabIndex = 3;
            this.pixelOffButton.Text = "OFF";
            this.pixelOffButton.Transparent = false;
            this.pixelOffButton.Click += new System.EventHandler(this.pixelOffButton_Click);
            // 
            // pixelOnButton
            // 
            this.pixelOnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pixelOnButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.pixelOnButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pixelOnButton.Image = null;
            this.pixelOnButton.Location = new System.Drawing.Point(373, 74);
            this.pixelOnButton.Name = "pixelOnButton";
            this.pixelOnButton.NoRounding = false;
            this.pixelOnButton.Size = new System.Drawing.Size(100, 45);
            this.pixelOnButton.TabIndex = 2;
            this.pixelOnButton.Text = "ON";
            this.pixelOnButton.Transparent = false;
            this.pixelOnButton.Click += new System.EventHandler(this.pixelOnButton_Click);
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.Color.SandyBrown;
            this.colorPanel.Location = new System.Drawing.Point(0, 314);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(683, 62);
            this.colorPanel.TabIndex = 1;
            // 
            // colorPicker
            // 
            this.colorPicker.Location = new System.Drawing.Point(50, 44);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.PickerImage = ((System.Drawing.Image)(resources.GetObject("colorPicker.PickerImage")));
            this.colorPicker.SelectedColor = System.Drawing.Color.Empty;
            this.colorPicker.ShowColorPreview = true;
            this.colorPicker.Size = new System.Drawing.Size(183, 185);
            this.colorPicker.TabIndex = 0;
            this.colorPicker.Text = "parrotColorPicker1";
            this.colorPicker.Click += new System.EventHandler(this.colorPicker_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 437);
            this.Controls.Add(this.tabPages);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPages.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlaveId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceId)).EndInit();
            this.adminpage.ResumeLayout(false);
            this.adminpage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setMaxNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setMinNumeric)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBrightnessNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.AirTabPage tabPages;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ReaLTaiizor.Controls.AirButton connectButton;
        private ReaLTaiizor.Controls.AirButton ledOnButton;
        private ReaLTaiizor.Controls.AirButton ledOffButton;
        private ReaLTaiizor.Controls.CrownNumeric SlaveId;
        private ReaLTaiizor.Controls.CrownNumeric dimNum;
        private ReaLTaiizor.Controls.CrownNumeric deviceId;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.BigLabel deviceLabel;
        private ReaLTaiizor.Controls.BigLabel slaveLabel;
        private ReaLTaiizor.Controls.BigLabel dimLabel;
        private System.Windows.Forms.TabPage adminpage;
        private ReaLTaiizor.Controls.AirButton loginButton;
        private ReaLTaiizor.Controls.AloneTextBox passwordTextbox;
        private ReaLTaiizor.Controls.CrownNumeric setMaxNumeric;
        private ReaLTaiizor.Controls.CrownNumeric setMinNumeric;
        private ReaLTaiizor.Controls.AirButton logOutButton;
        private ReaLTaiizor.Controls.AirButton setMaxButton;
        private ReaLTaiizor.Controls.AirButton setMinButton;
        private System.Windows.Forms.TabPage tabPage3;
        private ReaLTaiizor.Controls.AirButton pixelOnButton;
        private System.Windows.Forms.Panel colorPanel;
        private ReaLTaiizor.Controls.ParrotColorPicker colorPicker;
        private ReaLTaiizor.Controls.AirButton pixelOffButton;
        private ReaLTaiizor.Controls.BigLabel bigLabel3;
        private ReaLTaiizor.Controls.CrownNumeric pixelBrightnessNum;
        private ReaLTaiizor.Controls.BigLabel bigLabel4;
        private System.Windows.Forms.Panel panel2;
        private ReaLTaiizor.Controls.BigLabel passErrorLabel;
        private ReaLTaiizor.Controls.BigLabel connectionStatusLabel;
        private ReaLTaiizor.Controls.BigLabel passLabel;
    }
}

