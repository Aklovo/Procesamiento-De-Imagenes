using ProcesamientoBasico.Business;
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
    public partial class UITanimoto : Form
    {
        
        LogicTanimoto tanimoto;

        DTOBinaryObject Objeto1 = new DTOBinaryObject();
        DTOBinaryObject Objeto2 = new DTOBinaryObject();
        private bool flag1 = false;
        private bool flag2 = false;

        public UITanimoto(Dictionary<int, DTOBinaryObject> dic)
        {
            tanimoto = new LogicTanimoto(dic);
            InitializeComponent();
            InitializeCombos();
        }

        private void InitializeCombos()
        {
            List<int> ComboBoxOneValues = new List<int>();
            String[] ComboBoxTwoValues;

            ComboBoxOneValues = tanimoto.getValuesComboBoxOne();
            ComboBoxTwoValues = LogicTanimoto.NombrePatrones;

            foreach (int x in ComboBoxOneValues)
            {
                comboBox1.Items.Add(x);
            }

            foreach (String nombre in ComboBoxTwoValues)
            {
                comboBox2.Items.Add(nombre);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Objeto1 = tanimoto.getBinaryObjectByName(comboBox1.Text.ToString());
            flag1 = true;

            if (flag2)
            {
                Objeto1 = tanimoto.Escalar(Objeto1, Objeto2.Altura, Objeto2.Anchura);
                tanimoto.algoritmoTinamoto(Objeto1, Objeto2);
            }

            LogicBasicProcessor procesador = new LogicBasicProcessor(Objeto1.Anchura, Objeto1.Altura, Objeto1.Pixeles); 
            pictureBox1.Image = procesador.getMapa();
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Objeto2 = tanimoto.getPatternObjectByName(comboBox2.Text.ToString());
            LogicBasicProcessor procesador = new LogicBasicProcessor(Objeto2.Anchura, Objeto2.Altura, Objeto2.Pixeles);
            pictureBox2.Image = procesador.getMapa();
            flag2 = true;

            if (flag1)
            {
                Objeto1 = tanimoto.Escalar(Objeto1, Objeto2.Altura, Objeto2.Anchura);

                LogicBasicProcessor proc = new LogicBasicProcessor(Objeto1.Anchura, Objeto1.Altura, Objeto1.Pixeles);
                pictureBox1.Image = proc.getMapa();

                this.labelDist.Text = tanimoto.algoritmoTinamoto(Objeto1, Objeto2).ToString();
            }
       }

    
    }


}
