using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace ProcesamientoBasico
{
    public partial class Tanimoto : Form
    {
        public Dictionary<int, ObjetoBinario> ObjetosBinarios = new Dictionary<int,ObjetoBinario>();
        public Dictionary<int, ObjetoBinario> ObjetosPatrones = new Dictionary<int, ObjetoBinario>();
        public Dictionary<int,ObjetoBinario> ObjetosPlaca = new Dictionary<int, ObjetoBinario>();

        String[] NombrePatrones = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", 
                                  "g", "h", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "u", "v", "x", "y", "z"};

        private bool flag1 = false;
        private bool flag2 = false;

        ObjetoBinario Objeto1 = new ObjetoBinario();
        ObjetoBinario Objeto2 = new ObjetoBinario();

        public Tanimoto(Dictionary<int, ObjetoBinario> obj)
        {
            ObjetosBinarios = obj;
            int Altura;
            int Anchura;

            InitializeComponent();

            foreach (int x in ObjetosBinarios.Keys)
            {
                Objeto1 = ObjetosBinarios[x];
                Altura = Objeto1.Altura;
                Anchura = Objeto1.Anchura;

                if (Altura > 110 || Altura < 25 || Anchura > 50 || Anchura < 10)
                    continue;

                ObjetosPlaca.Add(Objeto1.Cordenadas.PosX,Objeto1);
                comboBox1.Items.Add(x);
            }

            foreach(String nombre in NombrePatrones){
                String ruta = @"\\vmware-host\Shared Folders\Documents\Visual Studio 2012\Projects\ProcesamientoBasico\ProcesamientoBasico\Imagenes\Patrones\" + nombre + ".bmp";
                Bitmap map = new Bitmap(ruta);
                ObjetosPatrones[(int)nombre[0]] = new ObjetoBinario(map, (int)nombre[0]);
                ObjetosPatrones[(int)nombre[0]].CalcularCentroDeMasa();
                comboBox2.Items.Add(nombre);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Objeto1 = ObjetosBinarios[Convert.ToInt32(comboBox1.Text.ToString())];
            flag1 = true;

            if (flag2)
            {
                Objeto1 = escalar(Objeto1, Objeto2.Altura, Objeto2.Anchura);
                algoritmoTinamoto(Objeto1, Objeto2);
            }

            ProcesadorBasico procesador = new ProcesadorBasico(Objeto1.Anchura, Objeto1.Altura, Objeto1.Pixeles); 
            pictureBox1.Image = procesador.getMapa();
           
        }

        private ObjetoBinario escalar(ObjetoBinario Objeto1, int NuevaAltura, int NuevaAnchura)
        {
            ObjetoBinario nuevoObjeto = new ObjetoBinario();
          
            int tempX;
            int tempY;

            float esc_x = 0;
            float esc_y = 0;
            
            esc_y = (float)NuevaAltura / (float)Objeto1.Altura;
            esc_x = (float)NuevaAnchura / (float)Objeto1.Anchura;

            nuevoObjeto.Etiqueta = Objeto1.Etiqueta;
            nuevoObjeto.Altura = NuevaAltura;
            nuevoObjeto.Anchura = NuevaAnchura;
            nuevoObjeto.Pixeles = new int[NuevaAltura * NuevaAnchura];

            for (int y = 0; y < NuevaAltura; y++)
                for (int x = 0; x < NuevaAnchura; x++)
                {
  
                    tempX = (int)(x / esc_x);
                    tempY = (int)(y / esc_y);
                    int it = y * NuevaAnchura + x;
                    int itTemp = tempY * Objeto1.Anchura + tempX;
                    nuevoObjeto.Pixeles[it] = Objeto1.Pixeles[itTemp];
                }

            nuevoObjeto.CalcularCentroDeMasa();

            return nuevoObjeto;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Objeto2 = ObjetosPatrones[(int)(comboBox2.Text.ToString())[0]];
            ProcesadorBasico procesador = new ProcesadorBasico(Objeto2.Anchura, Objeto2.Altura, Objeto2.Pixeles);
            pictureBox2.Image = procesador.getMapa();
            flag2 = true;

            if (flag1)
            {
                Objeto1 = escalar(Objeto1, Objeto2.Altura, Objeto2.Anchura);
                this.labelDist.Text = algoritmoTinamoto(Objeto1, Objeto2).ToString();
            }
       }

       public double algoritmoTinamoto(ObjetoBinario Objeto1, ObjetoBinario Objeto2)
       {
           int ambosPixeles = 0;
           int izqPixeles = 0;
           int derPixeles = 0;
           double total = 0;

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

            izqPixeles = Objeto1.getTotalActivePixels();
            derPixeles = Objeto2.getTotalActivePixels();

            total = Convert.ToDouble(izqPixeles + derPixeles - (2 * ambosPixeles)) / Convert.ToDouble(izqPixeles + derPixeles - ambosPixeles);
            return total; 
       }

       public String obtenerPlacas()
       {
            ObjetoBinario ObjetoPatron = new ObjetoBinario();
            ObjetoBinario ObjetoEscalado = new ObjetoBinario();
            List<Double> Distancias = new List<Double>();

            String placa = String.Empty;
            double minimo = 1.0, distanciaTinamoto = 1.0;
            Char caracter = ' ';
            var ordered = ObjetosPlaca.OrderBy(x => x.Key);

            foreach (var varPlaca in ordered)
            {
                ObjetoBinario objeto = varPlaca.Value;
                minimo = 1.0;

                foreach (int llave in ObjetosPatrones.Keys)
                {
                    ObjetoPatron = ObjetosPatrones[llave];
                    ObjetoEscalado = escalar(objeto, ObjetoPatron.Altura, ObjetoPatron.Anchura);
                    ObjetoEscalado.CalcularCentroDeMasa();

                    distanciaTinamoto = algoritmoTinamoto(ObjetoEscalado, ObjetoPatron);
                   
                    if (distanciaTinamoto < minimo)
                    {
                        minimo = distanciaTinamoto;
                        caracter = llave < 10 ? llave.ToString()[0] :Char.ToUpper((char)llave);
                    }
                }

                Distancias.Add(minimo);
                placa += caracter;
           }

            while (Distancias.Count > 7) 
            {
                int indexMax = !Distancias.Any() ? -1 : Distancias.
                    Select((value, index) => new { Value = value, Index = index })
                    .Aggregate((a, b) => (a.Value > b.Value) ? a : b).Index;

                Distancias.Remove(Distancias.Max());

                placa = placa.Remove(indexMax,1);
            }

            if (Char.IsNumber(placa[2]))
            {
                placa = placa.Insert(2, "-");
                placa = placa.Insert(5, "-");
            }
            else
            {
                placa = placa.Insert(3, "-");
                placa = placa.Insert(6, "-");
            }

           return placa;
       }
    }


}
