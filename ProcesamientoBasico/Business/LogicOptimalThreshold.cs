using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesamientoBasico.Business
{
    class LogicOptimalThreshold
    {
        public int OptimalThreshold { get; set; }

        public LogicOptimalThreshold(Dictionary<int, int> mapPixels)
        {
            double minValue, valueLeft, valueRight, varLeft, varRight, weightLeft, weightRight, minTotal;
            int totalWeight;
            minValue = 0;
            minTotal = 1 << 30;

            totalWeight = getTotalWeight(mapPixels);

            for (int iteratorPixels = 1; iteratorPixels < mapPixels.Count; iteratorPixels++)
            {
                valueLeft = getLeftAverage(mapPixels, iteratorPixels);
                valueRight = getRightAverage(mapPixels, iteratorPixels);

                varLeft = getLeftVariance(mapPixels, iteratorPixels, valueLeft);
                varRight = getRightVariance(mapPixels, iteratorPixels, valueRight);

                weightLeft = getLeftWeight(mapPixels, iteratorPixels);
                weightRight = getRightWeight(mapPixels, iteratorPixels);

                minValue = (varLeft * (weightLeft / totalWeight)) + (varRight * (weightRight / totalWeight));

                if (minValue > 0)
                    minTotal = Math.Min(minValue, minTotal);

            }

            OptimalThreshold = (int)minTotal;
        }

        private int getTotalWeight(Dictionary<int, int> mapPixels)
        {
            int total = 0;

            for (int iteratorPixels = 0; iteratorPixels < mapPixels.Count ; iteratorPixels++)
            {
                total += mapPixels[iteratorPixels];
            }

            return total;
        }

        private double getLeftAverage(Dictionary<int, int> mapPixels, int bound)
        {
            double up = 0, down = 0;

            for (int iteratorBound = 0; iteratorBound < bound; iteratorBound++)
            {
                up += (mapPixels[iteratorBound] * iteratorBound);
                down += mapPixels[iteratorBound];
            }

            return up / down;
        }

        private double getRightAverage(Dictionary<int, int> mapPixels, int bound)
        {
            double up = 0, down = 0;

            for (int iteratorBound = bound; iteratorBound < mapPixels.Count; iteratorBound++)
            {
                up += (mapPixels[iteratorBound] * iteratorBound);
                down += mapPixels[iteratorBound];
            }

            return up / down;
        }

        private double getRightWeight(Dictionary<int, int> mapPixels, int bound)
        {
            double sum = 0;

            for (int iteratorBound = bound; iteratorBound < mapPixels.Count; iteratorBound++)
            {
                sum += mapPixels[iteratorBound];
            }

            return sum;
        }

        private double getLeftWeight(Dictionary<int, int> mapPixels, int bound)
        {
            double sum = 0;

            for (int iteratorBound = 0; iteratorBound < bound; iteratorBound++)
            {
                sum += mapPixels[iteratorBound];
            }

            return sum;
        }

        private double getRightVariance(Dictionary<int, int> mapPixels, int bound, double valueRight)
        {
            double up = 0, down = 0;

            for (int iteratorBound = bound ; iteratorBound < mapPixels.Count; iteratorBound++)
            {
                up += ((mapPixels[iteratorBound] - valueRight) * iteratorBound);
                down += mapPixels[iteratorBound];
            }

            return up / down;
        }

        private double getLeftVariance(Dictionary<int, int> mapPixels, int bound, double valueLeft)
        {
            double up = 0, down = 0;

            for (int iteratorBound = 0; iteratorBound < bound; iteratorBound++)
            {
                up += ((mapPixels[iteratorBound] - valueLeft) * iteratorBound);
                down += mapPixels[iteratorBound];
            }

            return up / down;
        }


    }
}
