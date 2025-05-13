namespace Repaso_parcial
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.registroLibroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lecturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMUsuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroLibroToolStripMenuItem,
            this.lecturaToolStripMenuItem,
            this.aBMUsuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // registroLibroToolStripMenuItem
            // 
            this.registroLibroToolStripMenuItem.Name = "registroLibroToolStripMenuItem";
            this.registroLibroToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.registroLibroToolStripMenuItem.Text = "ABM libros";
            this.registroLibroToolStripMenuItem.Click += new System.EventHandler(this.registroLibroToolStripMenuItem_Click);
            // 
            // lecturaToolStripMenuItem
            // 
            this.lecturaToolStripMenuItem.Name = "lecturaToolStripMenuItem";
            this.lecturaToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.lecturaToolStripMenuItem.Text = "Lectura";
            this.lecturaToolStripMenuItem.Click += new System.EventHandler(this.lecturaToolStripMenuItem_Click);
            // 
            // aBMUsuToolStripMenuItem
            // 
            this.aBMUsuToolStripMenuItem.Name = "aBMUsuToolStripMenuItem";
            this.aBMUsuToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.aBMUsuToolStripMenuItem.Text = "ABM Usuarios";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registroLibroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lecturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMUsuToolStripMenuItem;
    }
}

