using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProcesamientoBasico
{
    class LogicSegmentation : LogicBasicOperations
    {
        
        public LogicSegmentation(Bitmap imageMap) : base(imageMap){}

        int[] Colors;
        Dictionary<int, int> DictionaryColors = new Dictionary<int, int>();
        Dictionary<int, DTOBinaryObject> BinaryObjects = new Dictionary<int, DTOBinaryObject>();
 
        public void segmentation()
        {
            RGB = new int[Width * Height];
            Colors = new int[Width * Height];

            int cont = 0;

            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {
                    int it = iteratorHeight * Width + iteratorWidth;

                    if (ImageMap.GetPixel(iteratorWidth, iteratorHeight).ToArgb() != -1)
                    {
                        Colors[it] = ++cont;
                    }
                    else
                    {
                        Colors[it] = -1;
                    }
                }
            }

            createMaps();
            drawMaps();
        }

        public Dictionary<int, DTOBinaryObject> generateBinaryObjects()
        {
            segmentation();

            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {
                    int it = iteratorHeight * Width + iteratorWidth;
                    DTOBinaryObject binaryObject;

                    if (Colors[it] != -1) {
                        if(BinaryObjects.TryGetValue(Colors[it], out binaryObject)){
                            binaryObject.checkPoint(iteratorWidth,iteratorHeight);
                        } else {
                            binaryObject = new DTOBinaryObject(Colors[it], iteratorWidth, iteratorHeight);
                            BinaryObjects[Colors[it]] = binaryObject;
                        }
                    }
                }
            }

            foreach (var binaryObject in BinaryObjects) {

                binaryObject.Value.computeSize();
                int ptr = 0;
                binaryObject.Value.Pixels = new int[binaryObject.Value.Height * binaryObject.Value.Width];

                for (int iteratorPositionY = binaryObject.Value.Points.PosY ; 
                    iteratorPositionY <= binaryObject.Value.BottomPoint.PosY ; 
                    iteratorPositionY++)
                {
                    for (int i = binaryObject.Value.Points.PosX; i <= binaryObject.Value.BottomPoint.PosX; i++)
                    {
                        int it = iteratorPositionY * Width + i;
                        binaryObject.Value.Pixels[ptr++]  = Colors[it];
                    }
                }

                binaryObject.Value.setCenterOfMass();
                
            }

            return BinaryObjects;
        }

        public void printObjects()
        {
            Dictionary<int, Bitmap> bitMaps = new Dictionary<int, Bitmap>();
            int height;
            int width;
            int[] pixels;

            foreach (var binaryObject in BinaryObjects)
            { 
                
                height = binaryObject.Value.Height;
                width = binaryObject.Value.Width;
                pixels = binaryObject.Value.Pixels;

                Bitmap imageMap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                for (int iteratorHeight = 0; iteratorHeight < height; iteratorHeight++)
                {
                    for (int iteratorWidth = 0; iteratorWidth < width; iteratorWidth++)
                    {

                        int it = iteratorHeight * width + iteratorWidth;

                        int rgb = (0xff << 24) | (0 << 16) | (0 << 8) | 0;

                        if (pixels[it] == -1)
                            rgb = (0xff << 24) | (255 << 16) | (255 << 8) | 255;

                        imageMap.SetPixel(iteratorWidth, iteratorHeight, Color.FromArgb(rgb));
                        imageMap.Save(@"\\vmware-host\Shared Folders\Pictures\Objetos\" + binaryObject.Key + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
                    }
                }

            }
        }

        public void createMaps()
        {
            Boolean foundChange = true;
            int number = 0;

            while (foundChange)
            {
                foundChange = false;
                for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
                {
                    for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                    {
                        if (Colors[iteratorHeight * Width + iteratorWidth] != -1)
                        {
                            number = checkPixelsAround(iteratorHeight * Width + iteratorWidth, Colors[iteratorHeight * Width + iteratorWidth]);

                            if (number != -1 && number != Colors[iteratorHeight * Width + iteratorWidth])
                            {
                                Colors[iteratorHeight * Width + iteratorWidth] = number;
                                foundChange = true;
                            }

                        }
                    }
                }
            }

        }

        public void drawMaps() 
        {
            int actual, value, it, color;

            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {
                    actual = iteratorHeight * Width + iteratorWidth;

                    if (Colors[actual] != -1 && !DictionaryColors.TryGetValue(Colors[actual], out value))
                        DictionaryColors[Colors[actual]] = Colors[actual] * 100000;
                }
            }
            
            DictionaryColors[-1] = 0xFFFFFF;

            RGB = new int[Width * Height];

            for (int iteratorHeight = 0; iteratorHeight < Height; iteratorHeight++)
            {
                for (int iteratorWidth = 0; iteratorWidth < Width; iteratorWidth++)
                {
                    it = iteratorHeight * Width + iteratorWidth;
                    color = DictionaryColors[Colors[it]];

                    int R = (color & redMask) >> 16;
                    int G = (color & greenMask) >> 8;
                    int B = (color & blueMask);

                    RGB[it] = (0xff << 24) | (R << 16) | (G << 8) | B;
                }
            }

        }

        public int checkPixelsAround(int actual, int min) 
        {
            
            int leftTop = actual-Width-1;
            if(leftTop >= 0 && Colors[leftTop] != -1)
            {
                min = Math.Min(min, Colors[leftTop]);
            }

            int centerTop = actual - Width;
            if (centerTop >= 0 && Colors[centerTop] != -1)
            {
                min = Math.Min(min, Colors[centerTop]);
            }

            int rightTop = actual - Width + 1;
            if (rightTop >= 0 && Colors[rightTop] != -1)
            {
                min = Math.Min(min, Colors[rightTop]);
            }

            int centerLeft = actual - 1;
            if (centerLeft >= 0 && Colors[centerLeft] != -1)
            {
                min = Math.Min(min, Colors[centerLeft]);
            }

            int centerRight = actual + 1;
            if (centerRight < Width * Height && Colors[centerRight] != -1)
            { 
                min = Math.Min(min,Colors[centerRight]);
            }

            int leftBottom = actual + Width - 1;
            if (leftBottom < Width * Height && Colors[leftBottom] != -1)
            {
                min = Math.Min(min,Colors[leftBottom]);
            }

            int centerBottom = actual + Width;
            if (centerBottom < Width * Height && Colors[centerBottom] != -1)
            {
                min = Math.Min(min, Colors[centerBottom]);
            }

            int rightBottom = actual + Width + 1;
            if (rightBottom < Width * Height && Colors[rightBottom] != -1)
            {
                min = Math.Min(min, Colors[rightBottom]);
            }

            return min;
        }
    }
    
}
