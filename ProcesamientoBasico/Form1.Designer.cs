namespace ProcesamientoBasico
{
    partial class Form1
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
            this.MSPrincipal = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesBasicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escalaDeGrisesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binarizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negativoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componenteRojoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componenteVerdeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componenteAzulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clasificacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objetosBinariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bordeHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OFIMagen = new System.Windows.Forms.OpenFileDialog();
            this.SFImagen = new System.Windows.Forms.SaveFileDialog();
            this.PBImagen = new System.Windows.Forms.PictureBox();
            this.bordeVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MSPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // MSPrincipal
            // 
            this.MSPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.operacionesBasicasToolStripMenuItem});
            this.MSPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MSPrincipal.Name = "MSPrincipal";
            this.MSPrincipal.Size = new System.Drawing.Size(652, 24);
            this.MSPrincipal.TabIndex = 0;
            this.MSPrincipal.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // operacionesBasicasToolStripMenuItem
            // 
            this.operacionesBasicasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escalaDeGrisesToolStripMenuItem,
            this.binarizacionToolStripMenuItem,
            this.negativoToolStripMenuItem,
            this.componenteRojoToolStripMenuItem,
            this.componenteVerdeToolStripMenuItem,
            this.componenteAzulToolStripMenuItem,
            this.clasificacionToolStripMenuItem,
            this.objetosBinariosToolStripMenuItem,
            this.bordeHorizontalToolStripMenuItem,
            this.bordeVerticalToolStripMenuItem});
            this.operacionesBasicasToolStripMenuItem.Name = "operacionesBasicasToolStripMenuItem";
            this.operacionesBasicasToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.operacionesBasicasToolStripMenuItem.Text = "Operaciones Basicas";
            // 
            // escalaDeGrisesToolStripMenuItem
            // 
            this.escalaDeGrisesToolStripMenuItem.Name = "escalaDeGrisesToolStripMenuItem";
            this.escalaDeGrisesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.escalaDeGrisesToolStripMenuItem.Text = "Escala De Grises";
            this.escalaDeGrisesToolStripMenuItem.Click += new System.EventHandler(this.escalaDeGrisesToolStripMenuItem_Click);
            // 
            // binarizacionToolStripMenuItem
            // 
            this.binarizacionToolStripMenuItem.Name = "binarizacionToolStripMenuItem";
            this.binarizacionToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.binarizacionToolStripMenuItem.Text = "Binarizacion";
            this.binarizacionToolStripMenuItem.Click += new System.EventHandler(this.binarizacionToolStripMenuItem_Click);
            // 
            // negativoToolStripMenuItem
            // 
            this.negativoToolStripMenuItem.Name = "negativoToolStripMenuItem";
            this.negativoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.negativoToolStripMenuItem.Text = "Negativo";
            this.negativoToolStripMenuItem.Click += new System.EventHandler(this.negativoToolStripMenuItem_Click);
            // 
            // componenteRojoToolStripMenuItem
            // 
            this.componenteRojoToolStripMenuItem.Name = "componenteRojoToolStripMenuItem";
            this.componenteRojoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.componenteRojoToolStripMenuItem.Text = "Componente Rojo";
            this.componenteRojoToolStripMenuItem.Click += new System.EventHandler(this.componenteRojoToolStripMenuItem_Click);
            // 
            // componenteVerdeToolStripMenuItem
            // 
            this.componenteVerdeToolStripMenuItem.Name = "componenteVerdeToolStripMenuItem";
            this.componenteVerdeToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.componenteVerdeToolStripMenuItem.Text = "Componente Verde";
            this.componenteVerdeToolStripMenuItem.Click += new System.EventHandler(this.componenteVerdeToolStripMenuItem_Click);
            // 
            // componenteAzulToolStripMenuItem
            // 
            this.componenteAzulToolStripMenuItem.Name = "componenteAzulToolStripMenuItem";
            this.componenteAzulToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.componenteAzulToolStripMenuItem.Text = "Componente Azul";
            this.componenteAzulToolStripMenuItem.Click += new System.EventHandler(this.componenteAzulToolStripMenuItem_Click);
            // 
            // clasificacionToolStripMenuItem
            // 
            this.clasificacionToolStripMenuItem.Name = "clasificacionToolStripMenuItem";
            this.clasificacionToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.clasificacionToolStripMenuItem.Text = "Segmentacion";
            this.clasificacionToolStripMenuItem.Click += new System.EventHandler(this.clasificacionToolStripMenuItem_Click);
            // 
            // objetosBinariosToolStripMenuItem
            // 
            this.objetosBinariosToolStripMenuItem.Name = "objetosBinariosToolStripMenuItem";
            this.objetosBinariosToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.objetosBinariosToolStripMenuItem.Text = "Objetos Binarios";
            this.objetosBinariosToolStripMenuItem.Click += new System.EventHandler(this.objetosBinariosToolStripMenuItem_Click);
            // 
            // bordeHorizontalToolStripMenuItem
            // 
            this.bordeHorizontalToolStripMenuItem.Name = "bordeHorizontalToolStripMenuItem";
            this.bordeHorizontalToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.bordeHorizontalToolStripMenuItem.Text = "Borde Horizontal";
            this.bordeHorizontalToolStripMenuItem.Click += new System.EventHandler(this.bordeHorizontalToolStripMenuItem_Click);
            // 
            // OFIMagen
            // 
            this.OFIMagen.FileName = "openFileDialog1";
            // 
            // SFImagen
            // 
            this.SFImagen.Filter = "\"mapas de bits|*.bmp|jpeges|*.jpg\"";
            // 
            // PBImagen
            // 
            this.PBImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PBImagen.Location = new System.Drawing.Point(12, 27);
            this.PBImagen.Name = "PBImagen";
            this.PBImagen.Size = new System.Drawing.Size(628, 443);
            this.PBImagen.TabIndex = 1;
            this.PBImagen.TabStop = false;
            // 
            // bordeVerticalToolStripMenuItem
            // 
            this.bordeVerticalToolStripMenuItem.Name = "bordeVerticalToolStripMenuItem";
            this.bordeVerticalToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.bordeVerticalToolStripMenuItem.Text = "Borde Vertical";
            this.bordeVerticalToolStripMenuItem.Click += new System.EventHandler(this.bordeVerticalToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 482);
            this.Controls.Add(this.PBImagen);
            this.Controls.Add(this.MSPrincipal);
            this.MainMenuStrip = this.MSPrincipal;
            this.Name = "Form1";
            this.Text = "Form1";
            this.MSPrincipal.ResumeLayout(false);
            this.MSPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MSPrincipal;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OFIMagen;
        private System.Windows.Forms.SaveFileDialog SFImagen;
        private System.Windows.Forms.PictureBox PBImagen;
        private System.Windows.Forms.ToolStripMenuItem operacionesBasicasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escalaDeGrisesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binarizacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negativoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem componenteRojoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem componenteVerdeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem componenteAzulToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clasificacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objetosBinariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bordeHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bordeVerticalToolStripMenuItem;
    }
}

