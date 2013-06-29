using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesamientoBasico.Business
{
    class LogicTanimoto
    {
        public static String[] Patterns = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", 
                                  "g", "h", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "u", "v", "x", "y", "z"};


        public static Dictionary<int, DTOBinaryObject> PatternObjects{ get; private set; }
        public Dictionary<int, DTOBinaryObject> PlateObjects = new Dictionary<int, DTOBinaryObject>();
        public Dictionary<int, DTOBinaryObject> BinaryObjects;

        private static bool isSet = false;

        DTOBinaryObject BinaryObject1 = new DTOBinaryObject();
        DTOBinaryObject BinaryObject2 = new DTOBinaryObject();

        public LogicTanimoto(Dictionary<int, DTOBinaryObject> dictionary)
        {
            
            BinaryObjects = new Dictionary<int, DTOBinaryObject>(dictionary);
            PatternObjects = new Dictionary<int, DTOBinaryObject>();
            PatternObjects = setPatterns();
        }

        public DTOBinaryObject getBinaryObjectByName(String id) 
        {
            return BinaryObjects[Convert.ToInt32(id)];
        }

        public DTOBinaryObject getPatternObjectByName(string id)
        {
            return PatternObjects[(int)(id)[0]];
        }

        public List<int> getValuesComboBoxOne() {
            List<int> listCombo = new List<int>();
            int height;
            int width;

            foreach (int objectKey in BinaryObjects.Keys)
            {
                BinaryObject1 = BinaryObjects[objectKey];
                height = BinaryObject1.Height;
                width = BinaryObject1.Width;

                if (height > 110 || height < 15 || width > 50 || width < 5)
                    continue;

                PlateObjects.Add(BinaryObject1.Points.PosX, BinaryObject1);
                listCombo.Add(objectKey);

            }
         
            return listCombo;
        }

        public void evaluateImages()
        {
            int height;
            int width;

            foreach (int objectKey in BinaryObjects.Keys)
            {
                BinaryObject1 = BinaryObjects[objectKey];
                height = BinaryObject1.Height;
                width = BinaryObject1.Width;

                if (height > 110 || height < 15 || width > 50 || width < 5)
                    continue;

                PlateObjects.Add(BinaryObject1.Points.PosX, BinaryObject1);
            }
        }

        public double tanimotoDistance(DTOBinaryObject BinaryObject1, DTOBinaryObject BinaryObject2)
        {
            int bothPixels = 0;
            int leftPixels = 0;
            int rightPixels = 0;
            double total = 0;

            DTOCoordinate diff = new DTOCoordinate(BinaryObject2.CenterOfMass.PosX - BinaryObject1.CenterOfMass.PosX,
                                             BinaryObject2.CenterOfMass.PosY - BinaryObject1.CenterOfMass.PosY);

            for (int iteratorHeight = 0; iteratorHeight < BinaryObject2.Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < BinaryObject2.Width; iteratorWidth++)
                {

                    if (iteratorHeight - diff.PosY < 0 || iteratorHeight - diff.PosY >= BinaryObject1.Height
                        || iteratorWidth - diff.PosX < 0 || iteratorWidth - diff.PosX >= BinaryObject1.Width)
                        continue;

                    int itAbove = (iteratorHeight - diff.PosY) * BinaryObject1.Width + (iteratorWidth - diff.PosX);
                    int it = iteratorHeight * BinaryObject2.Width + iteratorWidth;

                    if (BinaryObject2.Pixels[it] != -1 && BinaryObject1.Pixels[itAbove] != -1)
                    {
                        bothPixels++;
                    }
                    else if (BinaryObject1.Pixels[itAbove] != -1)
                    {
                        leftPixels++;
                    }
                    else if (BinaryObject2.Pixels[it] != -1)
                    {
                        rightPixels++;
                    }
                }
            }

            int totalPixeles = BinaryObject1.totalActivePixels;

            leftPixels = BinaryObject1.totalActivePixels;
            rightPixels = BinaryObject2.totalActivePixels;

            total = Convert.ToDouble(leftPixels + rightPixels - (2 * bothPixels)) / Convert.ToDouble(leftPixels + rightPixels - bothPixels);
            return total;
        }

        public String getPlate()
        {
            DTOBinaryObject patternObject = new DTOBinaryObject();
            DTOBinaryObject resizedObject = new DTOBinaryObject();
            List<Double> distances = new List<Double>();
            evaluateImages();

            String plate = String.Empty;
            double minimum = 1.0, distance = 1.0;
            Char character = ' ';
            var ordered = PlateObjects.OrderBy(x => x.Key);

            foreach (var varPlate in ordered)
            {
                DTOBinaryObject objeto = varPlate.Value;
                minimum = 1.0;

                foreach (int key in PatternObjects.Keys)
                {
                    patternObject = PatternObjects[key];
                    resizedObject = Scalar(objeto, patternObject.Height, patternObject.Width);
                    resizedObject.setCenterOfMass();

                    distance = tanimotoDistance(resizedObject, patternObject);

                    if (distance < minimum)
                    {
                        minimum = distance;
                        character = key < 10 ? key.ToString()[0] : Char.ToUpper((char)key);
                    }
                }

                distances.Add(minimum);
                plate += character;
            }

            while (distances.Count > 7)
            {
                int indexMax = !distances.Any() ? -1 : distances.
                    Select((value, index) => new { Value = value, Index = index })
                    .Aggregate((a, b) => (a.Value > b.Value) ? a : b).Index;

                distances.Remove(distances.Max());

                plate = plate.Remove(indexMax, 1);
            }

            if (Char.IsNumber(plate[2]))
            {
                plate = plate.Insert(2, "-");
                plate = plate.Insert(5, "-");
            }
            else
            {
                plate = plate.Insert(3, "-");
                plate = plate.Insert(6, "-");
            }

            return plate;
        }

        static private Dictionary<int, DTOBinaryObject> setPatterns()
        {
            if (isSet == false)
            {
                foreach (String name in Patterns)
                {
                    String ruta = @"\\vmware-host\Shared Folders\Documents\Visual Studio 2012\Projects\ProcesamientoBasico\ProcesamientoBasico\Imagenes\Patrones\" + name + ".bmp";
                    Bitmap map = new Bitmap(ruta);
                    PatternObjects[(int)name[0]] = new DTOBinaryObject(map, (int)name[0]);
                    PatternObjects[(int)name[0]].setCenterOfMass();
                }
            }

            return PatternObjects;
        }

        public DTOBinaryObject Scalar(DTOBinaryObject binaryObject, int newHeight, int netWidth)
        {
            DTOBinaryObject newBinaryObject = new DTOBinaryObject();

            int tempX, tempY, it, itTemp;
            float esc_x = 0;
            float esc_y = 0;

            esc_y = (float)newHeight / (float)binaryObject.Height;
            esc_x = (float)netWidth / (float)binaryObject.Width;

            newBinaryObject.Label = binaryObject.Label;
            newBinaryObject.Height = newHeight;
            newBinaryObject.Width = netWidth;
            newBinaryObject.Pixels = new int[newHeight * netWidth];

            for (int iteratorHeight = 0; iteratorHeight < newHeight; iteratorHeight++)
            {
                for (int interatorWidth = 0; interatorWidth < netWidth; interatorWidth++)
                {
                    tempX = (int)(interatorWidth / esc_x);
                    tempY = (int)(iteratorHeight / esc_y);
                    it = iteratorHeight * netWidth + interatorWidth;
                    itTemp = tempY * binaryObject.Width + tempX;
                    newBinaryObject.Pixels[it] = binaryObject.Pixels[itTemp];
                }
            }

            newBinaryObject.setCenterOfMass();

            return newBinaryObject;
        }

    }
}
