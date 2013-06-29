using ProcesamientoBasico.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcesamientoBasico
{
    public partial class UICarPlates : Form
    {
        private Bitmap ImageMap;

        public UICarPlates()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                textBox1.Text = folderBrowserDialog1.SelectedPath;

                foreach (string nameFiles in files)
                {
                    comboBox1.Items.Add(nameFiles);
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Dictionary<int, int> mapPixels = new Dictionary<int,int>();
            int optimalThreshold;
            ImageMap = new Bitmap(comboBox1.Text);

            LogicSegmentation segmentation = new LogicSegmentation(ImageMap);

            segmentation.decomposeRGB();
            segmentation.greyScale();
            segmentation.composeRGB();
            segmentation.setMapImage(segmentation.getImageMap());
            mapPixels = segmentation.getMapOfPixels();

            LogicOptimalThreshold threshold = new LogicOptimalThreshold(mapPixels);
            optimalThreshold = threshold.OptimalThreshold;
            
            pictureHistogram.Image = segmentation.getHistogram(mapPixels, optimalThreshold);

            segmentation.decomposeRGB();
            segmentation.binarization(optimalThreshold);
            segmentation.composeRGB();
            segmentation.setMapImage(segmentation.getImageMap());
            pictureBox1.Image = ImageMap;

            labelUmbral.Text = optimalThreshold.ToString();
            Dictionary<int, DTOBinaryObject> binaryObjects = segmentation.generateBinaryObjects();
            LogicTanimoto tanimoto = new LogicTanimoto(binaryObjects);
            label2.Text = tanimoto.getPlate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            LogicSegmentation segmentation = new LogicSegmentation(ImageMap);

            segmentation.decomposeRGB();
            segmentation.greyScale();
            segmentation.composeRGB();
            segmentation.setMapImage(segmentation.getImageMap());


            segmentation.decomposeRGB();
            segmentation.binarization((int)numericUpDown1.Value);
            segmentation.composeRGB();
            segmentation.setMapImage(segmentation.getImageMap());
            pictureBox1.Image = segmentation.getImageMap();

            Dictionary<int, DTOBinaryObject> binaryObjects = segmentation.generateBinaryObjects();
            LogicTanimoto tanimoto = new LogicTanimoto(binaryObjects);
            label2.Text = tanimoto.getPlate();
        }

    }
}
