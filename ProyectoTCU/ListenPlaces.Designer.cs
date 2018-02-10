namespace ProyectoTCU
{
    partial class ListenPlaces
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backB = new System.Windows.Forms.Button();
            this.pictureBox_next = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.audio_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(251, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Places in my neighborhood\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(214, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "place";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // backB
            // 
            this.backB.BackColor = System.Drawing.Color.LightSkyBlue;
            this.backB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.backB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backB.Image = global::ProyectoTCU.Properties.Resources.back_arrow__1_1;
            this.backB.Location = new System.Drawing.Point(12, 12);
            this.backB.Name = "backB";
            this.backB.Size = new System.Drawing.Size(70, 56);
            this.backB.TabIndex = 5;
            this.backB.UseVisualStyleBackColor = false;
            this.backB.Click += new System.EventHandler(this.backB_Click);
            // 
            // pictureBox_next
            // 
            this.pictureBox_next.Image = global::ProyectoTCU.Properties.Resources.Button_Next_icon___Copy;
            this.pictureBox_next.Location = new System.Drawing.Point(59, 254);
            this.pictureBox_next.Name = "pictureBox_next";
            this.pictureBox_next.Size = new System.Drawing.Size(81, 73);
            this.pictureBox_next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_next.TabIndex = 3;
            this.pictureBox_next.TabStop = false;
            this.pictureBox_next.Click += new System.EventHandler(this.pictureBox_next_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(212, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 246);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // audio_Button
            // 
            this.audio_Button.BackColor = System.Drawing.Color.Yellow;
            this.audio_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.audio_Button.ForeColor = System.Drawing.Color.Yellow;
            this.audio_Button.Image = global::ProyectoTCU.Properties.Resources.speaker__10_;
            this.audio_Button.Location = new System.Drawing.Point(83, 166);
            this.audio_Button.Name = "audio_Button";
            this.audio_Button.Size = new System.Drawing.Size(57, 51);
            this.audio_Button.TabIndex = 1;
            this.audio_Button.UseVisualStyleBackColor = false;
            this.audio_Button.Click += new System.EventHandler(this.audio_Button_Click);
            // 
            // ListenPlaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(698, 444);
            this.Controls.Add(this.backB);
            this.Controls.Add(this.pictureBox_next);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.audio_Button);
            this.Controls.Add(this.label1);
            this.Name = "ListenPlaces";
            this.Text = "ListenPlaces";
            this.Load += new System.EventHandler(this.ListenPlaces_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button audio_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox_next;
        private System.Windows.Forms.Button backB;
    }
}