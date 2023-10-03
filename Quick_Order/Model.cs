using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Quick_Order
{
    class Model : IModel
    {
        private readonly Random _random = new Random();

        public string LevelEasy { get; set; } = "Легкий";
        public string LevelNormal { get; set; } = "Средний";
        public string LevelHard { get; set; } = "Тяжёлый";
        public double TimerEasy { get; set; } = 1;
        public double TimerHard { get; set; } = 2;
        public double TimerNormal { get; set; } = 1;
        public double[,] Matrix { get; } = new double[4, 4];

        public int CountMistakes { get; set; } = 0;

        public int GetRandomInteger()
        {
            return _random.Next(0, 101);
        }
        public int GetRandomIntNormal()
        {
            return _random.Next(0, 200);
        }
        public double GetRandomDouble()
        {
            return Math.Round(_random.NextDouble() * 100, 2);
        }
        public double FindMinValueInMatrix()
        {
            double minValue = double.MaxValue;
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (Matrix[i, j] < minValue)
                    {
                        minValue = Matrix[i, j];
                    }
                }
            }
            return minValue;
        }

        public void Delate(int i, int j)
        {
            Matrix[i, j] = double.NaN; 
        }
        public bool Win()
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (!double.IsNaN(Matrix[i, j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
