namespace Zombie
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelNaboje = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.HealthBar = new System.Windows.Forms.Label();
            this.ZivotyBar = new System.Windows.Forms.ProgressBar();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.hrac = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.hrac)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNaboje
            // 
            this.labelNaboje.AutoSize = true;
            this.labelNaboje.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelNaboje.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelNaboje.Location = new System.Drawing.Point(16, 11);
            this.labelNaboje.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNaboje.Name = "labelNaboje";
            this.labelNaboje.Size = new System.Drawing.Size(123, 29);
            this.labelNaboje.TabIndex = 1;
            this.labelNaboje.Text = "Náboje : 0";
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelBody.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelBody.Location = new System.Drawing.Point(488, 12);
            this.labelBody.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(93, 29);
            this.labelBody.TabIndex = 2;
            this.labelBody.Text = "Body: 0";
            // 
            // HealthBar
            // 
            this.HealthBar.AutoSize = true;
            this.HealthBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.HealthBar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.HealthBar.Location = new System.Drawing.Point(869, 13);
            this.HealthBar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HealthBar.Name = "HealthBar";
            this.HealthBar.Size = new System.Drawing.Size(81, 29);
            this.HealthBar.TabIndex = 3;
            this.HealthBar.Text = "Životy:";
            // 
            // ZivotyBar
            // 
            this.ZivotyBar.Location = new System.Drawing.Point(958, 13);
            this.ZivotyBar.Margin = new System.Windows.Forms.Padding(4);
            this.ZivotyBar.Name = "ZivotyBar";
            this.ZivotyBar.Size = new System.Drawing.Size(230, 28);
            this.ZivotyBar.TabIndex = 4;
            this.ZivotyBar.Value = 100;
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.Timer);
            // 
            // hrac
            // 
            this.hrac.Image = global::Zombie.Properties.Resources.up;
            this.hrac.Location = new System.Drawing.Point(544, 514);
            this.hrac.Margin = new System.Windows.Forms.Padding(4);
            this.hrac.Name = "hrac";
            this.hrac.Size = new System.Drawing.Size(71, 100);
            this.hrac.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.hrac.TabIndex = 0;
            this.hrac.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1201, 670);
            this.Controls.Add(this.ZivotyBar);
            this.Controls.Add(this.HealthBar);
            this.Controls.Add(this.labelBody);
            this.Controls.Add(this.labelNaboje);
            this.Controls.Add(this.hrac);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = " ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyZmacknut);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyNezmacknut);
            ((System.ComponentModel.ISupportInitialize)(this.hrac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox hrac;
        private System.Windows.Forms.Label labelNaboje;
        private System.Windows.Forms.Label labelBody;
        private System.Windows.Forms.Label HealthBar;
        private System.Windows.Forms.ProgressBar ZivotyBar;
        private System.Windows.Forms.Timer GameTimer;
    }
}

