﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcesamientoBasico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OFIMagen.ShowDialog();
            PBImagen.Image = new Bitmap(OFIMagen.FileName);

        }

        private void escalaDeGrisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperacionesBasicas ob = new OperacionesBasicas((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.escalaDeGrises();
            ob.componerRGB();
            PBImagen.Image = ob.getMapa();
        }

        private void binarizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperacionesBasicas ob = new OperacionesBasicas((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.binarizacion(125);
            ob.componerRGB();
            PBImagen.Image = ob.getMapa();
        }

        private void negativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperacionesBasicas ob = new OperacionesBasicas((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.negativo();
            ob.componerRGB();
            PBImagen.Image = ob.getMapa();
        }

        private void componenteRojoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperacionesBasicas ob = new OperacionesBasicas((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.componenteRojo();
            PBImagen.Image = ob.getMapa();
        }

        private void componenteVerdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperacionesBasicas ob = new OperacionesBasicas((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.componenteVerde();
            PBImagen.Image = ob.getMapa();
        }

        private void componenteAzulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperacionesBasicas ob = new OperacionesBasicas((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.componenteAzul();
            PBImagen.Image = ob.getMapa();
        }

        private void clasificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlgoritmoSegmentacion ob = new AlgoritmoSegmentacion((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.binarizacion(125);
            ob.componerRGB();
            PBImagen.Image = ob.getMapa();

            ob.setMapa((Bitmap)this.PBImagen.Image);
            ob.segmentacion();

            PBImagen.Image = ob.getMapa();
        }

        private void objetosBinariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlgoritmoSegmentacion ob = new AlgoritmoSegmentacion((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.binarizacion(125);
            ob.componerRGB();
            PBImagen.Image = ob.getMapa();


            ob.setMapa((Bitmap)this.PBImagen.Image);
            ob.generarObjetosBinarios();
            
            PBImagen.Image = ob.getMapa();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Bitmap bmp1 = new Bitmap((Bitmap)this.PBImagen.Image);
            bmp1.Save("TEST.gif", System.Drawing.Imaging.ImageFormat.Gif);
        }
    }
}
