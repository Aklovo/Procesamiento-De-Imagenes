using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProcesamientoBasico
{
    class AlgoritmoSegmentacion : OperacionesBasicas
    {
        
        public AlgoritmoSegmentacion(Bitmap mapa) : base(mapa){}

        int[] VectorColores;
        Dictionary<int, int> colores = new Dictionary<int, int>();
        Dictionary<int, ObjetoBinario> ObjetosBinarios = new Dictionary<int, ObjetoBinario>();
 
        public void segmentacion()
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
                        VectorColores[it] = ++cont;
                    else
                        VectorColores[it] = -1;
                }
            }

            generarMapas();
            colorearMapas();
        }

        public Dictionary<int, ObjetoBinario> generarObjetosBinarios()
        {
            segmentacion();

            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    int it = j * Width + i;
                    ObjetoBinario objeto;

                    if (VectorColores[it] != -1) {
                        if(ObjetosBinarios.TryGetValue(VectorColores[it], out objeto)){
                            objeto.VerificarPunto(i,j);
                        } else {
                            objeto = new ObjetoBinario(VectorColores[it], i, j);
                            ObjetosBinarios[VectorColores[it]] = objeto;
                        }
                    }
                }
            }

            foreach (var objetoBinario in ObjetosBinarios) {

                objetoBinario.Value.CalcularAnchuraAltura();
                int ptr = 0;
                objetoBinario.Value.Pixeles = new int[objetoBinario.Value.Altura * objetoBinario.Value.Anchura];

                for (int j = objetoBinario.Value.Cordenadas.PosY; j <= objetoBinario.Value.CordenadasInferior.PosY; j++)
                {
                    for (int i = objetoBinario.Value.Cordenadas.PosX; i <= objetoBinario.Value.CordenadasInferior.PosX; i++)
                    {
                        int it = j * Width + i;
                        objetoBinario.Value.Pixeles[ptr++]  = VectorColores[it];
                    }
                }

                objetoBinario.Value.CalcularCentroDeMasa();
                
            }

            return ObjetosBinarios;
        }

        public void imprimirObjetos()
        {
            Dictionary<int, Bitmap> BitMaps = new Dictionary<int, Bitmap>();
            int altura;
            int anchura;
            int[] pixeles;

            foreach (var objetos in ObjetosBinarios)
            { 
                
                altura = objetos.Value.Altura;
                anchura = objetos.Value.Anchura;
                pixeles = objetos.Value.Pixeles;

                Bitmap mapa = new Bitmap(anchura, altura, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                for (int j = 0; j < altura; j++)
                    for (int i = 0; i < anchura; i++)
                    {

                        int it = j * anchura + i;

                        int rgb = (0xff << 24) | (0 << 16) | (0 << 8) | 0; 

                        if (pixeles[it] == -1)
                            rgb = (0xff << 24) | (255 << 16) | (255 << 8) | 255;

                        mapa.SetPixel(i, j, Color.FromArgb(rgb));
                        mapa.Save(@"\\vmware-host\Shared Folders\Pictures\Objetos\" + objetos.Key + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
                    }

            }
        }

        public void generarMapas()
        {
            Boolean foundChange = true;
            int numero = 0;
            while (foundChange)
            {
                foundChange = false;

                for (int j = 0; j < Height; j++)
                    for (int i = 0; i < Width; i++)
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

        public void colorearMapas() 
        {

            for (int j = 0; j < Height; j++)
                for (int i = 0; i < Width; i++)
                {
                    int actual = j * Width + i;
                    int value;

                    if (VectorColores[actual] != -1 && !colores.TryGetValue(VectorColores[actual], out value)) 
                        colores[VectorColores[actual]] = VectorColores[actual] * 100000;
                }
            
            colores[-1] = 0xFFFFFF;

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
