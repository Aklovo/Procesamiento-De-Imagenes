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
            LogicBasicOperations basicOperations = new LogicBasicOperations((Bitmap)this.PBImagen.Image);
            basicOperations.decomposeRGB();
            basicOperations.greyScale();
            basicOperations.composeRGB();
            PBImagen.Image = basicOperations.getImageMap();
        }

        private void binarizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations basicOperations = new LogicBasicOperations((Bitmap)this.PBImagen.Image);
            basicOperations.decomposeRGB();
            basicOperations.binarization(125);
            basicOperations.composeRGB();
            PBImagen.Image = basicOperations.getImageMap();
        }

        private void negativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations basicOperations = new LogicBasicOperations((Bitmap)this.PBImagen.Image);
            basicOperations.decomposeRGB();
            basicOperations.negative();
            basicOperations.composeRGB();
            PBImagen.Image = basicOperations.getImageMap();
        }

        private void componenteRojoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations basicOperations = new LogicBasicOperations((Bitmap)this.PBImagen.Image);
            basicOperations.decomposeRGB();
            basicOperations.redComponent();
            PBImagen.Image = basicOperations.getImageMap();
        }

        private void componenteVerdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations basicOperations = new LogicBasicOperations((Bitmap)this.PBImagen.Image);
            basicOperations.decomposeRGB();
            basicOperations.greenComponent();
            PBImagen.Image = basicOperations.getImageMap();
        }

        private void componenteAzulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations basicOperations = new LogicBasicOperations((Bitmap)this.PBImagen.Image);
            basicOperations.decomposeRGB();
            basicOperations.blueComponent();
            PBImagen.Image = basicOperations.getImageMap();
        }

        private void clasificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicSegmentation segmentation = new LogicSegmentation((Bitmap)this.PBImagen.Image);
            segmentation.decomposeRGB();
            segmentation.binarization(125);
            segmentation.composeRGB();
            segmentation.setMapImage(segmentation.getImageMap());
            segmentation.segmentation();

            PBImagen.Image = segmentation.getImageMap();
        }

        private void objetosBinariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            LogicSegmentation segmentation = new LogicSegmentation((Bitmap)this.PBImagen.Image);

            segmentation.decomposeRGB();
            segmentation.greyScale();
            segmentation.composeRGB();
            segmentation.setMapImage(segmentation.getImageMap());

            segmentation.decomposeRGB();
            segmentation.binarization(125);
            segmentation.composeRGB();
            segmentation.setMapImage(segmentation.getImageMap());

            segmentation.generateBinaryObjects();
            
            PBImagen.Image = segmentation.getImageMap();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Bitmap bmp1 = new Bitmap((Bitmap)this.PBImagen.Image);
            bmp1.Save("image.gif", System.Drawing.Imaging.ImageFormat.Gif);
        }

        private void bordeHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations basicOperations = new LogicBasicOperations((Bitmap)this.PBImagen.Image);

            basicOperations.decomposeRGB();
            basicOperations.greyScale();
            basicOperations.horizontalEdge();

            PBImagen.Image = basicOperations.getImageMap();
        }

        private void bordeVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations basicOperations = new LogicBasicOperations((Bitmap)this.PBImagen.Image);

            basicOperations.decomposeRGB();
            basicOperations.greyScale();
            basicOperations.verticalEdge();

            PBImagen.Image = basicOperations.getImageMap();
        }

        private void filtroRobertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicBasicOperations basicOperations = new LogicBasicOperations((Bitmap)this.PBImagen.Image);

            basicOperations.decomposeRGB();
            basicOperations.greyScale();
            basicOperations.robertsCross();

            PBImagen.Image = basicOperations.getImageMap();
        }

        private void segmentacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogicSegmentation segmentation = new LogicSegmentation((Bitmap)this.PBImagen.Image);
            segmentation.decomposeRGB();
            segmentation.binarization(125);
            segmentation.composeRGB();
            segmentation.setMapImage(segmentation.getImageMap());
            segmentation.segmentation();

            PBImagen.Image = segmentation.getImageMap();
        }

        private void distanciaTinamotoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            LogicSegmentation segmentation = new LogicSegmentation((Bitmap)this.PBImagen.Image);

            segmentation.decomposeRGB();
            segmentation.greyScale();
            segmentation.composeRGB();
            segmentation.setMapImage(segmentation.getImageMap());
            
            segmentation.decomposeRGB();
            segmentation.binarization(90);
            segmentation.composeRGB();
            segmentation.setMapImage(segmentation.getImageMap());

            Dictionary<int, DTOBinaryObject> binaryObjects = segmentation.generateBinaryObjects();
            PBImagen.Image = segmentation.getImageMap();

            UITanimoto tanimoto = new UITanimoto(binaryObjects);
            tanimoto.Show();
        }

        private void objetosBinariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            LogicSegmentation segmentation = new LogicSegmentation((Bitmap)this.PBImagen.Image);

            segmentation.decomposeRGB();
            segmentation.greyScale();
            segmentation.composeRGB();
            segmentation.setMapImage(segmentation.getImageMap());

            segmentation.decomposeRGB();
            segmentation.binarization(125);
            segmentation.composeRGB();
            segmentation.setMapImage(segmentation.getImageMap());

            segmentation.generateBinaryObjects();
            segmentation.printObjects();
            PBImagen.Image = segmentation.getImageMap();
        }

        private void placasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UICarPlates plates = new UICarPlates();
            plates.Show();
        }


        private void btnBright_Click(object sender, EventArgs e)
        {
            decimal numericValue = numericUpDown1.Value;
            LogicSegmentation segmentation = new LogicSegmentation((Bitmap)this.PBImagen.Image);
            segmentation.decomposeRGB();
            segmentation.getNoise((double)numericValue);
            segmentation.composeRGB();
            segmentation.setMapImage(segmentation.getImageMap());

            PBImagen.Image = segmentation.getImageMap();
            
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
