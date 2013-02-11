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
        int[] VectorColores;

        public OperacionesBasicas(Bitmap mapa) : base(mapa){}

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

        public void clasificacion()
        {
            RGB = new int[Width * Height];
            VectorColores = new int[Width * Height];

            int cont = 0;

            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    int it = j * Width + i;

                    if (mapa.GetPixel(i, j).ToArgb() != -1)
                    {
                        VectorColores[it] = ++cont;
                    }
                    else
                    {
                        VectorColores[it] = -1;
                    }

                }
            }

            generarMapas();
            colorearMapas();
        }

        public void generarMapas()
        {
            Boolean foundChange = true;

            while (foundChange)
            {
                foundChange = false;

                for (int j = 0; j < Height; j++)
                {
                    for (int i = 0; i < Width; i++)
                    {
                        int numero;

                        if (VectorColores[j * Width + i] != -1)
                        {
                            numero = verificarPixelesAlrededor(j * Width + i, VectorColores[j * Width + i]);

                            if (numero != -1 && numero != VectorColores[j * Width + i])
                            {
                                VectorColores[j * Width + i] = numero;
                                foundChange = true;
                            }

                        }

                    }
                }
            }
        }

        public void colorearMapas() 
        {

            Dictionary<int,int> colores = new Dictionary<int, int>();
            
            int[] coloresRGB = new int[7];
            coloresRGB[0] = 0x8A2BE2; // Violet
            coloresRGB[1] = 0x0000FF; // Blue
            coloresRGB[2] = 0x00FF00; // Green
            coloresRGB[3] = 0xFF0000; // Red
            coloresRGB[4] = 0xFF8C00; // Orange
            coloresRGB[5] = 0XFF1493; // Pink
            coloresRGB[6] = 0xFFFFFF; // White

            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    int actual = j * Width + i;
                    int value;

                    if (VectorColores[actual] != -1 && !colores.TryGetValue(VectorColores[actual], out value)) 
                    {
                        colores[VectorColores[actual]] = 0;
                    }
                }
            }

            for (int index = 0; index < colores.Count; index++)
            {
                colores[colores.ElementAt(index).Key]= coloresRGB[index%6];
            }

            colores[-1] = coloresRGB[6];

            RGB = new int[Width * Height];

            int mascaraR = 0xFF0000;
            int mascaraG = 0xFF00;
            int mascaraB = 0xFF;

            for (int j = 0; j < Height; j++)
                for (int i = 0; i < Width; i++)
                {
                    int it = j * Width + i;
                    int color = colores[VectorColores[it]];
                    int R =  (color & mascaraR) >> 16;
                    int G = (color & mascaraG) >> 8;
                    int B = (color & mascaraB);

                    RGB[it] = (0xff << 24) | (R << 16) | (G << 8) | B;
                }    

        }

        public int verificarPixelesAlrededor(int actual, int min) 
        {
            
            int izqSuperior = actual-Width-1;
            if(izqSuperior >= 0 && VectorColores[izqSuperior] != -1)
            {
                min = Math.Min(min, VectorColores[izqSuperior]);
            }

            int centSuperior = actual - Width;
            if (centSuperior >= 0 && VectorColores[centSuperior] != -1)
            {
                min = Math.Min(min, VectorColores[centSuperior]);
            }

            int derSuperior = actual - Width + 1;
            if (derSuperior >= 0 && VectorColores[derSuperior] != -1)
            {
                min = Math.Min(min, VectorColores[derSuperior]);
            }

            int izqCentral = actual - 1;
            if (izqCentral >= 0 && VectorColores[izqCentral] != -1)
            {
                min = Math.Min(min, VectorColores[izqCentral]);
            }

            int derCentral = actual + 1;
            if (derCentral < Width * Height && VectorColores[derCentral] != -1)
            { 
                min = Math.Min(min,VectorColores[derCentral]);
            }

            int izqInferior = actual + Width - 1;
            if (izqInferior < Width * Height && VectorColores[izqInferior] != -1)
            {
                min = Math.Min(min,VectorColores[izqInferior]);
            }

            int centInferior = actual + Width;
            if (centInferior < Width * Height && VectorColores[centInferior] != -1)
            {
                min = Math.Min(min, VectorColores[centInferior]);
            }

            int derInferior = actual + Width + 1;
            if (derInferior < Width * Height && VectorColores[derInferior] != -1)
            {
                min = Math.Min(min, VectorColores[derInferior]);
            }

            return min;
        }

    }


}
