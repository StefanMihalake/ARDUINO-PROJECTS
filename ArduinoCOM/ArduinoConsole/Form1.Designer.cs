
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
            this.connectButton = new System.Windows.Forms.Button();
            this.selectedPort = new System.Windows.Forms.ComboBox();
            this.onButton = new System.Windows.Forms.Button();
            this.setDim = new System.Windows.Forms.Button();
            this.dim = new System.Windows.Forms.NumericUpDown();
            this.offButton = new System.Windows.Forms.Button();
            this.idLed = new System.Windows.Forms.NumericUpDown();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.getStatus = new System.Windows.Forms.Button();
            this.errorPortAlert = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackDim = new System.Windows.Forms.TrackBar();
            this.noIdAlert = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idLed)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackDim)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.connectButton.ForeColor = System.Drawing.Color.Black;
            this.connectButton.Location = new System.Drawing.Point(18, 108);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(156, 59);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // selectedPort
            // 
            this.selectedPort.AccessibleName = "";
            this.selectedPort.FormattingEnabled = true;
            this.selectedPort.Location = new System.Drawing.Point(18, 52);
            this.selectedPort.Name = "selectedPort";
            this.selectedPort.Size = new System.Drawing.Size(156, 23);
            this.selectedPort.TabIndex = 1;
            this.selectedPort.Text = "SELECT COM PORT";
            this.selectedPort.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // onButton
            // 
            this.onButton.Location = new System.Drawing.Point(203, 25);
            this.onButton.Name = "onButton";
            this.onButton.Size = new System.Drawing.Size(120, 30);
            this.onButton.TabIndex = 3;
            this.onButton.Text = "ON";
            this.onButton.UseVisualStyleBackColor = true;
            this.onButton.Click += new System.EventHandler(this.onButton_Click);
            // 
            // setDim
            // 
            this.setDim.Location = new System.Drawing.Point(203, 67);
            this.setDim.Name = "setDim";
            this.setDim.Size = new System.Drawing.Size(120, 30);
            this.setDim.TabIndex = 5;
            this.setDim.Text = "SET DIM";
            this.setDim.UseVisualStyleBackColor = true;
            this.setDim.Click += new System.EventHandler(this.setDim_Click);
            // 
            // dim
            // 
            this.dim.Location = new System.Drawing.Point(26, 73);
            this.dim.Name = "dim";
            this.dim.Size = new System.Drawing.Size(120, 23);
            this.dim.TabIndex = 7;
            // 
            // offButton
            // 
            this.offButton.Location = new System.Drawing.Point(340, 24);
            this.offButton.Name = "offButton";
            this.offButton.Size = new System.Drawing.Size(120, 30);
            this.offButton.TabIndex = 8;
            this.offButton.Text = "OFF";
            this.offButton.UseVisualStyleBackColor = true;
            this.offButton.Click += new System.EventHandler(this.offButton_Click);
            // 
            // idLed
            // 
            this.idLed.Location = new System.Drawing.Point(26, 30);
            this.idLed.Name = "idLed";
            this.idLed.Size = new System.Drawing.Size(120, 23);
            this.idLed.TabIndex = 9;
            this.idLed.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.progressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar1.Location = new System.Drawing.Point(26, 173);
            this.progressBar1.Maximum = 105;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(434, 26);
            this.progressBar1.TabIndex = 11;
            // 
            // getStatus
            // 
            this.getStatus.Location = new System.Drawing.Point(340, 67);
            this.getStatus.Name = "getStatus";
            this.getStatus.Size = new System.Drawing.Size(120, 30);
            this.getStatus.TabIndex = 12;
            this.getStatus.Text = "GET STATUS";
            this.getStatus.UseVisualStyleBackColor = true;
            this.getStatus.Click += new System.EventHandler(this.getStatus_Click);
            // 
            // errorPortAlert
            // 
            this.errorPortAlert.AutoSize = true;
            this.errorPortAlert.ForeColor = System.Drawing.Color.Red;
            this.errorPortAlert.Location = new System.Drawing.Point(18, 173);
            this.errorPortAlert.Name = "errorPortAlert";
            this.errorPortAlert.Size = new System.Drawing.Size(0, 15);
            this.errorPortAlert.TabIndex = 13;
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(340, 218);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(120, 23);
            this.statusLabel.TabIndex = 14;
            this.statusLabel.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackDim);
            this.groupBox1.Controls.Add(this.noIdAlert);
            this.groupBox1.Controls.Add(this.statusLabel);
            this.groupBox1.Controls.Add(this.getStatus);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.idLed);
            this.groupBox1.Controls.Add(this.offButton);
            this.groupBox1.Controls.Add(this.dim);
            this.groupBox1.Controls.Add(this.setDim);
            this.groupBox1.Controls.Add(this.onButton);
            this.groupBox1.Location = new System.Drawing.Point(252, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 260);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Led";
            // 
            // trackDim
            // 
            this.trackDim.Location = new System.Drawing.Point(26, 112);
            this.trackDim.Maximum = 100;
            this.trackDim.Name = "trackDim";
            this.trackDim.Size = new System.Drawing.Size(434, 45);
            this.trackDim.TabIndex = 16;
            this.trackDim.Scroll += new System.EventHandler(this.trackDim_Scroll);
            // 
            // noIdAlert
            // 
            this.noIdAlert.AutoSize = true;
            this.noIdAlert.BackColor = System.Drawing.SystemColors.Control;
            this.noIdAlert.ForeColor = System.Drawing.Color.Red;
            this.noIdAlert.Location = new System.Drawing.Point(26, 160);
            this.noIdAlert.Name = "noIdAlert";
            this.noIdAlert.Size = new System.Drawing.Size(0, 15);
            this.noIdAlert.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.errorPortAlert);
            this.groupBox2.Controls.Add(this.selectedPort);
            this.groupBox2.Controls.Add(this.connectButton);
            this.groupBox2.Location = new System.Drawing.Point(17, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 259);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connect to Arduino";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 338);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idLed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackDim)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ComboBox selectedPort;
        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.Button setDim;
        private System.Windows.Forms.NumericUpDown dim;
        private System.Windows.Forms.Button offButton;
        private System.Windows.Forms.NumericUpDown idLed;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button getStatus;
        private System.Windows.Forms.Label errorPortAlert;
        private System.Windows.Forms.TextBox statusLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button on2;
        private System.Windows.Forms.Label noIdAlert;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar trackDim;
    }
}

