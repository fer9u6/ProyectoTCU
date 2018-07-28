namespace ProyectoTCU
{
    partial class Neighborhood
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Neighborhood));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backB = new System.Windows.Forms.Button();
            this.labelquestion = new System.Windows.Forms.Label();
            this.o1 = new System.Windows.Forms.Button();
            this.o2 = new System.Windows.Forms.Button();
            this.pictureBoxRespuesta = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRespuesta)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProyectoTCU.Properties.Resources.city___Copy1;
            this.pictureBox1.Location = new System.Drawing.Point(153, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(740, 437);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // backB
            // 
            this.backB.BackColor = System.Drawing.Color.White;
            this.backB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backB.BackgroundImage")));
            this.backB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.backB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backB.Location = new System.Drawing.Point(12, 12);
            this.backB.Name = "backB";
            this.backB.Size = new System.Drawing.Size(70, 60);
            this.backB.TabIndex = 4;
            this.backB.UseVisualStyleBackColor = false;
            this.backB.Click += new System.EventHandler(this.backB_Click);
            // 
            // labelquestion
            // 
            this.labelquestion.AutoSize = true;
            this.labelquestion.Font = new System.Drawing.Font("Open Sans Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelquestion.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelquestion.Location = new System.Drawing.Point(242, 498);
            this.labelquestion.Name = "labelquestion";
            this.labelquestion.Size = new System.Drawing.Size(86, 33);
            this.labelquestion.TabIndex = 6;
            this.labelquestion.Text = "label1";
            this.labelquestion.Click += new System.EventHandler(this.labelquestion_Click);
            // 
            // o1
            // 
            this.o1.BackColor = System.Drawing.Color.Gold;
            this.o1.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.o1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.o1.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.o1.Location = new System.Drawing.Point(153, 609);
            this.o1.Name = "o1";
            this.o1.Size = new System.Drawing.Size(365, 51);
            this.o1.TabIndex = 7;
            this.o1.Text = "button1";
            this.o1.UseVisualStyleBackColor = false;
            this.o1.Click += new System.EventHandler(this.o1_Click);
            // 
            // o2
            // 
            this.o2.BackColor = System.Drawing.Color.Gold;
            this.o2.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.o2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.o2.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.o2.Location = new System.Drawing.Point(587, 607);
            this.o2.Name = "o2";
            this.o2.Size = new System.Drawing.Size(365, 53);
            this.o2.TabIndex = 8;
            this.o2.Text = "button2";
            this.o2.UseVisualStyleBackColor = false;
            this.o2.Click += new System.EventHandler(this.o1_Click);
            // 
            // pictureBoxRespuesta
            // 
            this.pictureBoxRespuesta.Location = new System.Drawing.Point(587, 498);
            this.pictureBoxRespuesta.Name = "pictureBoxRespuesta";
            this.pictureBoxRespuesta.Size = new System.Drawing.Size(91, 65);
            this.pictureBoxRespuesta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRespuesta.TabIndex = 21;
            this.pictureBoxRespuesta.TabStop = false;
            // 
            // Neighborhood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(991, 702);
            this.Controls.Add(this.pictureBoxRespuesta);
            this.Controls.Add(this.o2);
            this.Controls.Add(this.o1);
            this.Controls.Add(this.labelquestion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.backB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Neighborhood";
            this.Text = "TCU-501 UCR";
            this.Load += new System.EventHandler(this.Neighborhood_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRespuesta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelquestion;
        private System.Windows.Forms.Button o1;
        private System.Windows.Forms.Button o2;
        private System.Windows.Forms.PictureBox pictureBoxRespuesta;
    }
}