
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.getStatus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dimtrack = new System.Windows.Forms.TrackBar();
            this.minDimValue = new System.Windows.Forms.NumericUpDown();
            this.maxDimValue = new System.Windows.Forms.NumericUpDown();
            this.device_id = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.minLabel = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idLed)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dimtrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minDimValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDimValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.device_id)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.connectButton.ForeColor = System.Drawing.Color.Black;
            this.connectButton.Location = new System.Drawing.Point(28, 134);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(156, 59);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.Connect_Button_Click);
            // 
            // selectedPort
            // 
            this.selectedPort.AccessibleName = "";
            this.selectedPort.FormattingEnabled = true;
            this.selectedPort.Location = new System.Drawing.Point(28, 54);
            this.selectedPort.Name = "selectedPort";
            this.selectedPort.Size = new System.Drawing.Size(156, 23);
            this.selectedPort.TabIndex = 1;
            this.selectedPort.Text = "SELECT COM PORT";
            this.selectedPort.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // onButton
            // 
            this.onButton.BackColor = System.Drawing.Color.Silver;
            this.onButton.Location = new System.Drawing.Point(351, 223);
            this.onButton.Name = "onButton";
            this.onButton.Size = new System.Drawing.Size(120, 48);
            this.onButton.TabIndex = 3;
            this.onButton.Text = "ON";
            this.onButton.UseVisualStyleBackColor = false;
            this.onButton.Click += new System.EventHandler(this.OnButton_Click);
            // 
            // setDim
            // 
            this.setDim.BackColor = System.Drawing.Color.Silver;
            this.setDim.Location = new System.Drawing.Point(26, 224);
            this.setDim.Name = "setDim";
            this.setDim.Size = new System.Drawing.Size(120, 47);
            this.setDim.TabIndex = 5;
            this.setDim.Text = "SET DIM";
            this.setDim.UseVisualStyleBackColor = false;
            this.setDim.Visible = false;
            this.setDim.Click += new System.EventHandler(this.SetDim_Click);
            // 
            // dim
            // 
            this.dim.Location = new System.Drawing.Point(26, 130);
            this.dim.Name = "dim";
            this.dim.Size = new System.Drawing.Size(120, 23);
            this.dim.TabIndex = 7;
            this.dim.ValueChanged += new System.EventHandler(this.On_dim_ValueChanged);
            // 
            // offButton
            // 
            this.offButton.BackColor = System.Drawing.Color.Silver;
            this.offButton.Location = new System.Drawing.Point(191, 224);
            this.offButton.Name = "offButton";
            this.offButton.Size = new System.Drawing.Size(120, 47);
            this.offButton.TabIndex = 8;
            this.offButton.Text = "OFF";
            this.offButton.UseVisualStyleBackColor = false;
            this.offButton.Click += new System.EventHandler(this.OffButton_Click);
            // 
            // idLed
            // 
            this.idLed.Location = new System.Drawing.Point(26, 42);
            this.idLed.Name = "idLed";
            this.idLed.Size = new System.Drawing.Size(120, 23);
            this.idLed.TabIndex = 9;
            this.idLed.ValueChanged += new System.EventHandler(this.On_Id_ValueChanged);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar.Location = new System.Drawing.Point(191, 146);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(442, 36);
            this.progressBar.TabIndex = 11;
            // 
            // getStatus
            // 
            this.getStatus.BackColor = System.Drawing.Color.Silver;
            this.getStatus.Location = new System.Drawing.Point(513, 224);
            this.getStatus.Name = "getStatus";
            this.getStatus.Size = new System.Drawing.Size(120, 47);
            this.getStatus.TabIndex = 12;
            this.getStatus.Text = "START UPDATE STATUS";
            this.getStatus.UseVisualStyleBackColor = false;
            this.getStatus.Click += new System.EventHandler(this.GetStatus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(28, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 13;
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(513, 293);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(120, 23);
            this.statusLabel.TabIndex = 14;
            this.statusLabel.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maxLabel);
            this.groupBox1.Controls.Add(this.minLabel);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dimtrack);
            this.groupBox1.Controls.Add(this.minDimValue);
            this.groupBox1.Controls.Add(this.maxDimValue);
            this.groupBox1.Controls.Add(this.statusLabel);
            this.groupBox1.Controls.Add(this.getStatus);
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Controls.Add(this.idLed);
            this.groupBox1.Controls.Add(this.offButton);
            this.groupBox1.Controls.Add(this.dim);
            this.groupBox1.Controls.Add(this.setDim);
            this.groupBox1.Controls.Add(this.onButton);
            this.groupBox1.Location = new System.Drawing.Point(213, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 342);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Led";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(416, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "SET MAX";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SetMax_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "SET MIN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SetMin_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "Dimmer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(513, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Max";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Id";
            // 
            // dimtrack
            // 
            this.dimtrack.Location = new System.Drawing.Point(191, 108);
            this.dimtrack.Maximum = 100;
            this.dimtrack.Name = "dimtrack";
            this.dimtrack.Size = new System.Drawing.Size(442, 45);
            this.dimtrack.TabIndex = 17;
            this.dimtrack.Scroll += new System.EventHandler(this.On_dimtrack_Scroll);
            // 
            // minDimValue
            // 
            this.minDimValue.Location = new System.Drawing.Point(191, 44);
            this.minDimValue.Name = "minDimValue";
            this.minDimValue.Size = new System.Drawing.Size(120, 23);
            this.minDimValue.TabIndex = 16;
            this.minDimValue.ValueChanged += new System.EventHandler(this.SetMinDim_ValueChanged);
            // 
            // maxDimValue
            // 
            this.maxDimValue.Location = new System.Drawing.Point(513, 46);
            this.maxDimValue.Name = "maxDimValue";
            this.maxDimValue.Size = new System.Drawing.Size(120, 23);
            this.maxDimValue.TabIndex = 15;
            this.maxDimValue.ValueChanged += new System.EventHandler(this.SetMaxDim_ValueChanged);
            // 
            // device_id
            // 
            this.device_id.Location = new System.Drawing.Point(26, 20);
            this.device_id.Name = "device_id";
            this.device_id.Size = new System.Drawing.Size(120, 23);
            this.device_id.TabIndex = 22;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.device_id);
            this.groupBox2.Location = new System.Drawing.Point(213, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(665, 79);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device ID";
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Location = new System.Drawing.Point(273, 22);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(28, 15);
            this.minLabel.TabIndex = 24;
            this.minLabel.Text = "min";
            this.minLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Location = new System.Drawing.Point(595, 22);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(29, 15);
            this.maxLabel.TabIndex = 25;
            this.maxLabel.Text = "max";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 492);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectedPort);
            this.Controls.Add(this.connectButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idLed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dimtrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minDimValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDimValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.device_id)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ComboBox selectedPort;
        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.Button setDim;
        private System.Windows.Forms.NumericUpDown dim;
        private System.Windows.Forms.Button offButton;
        private System.Windows.Forms.NumericUpDown idLed;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button getStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox statusLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button on2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar dimtrack;
        private System.Windows.Forms.NumericUpDown minDimValue;
        private System.Windows.Forms.NumericUpDown maxDimValue;
        private System.Windows.Forms.NumericUpDown device_id;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.Label minLabel;
    }
}

