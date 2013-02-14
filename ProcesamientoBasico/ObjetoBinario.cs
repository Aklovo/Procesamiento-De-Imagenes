using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesamientoBasico
{
    class ObjetoBinario
    {
        public int[] Pixeles { get; set; }
        public int Anchura { get; set; }
        public int Altura { get; set; }
        public Cordenada Cordenadas { get; set; }
        public Cordenada CordenadasInferior { get; set; }
        public int Etiqueta { get; set; }

        public ObjetoBinario(int etiqueta, int x, int y)
        {
            Cordenadas = new Cordenada(x,y);
            CordenadasInferior = new Cordenada(x,y);

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

        override public String ToString() 
        {
            return Cordenadas + " " + CordenadasInferior + " Alt: " + Altura + " Anch: " + Anchura;
        }
    }
}
