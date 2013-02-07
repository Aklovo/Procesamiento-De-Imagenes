using System;
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
    }
}
