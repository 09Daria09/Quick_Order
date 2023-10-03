using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Quick_Order
{
    interface IView
    {
        event EventHandler<SelectionEventArgs> ButtonEvent;
        event EventHandler<EventArgs> NewGameEvent;
        ComboBox ComboLevel { get; set; } 
        TextBox TextBoxTimer { get; set; }
        ProgressBar ProgressBar { get; set; }
        ListView ListViewCorrect { get; set; }
        void ShowMessage(string message);
        Brush myBrushRed {  get; set; }
        Brush myBrushBlack { get; set; }
        void SetBorderThickness(int i, int j, Thickness thickness);

        Button[,] Board { get; set; }
    }
    public class SelectionEventArgs : EventArgs
    {
        public int I { get; }
        public int J { get; }

        public SelectionEventArgs(int i, int j)
        {
            I = i;
            J = j;
        }
    }
}
