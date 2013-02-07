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

        public OperacionesBasicas(Bitmap mapa) : base(mapa)
        {
            
        }


        public void escalaDeGrises()
        {
            RGB = new int[Width * Height];
            for (int j = 0; j < mapa.Size.Height; j++)
                for (int i = 0; i < mapa.Size.Width; i++)
                {
                    int it = j * Width + i;
                    int color = (R[it] + G[it] + B[it]) / 3;
                    R[it] = color;
                    G[it] = color;
                    B[it] = color;
                }
        }

        public void binarizacion(int lumbral)
        {
            RGB = new int[Width * Height];
            for (int j = 0; j < Height; j++)
                for (int i = 0; i < Width; i++)
                {
                    int it = j * Width + i;
                    R[it] = R[it] < lumbral ? 0 : 255;
                    G[it] = G[it] < lumbral ? 0 : 255;
                    B[it] = B[it] < lumbral ? 0 : 255;
                }
        }

        public void negativo()
        {
            RGB = new int[Width * Height];
            for (int j = 0; j < Height; j++)
                for (int i = 0; i < Width; i++)
                {
                    int it = j * Width + i;
                    R[it] = 255 - R[it];
                    G[it] = 255 - G[it];
                    B[it] = 255 - B[it];
                }
        }

    }
}
