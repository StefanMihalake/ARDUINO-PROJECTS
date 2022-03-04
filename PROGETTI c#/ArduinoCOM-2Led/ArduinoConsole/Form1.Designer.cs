
namespace ArduinoConsole
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
            this.idLed = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.device_id = new System.Windows.Forms.NumericUpDown();
            this.noIdLabel = new System.Windows.Forms.Label();
            this.portErrorLabel = new System.Windows.Forms.Label();
            this.connectButton = new ReaLTaiizor.Controls.ForeverButton();
            this.selectComPort = new ReaLTaiizor.Controls.PoisonComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AdminPage = new System.Windows.Forms.TabPage();
            this.minLabel = new System.Windows.Forms.Label();
            this.minDimValue = new System.Windows.Forms.NumericUpDown();
            this.minValueLabel = new System.Windows.Forms.Label();
            this.AdminGroup = new System.Windows.Forms.GroupBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.setMinButton = new System.Windows.Forms.Button();
            this.passwordNotValidLabel = new System.Windows.Forms.Label();
            this.maxValueLabel = new System.Windows.Forms.Label();
            this.setMaxButton = new System.Windows.Forms.Button();
            this.maxDimValue = new System.Windows.Forms.NumericUpDown();
            this.disableControls = new System.Windows.Forms.CheckBox();
            this.maxLabel = new System.Windows.Forms.Label();
            this.adminLabel = new ReaLTaiizor.Controls.MetroLabel();
            this.UserPage = new System.Windows.Forms.TabPage();
            this.offButton = new System.Windows.Forms.Button();
            this.dim = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.onButton = new System.Windows.Forms.Button();
            this.progressbar = new ReaLTaiizor.Controls.PoisonProgressBar();
            this.dimtrack = new ReaLTaiizor.Controls.PoisonTrackBar();
            this.dimLed = new System.Windows.Forms.Label();
            this.minUserLabel = new System.Windows.Forms.Label();
            this.maxUserLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.idLed)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.device_id)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.AdminPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minDimValue)).BeginInit();
            this.AdminGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxDimValue)).BeginInit();
            this.UserPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dim)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLed
            // 
            this.idLed.BackColor = System.Drawing.Color.DarkKhaki;
            this.idLed.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.idLed.ForeColor = System.Drawing.Color.White;
            this.idLed.Location = new System.Drawing.Point(50, 85);
            this.idLed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.idLed.Name = "idLed";
            this.idLed.Size = new System.Drawing.Size(97, 27);
            this.idLed.TabIndex = 9;
            this.idLed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.idLed.ValueChanged += new System.EventHandler(this.On_Id_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Device Id";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.device_id);
            this.groupBox2.Controls.Add(this.noIdLabel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.idLed);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(15, 291);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(196, 143);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Slave Id";
            // 
            // device_id
            // 
            this.device_id.BackColor = System.Drawing.Color.LightSlateGray;
            this.device_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.device_id.ForeColor = System.Drawing.Color.White;
            this.device_id.Location = new System.Drawing.Point(50, 31);
            this.device_id.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.device_id.Name = "device_id";
            this.device_id.Size = new System.Drawing.Size(97, 27);
            this.device_id.TabIndex = 32;
            this.device_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // noIdLabel
            // 
            this.noIdLabel.AutoSize = true;
            this.noIdLabel.BackColor = System.Drawing.Color.Transparent;
            this.noIdLabel.ForeColor = System.Drawing.Color.Red;
            this.noIdLabel.Location = new System.Drawing.Point(47, 115);
            this.noIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noIdLabel.Name = "noIdLabel";
            this.noIdLabel.Size = new System.Drawing.Size(100, 15);
            this.noIdLabel.TabIndex = 24;
            this.noIdLabel.Tag = "";
            this.noIdLabel.Text = "NO LED WITH ID";
            // 
            // portErrorLabel
            // 
            this.portErrorLabel.AutoSize = true;
            this.portErrorLabel.BackColor = System.Drawing.Color.Transparent;
            this.portErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.portErrorLabel.Location = new System.Drawing.Point(28, 207);
            this.portErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portErrorLabel.Name = "portErrorLabel";
            this.portErrorLabel.Size = new System.Drawing.Size(57, 16);
            this.portErrorLabel.TabIndex = 13;
            this.portErrorLabel.Tag = "";
            this.portErrorLabel.Text = "port error";
            this.portErrorLabel.UseWaitCursor = true;
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.connectButton.BaseColor = System.Drawing.Color.Transparent;
            this.connectButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.connectButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectButton.Location = new System.Drawing.Point(21, 131);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.connectButton.Name = "connectButton";
            this.connectButton.Rounded = false;
            this.connectButton.Size = new System.Drawing.Size(156, 61);
            this.connectButton.TabIndex = 38;
            this.connectButton.Text = "Connect";
            this.connectButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.connectButton.Click += new System.EventHandler(this.Connect_Button_Click);
            // 
            // selectComPort
            // 
            this.selectComPort.FormattingEnabled = true;
            this.selectComPort.ItemHeight = 23;
            this.selectComPort.Location = new System.Drawing.Point(21, 48);
            this.selectComPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.selectComPort.Name = "selectComPort";
            this.selectComPort.Size = new System.Drawing.Size(156, 29);
            this.selectComPort.TabIndex = 39;
            this.selectComPort.UseSelectable = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectComPort);
            this.groupBox1.Controls.Add(this.connectButton);
            this.groupBox1.Controls.Add(this.portErrorLabel);
            this.groupBox1.Location = new System.Drawing.Point(15, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(196, 244);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // AdminPage
            // 
            this.AdminPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.AdminPage.Controls.Add(this.adminLabel);
            this.AdminPage.Controls.Add(this.maxLabel);
            this.AdminPage.Controls.Add(this.disableControls);
            this.AdminPage.Controls.Add(this.maxDimValue);
            this.AdminPage.Controls.Add(this.setMaxButton);
            this.AdminPage.Controls.Add(this.maxValueLabel);
            this.AdminPage.Controls.Add(this.passwordNotValidLabel);
            this.AdminPage.Controls.Add(this.setMinButton);
            this.AdminPage.Controls.Add(this.AdminGroup);
            this.AdminPage.Controls.Add(this.minValueLabel);
            this.AdminPage.Controls.Add(this.minDimValue);
            this.AdminPage.Controls.Add(this.minLabel);
            this.AdminPage.Location = new System.Drawing.Point(4, 25);
            this.AdminPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AdminPage.Name = "AdminPage";
            this.AdminPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AdminPage.Size = new System.Drawing.Size(669, 392);
            this.AdminPage.TabIndex = 1;
            this.AdminPage.Text = "Admin";
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Location = new System.Drawing.Point(126, 257);
            this.minLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(28, 16);
            this.minLabel.TabIndex = 19;
            this.minLabel.Text = "Min";
            // 
            // minDimValue
            // 
            this.minDimValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.minDimValue.Location = new System.Drawing.Point(195, 188);
            this.minDimValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.minDimValue.Name = "minDimValue";
            this.minDimValue.Size = new System.Drawing.Size(120, 23);
            this.minDimValue.TabIndex = 16;
            this.minDimValue.ValueChanged += new System.EventHandler(this.SetMinDim_ValueChanged);
            // 
            // minValueLabel
            // 
            this.minValueLabel.AutoSize = true;
            this.minValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minValueLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.minValueLabel.Location = new System.Drawing.Point(195, 244);
            this.minValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minValueLabel.Name = "minValueLabel";
            this.minValueLabel.Size = new System.Drawing.Size(57, 31);
            this.minValueLabel.TabIndex = 24;
            this.minValueLabel.Text = "min";
            this.minValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdminGroup
            // 
            this.AdminGroup.BackColor = System.Drawing.Color.Transparent;
            this.AdminGroup.Controls.Add(this.button3);
            this.AdminGroup.Controls.Add(this.passwordTextBox);
            this.AdminGroup.Location = new System.Drawing.Point(218, 56);
            this.AdminGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AdminGroup.Name = "AdminGroup";
            this.AdminGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AdminGroup.Size = new System.Drawing.Size(217, 110);
            this.AdminGroup.TabIndex = 29;
            this.AdminGroup.TabStop = false;
            this.AdminGroup.Text = "Admin";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.passwordTextBox.Location = new System.Drawing.Point(47, 36);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.PlaceholderText = "          Password";
            this.passwordTextBox.Size = new System.Drawing.Size(119, 23);
            this.passwordTextBox.TabIndex = 26;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(75, 65);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 24);
            this.button3.TabIndex = 27;
            this.button3.Text = "Login";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.LoginAdmin_Click);
            // 
            // setMinButton
            // 
            this.setMinButton.BackColor = System.Drawing.Color.Gray;
            this.setMinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setMinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.setMinButton.ForeColor = System.Drawing.Color.White;
            this.setMinButton.Location = new System.Drawing.Point(55, 172);
            this.setMinButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.setMinButton.Name = "setMinButton";
            this.setMinButton.Size = new System.Drawing.Size(114, 48);
            this.setMinButton.TabIndex = 22;
            this.setMinButton.Text = "SET MIN";
            this.setMinButton.UseVisualStyleBackColor = false;
            this.setMinButton.Click += new System.EventHandler(this.SetMin_Click);
            // 
            // passwordNotValidLabel
            // 
            this.passwordNotValidLabel.AutoSize = true;
            this.passwordNotValidLabel.BackColor = System.Drawing.Color.Transparent;
            this.passwordNotValidLabel.ForeColor = System.Drawing.Color.Red;
            this.passwordNotValidLabel.Location = new System.Drawing.Point(443, 95);
            this.passwordNotValidLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordNotValidLabel.Name = "passwordNotValidLabel";
            this.passwordNotValidLabel.Size = new System.Drawing.Size(106, 16);
            this.passwordNotValidLabel.TabIndex = 30;
            this.passwordNotValidLabel.Text = "Password not valid";
            // 
            // maxValueLabel
            // 
            this.maxValueLabel.AutoSize = true;
            this.maxValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxValueLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.maxValueLabel.Location = new System.Drawing.Point(502, 240);
            this.maxValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.maxValueLabel.Name = "maxValueLabel";
            this.maxValueLabel.Size = new System.Drawing.Size(64, 31);
            this.maxValueLabel.TabIndex = 25;
            this.maxValueLabel.Text = "max";
            // 
            // setMaxButton
            // 
            this.setMaxButton.BackColor = System.Drawing.Color.Gray;
            this.setMaxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setMaxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.setMaxButton.ForeColor = System.Drawing.Color.White;
            this.setMaxButton.Location = new System.Drawing.Point(349, 172);
            this.setMaxButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.setMaxButton.Name = "setMaxButton";
            this.setMaxButton.Size = new System.Drawing.Size(112, 48);
            this.setMaxButton.TabIndex = 23;
            this.setMaxButton.Text = "SET MAX";
            this.setMaxButton.UseVisualStyleBackColor = false;
            this.setMaxButton.Click += new System.EventHandler(this.SetMax_Click);
            // 
            // maxDimValue
            // 
            this.maxDimValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.maxDimValue.Location = new System.Drawing.Point(483, 188);
            this.maxDimValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.maxDimValue.Name = "maxDimValue";
            this.maxDimValue.Size = new System.Drawing.Size(120, 23);
            this.maxDimValue.TabIndex = 15;
            this.maxDimValue.ValueChanged += new System.EventHandler(this.SetMaxDim_ValueChanged);
            // 
            // disableControls
            // 
            this.disableControls.AutoSize = true;
            this.disableControls.Location = new System.Drawing.Point(20, 355);
            this.disableControls.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.disableControls.Name = "disableControls";
            this.disableControls.Size = new System.Drawing.Size(110, 20);
            this.disableControls.TabIndex = 36;
            this.disableControls.Text = "Disable controls";
            this.disableControls.UseVisualStyleBackColor = true;
            this.disableControls.CheckedChanged += new System.EventHandler(this.DisableControls_CheckedChanged);
            this.disableControls.Click += new System.EventHandler(this.AdminCheck);
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Location = new System.Drawing.Point(438, 254);
            this.maxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(29, 16);
            this.maxLabel.TabIndex = 20;
            this.maxLabel.Text = "Max";
            // 
            // adminLabel
            // 
            this.adminLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.adminLabel.IsDerivedStyle = true;
            this.adminLabel.Location = new System.Drawing.Point(265, 3);
            this.adminLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.adminLabel.Name = "adminLabel";
            this.adminLabel.Size = new System.Drawing.Size(150, 29);
            this.adminLabel.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            this.adminLabel.StyleManager = null;
            this.adminLabel.TabIndex = 38;
            this.adminLabel.Text = "Admin controls";
            this.adminLabel.ThemeAuthor = "Taiizor";
            this.adminLabel.ThemeName = "MetroLight";
            // 
            // UserPage
            // 
            this.UserPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UserPage.Controls.Add(this.maxUserLabel);
            this.UserPage.Controls.Add(this.minUserLabel);
            this.UserPage.Controls.Add(this.dimLed);
            this.UserPage.Controls.Add(this.dimtrack);
            this.UserPage.Controls.Add(this.progressbar);
            this.UserPage.Controls.Add(this.onButton);
            this.UserPage.Controls.Add(this.label5);
            this.UserPage.Controls.Add(this.dim);
            this.UserPage.Controls.Add(this.offButton);
            this.UserPage.Location = new System.Drawing.Point(4, 25);
            this.UserPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.UserPage.Name = "UserPage";
            this.UserPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.UserPage.Size = new System.Drawing.Size(669, 392);
            this.UserPage.TabIndex = 0;
            this.UserPage.Text = "User";
            this.UserPage.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // offButton
            // 
            this.offButton.BackColor = System.Drawing.Color.Gray;
            this.offButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.offButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.offButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.offButton.ForeColor = System.Drawing.Color.White;
            this.offButton.Location = new System.Drawing.Point(107, 221);
            this.offButton.Margin = new System.Windows.Forms.Padding(0);
            this.offButton.Name = "offButton";
            this.offButton.Size = new System.Drawing.Size(120, 51);
            this.offButton.TabIndex = 8;
            this.offButton.Text = "OFF";
            this.offButton.UseVisualStyleBackColor = false;
            this.offButton.Click += new System.EventHandler(this.OffButton_Click);
            // 
            // dim
            // 
            this.dim.BackColor = System.Drawing.Color.Gray;
            this.dim.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dim.ForeColor = System.Drawing.Color.White;
            this.dim.Location = new System.Drawing.Point(52, 138);
            this.dim.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dim.Name = "dim";
            this.dim.Size = new System.Drawing.Size(57, 27);
            this.dim.TabIndex = 7;
            this.dim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dim.ValueChanged += new System.EventHandler(this.On_dim_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 106);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Dimmer";
            // 
            // onButton
            // 
            this.onButton.BackColor = System.Drawing.Color.Gray;
            this.onButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.onButton.FlatAppearance.BorderSize = 0;
            this.onButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.onButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.onButton.ForeColor = System.Drawing.Color.White;
            this.onButton.Location = new System.Drawing.Point(462, 221);
            this.onButton.Margin = new System.Windows.Forms.Padding(0);
            this.onButton.Name = "onButton";
            this.onButton.Size = new System.Drawing.Size(120, 51);
            this.onButton.TabIndex = 3;
            this.onButton.Text = "ON";
            this.onButton.UseVisualStyleBackColor = false;
            this.onButton.Click += new System.EventHandler(this.OnButton_Click);
            // 
            // progressbar
            // 
            this.progressbar.BackColor = System.Drawing.Color.Silver;
            this.progressbar.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressbar.Location = new System.Drawing.Point(0, 345);
            this.progressbar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(669, 41);
            this.progressbar.TabIndex = 26;
            this.progressbar.UseCustomBackColor = true;
            this.progressbar.UseWaitCursor = true;
            // 
            // dimtrack
            // 
            this.dimtrack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dimtrack.LargeChange = 30;
            this.dimtrack.Location = new System.Drawing.Point(135, 138);
            this.dimtrack.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dimtrack.MouseWheelBarPartitions = 30;
            this.dimtrack.Name = "dimtrack";
            this.dimtrack.Size = new System.Drawing.Size(433, 24);
            this.dimtrack.SmallChange = 30;
            this.dimtrack.TabIndex = 31;
            this.dimtrack.Text = "dimtrack";
            this.dimtrack.UseCustomBackColor = true;
            this.dimtrack.ValueChanged += new System.EventHandler(this.On_dimTrack_ValueChanged);
            // 
            // dimLed
            // 
            this.dimLed.AutoSize = true;
            this.dimLed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dimLed.ForeColor = System.Drawing.Color.Orange;
            this.dimLed.Location = new System.Drawing.Point(304, 92);
            this.dimLed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dimLed.Name = "dimLed";
            this.dimLed.Size = new System.Drawing.Size(108, 31);
            this.dimLed.TabIndex = 32;
            this.dimLed.Text = "Dimmer";
            // 
            // minUserLabel
            // 
            this.minUserLabel.AutoSize = true;
            this.minUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minUserLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.minUserLabel.Location = new System.Drawing.Point(135, 165);
            this.minUserLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minUserLabel.Name = "minUserLabel";
            this.minUserLabel.Size = new System.Drawing.Size(28, 15);
            this.minUserLabel.TabIndex = 34;
            this.minUserLabel.Text = "min";
            this.minUserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // maxUserLabel
            // 
            this.maxUserLabel.AutoSize = true;
            this.maxUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxUserLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.maxUserLabel.Location = new System.Drawing.Point(537, 165);
            this.maxUserLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.maxUserLabel.Name = "maxUserLabel";
            this.maxUserLabel.Size = new System.Drawing.Size(31, 15);
            this.maxUserLabel.TabIndex = 35;
            this.maxUserLabel.Text = "max";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.UserPage);
            this.tabControl1.Controls.Add(this.AdminPage);
            this.tabControl1.Location = new System.Drawing.Point(226, 13);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(677, 421);
            this.tabControl1.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(915, 447);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(1920, 1107);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arduino Console";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.idLed)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.device_id)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.AdminPage.ResumeLayout(false);
            this.AdminPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minDimValue)).EndInit();
            this.AdminGroup.ResumeLayout(false);
            this.AdminGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxDimValue)).EndInit();
            this.UserPage.ResumeLayout(false);
            this.UserPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dim)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown idLed;
        private System.Windows.Forms.Button on2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown device_id;
        private ReaLTaiizor.Controls.CheckBox adminChecked;
        private ReaLTaiizor.Controls.FoxCheckBox foxCheckBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label noIdLabel;
        private System.Windows.Forms.Label portErrorLabel;
        private ReaLTaiizor.Controls.ForeverButton connectButton;
        private ReaLTaiizor.Controls.PoisonComboBox selectComPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage AdminPage;
        private ReaLTaiizor.Controls.MetroLabel adminLabel;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.CheckBox disableControls;
        private System.Windows.Forms.NumericUpDown maxDimValue;
        private System.Windows.Forms.Button setMaxButton;
        private System.Windows.Forms.Label maxValueLabel;
        private System.Windows.Forms.Label passwordNotValidLabel;
        private System.Windows.Forms.Button setMinButton;
        private System.Windows.Forms.GroupBox AdminGroup;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label minValueLabel;
        private System.Windows.Forms.NumericUpDown minDimValue;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.TabPage UserPage;
        private System.Windows.Forms.Label maxUserLabel;
        private System.Windows.Forms.Label minUserLabel;
        private System.Windows.Forms.Label dimLed;
        private ReaLTaiizor.Controls.PoisonTrackBar dimtrack;
        private ReaLTaiizor.Controls.PoisonProgressBar progressbar;
        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown dim;
        private System.Windows.Forms.Button offButton;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

