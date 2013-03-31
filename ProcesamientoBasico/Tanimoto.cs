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
    public partial class Tanimoto : Form
    {
        public Dictionary<int, ObjetoBinario> ObjetosBinarios = new Dictionary<int,ObjetoBinario>();
        public Dictionary<int, ObjetoBinario> ObjetosPatrones = new Dictionary<int, ObjetoBinario>();

        private bool flag1 = false;
        private bool flag2 = false;

        ObjetoBinario Objeto1 = new ObjetoBinario();
        ObjetoBinario Objeto2 = new ObjetoBinario();

        public Tanimoto(Dictionary<int, ObjetoBinario> obj)
        {
            ObjetosBinarios = obj;
            InitializeComponent();

            foreach (int x in ObjetosBinarios.Keys)
            {
                comboBox1.Items.Add(x);
                comboBox2.Items.Add(x);
            }

           /* for(int i=0 ; i<10 ; ++i){

                Bitmap map = new Bitmap(@"\\vmware-host\Shared Folders\Documents\Visual Studio 2012\Projects\ProcesamientoBasico\ProcesamientoBasico\Patrones\" + i + ".bmp");
                ObjetosPatrones[i] = new ObjetoBinario(map,i);
                ObjetosPatrones[i].CalcularCentroDeMasa();
                comboBox2.Items.Add(i);
            }*/

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Objeto1 = ObjetosBinarios[Convert.ToInt32(comboBox1.Text.ToString())];
            ProcesadorBasico procesador = new ProcesadorBasico(Objeto1.Anchura, Objeto1.Altura, Objeto1.Pixeles); 
            pictureBox1.Image = procesador.getMapa();
            flag1 = true;

            algoritmoTinamoto();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Objeto2 = ObjetosBinarios[Convert.ToInt32(comboBox2.Text.ToString())];
            ProcesadorBasico procesador = new ProcesadorBasico(Objeto2.Anchura, Objeto2.Altura, Objeto2.Pixeles);
            pictureBox2.Image = procesador.getMapa();
            flag2 = true;

            algoritmoTinamoto();
        }

       public void algoritmoTinamoto()
       {
           int ambosPixeles = 0;
           int izqPixeles = 0;
           int derPixeles = 0;
           double total = 0;

           if (!flag1 || !flag2)
               return;

           Cordenada diff = new Cordenada(Objeto2.CentroDeMasa.PosX - Objeto1.CentroDeMasa.PosX,
                                            Objeto2.CentroDeMasa.PosY - Objeto1.CentroDeMasa.PosY);
           
            for(int j=0 ; j<Objeto2.Altura ; j++)
                for (int i = 0; i < Objeto2.Anchura; i++)
                {
                   
                    if (j - diff.PosY < 0 || j - diff.PosY >= Objeto1.Altura 
                        || i - diff.PosX < 0 || i - diff.PosX >= Objeto1.Anchura)
                        continue;

                    int itAbove = (j-diff.PosY) * Objeto1.Anchura + (i-diff.PosX);
                    int it = j * Objeto2.Anchura + i;

                    if (Objeto2.Pixeles[it] != -1 && Objeto1.Pixeles[itAbove] != -1)
                    {
                        ambosPixeles++;
                    }
                    else if (Objeto1.Pixeles[itAbove] != -1) 
                    {
                        izqPixeles++;
                    }
                    else if (Objeto2.Pixeles[it] != -1)
                    {
                        derPixeles++;
                    }
                }

            int totalPixeles = Objeto1.getTotalActivePixels();

            izqPixeles += (totalPixeles - ambosPixeles - izqPixeles);

            izqPixeles = Objeto1.getTotalActivePixels();
            derPixeles = Objeto2.getTotalActivePixels();

            total = Convert.ToDouble(izqPixeles + derPixeles - (2 * ambosPixeles)) / Convert.ToDouble(izqPixeles + derPixeles - ambosPixeles);
            Console.WriteLine(total);

       }


    }
}
