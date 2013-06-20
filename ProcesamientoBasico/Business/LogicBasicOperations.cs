using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProcesamientoBasico
{
    class LogicBasicOperations : LogicBasicProcessor
    {
        public LogicBasicOperations(Bitmap mapa) : base(mapa) { }

        public void escalaDeGrises()
        {
            RGB = new int[Width * Height];

            for (int j = 0; j < mapa.Size.Height; j++)
            {
                for (int i = 0; i < mapa.Size.Width; i++)
                {
                    int it = j * Width + i;
                    int color = (R[it] + G[it] + B[it]) / 3;
                    R[it] = color;
                    G[it] = color;
                    B[it] = color;
                }
            }
        }

        public void binarizacion(int lumbral)
        {
            RGB = new int[Width * Height];

            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    int it = j * Width + i;
                    R[it] = R[it] < lumbral ? 0 : 255;
                    G[it] = G[it] < lumbral ? 0 : 255;
                    B[it] = B[it] < lumbral ? 0 : 255;
                }
            }
        }

        public void negativo()
        {
            RGB = new int[Width * Height];

            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    int it = j * Width + i;
                    R[it] = 255 - R[it];
                    G[it] = 255 - G[it];
                    B[it] = 255 - B[it];
                }
            }
        }

        public void componenteRojo()
        {
            RGB = new int[Width * Height];

            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    int it = j * Width + i;
                    RGB[it] = (0xff << 24) | (R[it] << 16);
                }
            }
        }

        public void componenteVerde()
        {
            RGB = new int[Width * Height];
            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    int it = j * Width + i;
                    RGB[it] = (0xff << 24) | (G[it] << 8);
                }
            }
        }

        public void componenteAzul()
        {
            RGB = new int[Width * Height];

            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    int it = j * Width + i;
                    RGB[it] = (0xff << 24) | B[it];
                }
            }
        }


        public void bordeHorizontal()
        {
            RGB = new int[Width * Height];
            int it = 0, pixel = 0;

            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width-1; i++)
                {
                    it = j * Width + i;
                    pixel = Math.Abs(R[it] - R[it + 1]);
                    RGB[it] = (0xff << 24) | (pixel << 16) | (pixel << 8) | pixel;
                }

                ++it;
                RGB[it] = RGB[it - 1];
            }
        }

        public void bordeVertical()
        {
            RGB = new int[Width * Height];
            int it = 0, pixel = 0;

            for (int j = 0; j < Height - 1; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    it = j * Width + i;
                    pixel = Math.Abs(R[it] - R[it + Width]);
                    RGB[it] = (0xff << 24) | (pixel << 16) | (pixel << 8) | pixel;
                }

                ++it;
                RGB[it] = RGB[it - Width];
            }
        }

        public void filtroRoberts()
        {
            RGB = new int[Width * Height];
            int it = 0, pixel = 0, pixelDer = 0, pixelAb = 0;

            for (int j = 0; j < Height - 1; j++)
            {
                for (int i = 0; i < Width - 1; i++)
                {
                    it = j * Width + i;
                    pixelDer = Math.Abs(R[it] - R[it + 1]);
                    pixelAb = Math.Abs(R[it] - R[it + Width]);

                    pixel = (int)Math.Sqrt(Math.Pow(pixelDer, 2) + Math.Pow(pixelAb, 2));

                    RGB[it] = (0xff << 24) | (pixel << 16) | (pixel << 8) | pixel;
                }
            }
        }

        public Bitmap getHistrogram(Dictionary<int, int> mapPixels, int umbral)
        {
            Bitmap mapa = new Bitmap(256, 100, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int MaxValue = mapPixels.Values.Max();
        
            for (int j = 0; j < 256 ; j++) 
            {
                int CurrentValue = mapPixels[j];

                CurrentValue *= 100;
                CurrentValue /= MaxValue;

                for (int i = 0; i < 100; i++)
                {
                    int RGB;

                    if (j == umbral)
                    {
                        RGB = (0xff << 24) | (255 << 16) | (0 << 8) | 0; 
                    }
                    else if (CurrentValue >= i)
                    {
                        RGB = (0xff << 24) | (0 << 16) | (0 << 8) | 0;   
                    }
                    else
                    {
                        RGB = (0xff << 24) | (255 << 16) | (255 << 8) | 255; 
                    }

                    mapa.SetPixel(j,99-i, Color.FromArgb(RGB));
                }
            }
            return mapa;
        }

        public Dictionary<int, int> getMapOfPixels()
        {
            Dictionary<int, int> MapPixels = new Dictionary<int, int>();
            int it = 0;

            for (int i = 0; i < 256; i++)
            {
                MapPixels[i] = 0;
            }

            for (int j = 0; j < Height - 1; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    it = j * Width + i;
                    int key = R[it];
                    MapPixels[key]++;
                }
            }

            return MapPixels;
        }


        public int getBestUmbral(Dictionary<int, int> mapPixels)
        {
            double minValue, valueLeft, valueRight, varLeft, varRight, weightLeft, weightRight, minTotal;
            int totalWeight;
            minValue = 0;
            minTotal = 100000000000000000;

            totalWeight = getTotalWeight(mapPixels);

            for (int i = 1; i < mapPixels.Count; i++)
            {
                valueLeft = getAverageLeft(mapPixels, i);
                valueRight = getAverageRight(mapPixels, i);

                varLeft = getVarLeft(mapPixels, i, valueLeft);
                varRight = getVarRight(mapPixels, i, valueRight);

                weightLeft = getWeightLeft(mapPixels, i);
                weightRight = getWeightRight(mapPixels, i);

                minValue = (varLeft * (weightLeft/totalWeight)) + (varRight * (weightRight/totalWeight));

                if (minValue > 0)
                    minTotal = Math.Min(minValue, minTotal);

            }

            return (int)minTotal;
        }

        private int getTotalWeight(Dictionary<int, int> mapPixels)
        {
            int total = 0;

            for (int i = 0; i < mapPixels.Count ; i++)
            {
                total += mapPixels[i];
            }

            return total;
        }

        private double getAverageLeft(Dictionary<int, int> mapPixels, int bound)
        {
            double up = 0, down = 0;

            for (int i = 0; i < bound; i++)
            {
                up += (mapPixels[i] * i);
                down += mapPixels[i];
            }

            return up / down;
        }

        private double getAverageRight(Dictionary<int, int> mapPixels, int bound)
        {
            double up = 0, down = 0;

            for (int i = bound; i < mapPixels.Count; i++)
            {
                up += (mapPixels[i] * i);
                down += mapPixels[i];
            }

            return up / down;
        }

        private double getWeightRight(Dictionary<int, int> mapPixels, int bound)
        {
            double sum = 0;

            for (int i = bound; i < mapPixels.Count; i++)
            {
                sum += mapPixels[i];
            }

            return sum;
        }

        private double getWeightLeft(Dictionary<int, int> mapPixels, int bound)
        {
            double sum = 0;

            for (int i = 0; i < bound; i++)
            {
                sum += mapPixels[i];
            }

            return sum;
        }

        private double getVarRight(Dictionary<int, int> mapPixels, int bound, double valueRight)
        {
            double up = 0, down = 0;

            for (int i = bound ; i < mapPixels.Count; i++)
            {
                up += ((mapPixels[i] - valueRight) * i);
                down += mapPixels[i];
            }

            return up / down;
        }

        private double getVarLeft(Dictionary<int, int> mapPixels, int bound, double valueLeft)
        {
            double up = 0, down = 0;

            for (int i = 0; i < bound; i++)
            {
                up += ((mapPixels[i] - valueLeft) * i);
                down += mapPixels[i];
            }

            return up / down;
        }

        

        
    }

}
