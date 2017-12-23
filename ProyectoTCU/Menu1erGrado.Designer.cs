namespace ProyectoTCU
{
    partial class Menu1erGrado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu1erGrado));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(55, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Things in my classroom";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(55, 218);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 43);
            this.button2.TabIndex = 1;
            this.button2.Text = "My neighborhood";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(215, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose the game";
            // 
            // backB
            // 
            this.backB.BackColor = System.Drawing.Color.White;
            this.backB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backB.BackgroundImage")));
            this.backB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.backB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backB.Location = new System.Drawing.Point(22, 30);
            this.backB.Name = "backB";
            this.backB.Size = new System.Drawing.Size(70, 60);
            this.backB.TabIndex = 3;
            this.backB.UseVisualStyleBackColor = false;
            this.backB.Click += new System.EventHandler(this.backB_Click);
            this.backB.MouseLeave += new System.EventHandler(this.backB_MouseLeave);
            this.backB.MouseHover += new System.EventHandler(this.backB_MouseHover);
            // 
            // Menu1erGrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(669, 380);
            this.Controls.Add(this.backB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Menu1erGrado";
            this.Text = "1er Grade";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backB;
    }
}