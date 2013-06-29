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

        DTOBinaryObject BinaryObject1 = new DTOBinaryObject();
        DTOBinaryObject BinaryObject2 = new DTOBinaryObject();
        private bool Flag1 = false;
        private bool Flag2 = false;

        public UITanimoto(Dictionary<int, DTOBinaryObject> dictionary)
        {
            tanimoto = new LogicTanimoto(dictionary);
            InitializeComponent();
            InitializeCombos();
        }

        private void InitializeCombos()
        {
            List<int> ComboBoxOneValues = new List<int>();
            String[] ComboBoxTwoValues;

            ComboBoxOneValues = tanimoto.getValuesComboBoxOne();
            ComboBoxTwoValues = LogicTanimoto.Patterns;

            foreach (int value in ComboBoxOneValues)
            {
                comboBox1.Items.Add(value);
            }

            foreach (String name in ComboBoxTwoValues)
            {
                comboBox2.Items.Add(name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            BinaryObject1 = tanimoto.getBinaryObjectByName(comboBox1.Text.ToString());
            Flag1 = true;

            if (Flag2)
            {
                BinaryObject1 = tanimoto.Scalar(BinaryObject1, BinaryObject2.Height, BinaryObject2.Width);
                tanimoto.tanimotoDistance(BinaryObject1, BinaryObject2);
            }

            LogicBasicProcessor processor = new LogicBasicProcessor(BinaryObject1.Width, BinaryObject1.Height, BinaryObject1.Pixels); 
            pictureBox1.Image = processor.getImageMap();
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BinaryObject2 = tanimoto.getPatternObjectByName(comboBox2.Text.ToString());
            LogicBasicProcessor processor = new LogicBasicProcessor(BinaryObject2.Width, BinaryObject2.Height, BinaryObject2.Pixels);
            pictureBox2.Image = processor.getImageMap();
            Flag2 = true;

            if (Flag1)
            {
                BinaryObject1 = tanimoto.Scalar(BinaryObject1, BinaryObject2.Height, BinaryObject2.Width);

                LogicBasicProcessor newProcessor = new LogicBasicProcessor(BinaryObject1.Width, BinaryObject1.Height, BinaryObject1.Pixels);
                pictureBox1.Image = newProcessor.getImageMap();

                this.labelDist.Text = tanimoto.tanimotoDistance(BinaryObject1, BinaryObject2).ToString();
            }
       }

    
    }


}
