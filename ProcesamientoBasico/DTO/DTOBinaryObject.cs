using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesamientoBasico
{
    public class DTOBinaryObject
    {
        public int[] Pixeles { get; set; }
        public int Anchura { get; set; }
        public int Altura { get; set; }
        public DTOCoordinate Cordenadas { get; set; }
        public DTOCoordinate CordenadasInferior { get; set; }
        public int Etiqueta { get; set; }
        public DTOCoordinate CentroDeMasa{ get; set; }
        public int totalActivePixels;

        public DTOBinaryObject()
        { 
        
        }

        public DTOBinaryObject(Bitmap map, int etiqueta)
        {
            
            Anchura = map.Width;
            Altura = map.Height;
            Etiqueta = etiqueta;
            Pixeles = new int[Anchura * Altura];

            for (int j = 0; j < Altura; j++)
                for (int i = 0; i < Anchura; i++){
                    int it = j * Anchura + i;
                    Pixeles[it] = map.GetPixel(i, j).B == 0 ? 255 : -1;
                }
                    
        }

        public DTOBinaryObject(int etiqueta, int x, int y)
        {
            Cordenadas = new DTOCoordinate(x,y);
            CordenadasInferior = new DTOCoordinate(x,y);

            Etiqueta = etiqueta;
        }

        public void VerificarPunto(int x, int y)
        {
            Cordenadas.PosX = Math.Min(Cordenadas.PosX, x);
            Cordenadas.PosY = Math.Min(Cordenadas.PosY, y);
            CordenadasInferior.PosX = Math.Max(CordenadasInferior.PosX, x);
            CordenadasInferior.PosY = Math.Max(CordenadasInferior.PosY, y);

        }

        public void CalcularAnchuraAltura()
        {
            Anchura = CordenadasInferior.PosX - Cordenadas.PosX + 1;
            Altura = CordenadasInferior.PosY - Cordenadas.PosY + 1;
        }

        public void CalcularCentroDeMasa() 
        {
            
            int sumaX = 0, x = 0;
            int sumaY = 0, y = 0;
            totalActivePixels = 0;

            for (int j = 0; j < Altura; j++)
                for (int i = 0; i < Anchura; i++)
                    if (Pixeles[j * Anchura + i] != -1)
                    {
                        totalActivePixels++;
                        sumaY += j;
                        sumaX += i;
                        x++;
                        y++;
                    }

            CentroDeMasa = new DTOCoordinate( (int)Math.Round( (float)sumaX / (float)x) ,  (int)Math.Round( (float)sumaY / (float)y) );

        }

        public int getTotalActivePixels()
        {
            return totalActivePixels;
        }
    }
}
