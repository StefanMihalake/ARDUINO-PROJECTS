
namespace LedStrip
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
            this.colorPicker = new ReaLTaiizor.Controls.ParrotColorPicker();
            this.airButton1 = new ReaLTaiizor.Controls.AirButton();
            this.airButton2 = new ReaLTaiizor.Controls.AirButton();
            this.dungeonHeaderLabel1 = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialogButton = new ReaLTaiizor.Controls.AirButton();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // colorPicker
            // 
            this.colorPicker.Location = new System.Drawing.Point(23, 12);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.PickerImage = ((System.Drawing.Image)(resources.GetObject("colorPicker.PickerImage")));
            this.colorPicker.SelectedColor = System.Drawing.Color.Empty;
            this.colorPicker.ShowColorPreview = true;
            this.colorPicker.Size = new System.Drawing.Size(193, 188);
            this.colorPicker.TabIndex = 0;
            this.colorPicker.Text = "colorPicker";
            this.colorPicker.Click += new System.EventHandler(this.colorPicker_Click);
            // 
            // airButton1
            // 
            this.airButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.airButton1.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.airButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.airButton1.Image = null;
            this.airButton1.Location = new System.Drawing.Point(351, 99);
            this.airButton1.Name = "airButton1";
            this.airButton1.NoRounding = false;
            this.airButton1.Size = new System.Drawing.Size(100, 45);
            this.airButton1.TabIndex = 1;
            this.airButton1.Text = "ON";
            this.airButton1.Transparent = false;
            this.airButton1.Click += new System.EventHandler(this.airButton1_Click);
            // 
            // airButton2
            // 
            this.airButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.airButton2.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.airButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.airButton2.Image = null;
            this.airButton2.Location = new System.Drawing.Point(351, 242);
            this.airButton2.Name = "airButton2";
            this.airButton2.NoRounding = false;
            this.airButton2.Size = new System.Drawing.Size(100, 45);
            this.airButton2.TabIndex = 2;
            this.airButton2.Text = "OFF";
            this.airButton2.Transparent = false;
            this.airButton2.Click += new System.EventHandler(this.airButton2_Click);
            // 
            // dungeonHeaderLabel1
            // 
            this.dungeonHeaderLabel1.AutoSize = true;
            this.dungeonHeaderLabel1.BackColor = System.Drawing.Color.Transparent;
            this.dungeonHeaderLabel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dungeonHeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.dungeonHeaderLabel1.Location = new System.Drawing.Point(476, 179);
            this.dungeonHeaderLabel1.Name = "dungeonHeaderLabel1";
            this.dungeonHeaderLabel1.Size = new System.Drawing.Size(78, 19);
            this.dungeonHeaderLabel1.TabIndex = 6;
            this.dungeonHeaderLabel1.Text = "Brightness";
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.colorPanel.Location = new System.Drawing.Point(23, 327);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(531, 45);
            this.colorPanel.TabIndex = 7;
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(573, 12);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 360);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // colorDialogButton
            // 
            this.colorDialogButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorDialogButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.colorDialogButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colorDialogButton.Image = null;
            this.colorDialogButton.Location = new System.Drawing.Point(70, 242);
            this.colorDialogButton.Name = "colorDialogButton";
            this.colorDialogButton.NoRounding = false;
            this.colorDialogButton.Size = new System.Drawing.Size(100, 45);
            this.colorDialogButton.TabIndex = 9;
            this.colorDialogButton.Text = "COLOR Dialog";
            this.colorDialogButton.Transparent = false;
            this.colorDialogButton.Click += new System.EventHandler(this.colorDialog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 384);
            this.Controls.Add(this.colorDialogButton);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.dungeonHeaderLabel1);
            this.Controls.Add(this.airButton2);
            this.Controls.Add(this.airButton1);
            this.Controls.Add(this.colorPicker);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.ParrotColorPicker colorPicker;
        private ReaLTaiizor.Controls.AirButton airButton1;
        private ReaLTaiizor.Controls.AirButton airButton2;
        private ReaLTaiizor.Controls.DungeonHeaderLabel dungeonHeaderLabel1;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private ReaLTaiizor.Controls.AirButton colorDialogButton;
    }
}

