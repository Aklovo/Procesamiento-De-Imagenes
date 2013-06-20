using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ProcesamientoBasico
{
    public partial class UIMain : Form
    {
        public UIMain()
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
            LogicBasicOperations ob = new LogicBasicOperations((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.escalaDeGrises();
            ob.componerRGB();
            PBImagen.Image = ob.getMapa();
        }

        private void binarizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations ob = new LogicBasicOperations((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.binarizacion(125);
            ob.componerRGB();
            PBImagen.Image = ob.getMapa();
        }

        private void negativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations ob = new LogicBasicOperations((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.negativo();
            ob.componerRGB();
            PBImagen.Image = ob.getMapa();
        }

        private void componenteRojoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations ob = new LogicBasicOperations((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.componenteRojo();
            PBImagen.Image = ob.getMapa();
        }

        private void componenteVerdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations ob = new LogicBasicOperations((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.componenteVerde();
            PBImagen.Image = ob.getMapa();
        }

        private void componenteAzulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations ob = new LogicBasicOperations((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.componenteAzul();
            PBImagen.Image = ob.getMapa();
        }

        private void clasificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicSegmentation ob = new LogicSegmentation((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.binarizacion(125);
            ob.componerRGB();
            ob.setMapa(ob.getMapa());
            ob.segmentacion();

            PBImagen.Image = ob.getMapa();
        }

        private void objetosBinariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            LogicSegmentation ob = new LogicSegmentation((Bitmap)this.PBImagen.Image);

            ob.descomponerRGB();
            ob.escalaDeGrises();
            ob.componerRGB();
            ob.setMapa(ob.getMapa());

            ob.descomponerRGB();
            ob.binarizacion(125);
            ob.componerRGB();
            ob.setMapa(ob.getMapa());

            ob.generarObjetosBinarios();
            
            PBImagen.Image = ob.getMapa();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Bitmap bmp1 = new Bitmap((Bitmap)this.PBImagen.Image);
            bmp1.Save("TEST.gif", System.Drawing.Imaging.ImageFormat.Gif);
        }

        private void bordeHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations ob = new LogicBasicOperations((Bitmap)this.PBImagen.Image);

            ob.descomponerRGB();
            ob.escalaDeGrises();
            ob.bordeHorizontal();

            PBImagen.Image = ob.getMapa();
        }

        private void bordeVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations ob = new LogicBasicOperations((Bitmap)this.PBImagen.Image);

            ob.descomponerRGB();
            ob.escalaDeGrises();
            ob.bordeVertical();

            PBImagen.Image = ob.getMapa();
        }

        private void filtroRobertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations ob = new LogicBasicOperations((Bitmap)this.PBImagen.Image);

            ob.descomponerRGB();
            ob.escalaDeGrises();
            ob.filtroRoberts();

            PBImagen.Image = ob.getMapa();
        }

        private void segmentacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogicSegmentation ob = new LogicSegmentation((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.binarizacion(125);
            ob.componerRGB();
            ob.setMapa(ob.getMapa());
            ob.segmentacion();

            PBImagen.Image = ob.getMapa();
        }

        private void distanciaTinamotoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            LogicSegmentation ob = new LogicSegmentation((Bitmap)this.PBImagen.Image);

            ob.descomponerRGB();
            ob.escalaDeGrises();
            ob.componerRGB();
            ob.setMapa(ob.getMapa());
            
            ob.descomponerRGB();
            ob.binarizacion(90);
            ob.componerRGB();
            ob.setMapa(ob.getMapa());
            Dictionary<int, DTOBinaryObject> objetos = ob.generarObjetosBinarios();
            PBImagen.Image = ob.getMapa();

            UITanimoto tanimoto = new UITanimoto(objetos);
            tanimoto.Show();
        }

        private void objetosBinariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            LogicSegmentation ob = new LogicSegmentation((Bitmap)this.PBImagen.Image);

            ob.descomponerRGB();
            ob.escalaDeGrises();
            ob.componerRGB();
            ob.setMapa(ob.getMapa());

            ob.descomponerRGB();
            ob.binarizacion(125);
            ob.componerRGB();
            ob.setMapa(ob.getMapa());

            ob.generarObjetosBinarios();
            ob.imprimirObjetos();
            PBImagen.Image = ob.getMapa();
        }

        private void placasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UICarPlates placas = new UICarPlates();
            placas.Show();
        }


        private void btnBright_Click(object sender, EventArgs e)
        {
            decimal numericValue = numericUpDown1.Value;
            LogicSegmentation ob = new LogicSegmentation((Bitmap)this.PBImagen.Image);
            ob.descomponerRGB();
            ob.getAbrillantamiento((double)numericValue);
            ob.componerRGB();
            ob.setMapa(ob.getMapa());

            PBImagen.Image = ob.getMapa();
            
           }

        private void UIMain_Load(object sender, EventArgs e)
        {
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = 0.1M;
            this.numericUpDown1.Maximum = 2;
            this.numericUpDown1.Minimum = 0;
        }
    }
}
