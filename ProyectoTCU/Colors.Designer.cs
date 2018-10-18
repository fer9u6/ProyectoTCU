namespace ProyectoTCU
{
    partial class Colors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Colors));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Dubai", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(437, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 56);
            this.button1.TabIndex = 1;
            this.button1.Text = "Flash cards";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Dubai", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(437, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 59);
            this.button2.TabIndex = 2;
            this.button2.Text = "Play";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ProyectoTCU.Properties.Resources.colorsfc1;
            this.pictureBox3.Location = new System.Drawing.Point(58, 111);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(343, 253);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(292, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 54);
            this.label1.TabIndex = 5;
            this.label1.Text = "Colors";
            // 
            // backB
            // 
            this.backB.BackColor = System.Drawing.Color.LightCyan;
            this.backB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backB.BackgroundImage")));
            this.backB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.backB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backB.Location = new System.Drawing.Point(12, 12);
            this.backB.Name = "backB";
            this.backB.Size = new System.Drawing.Size(70, 60);
            this.backB.TabIndex = 6;
            this.backB.UseVisualStyleBackColor = false;
            this.backB.Click += new System.EventHandler(this.backB_Click);
            // 
            // Colors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(705, 403);
            this.Controls.Add(this.backB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Colors";
            this.Text = "TCU-501 UCR";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backB;
    }
}