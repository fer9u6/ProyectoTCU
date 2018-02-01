namespace ProyectoTCU
{
    partial class Diseases2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Diseases2));
            this.playButton = new System.Windows.Forms.Button();
            this.o3 = new System.Windows.Forms.Button();
            this.o1 = new System.Windows.Forms.Button();
            this.backB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelsituation = new System.Windows.Forms.Label();
            this.imageListEnfermedades = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.Chartreuse;
            this.playButton.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(12, 150);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(85, 52);
            this.playButton.TabIndex = 22;
            this.playButton.Text = "Play!";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // o3
            // 
            this.o3.BackColor = System.Drawing.Color.Yellow;
            this.o3.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.o3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.o3.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.o3.Location = new System.Drawing.Point(402, 312);
            this.o3.Name = "o3";
            this.o3.Size = new System.Drawing.Size(270, 39);
            this.o3.TabIndex = 20;
            this.o3.UseVisualStyleBackColor = false;
            this.o3.Click += new System.EventHandler(this.o1_Click);
            // 
            // o1
            // 
            this.o1.BackColor = System.Drawing.Color.Yellow;
            this.o1.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.o1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.o1.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.o1.Location = new System.Drawing.Point(92, 312);
            this.o1.Name = "o1";
            this.o1.Size = new System.Drawing.Size(270, 39);
            this.o1.TabIndex = 18;
            this.o1.UseVisualStyleBackColor = false;
            this.o1.Click += new System.EventHandler(this.o1_Click);
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
            this.backB.TabIndex = 17;
            this.backB.UseVisualStyleBackColor = false;
            this.backB.Click += new System.EventHandler(this.backB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 26);
            this.label1.TabIndex = 23;
            this.label1.Text = "Health problem";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(166, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 83);
            this.panel1.TabIndex = 24;
            // 
            // labelsituation
            // 
            this.labelsituation.AutoSize = true;
            this.labelsituation.Font = new System.Drawing.Font("Open Sans Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelsituation.Location = new System.Drawing.Point(161, 240);
            this.labelsituation.Name = "labelsituation";
            this.labelsituation.Size = new System.Drawing.Size(316, 28);
            this.labelsituation.TabIndex = 25;
            this.labelsituation.Text = "What can we do to feel better?";
            // 
            // imageListEnfermedades
            // 
            this.imageListEnfermedades.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListEnfermedades.ImageStream")));
            this.imageListEnfermedades.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListEnfermedades.Images.SetKeyName(0, "fever - Copy.jpg");
            this.imageListEnfermedades.Images.SetKeyName(1, "toothache - Copy.jpg");
            this.imageListEnfermedades.Images.SetKeyName(2, "cough - Copy.jpg");
            this.imageListEnfermedades.Images.SetKeyName(3, "chiken pox - Copy.jpg");
            this.imageListEnfermedades.Images.SetKeyName(4, "stomachache - Copy.jpg");
            this.imageListEnfermedades.Images.SetKeyName(5, "sore throat - Copy.jpg");
            this.imageListEnfermedades.Images.SetKeyName(6, "sunburn.jpg");
            this.imageListEnfermedades.Images.SetKeyName(7, "headache - Copy.jpg");
            this.imageListEnfermedades.Images.SetKeyName(8, "back-pain - Copy.jpg");
            this.imageListEnfermedades.Images.SetKeyName(9, "bloody nose - Copy.jpg");
            this.imageListEnfermedades.Images.SetKeyName(10, "broken arm - Copy.jpg");
            this.imageListEnfermedades.Images.SetKeyName(11, "bruise.jpg");
            this.imageListEnfermedades.Images.SetKeyName(12, "cut.jpg");
            this.imageListEnfermedades.Images.SetKeyName(13, "insectbite - Copy.jpg");
            // 
            // Diseases2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(740, 415);
            this.Controls.Add(this.labelsituation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.o3);
            this.Controls.Add(this.o1);
            this.Controls.Add(this.backB);
            this.Name = "Diseases2";
            this.Text = "Diseases2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button o3;
        private System.Windows.Forms.Button o1;
        private System.Windows.Forms.Button backB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelsituation;
        private System.Windows.Forms.ImageList imageListEnfermedades;
    }
}