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
    public partial class Placas : Form
    {

        AlgoritmoSegmentacion ob;
        Bitmap map;

        public Placas()
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
            map = new Bitmap(comboBox1.Text);

            ob = new AlgoritmoSegmentacion(map);

            ob.descomponerRGB();
            ob.escalaDeGrises();
            ob.componerRGB();
            ob.setMapa(ob.getMapa());

            ob.descomponerRGB();
            ob.binarizacion((int)numericUpDown1.Value);
            ob.componerRGB();
            ob.setMapa(ob.getMapa());
            pictureBox1.Image = map;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ob = new AlgoritmoSegmentacion(map);

            ob.descomponerRGB();
            ob.escalaDeGrises();
            ob.componerRGB();
            ob.setMapa(ob.getMapa());

            ob.descomponerRGB();
            ob.binarizacion((int)numericUpDown1.Value);
            ob.componerRGB();
            ob.setMapa(ob.getMapa());
            pictureBox1.Image = ob.getMapa();
            Dictionary<int, ObjetoBinario> objetos = ob.generarObjetosBinarios();
            Tanimoto tanimoto = new Tanimoto(objetos);
            label2.Text = tanimoto.obtenerPlacas();
        }

    }
}
