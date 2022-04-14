
namespace ArduinoConsole
{
    partial class ArduinoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArduinoForm));
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deviceId = new ReaLTaiizor.Controls.CrownNumeric();
            this.slave_id = new ReaLTaiizor.Controls.CrownNumeric();
            this.noIdLabel = new System.Windows.Forms.Label();
            this.portErrorLabel = new System.Windows.Forms.Label();
            this.connectButton = new ReaLTaiizor.Controls.ForeverButton();
            this.selectComPort = new ReaLTaiizor.Controls.PoisonComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AdminPage = new System.Windows.Forms.TabPage();
            this.adminPannel = new System.Windows.Forms.Panel();
            this.setMinButton = new System.Windows.Forms.Button();
            this.minLabel = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            this.minDimValue = new System.Windows.Forms.NumericUpDown();
            this.minValueLabel = new System.Windows.Forms.Label();
            this.maxDimValue = new System.Windows.Forms.NumericUpDown();
            this.maxValueLabel = new System.Windows.Forms.Label();
            this.setMaxButton = new System.Windows.Forms.Button();
            this.startWorker = new System.Windows.Forms.Button();
            this.disableControls = new System.Windows.Forms.CheckBox();
            this.passwordNotValidLabel = new System.Windows.Forms.Label();
            this.AdminGroup = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.adminLabel = new ReaLTaiizor.Controls.MetroLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.UserPage = new System.Windows.Forms.TabPage();
            this.userPannel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.maxUserLabel = new System.Windows.Forms.Label();
            this.offButton = new System.Windows.Forms.Button();
            this.minUserLabel = new System.Windows.Forms.Label();
            this.dim = new System.Windows.Forms.NumericUpDown();
            this.dimLed = new System.Windows.Forms.Label();
            this.onButton = new System.Windows.Forms.Button();
            this.dimtrack = new ReaLTaiizor.Controls.PoisonTrackBar();
            this.errorResponseLabel = new ReaLTaiizor.Controls.BigLabel();
            this.progressbar = new ReaLTaiizor.Controls.PoisonProgressBar();
            this.Neopixel = new System.Windows.Forms.TabPage();
            this.neoPannel = new System.Windows.Forms.Panel();
            this.brightnessLabel = new ReaLTaiizor.Controls.BigLabel();
            this.colorpicker = new ReaLTaiizor.Controls.ParrotColorPicker();
            this.label1 = new System.Windows.Forms.Label();
            this.onPixel = new ReaLTaiizor.Controls.ForeverButton();
            this.brightnessSet = new System.Windows.Forms.NumericUpDown();
            this.offPixel = new ReaLTaiizor.Controls.ForeverButton();
            this.colorDialog = new ReaLTaiizor.Controls.ForeverButton();
            this.colorpanel = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deviceId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slave_id)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.AdminPage.SuspendLayout();
            this.adminPannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minDimValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDimValue)).BeginInit();
            this.AdminGroup.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.UserPage.SuspendLayout();
            this.userPannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dim)).BeginInit();
            this.Neopixel.SuspendLayout();
            this.neoPannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Device Id";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.deviceId);
            this.groupBox2.Controls.Add(this.slave_id);
            this.groupBox2.Controls.Add(this.noIdLabel);
            this.groupBox2.Controls.Add(this.label2);
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
            // deviceId
            // 
            this.deviceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deviceId.Location = new System.Drawing.Point(47, 79);
            this.deviceId.Name = "deviceId";
            this.deviceId.Size = new System.Drawing.Size(103, 30);
            this.deviceId.TabIndex = 34;
            this.deviceId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.deviceId.ValueChanged += new System.EventHandler(this.On_Id_ValueChanged);
            // 
            // slave_id
            // 
            this.slave_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.slave_id.Location = new System.Drawing.Point(50, 20);
            this.slave_id.Name = "slave_id";
            this.slave_id.Size = new System.Drawing.Size(100, 30);
            this.slave_id.TabIndex = 33;
            this.slave_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // noIdLabel
            // 
            this.noIdLabel.AutoSize = true;
            this.noIdLabel.BackColor = System.Drawing.Color.Transparent;
            this.noIdLabel.ForeColor = System.Drawing.Color.Red;
            this.noIdLabel.Location = new System.Drawing.Point(47, 115);
            this.noIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noIdLabel.Name = "noIdLabel";
            this.noIdLabel.Size = new System.Drawing.Size(124, 18);
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
            this.portErrorLabel.Size = new System.Drawing.Size(73, 19);
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
            this.selectComPort.ItemHeight = 24;
            this.selectComPort.Location = new System.Drawing.Point(21, 48);
            this.selectComPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.selectComPort.Name = "selectComPort";
            this.selectComPort.Size = new System.Drawing.Size(156, 30);
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
            this.AdminPage.Controls.Add(this.adminPannel);
            this.AdminPage.Controls.Add(this.startWorker);
            this.AdminPage.Controls.Add(this.disableControls);
            this.AdminPage.Controls.Add(this.passwordNotValidLabel);
            this.AdminPage.Controls.Add(this.AdminGroup);
            this.AdminPage.Location = new System.Drawing.Point(4, 28);
            this.AdminPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AdminPage.Name = "AdminPage";
            this.AdminPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AdminPage.Size = new System.Drawing.Size(669, 389);
            this.AdminPage.TabIndex = 1;
            this.AdminPage.Text = "Admin";
            // 
            // adminPannel
            // 
            this.adminPannel.Controls.Add(this.setMinButton);
            this.adminPannel.Controls.Add(this.minLabel);
            this.adminPannel.Controls.Add(this.maxLabel);
            this.adminPannel.Controls.Add(this.minDimValue);
            this.adminPannel.Controls.Add(this.minValueLabel);
            this.adminPannel.Controls.Add(this.maxDimValue);
            this.adminPannel.Controls.Add(this.maxValueLabel);
            this.adminPannel.Controls.Add(this.setMaxButton);
            this.adminPannel.Location = new System.Drawing.Point(20, 147);
            this.adminPannel.Name = "adminPannel";
            this.adminPannel.Size = new System.Drawing.Size(628, 124);
            this.adminPannel.TabIndex = 40;
            this.adminPannel.Visible = false;
            // 
            // setMinButton
            // 
            this.setMinButton.BackColor = System.Drawing.Color.Gray;
            this.setMinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setMinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.setMinButton.ForeColor = System.Drawing.Color.White;
            this.setMinButton.Location = new System.Drawing.Point(33, 13);
            this.setMinButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.setMinButton.Name = "setMinButton";
            this.setMinButton.Size = new System.Drawing.Size(114, 48);
            this.setMinButton.TabIndex = 22;
            this.setMinButton.Text = "SET MIN";
            this.setMinButton.UseVisualStyleBackColor = false;
            this.setMinButton.Click += new System.EventHandler(this.SetMin_Click);
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Location = new System.Drawing.Point(119, 98);
            this.minLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(34, 19);
            this.minLabel.TabIndex = 19;
            this.minLabel.Text = "Min";
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Location = new System.Drawing.Point(431, 95);
            this.maxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(37, 19);
            this.maxLabel.TabIndex = 20;
            this.maxLabel.Text = "Max";
            // 
            // minDimValue
            // 
            this.minDimValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.minDimValue.Location = new System.Drawing.Point(188, 29);
            this.minDimValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.minDimValue.Name = "minDimValue";
            this.minDimValue.Size = new System.Drawing.Size(120, 27);
            this.minDimValue.TabIndex = 16;
            // 
            // minValueLabel
            // 
            this.minValueLabel.AutoSize = true;
            this.minValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minValueLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.minValueLabel.Location = new System.Drawing.Point(188, 85);
            this.minValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minValueLabel.Name = "minValueLabel";
            this.minValueLabel.Size = new System.Drawing.Size(72, 39);
            this.minValueLabel.TabIndex = 24;
            this.minValueLabel.Text = "min";
            this.minValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // maxDimValue
            // 
            this.maxDimValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.maxDimValue.Location = new System.Drawing.Point(476, 29);
            this.maxDimValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.maxDimValue.Name = "maxDimValue";
            this.maxDimValue.Size = new System.Drawing.Size(120, 27);
            this.maxDimValue.TabIndex = 15;
            // 
            // maxValueLabel
            // 
            this.maxValueLabel.AutoSize = true;
            this.maxValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxValueLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.maxValueLabel.Location = new System.Drawing.Point(495, 81);
            this.maxValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.maxValueLabel.Name = "maxValueLabel";
            this.maxValueLabel.Size = new System.Drawing.Size(81, 39);
            this.maxValueLabel.TabIndex = 25;
            this.maxValueLabel.Text = "max";
            // 
            // setMaxButton
            // 
            this.setMaxButton.BackColor = System.Drawing.Color.Gray;
            this.setMaxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setMaxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.setMaxButton.ForeColor = System.Drawing.Color.White;
            this.setMaxButton.Location = new System.Drawing.Point(342, 13);
            this.setMaxButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.setMaxButton.Name = "setMaxButton";
            this.setMaxButton.Size = new System.Drawing.Size(112, 48);
            this.setMaxButton.TabIndex = 23;
            this.setMaxButton.Text = "SET MAX";
            this.setMaxButton.UseVisualStyleBackColor = false;
            this.setMaxButton.Click += new System.EventHandler(this.SetMax_Click);
            // 
            // startWorker
            // 
            this.startWorker.BackColor = System.Drawing.Color.Gray;
            this.startWorker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startWorker.ForeColor = System.Drawing.Color.White;
            this.startWorker.Location = new System.Drawing.Point(538, 344);
            this.startWorker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.startWorker.Name = "startWorker";
            this.startWorker.Size = new System.Drawing.Size(123, 39);
            this.startWorker.TabIndex = 39;
            this.startWorker.Text = "START WORKER";
            this.startWorker.UseVisualStyleBackColor = false;
            this.startWorker.Click += new System.EventHandler(this.startWorker_Click);
            // 
            // disableControls
            // 
            this.disableControls.AutoSize = true;
            this.disableControls.Location = new System.Drawing.Point(20, 355);
            this.disableControls.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.disableControls.Name = "disableControls";
            this.disableControls.Size = new System.Drawing.Size(138, 23);
            this.disableControls.TabIndex = 36;
            this.disableControls.Text = "Disable controls";
            this.disableControls.UseVisualStyleBackColor = true;
            this.disableControls.CheckedChanged += new System.EventHandler(this.DisableControls_CheckedChanged);
            // 
            // passwordNotValidLabel
            // 
            this.passwordNotValidLabel.AutoSize = true;
            this.passwordNotValidLabel.BackColor = System.Drawing.Color.Transparent;
            this.passwordNotValidLabel.ForeColor = System.Drawing.Color.Red;
            this.passwordNotValidLabel.Location = new System.Drawing.Point(451, 67);
            this.passwordNotValidLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordNotValidLabel.Name = "passwordNotValidLabel";
            this.passwordNotValidLabel.Size = new System.Drawing.Size(133, 19);
            this.passwordNotValidLabel.TabIndex = 30;
            this.passwordNotValidLabel.Text = "Password not valid";
            // 
            // AdminGroup
            // 
            this.AdminGroup.BackColor = System.Drawing.Color.Transparent;
            this.AdminGroup.Controls.Add(this.button3);
            this.AdminGroup.Controls.Add(this.passwordTextBox);
            this.AdminGroup.Controls.Add(this.adminLabel);
            this.AdminGroup.Location = new System.Drawing.Point(218, 6);
            this.AdminGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AdminGroup.Name = "AdminGroup";
            this.AdminGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AdminGroup.Size = new System.Drawing.Size(217, 135);
            this.AdminGroup.TabIndex = 29;
            this.AdminGroup.TabStop = false;
            this.AdminGroup.Text = "Admin";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(75, 90);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 24);
            this.button3.TabIndex = 27;
            this.button3.Text = "Login";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.LoginAdmin_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.passwordTextBox.Location = new System.Drawing.Point(47, 61);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.PlaceholderText = "          Password";
            this.passwordTextBox.Size = new System.Drawing.Size(119, 27);
            this.passwordTextBox.TabIndex = 26;
            // 
            // adminLabel
            // 
            this.adminLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.adminLabel.IsDerivedStyle = true;
            this.adminLabel.Location = new System.Drawing.Point(47, 19);
            this.adminLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.adminLabel.Name = "adminLabel";
            this.adminLabel.Size = new System.Drawing.Size(128, 24);
            this.adminLabel.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            this.adminLabel.StyleManager = null;
            this.adminLabel.TabIndex = 38;
            this.adminLabel.Text = "Controls password";
            this.adminLabel.ThemeAuthor = "Taiizor";
            this.adminLabel.ThemeName = "MetroLight";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.UserPage);
            this.tabControl1.Controls.Add(this.AdminPage);
            this.tabControl1.Controls.Add(this.Neopixel);
            this.tabControl1.Location = new System.Drawing.Point(226, 13);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(677, 421);
            this.tabControl1.TabIndex = 37;
            // 
            // UserPage
            // 
            this.UserPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UserPage.Controls.Add(this.userPannel);
            this.UserPage.Controls.Add(this.errorResponseLabel);
            this.UserPage.Controls.Add(this.progressbar);
            this.UserPage.Location = new System.Drawing.Point(4, 28);
            this.UserPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.UserPage.Name = "UserPage";
            this.UserPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.UserPage.Size = new System.Drawing.Size(669, 389);
            this.UserPage.TabIndex = 0;
            this.UserPage.Text = "User";
            // 
            // userPannel
            // 
            this.userPannel.Controls.Add(this.label5);
            this.userPannel.Controls.Add(this.maxUserLabel);
            this.userPannel.Controls.Add(this.offButton);
            this.userPannel.Controls.Add(this.minUserLabel);
            this.userPannel.Controls.Add(this.dim);
            this.userPannel.Controls.Add(this.dimLed);
            this.userPannel.Controls.Add(this.onButton);
            this.userPannel.Controls.Add(this.dimtrack);
            this.userPannel.Location = new System.Drawing.Point(7, 53);
            this.userPannel.Name = "userPannel";
            this.userPannel.Size = new System.Drawing.Size(623, 246);
            this.userPannel.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 19);
            this.label5.TabIndex = 21;
            this.label5.Text = "Dimmer";
            // 
            // maxUserLabel
            // 
            this.maxUserLabel.AutoSize = true;
            this.maxUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxUserLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.maxUserLabel.Location = new System.Drawing.Point(535, 99);
            this.maxUserLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.maxUserLabel.Name = "maxUserLabel";
            this.maxUserLabel.Size = new System.Drawing.Size(36, 18);
            this.maxUserLabel.TabIndex = 35;
            this.maxUserLabel.Text = "max";
            // 
            // offButton
            // 
            this.offButton.BackColor = System.Drawing.Color.Gray;
            this.offButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.offButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.offButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.offButton.ForeColor = System.Drawing.Color.White;
            this.offButton.Location = new System.Drawing.Point(105, 155);
            this.offButton.Margin = new System.Windows.Forms.Padding(0);
            this.offButton.Name = "offButton";
            this.offButton.Size = new System.Drawing.Size(120, 51);
            this.offButton.TabIndex = 8;
            this.offButton.Text = "OFF";
            this.offButton.UseVisualStyleBackColor = false;
            this.offButton.Click += new System.EventHandler(this.OffButton_Click);
            // 
            // minUserLabel
            // 
            this.minUserLabel.AutoSize = true;
            this.minUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minUserLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.minUserLabel.Location = new System.Drawing.Point(133, 99);
            this.minUserLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minUserLabel.Name = "minUserLabel";
            this.minUserLabel.Size = new System.Drawing.Size(32, 18);
            this.minUserLabel.TabIndex = 34;
            this.minUserLabel.Text = "min";
            this.minUserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dim
            // 
            this.dim.BackColor = System.Drawing.Color.Gray;
            this.dim.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dim.ForeColor = System.Drawing.Color.White;
            this.dim.Location = new System.Drawing.Point(50, 72);
            this.dim.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dim.Name = "dim";
            this.dim.Size = new System.Drawing.Size(57, 32);
            this.dim.TabIndex = 7;
            this.dim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dim.ValueChanged += new System.EventHandler(this.On_dim_ValueChanged);
            // 
            // dimLed
            // 
            this.dimLed.AutoSize = true;
            this.dimLed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dimLed.ForeColor = System.Drawing.Color.Orange;
            this.dimLed.Location = new System.Drawing.Point(302, 26);
            this.dimLed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dimLed.Name = "dimLed";
            this.dimLed.Size = new System.Drawing.Size(136, 39);
            this.dimLed.TabIndex = 32;
            this.dimLed.Text = "Dimmer";
            // 
            // onButton
            // 
            this.onButton.BackColor = System.Drawing.Color.Gray;
            this.onButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.onButton.FlatAppearance.BorderSize = 0;
            this.onButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.onButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.onButton.ForeColor = System.Drawing.Color.White;
            this.onButton.Location = new System.Drawing.Point(460, 155);
            this.onButton.Margin = new System.Windows.Forms.Padding(0);
            this.onButton.Name = "onButton";
            this.onButton.Size = new System.Drawing.Size(120, 51);
            this.onButton.TabIndex = 3;
            this.onButton.Text = "ON";
            this.onButton.UseVisualStyleBackColor = false;
            this.onButton.Click += new System.EventHandler(this.OnButton_Click);
            // 
            // dimtrack
            // 
            this.dimtrack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dimtrack.LargeChange = 30;
            this.dimtrack.Location = new System.Drawing.Point(133, 72);
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
            // errorResponseLabel
            // 
            this.errorResponseLabel.AutoSize = true;
            this.errorResponseLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorResponseLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.errorResponseLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.errorResponseLabel.Location = new System.Drawing.Point(7, 348);
            this.errorResponseLabel.Name = "errorResponseLabel";
            this.errorResponseLabel.Size = new System.Drawing.Size(235, 35);
            this.errorResponseLabel.TabIndex = 41;
            this.errorResponseLabel.Text = "errorResponseLabel";
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
            // Neopixel
            // 
            this.Neopixel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Neopixel.Controls.Add(this.neoPannel);
            this.Neopixel.Controls.Add(this.colorpanel);
            this.Neopixel.Location = new System.Drawing.Point(4, 28);
            this.Neopixel.Name = "Neopixel";
            this.Neopixel.Padding = new System.Windows.Forms.Padding(3);
            this.Neopixel.Size = new System.Drawing.Size(669, 389);
            this.Neopixel.TabIndex = 2;
            this.Neopixel.Text = "Neopixel";
            // 
            // neoPannel
            // 
            this.neoPannel.Controls.Add(this.brightnessLabel);
            this.neoPannel.Controls.Add(this.colorpicker);
            this.neoPannel.Controls.Add(this.label1);
            this.neoPannel.Controls.Add(this.onPixel);
            this.neoPannel.Controls.Add(this.brightnessSet);
            this.neoPannel.Controls.Add(this.offPixel);
            this.neoPannel.Controls.Add(this.colorDialog);
            this.neoPannel.Location = new System.Drawing.Point(6, 28);
            this.neoPannel.Name = "neoPannel";
            this.neoPannel.Size = new System.Drawing.Size(635, 301);
            this.neoPannel.TabIndex = 41;
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.AutoSize = true;
            this.brightnessLabel.BackColor = System.Drawing.Color.Transparent;
            this.brightnessLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.brightnessLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.brightnessLabel.Location = new System.Drawing.Point(420, 129);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(89, 23);
            this.brightnessLabel.TabIndex = 48;
            this.brightnessLabel.Text = "Brightness";
            // 
            // colorpicker
            // 
            this.colorpicker.Location = new System.Drawing.Point(57, 3);
            this.colorpicker.Name = "colorpicker";
            this.colorpicker.PickerImage = ((System.Drawing.Image)(resources.GetObject("colorpicker.PickerImage")));
            this.colorpicker.SelectedColor = System.Drawing.Color.Empty;
            this.colorpicker.ShowColorPreview = true;
            this.colorpicker.Size = new System.Drawing.Size(193, 196);
            this.colorpicker.TabIndex = 0;
            this.colorpicker.Text = "parrotColorPicker1";
            this.colorpicker.Click += new System.EventHandler(this.colorpicker_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 19);
            this.label1.TabIndex = 47;
            this.label1.Text = "SET BRIGHTNESS";
            // 
            // onPixel
            // 
            this.onPixel.BackColor = System.Drawing.Color.Silver;
            this.onPixel.BaseColor = System.Drawing.Color.Transparent;
            this.onPixel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.onPixel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.onPixel.Location = new System.Drawing.Point(268, 225);
            this.onPixel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.onPixel.Name = "onPixel";
            this.onPixel.Rounded = false;
            this.onPixel.Size = new System.Drawing.Size(156, 61);
            this.onPixel.TabIndex = 40;
            this.onPixel.Text = "ON";
            this.onPixel.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.onPixel.Click += new System.EventHandler(this.onPixel_Click);
            // 
            // brightnessSet
            // 
            this.brightnessSet.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.brightnessSet.Location = new System.Drawing.Point(357, 86);
            this.brightnessSet.Name = "brightnessSet";
            this.brightnessSet.Size = new System.Drawing.Size(156, 33);
            this.brightnessSet.TabIndex = 46;
            this.brightnessSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.brightnessSet.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // offPixel
            // 
            this.offPixel.BackColor = System.Drawing.Color.Silver;
            this.offPixel.BaseColor = System.Drawing.Color.Transparent;
            this.offPixel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.offPixel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.offPixel.Location = new System.Drawing.Point(461, 225);
            this.offPixel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.offPixel.Name = "offPixel";
            this.offPixel.Rounded = false;
            this.offPixel.Size = new System.Drawing.Size(156, 61);
            this.offPixel.TabIndex = 41;
            this.offPixel.Text = "OFF";
            this.offPixel.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.offPixel.Click += new System.EventHandler(this.offPixel_Click);
            // 
            // colorDialog
            // 
            this.colorDialog.BackColor = System.Drawing.Color.LightSteelBlue;
            this.colorDialog.BaseColor = System.Drawing.Color.Transparent;
            this.colorDialog.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.colorDialog.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colorDialog.Location = new System.Drawing.Point(73, 225);
            this.colorDialog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.colorDialog.Name = "colorDialog";
            this.colorDialog.Rounded = false;
            this.colorDialog.Size = new System.Drawing.Size(156, 61);
            this.colorDialog.TabIndex = 44;
            this.colorDialog.Text = "CUSTOM COLOR";
            this.colorDialog.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.colorDialog.Click += new System.EventHandler(this.colorDialog_Click);
            // 
            // colorpanel
            // 
            this.colorpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(186)))), ((int)(((byte)(3)))));
            this.colorpanel.Location = new System.Drawing.Point(0, 344);
            this.colorpanel.Name = "colorpanel";
            this.colorpanel.Size = new System.Drawing.Size(669, 52);
            this.colorpanel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(943, 453);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(1920, 1107);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arduino Console";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deviceId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slave_id)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.AdminPage.ResumeLayout(false);
            this.AdminPage.PerformLayout();
            this.adminPannel.ResumeLayout(false);
            this.adminPannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minDimValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDimValue)).EndInit();
            this.AdminGroup.ResumeLayout(false);
            this.AdminGroup.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.UserPage.ResumeLayout(false);
            this.UserPage.PerformLayout();
            this.userPannel.ResumeLayout(false);
            this.userPannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dim)).EndInit();
            this.Neopixel.ResumeLayout(false);
            this.neoPannel.ResumeLayout(false);
            this.neoPannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button on2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage UserPage;
        private ReaLTaiizor.Controls.BigLabel errorResponseLabel;
        private System.Windows.Forms.Label maxUserLabel;
        private System.Windows.Forms.Label minUserLabel;
        private System.Windows.Forms.Label dimLed;
        private ReaLTaiizor.Controls.PoisonTrackBar dimtrack;
        private ReaLTaiizor.Controls.PoisonProgressBar progressbar;
        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown dim;
        private System.Windows.Forms.Button offButton;
        private System.Windows.Forms.TabPage Neopixel;
        private ReaLTaiizor.Controls.ParrotColorPicker colorpicker;
        private System.Windows.Forms.Panel colorpanel;
        private ReaLTaiizor.Controls.ForeverButton colorDialog;
        private ReaLTaiizor.Controls.ForeverButton offPixel;
        private ReaLTaiizor.Controls.ForeverButton onPixel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown brightnessSet;
        private System.Windows.Forms.Button startWorker;
        private ReaLTaiizor.Controls.BigLabel brightnessLabel;
        private ReaLTaiizor.Controls.CrownNumeric deviceId;
        private ReaLTaiizor.Controls.CrownNumeric slave_id;
        private System.Windows.Forms.Panel adminPannel;
        private System.Windows.Forms.Panel userPannel;
        private System.Windows.Forms.Panel neoPannel;
    }
}

