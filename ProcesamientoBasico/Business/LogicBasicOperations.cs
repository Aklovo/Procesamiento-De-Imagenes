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

        public void greyScale()
        {
            RGB = new int[Width * Height];

            for (int iteratorSize = 0; iteratorSize < ImageMap.Size.Height; iteratorSize++)
            {
                for (int iteratorWidth = 0; iteratorWidth < ImageMap.Size.Width; iteratorWidth++)
                {
                    int it = iteratorSize * Width + iteratorWidth;
                    int color = (R[it] + G[it] + B[it]) / 3;
                    R[it] = color;
                    G[it] = color;
                    B[it] = color;
                }
            }
        }

        public void binarization(int threshold)
        {
            RGB = new int[Width * Height];

            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {
                    int it = iteratorHeight * Width + iteratorWidth;
                    R[it] = R[it] < threshold ? 0 : 255;
                    G[it] = G[it] < threshold ? 0 : 255;
                    B[it] = B[it] < threshold ? 0 : 255;
                }
            }
        }

        public void negative()
        {
            RGB = new int[Width * Height];

            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {
                    int it = iteratorHeight * Width + iteratorWidth;
                    R[it] = 255 - R[it];
                    G[it] = 255 - G[it];
                    B[it] = 255 - B[it];
                }
            }
        }

        public void redComponent()
        {
            RGB = new int[Width * Height];

            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {
                    int it = iteratorHeight * Width + iteratorWidth;
                    RGB[it] = (0xff << 24) | (R[it] << 16);
                }
            }
        }

        public void greenComponent()
        {
            RGB = new int[Width * Height];
            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {
                    int it = iteratorHeight * Width + iteratorWidth;
                    RGB[it] = (0xff << 24) | (G[it] << 8);
                }
            }
        }

        public void blueComponent()
        {
            RGB = new int[Width * Height];

            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {
                    int it = iteratorHeight * Width + iteratorWidth;
                    RGB[it] = (0xff << 24) | B[it];
                }
            }
        }


        public void horizontalEdge()
        {
            RGB = new int[Width * Height];
            int it = 0, pixel = 0;

            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width - 1; iteratorWidth++)
                {
                    it = iteratorHeight * Width + iteratorWidth;
                    pixel = Math.Abs(R[it] - R[it + 1]);
                    RGB[it] = (0xff << 24) | (pixel << 16) | (pixel << 8) | pixel;
                }

                ++it;
                RGB[it] = RGB[it - 1];
            }
        }

        public void verticalEdge()
        {
            RGB = new int[Width * Height];
            int it = 0, pixel = 0;

            for (int iteratorHeight = 0; iteratorHeight < Height - 1; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {
                    it = iteratorHeight * Width + iteratorWidth;
                    pixel = Math.Abs(R[it] - R[it + Width]);
                    RGB[it] = (0xff << 24) | (pixel << 16) | (pixel << 8) | pixel;
                }

                ++it;
                RGB[it] = RGB[it - Width];
            }
        }

        public void robertsCross()
        {
            RGB = new int[Width * Height];
            int it = 0, pixel = 0, rightPixel = 0, absolutePixel = 0;

            for (int iteratorHeight = 0; iteratorHeight < Height - 1; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width - 1; iteratorWidth++)
                {
                    it = iteratorHeight * Width + iteratorWidth;
                    rightPixel = Math.Abs(R[it] - R[it + 1]);
                    absolutePixel = Math.Abs(R[it] - R[it + Width]);

                    pixel = (int)Math.Sqrt(Math.Pow(rightPixel, 2) + Math.Pow(absolutePixel, 2));

                    RGB[it] = (0xff << 24) | (pixel << 16) | (pixel << 8) | pixel;
                }
            }
        }

        public Bitmap getHistogram(Dictionary<int, int> mapPixels, int threshold)
        {
            Bitmap map = new Bitmap(256, 100, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int MaxValue = mapPixels.Values.Max();

            for (int iteratorPixels = 0; iteratorPixels < 256; iteratorPixels++)
            {
                int CurrentValue = mapPixels[iteratorPixels];

                CurrentValue *= 100;
                CurrentValue /= MaxValue;

                for (int iteratorHeight = 0; iteratorHeight < 100; iteratorHeight++)
                {
                    int RGB;

                    if (iteratorPixels == threshold)
                    {
                        RGB = (0xff << 24) | (255 << 16) | (0 << 8) | 0;
                    }
                    else if (CurrentValue >= iteratorHeight)
                    {
                        RGB = (0xff << 24) | (0 << 16) | (0 << 8) | 0;
                    }
                    else
                    {
                        RGB = (0xff << 24) | (255 << 16) | (255 << 8) | 255;
                    }

                    map.SetPixel(iteratorPixels, 99 - iteratorHeight, Color.FromArgb(RGB));
                }
            }
            return map;
        }

        public Dictionary<int, int> getMapOfPixels()
        {
            Dictionary<int, int> MapPixels = new Dictionary<int, int>();
            int it, key;

            for (int iteratorPixels = 0; iteratorPixels < 256; iteratorPixels++)
            {
                MapPixels[iteratorPixels] = 0;
            }

            for (int iteratorHeight = 0; iteratorHeight < Height - 1; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {
                    it = iteratorHeight * Width + iteratorWidth;
                    key = R[it];
                    MapPixels[key]++;
                }
            }

            return MapPixels;
        }

        public void getNoise(double noiseReduction)
        {
            double[] RedNoise = new double[ImageMap.Size.Width * ImageMap.Size.Height];
            double[] GreenNoise = new double[ImageMap.Size.Width * ImageMap.Size.Height]; ;
            double[] BlueNoise = new double[ImageMap.Size.Width * ImageMap.Size.Height];

            double original = 255;

            for (int iteratorHeight = 0; iteratorHeight < ImageMap.Size.Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < ImageMap.Size.Width; iteratorWidth++)
                {

                    RedNoise[iteratorHeight * ImageMap.Size.Width + iteratorWidth]
                        = R[iteratorHeight * ImageMap.Size.Width + iteratorWidth] / original;
                    GreenNoise[iteratorHeight * ImageMap.Size.Width + iteratorWidth]
                        = G[iteratorHeight * ImageMap.Size.Width + iteratorWidth] / original;
                    BlueNoise[iteratorHeight * ImageMap.Size.Width + iteratorWidth]
                        = B[iteratorHeight * ImageMap.Size.Width + iteratorWidth] / original;

                    RedNoise[iteratorHeight * ImageMap.Size.Width + iteratorWidth]
                        = Math.Pow(RedNoise[iteratorHeight * ImageMap.Size.Width + iteratorWidth], noiseReduction);
                    GreenNoise[iteratorHeight * ImageMap.Size.Width + iteratorWidth]
                        = Math.Pow(GreenNoise[iteratorHeight * ImageMap.Size.Width + iteratorWidth], noiseReduction);
                    BlueNoise[iteratorHeight * ImageMap.Size.Width + iteratorWidth]
                        = Math.Pow(BlueNoise[iteratorHeight * ImageMap.Size.Width + iteratorWidth], noiseReduction);

                    RedNoise[iteratorHeight * ImageMap.Size.Width + iteratorWidth] *= original;
                    GreenNoise[iteratorHeight * ImageMap.Size.Width + iteratorWidth] *= original;
                    BlueNoise[iteratorHeight * ImageMap.Size.Width + iteratorWidth] *= original;

                    R[iteratorHeight * ImageMap.Size.Width + iteratorWidth]
                        = (int)Math.Round(RedNoise[iteratorHeight * ImageMap.Size.Width + iteratorWidth]);
                    G[iteratorHeight * ImageMap.Size.Width + iteratorWidth]
                        = (int)Math.Round(GreenNoise[iteratorHeight * ImageMap.Size.Width + iteratorWidth]);
                    B[iteratorHeight * ImageMap.Size.Width + iteratorWidth]
                        = (int)Math.Round(BlueNoise[iteratorHeight * ImageMap.Size.Width + iteratorWidth]);

                }
            }
        }

    }

}
