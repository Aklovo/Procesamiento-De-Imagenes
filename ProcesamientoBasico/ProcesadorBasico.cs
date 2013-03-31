using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProcesamientoBasico
{
    /*
     * Autor: Mario Rodríguez.
     * 
     * Version: 29 de enero de 2013.
     * 
     * Descripción: Separa los componentes rojo, verde y azul
     * de una imagen dada.
     * 
     */

    class ProcesadorBasico
    {
        public int[] R;
        public int[] G;
        public int[] B;
        public int[] RGB;
        public Bitmap mapa;
        public int Width;
        public int Height;

        public ProcesadorBasico(Bitmap mapa)
        {
            this.mapa = mapa;
            Width = mapa.Size.Width;
            Height = mapa.Size.Height;
        }

        public ProcesadorBasico(int Width,int Height, int[] array)
        {
            this.Width = Width;
            this.Height = Height;

            RGB = new int[Width * Height];

            int mascaraR = 0xFF0000;
            int mascaraG = 0xFF00;
            int mascaraB = 0xFF;

            for (int j = 0; j < Height; j++)
                for (int i = 0; i < Width; i++)
                {

                    int it = j * Width + i;
                    int color = array[it] != -1? 0 : -1;
                    int R = (color & mascaraR) >> 16;
                    int G = (color & mascaraG) >> 8;
                    int B = (color & mascaraB);

                    RGB[it] = (0xff << 24) | (R << 16) | (G << 8) | B;
                }    
        }

        public void setMapa(Bitmap mapa)
        {
            this.mapa = mapa;
            Width = mapa.Size.Width;
            Height = mapa.Size.Height;
        }

        public void descomponerRGB()
        {
            int mascaraR = 0xFF0000;
            int mascaraG = 0xFF00;
            int mascaraB = 0xFF; 

            R = new int[Width * Height];
            G = new int[Width * Height];
            B = new int[Width * Height];

            int color;
            for (int j = 0; j < Height; j++)
                for (int i = 0; i < Width; i++)
                {
                    color = mapa.GetPixel(i, j).ToArgb();

                    int it = j * Width + i;
                    R[it] = (color & mascaraR) >> 16;
                    G[it] = (color & mascaraG) >> 8;
                    B[it] = (color & mascaraB);
                }
        }

        public void componerRGB()
        {
            RGB = new int[Width * Height];
            for (int j = 0; j < Height; j++)
                for (int i = 0; i < Width; i++)
                {
                    int it = j * Width + i;
                    RGB[it] = (0xff << 24) | (R[it] << 16) | (G[it] << 8) | B[it];
                }    
        }

        public Bitmap getMapa()
        {
            Bitmap mapa = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int j = 0; j < Height ; j++)
                for (int i = 0; i < Width ; i++)
                    mapa.SetPixel(i, j, Color.FromArgb(RGB[j * Width + i]));

            return mapa;
        }


    }
}
