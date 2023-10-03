using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick_Order
{
    interface IModel
    {
        int GetRandomInteger();
        double GetRandomDouble();
        int GetRandomIntNormal();
        double FindMinValueInMatrix();
        bool Win();
        void Delate(int i, int j);
        double [,] Matrix {  get; }
        string LevelEasy { get; set; }
        string LevelNormal { get; set; }
        string LevelHard { get; set; }
        
        double TimerEasy { get; set; }
        double TimerHard { get; set; }
        double TimerNormal { get; set; }

        int CountMistakes { get; set; }

    }
}
