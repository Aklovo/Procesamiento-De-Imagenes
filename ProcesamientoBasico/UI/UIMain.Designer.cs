namespace ProcesamientoBasico
{
    partial class UIMain
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
            this.bordeHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bordeVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtroRobertsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentacionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.objetosBinariosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.distanciaTinamotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.placasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OFIMagen = new System.Windows.Forms.OpenFileDialog();
            this.SFImagen = new System.Windows.Forms.SaveFileDialog();
            this.PBImagen = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBright = new System.Windows.Forms.Button();
            this.MSPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // MSPrincipal
            // 
            this.MSPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.operacionesBasicasToolStripMenuItem,
            this.segmentacionToolStripMenuItem,
            this.placasToolStripMenuItem});
            this.MSPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MSPrincipal.Name = "MSPrincipal";
            this.MSPrincipal.Size = new System.Drawing.Size(788, 24);
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
            this.bordeHorizontalToolStripMenuItem,
            this.bordeVerticalToolStripMenuItem,
            this.filtroRobertsToolStripMenuItem});
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
            // bordeHorizontalToolStripMenuItem
            // 
            this.bordeHorizontalToolStripMenuItem.Name = "bordeHorizontalToolStripMenuItem";
            this.bordeHorizontalToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.bordeHorizontalToolStripMenuItem.Text = "Borde Horizontal";
            this.bordeHorizontalToolStripMenuItem.Click += new System.EventHandler(this.bordeHorizontalToolStripMenuItem_Click);
            // 
            // bordeVerticalToolStripMenuItem
            // 
            this.bordeVerticalToolStripMenuItem.Name = "bordeVerticalToolStripMenuItem";
            this.bordeVerticalToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.bordeVerticalToolStripMenuItem.Text = "Borde Vertical";
            this.bordeVerticalToolStripMenuItem.Click += new System.EventHandler(this.bordeVerticalToolStripMenuItem_Click);
            // 
            // filtroRobertsToolStripMenuItem
            // 
            this.filtroRobertsToolStripMenuItem.Name = "filtroRobertsToolStripMenuItem";
            this.filtroRobertsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.filtroRobertsToolStripMenuItem.Text = "Filtro Roberts";
            this.filtroRobertsToolStripMenuItem.Click += new System.EventHandler(this.filtroRobertsToolStripMenuItem_Click);
            // 
            // segmentacionToolStripMenuItem
            // 
            this.segmentacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.segmentacionToolStripMenuItem1,
            this.objetosBinariosToolStripMenuItem1,
            this.distanciaTinamotoToolStripMenuItem});
            this.segmentacionToolStripMenuItem.Name = "segmentacionToolStripMenuItem";
            this.segmentacionToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.segmentacionToolStripMenuItem.Text = "Segmentacion";
            // 
            // segmentacionToolStripMenuItem1
            // 
            this.segmentacionToolStripMenuItem1.Name = "segmentacionToolStripMenuItem1";
            this.segmentacionToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.segmentacionToolStripMenuItem1.Text = "Segmentacion";
            this.segmentacionToolStripMenuItem1.Click += new System.EventHandler(this.segmentacionToolStripMenuItem1_Click);
            // 
            // objetosBinariosToolStripMenuItem1
            // 
            this.objetosBinariosToolStripMenuItem1.Name = "objetosBinariosToolStripMenuItem1";
            this.objetosBinariosToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.objetosBinariosToolStripMenuItem1.Text = "Objetos Binarios";
            this.objetosBinariosToolStripMenuItem1.Click += new System.EventHandler(this.objetosBinariosToolStripMenuItem1_Click);
            // 
            // distanciaTinamotoToolStripMenuItem
            // 
            this.distanciaTinamotoToolStripMenuItem.Name = "distanciaTinamotoToolStripMenuItem";
            this.distanciaTinamotoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.distanciaTinamotoToolStripMenuItem.Text = "Distancia Tinamoto";
            this.distanciaTinamotoToolStripMenuItem.Click += new System.EventHandler(this.distanciaTinamotoToolStripMenuItem_Click);
            // 
            // placasToolStripMenuItem
            // 
            this.placasToolStripMenuItem.Name = "placasToolStripMenuItem";
            this.placasToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.placasToolStripMenuItem.Text = "Obtener Placas";
            this.placasToolStripMenuItem.Click += new System.EventHandler(this.placasToolStripMenuItem_Click);
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
            this.PBImagen.Size = new System.Drawing.Size(642, 443);
            this.PBImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBImagen.TabIndex = 1;
            this.PBImagen.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(660, 227);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(657, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Brillo";
            // 
            // btnBright
            // 
            this.btnBright.Location = new System.Drawing.Point(705, 264);
            this.btnBright.Name = "btnBright";
            this.btnBright.Size = new System.Drawing.Size(75, 23);
            this.btnBright.TabIndex = 4;
            this.btnBright.Text = "Aceptar";
            this.btnBright.UseVisualStyleBackColor = true;
            this.btnBright.Click += new System.EventHandler(this.btnBright_Click);
            // 
            // UIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 482);
            this.Controls.Add(this.btnBright);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.PBImagen);
            this.Controls.Add(this.MSPrincipal);
            this.MainMenuStrip = this.MSPrincipal;
            this.Name = "UIMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.UIMain_Load);
            this.MSPrincipal.ResumeLayout(false);
            this.MSPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem bordeHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bordeVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtroRobertsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentacionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem objetosBinariosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem distanciaTinamotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem placasToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBright;
    }
}

