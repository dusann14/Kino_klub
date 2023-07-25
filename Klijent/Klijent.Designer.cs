namespace Klijent
{
    partial class Klijent
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iznajmljivanjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaIznajmljivanjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaFilmovaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korisnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.osvezavanjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.oceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filmToolStripMenuItem,
            this.iznajmljivanjeToolStripMenuItem,
            this.pretragaIznajmljivanjaToolStripMenuItem,
            this.oceneToolStripMenuItem,
            this.pretragaFilmovaToolStripMenuItem,
            this.korisnikToolStripMenuItem,
            this.osvezavanjeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(814, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filmToolStripMenuItem
            // 
            this.filmToolStripMenuItem.Name = "filmToolStripMenuItem";
            this.filmToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.filmToolStripMenuItem.Text = "Film";
            // 
            // iznajmljivanjeToolStripMenuItem
            // 
            this.iznajmljivanjeToolStripMenuItem.Name = "iznajmljivanjeToolStripMenuItem";
            this.iznajmljivanjeToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.iznajmljivanjeToolStripMenuItem.Text = "Iznajmljivanje";
            // 
            // pretragaIznajmljivanjaToolStripMenuItem
            // 
            this.pretragaIznajmljivanjaToolStripMenuItem.Name = "pretragaIznajmljivanjaToolStripMenuItem";
            this.pretragaIznajmljivanjaToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.pretragaIznajmljivanjaToolStripMenuItem.Text = "Pretraga iznajmljivanja";
            // 
            // pretragaFilmovaToolStripMenuItem
            // 
            this.pretragaFilmovaToolStripMenuItem.Name = "pretragaFilmovaToolStripMenuItem";
            this.pretragaFilmovaToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.pretragaFilmovaToolStripMenuItem.Text = "Pretraga filmova";
            // 
            // korisnikToolStripMenuItem
            // 
            this.korisnikToolStripMenuItem.Name = "korisnikToolStripMenuItem";
            this.korisnikToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.korisnikToolStripMenuItem.Text = "Korisnik";
            // 
            // osvezavanjeToolStripMenuItem
            // 
            this.osvezavanjeToolStripMenuItem.Name = "osvezavanjeToolStripMenuItem";
            this.osvezavanjeToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.osvezavanjeToolStripMenuItem.Text = "Osvezavanje";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 810);
            this.panel1.TabIndex = 1;
            // 
            // oceneToolStripMenuItem
            // 
            this.oceneToolStripMenuItem.Name = "oceneToolStripMenuItem";
            this.oceneToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.oceneToolStripMenuItem.Text = "Ocene";
            // 
            // Klijent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 838);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Klijent";
            this.Text = "Klijent";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ToolStripMenuItem filmToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem korisnikToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem osvezavanjeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem pretragaFilmovaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem iznajmljivanjeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem pretragaIznajmljivanjaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem oceneToolStripMenuItem;
    }
}

