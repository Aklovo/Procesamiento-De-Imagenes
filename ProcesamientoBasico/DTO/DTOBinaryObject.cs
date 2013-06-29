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
        public int[] Pixels { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public DTOCoordinate Points { get; set; }
        public DTOCoordinate BottomPoint { get; set; }
        public int Label { get; set; }
        public DTOCoordinate CenterOfMass{ get; set; }
        public int totalActivePixels{ get; set; }

        public DTOBinaryObject() { }

        public DTOBinaryObject(Bitmap map, int etiqueta)
        {
            Width = map.Width;
            Height = map.Height;
            Label = etiqueta;
            Pixels = new int[Width * Height];

            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++){
                    int it = iteratorHeight * Width + iteratorWidth;
                    Pixels[it] = map.GetPixel(iteratorWidth, iteratorHeight).B == 0 ? 255 : -1;
                }
                    
        }

        public DTOBinaryObject(int label, int x, int y)
        {
            Points = new DTOCoordinate(x,y);
            BottomPoint = new DTOCoordinate(x,y);

            Label = label;
        }

        public void checkPoint(int x, int y)
        {
            Points.PosX = Math.Min(Points.PosX, x);
            Points.PosY = Math.Min(Points.PosY, y);
            BottomPoint.PosX = Math.Max(BottomPoint.PosX, x);
            BottomPoint.PosY = Math.Max(BottomPoint.PosY, y);

        }

        public void computeSize()
        {
            Width = BottomPoint.PosX - Points.PosX + 1;
            Height = BottomPoint.PosY - Points.PosY + 1;
        }

        public void setCenterOfMass() 
        {
            
            int sumX = 0, x = 0;
            int sumY = 0, y = 0;
            totalActivePixels = 0;

            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {
                    if (Pixels[iteratorHeight * Width + iteratorWidth] != -1)
                    {
                        totalActivePixels++;
                        sumY += iteratorHeight;
                        sumX += iteratorWidth;
                        x++;
                        y++;
                    }
                }
            }

            CenterOfMass = new DTOCoordinate( (int)Math.Round( (float)sumX / (float)x) ,  (int)Math.Round( (float)sumY / (float)y) );

        }
    }
}
