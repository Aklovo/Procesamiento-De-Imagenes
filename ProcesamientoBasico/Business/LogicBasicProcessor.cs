using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProcesamientoBasico
{
    class LogicBasicProcessor
    {
        public int[] R;
        public int[] G;
        public int[] B;
        public int[] RGB;

        public Bitmap ImageMap;
        public int Width;
        public int Height;

        protected const int redMask = 0xFF0000;
        protected const int greenMask = 0xFF00;
        protected const int blueMask = 0xFF;

        public LogicBasicProcessor(Bitmap ImageMap)
        {
            this.ImageMap = ImageMap;
            Width = ImageMap.Size.Width;
            Height = ImageMap.Size.Height;
        }

        public LogicBasicProcessor(int Width,int Height, int[] array)
        {
            int it, color;
            this.Width = Width;
            this.Height = Height;

            RGB = new int[Width * Height];

            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {

                    it = iteratorHeight * Width + iteratorWidth;
                    color = array[it] != -1 ? 0 : -1;
                   
                    int R = (color & redMask) >> 16;
                    int G = (color & greenMask) >> 8;
                    int B = (color & blueMask);

                    RGB[it] = (0xff << 24) | (R << 16) | (G << 8) | B;
                }
            }
        }

        public void setMapImage(Bitmap ImageMap)
        {
            this.ImageMap = ImageMap;
            Width = ImageMap.Size.Width;
            Height = ImageMap.Size.Height;
        }

        public void decomposeRGB()
        {
            R = new int[Width * Height];
            G = new int[Width * Height];
            B = new int[Width * Height];

            int color, it;

            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {
                    color = ImageMap.GetPixel(iteratorWidth, iteratorHeight).ToArgb();

                    it = iteratorHeight * Width + iteratorWidth;
                    R[it] = (color & redMask) >> 16;
                    G[it] = (color & greenMask) >> 8;
                    B[it] = (color & blueMask);
                }
            }
        }

        public void composeRGB()
        {
            RGB = new int[Width * Height];
            int it;

            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {
                    it = iteratorHeight * Width + iteratorWidth;
                    RGB[it] = (0xff << 24) | (R[it] << 16) | (G[it] << 8) | B[it];
                }
            }
        }

        public Bitmap getImageMap()
        {
            Bitmap imageMap = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {
                    imageMap.SetPixel(iteratorWidth, iteratorHeight, Color.FromArgb(RGB[iteratorHeight * Width + iteratorWidth]));
                }
            }

            return imageMap;
        }


    }
}
