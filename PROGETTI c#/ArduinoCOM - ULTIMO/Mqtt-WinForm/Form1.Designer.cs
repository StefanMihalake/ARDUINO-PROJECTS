
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
            this.userPannel = new System.Windows.Forms.Panel();
            this.dimLed = new ReaLTaiizor.Controls.BigLabel();
            this.dim = new ReaLTaiizor.Controls.CrownNumeric();
            this.offButton = new ReaLTaiizor.Controls.ForeverButton();
            this.dimLabel = new ReaLTaiizor.Controls.BigLabel();
            this.onButton = new ReaLTaiizor.Controls.ForeverButton();
            this.maxUserLabel = new ReaLTaiizor.Controls.BigLabel();
            this.minUserLabel = new ReaLTaiizor.Controls.BigLabel();
            this.progressbar = new System.Windows.Forms.ProgressBar();
            this.deviceLabel = new ReaLTaiizor.Controls.BigLabel();
            this.deviceId = new ReaLTaiizor.Controls.CrownNumeric();
            this.adminpage = new System.Windows.Forms.TabPage();
            this.loginPannel = new System.Windows.Forms.Panel();
            this.passLabel = new ReaLTaiizor.Controls.BigLabel();
            this.passwordTextbox = new ReaLTaiizor.Controls.AloneTextBox();
            this.loginButton = new ReaLTaiizor.Controls.AirButton();
            this.adminPannel = new System.Windows.Forms.Panel();
            this.maxValueLabel = new ReaLTaiizor.Controls.BigLabel();
            this.setMinButton = new ReaLTaiizor.Controls.AirButton();
            this.minValueLabel = new ReaLTaiizor.Controls.BigLabel();
            this.setMaxButton = new ReaLTaiizor.Controls.AirButton();
            this.minDimValue = new ReaLTaiizor.Controls.CrownNumeric();
            this.maxDimValue = new ReaLTaiizor.Controls.CrownNumeric();
            this.passErrorLabel = new ReaLTaiizor.Controls.BigLabel();
            this.logOutButton = new ReaLTaiizor.Controls.AirButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.neoPannel = new System.Windows.Forms.Panel();
            this.offPixel = new ReaLTaiizor.Controls.ForeverButton();
            this.colorPicker = new ReaLTaiizor.Controls.ParrotColorPicker();
            this.onPixel = new ReaLTaiizor.Controls.ForeverButton();
            this.pixelBrightnessNum = new ReaLTaiizor.Controls.CrownNumeric();
            this.brightnessLabel = new System.Windows.Forms.Label();
            this.bigLabel3 = new ReaLTaiizor.Controls.BigLabel();
            this.colorpanel = new System.Windows.Forms.Panel();
            this.tabPages.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.userPannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceId)).BeginInit();
            this.adminpage.SuspendLayout();
            this.loginPannel.SuspendLayout();
            this.adminPannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minDimValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDimValue)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.neoPannel.SuspendLayout();
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
            this.tabPage2.Controls.Add(this.userPannel);
            this.tabPage2.Controls.Add(this.maxUserLabel);
            this.tabPage2.Controls.Add(this.minUserLabel);
            this.tabPage2.Controls.Add(this.progressbar);
            this.tabPage2.Controls.Add(this.deviceLabel);
            this.tabPage2.Controls.Add(this.deviceId);
            this.tabPage2.Location = new System.Drawing.Point(119, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(683, 407);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "User";
            // 
            // userPannel
            // 
            this.userPannel.Controls.Add(this.dimLed);
            this.userPannel.Controls.Add(this.dim);
            this.userPannel.Controls.Add(this.offButton);
            this.userPannel.Controls.Add(this.dimLabel);
            this.userPannel.Controls.Add(this.onButton);
            this.userPannel.Location = new System.Drawing.Point(33, 109);
            this.userPannel.Name = "userPannel";
            this.userPannel.Size = new System.Drawing.Size(612, 174);
            this.userPannel.TabIndex = 1;
            // 
            // dimLed
            // 
            this.dimLed.AutoSize = true;
            this.dimLed.BackColor = System.Drawing.Color.Transparent;
            this.dimLed.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dimLed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.dimLed.Location = new System.Drawing.Point(233, 15);
            this.dimLed.Name = "dimLed";
            this.dimLed.Size = new System.Drawing.Size(140, 46);
            this.dimLed.TabIndex = 8;
            this.dimLed.Text = "Dimmer";
            // 
            // dim
            // 
            this.dim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dim.Location = new System.Drawing.Point(12, 109);
            this.dim.Name = "dim";
            this.dim.Size = new System.Drawing.Size(120, 29);
            this.dim.TabIndex = 1;
            this.dim.ValueChanged += new System.EventHandler(this.numDim_ValueChanged);
            // 
            // offButton
            // 
            this.offButton.BackColor = System.Drawing.Color.Silver;
            this.offButton.BaseColor = System.Drawing.Color.Transparent;
            this.offButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.offButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.offButton.Location = new System.Drawing.Point(233, 99);
            this.offButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.offButton.Name = "offButton";
            this.offButton.Rounded = false;
            this.offButton.Size = new System.Drawing.Size(140, 54);
            this.offButton.TabIndex = 43;
            this.offButton.Text = "OFF";
            this.offButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.offButton.Click += new System.EventHandler(this.ledOffButton_Click);
            // 
            // dimLabel
            // 
            this.dimLabel.AutoSize = true;
            this.dimLabel.BackColor = System.Drawing.Color.Transparent;
            this.dimLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dimLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.dimLabel.Location = new System.Drawing.Point(12, 87);
            this.dimLabel.Name = "dimLabel";
            this.dimLabel.Size = new System.Drawing.Size(58, 19);
            this.dimLabel.TabIndex = 5;
            this.dimLabel.Text = "Dimmer";
            // 
            // onButton
            // 
            this.onButton.BackColor = System.Drawing.Color.Silver;
            this.onButton.BaseColor = System.Drawing.Color.Transparent;
            this.onButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.onButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.onButton.Location = new System.Drawing.Point(450, 99);
            this.onButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.onButton.Name = "onButton";
            this.onButton.Rounded = false;
            this.onButton.Size = new System.Drawing.Size(146, 54);
            this.onButton.TabIndex = 42;
            this.onButton.Text = "ON";
            this.onButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.onButton.Click += new System.EventHandler(this.ledOnButton_Click);
            // 
            // maxUserLabel
            // 
            this.maxUserLabel.AutoSize = true;
            this.maxUserLabel.BackColor = System.Drawing.Color.Transparent;
            this.maxUserLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxUserLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.maxUserLabel.Location = new System.Drawing.Point(638, 334);
            this.maxUserLabel.Name = "maxUserLabel";
            this.maxUserLabel.Size = new System.Drawing.Size(39, 21);
            this.maxUserLabel.TabIndex = 45;
            this.maxUserLabel.Text = "max";
            // 
            // minUserLabel
            // 
            this.minUserLabel.AutoSize = true;
            this.minUserLabel.BackColor = System.Drawing.Color.Transparent;
            this.minUserLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minUserLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.minUserLabel.Location = new System.Drawing.Point(0, 334);
            this.minUserLabel.Name = "minUserLabel";
            this.minUserLabel.Size = new System.Drawing.Size(37, 21);
            this.minUserLabel.TabIndex = 44;
            this.minUserLabel.Text = "min";
            // 
            // progressbar
            // 
            this.progressbar.Location = new System.Drawing.Point(0, 358);
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(683, 49);
            this.progressbar.TabIndex = 9;
            // 
            // deviceLabel
            // 
            this.deviceLabel.AutoSize = true;
            this.deviceLabel.BackColor = System.Drawing.Color.Transparent;
            this.deviceLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deviceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.deviceLabel.Location = new System.Drawing.Point(58, 17);
            this.deviceLabel.Name = "deviceLabel";
            this.deviceLabel.Size = new System.Drawing.Size(65, 19);
            this.deviceLabel.TabIndex = 7;
            this.deviceLabel.Text = "Device Id";
            // 
            // deviceId
            // 
            this.deviceId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deviceId.Location = new System.Drawing.Point(58, 39);
            this.deviceId.Name = "deviceId";
            this.deviceId.Size = new System.Drawing.Size(120, 29);
            this.deviceId.TabIndex = 0;
            // 
            // adminpage
            // 
            this.adminpage.BackColor = System.Drawing.Color.White;
            this.adminpage.Controls.Add(this.loginPannel);
            this.adminpage.Controls.Add(this.adminPannel);
            this.adminpage.Controls.Add(this.passErrorLabel);
            this.adminpage.Controls.Add(this.logOutButton);
            this.adminpage.Location = new System.Drawing.Point(119, 4);
            this.adminpage.Name = "adminpage";
            this.adminpage.Padding = new System.Windows.Forms.Padding(3);
            this.adminpage.Size = new System.Drawing.Size(683, 407);
            this.adminpage.TabIndex = 2;
            this.adminpage.Text = "Admin";
            // 
            // loginPannel
            // 
            this.loginPannel.Controls.Add(this.passLabel);
            this.loginPannel.Controls.Add(this.passwordTextbox);
            this.loginPannel.Controls.Add(this.loginButton);
            this.loginPannel.Location = new System.Drawing.Point(6, 35);
            this.loginPannel.Name = "loginPannel";
            this.loginPannel.Size = new System.Drawing.Size(170, 116);
            this.loginPannel.TabIndex = 1;
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.BackColor = System.Drawing.Color.Transparent;
            this.passLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.passLabel.Location = new System.Drawing.Point(53, 0);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(67, 19);
            this.passLabel.TabIndex = 8;
            this.passLabel.Text = "Password";
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.BackColor = System.Drawing.Color.White;
            this.passwordTextbox.EnabledCalc = true;
            this.passwordTextbox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.passwordTextbox.Location = new System.Drawing.Point(19, 22);
            this.passwordTextbox.MaxLength = 32767;
            this.passwordTextbox.MultiLine = false;
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.ReadOnly = false;
            this.passwordTextbox.Size = new System.Drawing.Size(139, 29);
            this.passwordTextbox.TabIndex = 5;
            this.passwordTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordTextbox.UseSystemPasswordChar = true;
            // 
            // loginButton
            // 
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.loginButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginButton.Image = null;
            this.loginButton.Location = new System.Drawing.Point(41, 73);
            this.loginButton.Name = "loginButton";
            this.loginButton.NoRounding = false;
            this.loginButton.Size = new System.Drawing.Size(97, 28);
            this.loginButton.TabIndex = 6;
            this.loginButton.Text = "LOGIN";
            this.loginButton.Transparent = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // adminPannel
            // 
            this.adminPannel.Controls.Add(this.maxValueLabel);
            this.adminPannel.Controls.Add(this.setMinButton);
            this.adminPannel.Controls.Add(this.minValueLabel);
            this.adminPannel.Controls.Add(this.setMaxButton);
            this.adminPannel.Controls.Add(this.minDimValue);
            this.adminPannel.Controls.Add(this.maxDimValue);
            this.adminPannel.Location = new System.Drawing.Point(189, 97);
            this.adminPannel.Name = "adminPannel";
            this.adminPannel.Size = new System.Drawing.Size(441, 238);
            this.adminPannel.TabIndex = 1;
            // 
            // maxValueLabel
            // 
            this.maxValueLabel.AutoSize = true;
            this.maxValueLabel.BackColor = System.Drawing.Color.Transparent;
            this.maxValueLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.maxValueLabel.Location = new System.Drawing.Point(381, 177);
            this.maxValueLabel.Name = "maxValueLabel";
            this.maxValueLabel.Size = new System.Drawing.Size(39, 21);
            this.maxValueLabel.TabIndex = 10;
            this.maxValueLabel.Text = "max";
            // 
            // setMinButton
            // 
            this.setMinButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setMinButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.setMinButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.setMinButton.Image = null;
            this.setMinButton.Location = new System.Drawing.Point(12, 26);
            this.setMinButton.Name = "setMinButton";
            this.setMinButton.NoRounding = false;
            this.setMinButton.Size = new System.Drawing.Size(112, 54);
            this.setMinButton.TabIndex = 0;
            this.setMinButton.Text = "SET MIN";
            this.setMinButton.Transparent = false;
            this.setMinButton.Click += new System.EventHandler(this.setMinButton_Click);
            // 
            // minValueLabel
            // 
            this.minValueLabel.AutoSize = true;
            this.minValueLabel.BackColor = System.Drawing.Color.Transparent;
            this.minValueLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.minValueLabel.Location = new System.Drawing.Point(381, 37);
            this.minValueLabel.Name = "minValueLabel";
            this.minValueLabel.Size = new System.Drawing.Size(37, 21);
            this.minValueLabel.TabIndex = 9;
            this.minValueLabel.Text = "min";
            // 
            // setMaxButton
            // 
            this.setMaxButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setMaxButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.setMaxButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.setMaxButton.Image = null;
            this.setMaxButton.Location = new System.Drawing.Point(12, 163);
            this.setMaxButton.Name = "setMaxButton";
            this.setMaxButton.NoRounding = false;
            this.setMaxButton.Size = new System.Drawing.Size(112, 53);
            this.setMaxButton.TabIndex = 1;
            this.setMaxButton.Text = "SET MAX";
            this.setMaxButton.Transparent = false;
            this.setMaxButton.Click += new System.EventHandler(this.setMaxButton_Click);
            // 
            // minDimValue
            // 
            this.minDimValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minDimValue.Location = new System.Drawing.Point(215, 35);
            this.minDimValue.Name = "minDimValue";
            this.minDimValue.Size = new System.Drawing.Size(120, 29);
            this.minDimValue.TabIndex = 3;
            // 
            // maxDimValue
            // 
            this.maxDimValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxDimValue.Location = new System.Drawing.Point(215, 175);
            this.maxDimValue.Name = "maxDimValue";
            this.maxDimValue.Size = new System.Drawing.Size(120, 29);
            this.maxDimValue.TabIndex = 4;
            // 
            // passErrorLabel
            // 
            this.passErrorLabel.AutoSize = true;
            this.passErrorLabel.BackColor = System.Drawing.Color.Transparent;
            this.passErrorLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passErrorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.passErrorLabel.Location = new System.Drawing.Point(182, 57);
            this.passErrorLabel.Name = "passErrorLabel";
            this.passErrorLabel.Size = new System.Drawing.Size(140, 19);
            this.passErrorLabel.TabIndex = 7;
            this.passErrorLabel.Text = "password not corrent";
            // 
            // logOutButton
            // 
            this.logOutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logOutButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.logOutButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logOutButton.Image = null;
            this.logOutButton.Location = new System.Drawing.Point(38, 347);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.NoRounding = false;
            this.logOutButton.Size = new System.Drawing.Size(97, 29);
            this.logOutButton.TabIndex = 2;
            this.logOutButton.Text = "LOG OUT";
            this.logOutButton.Transparent = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.neoPannel);
            this.tabPage3.Controls.Add(this.colorpanel);
            this.tabPage3.Location = new System.Drawing.Point(119, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(683, 407);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Neo Pixel";
            // 
            // neoPannel
            // 
            this.neoPannel.Controls.Add(this.offPixel);
            this.neoPannel.Controls.Add(this.colorPicker);
            this.neoPannel.Controls.Add(this.onPixel);
            this.neoPannel.Controls.Add(this.pixelBrightnessNum);
            this.neoPannel.Controls.Add(this.brightnessLabel);
            this.neoPannel.Controls.Add(this.bigLabel3);
            this.neoPannel.Location = new System.Drawing.Point(53, 54);
            this.neoPannel.Name = "neoPannel";
            this.neoPannel.Size = new System.Drawing.Size(570, 247);
            this.neoPannel.TabIndex = 1;
            // 
            // offPixel
            // 
            this.offPixel.BackColor = System.Drawing.Color.Silver;
            this.offPixel.BaseColor = System.Drawing.Color.Transparent;
            this.offPixel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.offPixel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.offPixel.Location = new System.Drawing.Point(343, 108);
            this.offPixel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.offPixel.Name = "offPixel";
            this.offPixel.Rounded = false;
            this.offPixel.Size = new System.Drawing.Size(112, 47);
            this.offPixel.TabIndex = 42;
            this.offPixel.Text = "OFF";
            this.offPixel.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.offPixel.Click += new System.EventHandler(this.ledOffButton_Click);
            // 
            // colorPicker
            // 
            this.colorPicker.Location = new System.Drawing.Point(16, 13);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.PickerImage = ((System.Drawing.Image)(resources.GetObject("colorPicker.PickerImage")));
            this.colorPicker.SelectedColor = System.Drawing.Color.Empty;
            this.colorPicker.ShowColorPreview = true;
            this.colorPicker.Size = new System.Drawing.Size(210, 217);
            this.colorPicker.TabIndex = 0;
            this.colorPicker.Text = "parrotColorPicker1";
            this.colorPicker.Click += new System.EventHandler(this.colorPicker_Click);
            // 
            // onPixel
            // 
            this.onPixel.BackColor = System.Drawing.Color.Silver;
            this.onPixel.BaseColor = System.Drawing.Color.Transparent;
            this.onPixel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.onPixel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.onPixel.Location = new System.Drawing.Point(343, 16);
            this.onPixel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.onPixel.Name = "onPixel";
            this.onPixel.Rounded = false;
            this.onPixel.Size = new System.Drawing.Size(112, 45);
            this.onPixel.TabIndex = 41;
            this.onPixel.Text = "ON";
            this.onPixel.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.onPixel.Click += new System.EventHandler(this.ledOnButton_Click);
            // 
            // pixelBrightnessNum
            // 
            this.pixelBrightnessNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pixelBrightnessNum.Location = new System.Drawing.Point(343, 204);
            this.pixelBrightnessNum.Name = "pixelBrightnessNum";
            this.pixelBrightnessNum.Size = new System.Drawing.Size(112, 29);
            this.pixelBrightnessNum.TabIndex = 4;
            this.pixelBrightnessNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pixelBrightnessNum.ValueChanged += new System.EventHandler(this.pixelBrightnessNum_ValueChanged);
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.AutoSize = true;
            this.brightnessLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.brightnessLabel.Location = new System.Drawing.Point(477, 211);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(73, 19);
            this.brightnessLabel.TabIndex = 0;
            this.brightnessLabel.Text = "brightness";
            // 
            // bigLabel3
            // 
            this.bigLabel3.AutoSize = true;
            this.bigLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel3.Location = new System.Drawing.Point(343, 182);
            this.bigLabel3.Name = "bigLabel3";
            this.bigLabel3.Size = new System.Drawing.Size(96, 19);
            this.bigLabel3.TabIndex = 5;
            this.bigLabel3.Text = "Set Brightness";
            // 
            // colorpanel
            // 
            this.colorpanel.BackColor = System.Drawing.Color.SandyBrown;
            this.colorpanel.Location = new System.Drawing.Point(0, 360);
            this.colorpanel.Name = "colorpanel";
            this.colorpanel.Size = new System.Drawing.Size(683, 51);
            this.colorpanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 443);
            this.Controls.Add(this.tabPages);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPages.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.userPannel.ResumeLayout(false);
            this.userPannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceId)).EndInit();
            this.adminpage.ResumeLayout(false);
            this.adminpage.PerformLayout();
            this.loginPannel.ResumeLayout(false);
            this.loginPannel.PerformLayout();
            this.adminPannel.ResumeLayout(false);
            this.adminPannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minDimValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDimValue)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.neoPannel.ResumeLayout(false);
            this.neoPannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBrightnessNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.AirTabPage tabPages;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ReaLTaiizor.Controls.AirButton connectButton;
        private ReaLTaiizor.Controls.CrownNumeric dim;
        private ReaLTaiizor.Controls.CrownNumeric deviceId;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.BigLabel deviceLabel;
        private ReaLTaiizor.Controls.BigLabel dimLabel;
        private System.Windows.Forms.TabPage adminpage;
        private ReaLTaiizor.Controls.AirButton loginButton;
        private ReaLTaiizor.Controls.AloneTextBox passwordTextbox;
        private ReaLTaiizor.Controls.CrownNumeric maxDimValue;
        private ReaLTaiizor.Controls.CrownNumeric minDimValue;
        private ReaLTaiizor.Controls.AirButton logOutButton;
        private ReaLTaiizor.Controls.AirButton setMaxButton;
        private ReaLTaiizor.Controls.AirButton setMinButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel colorpanel;
        private ReaLTaiizor.Controls.ParrotColorPicker colorPicker;
        private ReaLTaiizor.Controls.BigLabel bigLabel3;
        private ReaLTaiizor.Controls.CrownNumeric pixelBrightnessNum;
        private ReaLTaiizor.Controls.BigLabel dimLed;
        private ReaLTaiizor.Controls.BigLabel passErrorLabel;
        private ReaLTaiizor.Controls.BigLabel connectionStatusLabel;
        private ReaLTaiizor.Controls.BigLabel passLabel;
        private System.Windows.Forms.ProgressBar progressbar;
        private System.Windows.Forms.Label brightnessLabel;
        private ReaLTaiizor.Controls.ForeverButton onPixel;
        private ReaLTaiizor.Controls.ForeverButton offPixel;
        private ReaLTaiizor.Controls.ForeverButton onButton;
        private ReaLTaiizor.Controls.ForeverButton offButton;
        private ReaLTaiizor.Controls.BigLabel maxValueLabel;
        private ReaLTaiizor.Controls.BigLabel minValueLabel;
        private ReaLTaiizor.Controls.BigLabel maxUserLabel;
        private ReaLTaiizor.Controls.BigLabel minUserLabel;
        private System.Windows.Forms.Panel userPannel;
        private System.Windows.Forms.Panel adminPannel;
        private System.Windows.Forms.Panel neoPannel;
        private System.Windows.Forms.Panel loginPannel;
    }
}

