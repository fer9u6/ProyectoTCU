namespace ProyectoTCU
{
    partial class PrepositionsCity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrepositionsCity));
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backB = new System.Windows.Forms.Button();
            this.pictureBox_next = new System.Windows.Forms.PictureBox();
            this.audio_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_next)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(185, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "place";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(183, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(399, 265);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // backB
            // 
            this.backB.BackColor = System.Drawing.Color.LightSkyBlue;
            this.backB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backB.BackgroundImage")));
            this.backB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.backB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backB.Location = new System.Drawing.Point(12, 12);
            this.backB.Name = "backB";
            this.backB.Size = new System.Drawing.Size(70, 60);
            this.backB.TabIndex = 11;
            this.backB.UseVisualStyleBackColor = false;
            this.backB.Click += new System.EventHandler(this.backB_Click);
            // 
            // pictureBox_next
            // 
            this.pictureBox_next.Image = global::ProyectoTCU.Properties.Resources.Button_Next_icon___Copy;
            this.pictureBox_next.Location = new System.Drawing.Point(25, 259);
            this.pictureBox_next.Name = "pictureBox_next";
            this.pictureBox_next.Size = new System.Drawing.Size(107, 73);
            this.pictureBox_next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_next.TabIndex = 10;
            this.pictureBox_next.TabStop = false;
            this.pictureBox_next.Click += new System.EventHandler(this.pictureBox_next_Click);
            // 
            // audio_Button
            // 
            this.audio_Button.BackColor = System.Drawing.Color.Yellow;
            this.audio_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.audio_Button.ForeColor = System.Drawing.Color.Yellow;
            this.audio_Button.Image = global::ProyectoTCU.Properties.Resources.speaker__10_;
            this.audio_Button.Location = new System.Drawing.Point(41, 163);
            this.audio_Button.Name = "audio_Button";
            this.audio_Button.Size = new System.Drawing.Size(57, 51);
            this.audio_Button.TabIndex = 8;
            this.audio_Button.UseVisualStyleBackColor = false;
            this.audio_Button.Click += new System.EventHandler(this.audio_Button_Click);
            // 
            // PrepositionsCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(681, 461);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.backB);
            this.Controls.Add(this.pictureBox_next);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.audio_Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrepositionsCity";
            this.Text = "TCU-501 UCR";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_next)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backB;
        private System.Windows.Forms.PictureBox pictureBox_next;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button audio_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}