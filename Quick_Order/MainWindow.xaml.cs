using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quick_Order
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        private Button[,] board = new Button[4, 4];
        public MainWindow()
        {
            InitializeComponent();
            Board[0, 0] = ButtonRow0Col0; Board[0, 1] = ButtonRow0Col1; Board[0, 2] = ButtonRow0Col2; Board[0, 3] = ButtonRow0Col3;
            Board[1, 0] = ButtonRow1Col0; Board[1, 1] = ButtonRow1Col1; Board[1, 2] = ButtonRow1Col2; Board[1, 3] = ButtonRow1Col3;
            Board[2, 0] = ButtonRow2Col0; Board[2, 1] = ButtonRow2Col1; Board[2, 2] = ButtonRow2Col2; Board[2, 3] = ButtonRow2Col3;
            Board[3, 0] = ButtonRow3Col0; Board[3, 1] = ButtonRow3Col1; Board[3, 2] = ButtonRow3Col2; Board[3, 3] = ButtonRow3Col3;
            ComboLevel = difficultyComboBox;
            TextBoxTimer = Timer;
            ProgressBar = MyProgressBar;
            ListViewCorrect = ListView;
            myBrushRed = Brushes.Red;
            myBrushBlack = Brushes.Black;
        }
        public Button[,] Board
        {
            get
            {
                return board;
            }
            set
            {
                board = value;
            }
        }
        public ComboBox ComboLevel { get; set; }
        public TextBox TextBoxTimer { get; set; }
        public ProgressBar ProgressBar { get; set; }
        public ListView ListViewCorrect { get; set; }
        public Brush myBrushRed { get; set; }
        public Brush myBrushBlack { get; set; }

        public event EventHandler<SelectionEventArgs> ButtonEvent;
        public event EventHandler<EventArgs> NewGameEvent;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button clickedButton = sender as Button;

                if (clickedButton != null)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (Board[i, j] == clickedButton)
                            {
                                ButtonEvent?.Invoke(this, new SelectionEventArgs(i, j));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NewGameEvent?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
        public void SetBorderThickness(int i, int j, Thickness thickness)
        {
            Board[i, j].BorderThickness = thickness;
        }
    }
}
