using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProcesamientoBasico
{
    class OperacionesBasicas : ProcesadorBasico
    {
        public OperacionesBasicas(Bitmap mapa) : base(mapa) { }

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
    }

}
