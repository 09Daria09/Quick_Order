using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Quick_Order
{
    class Presenter
    {
        private IView _view;
        private IModel _model;

        TimeSpan _remainingTime;
        DispatcherTimer _timer;
        TimeSpan _totalTime;

        public Presenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
            _view.ButtonEvent += GameLogic;
            _view.NewGameEvent += new EventHandler<EventArgs>(InitializingButtons);
        }

        private async void GameLogic(object? sender, SelectionEventArgs e)
        {
            double minValue = _model.FindMinValueInMatrix();

            if (_model.Matrix[e.I, e.J] == minValue)
            {
                _view.Board[e.I, e.J].IsEnabled = false;
                _view.ListViewCorrect.Items.Add(minValue.ToString());
                _model.Delate(e.I, e.J);
            }
            else
            {
                _model.CountMistakes++;
                _view.Board[e.I, e.J].BorderBrush = _view.myBrushRed;
                _view.SetBorderThickness(e.I, e.J, new Thickness(5));


                await Task.Delay(1000);

                _view.Board[e.I, e.J].BorderBrush = _view.myBrushBlack;
                _view.SetBorderThickness(e.I, e.J, new Thickness(1));

            }
            if (_model.Win())
            {
                _timer.Stop();
                _view.ShowMessage($"Поздравляем! Вы победили.\nКоличество допущенных ошибок: {_model.CountMistakes}.");
                ResetGameState();
            }
        }

        private void InitializingButtons(object? sender, EventArgs e)
        {
            ResetGameState();

            double timer = 0.0;
            if (_view.ComboLevel.Text == _model.LevelEasy)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        int index = _model.GetRandomInteger();
                        _view.Board[i, j].Content = index;
                        _model.Matrix[i, j] = index;

                    }
                }
                timer = _model.TimerEasy;
            }
            if (_view.ComboLevel.Text == _model.LevelNormal)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        int index = _model.GetRandomIntNormal();
                        _view.Board[i, j].Content = index;
                        _model.Matrix[i, j] = index;
                    }
                }
                timer = _model.TimerNormal;
            }
            if (_view.ComboLevel.Text == _model.LevelHard)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        double index = _model.GetRandomDouble();
                        _view.Board[i, j].Content = index;
                        _model.Matrix[i, j] = index;
                    }
                }
                timer = _model.TimerHard;
            }
            InitializeTimer(timer);

        }
        public void InitializeTimer(double timeInMinutes)
        {
            _totalTime = TimeSpan.FromMinutes(timeInMinutes);
            _remainingTime = _totalTime;

            _view.ProgressBar.Maximum = _totalTime.TotalSeconds;
            _view.ProgressBar.Value = _totalTime.TotalSeconds;
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Tick -= TimerTick;
            }
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += TimerTick;
            _timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            _remainingTime = _remainingTime.Add(TimeSpan.FromSeconds(-1));

            _view.TextBoxTimer.Text = $"{_remainingTime.Minutes}:{_remainingTime.Seconds:D2}";
            _view.ProgressBar.Value = _remainingTime.TotalSeconds;

            if (_remainingTime.TotalSeconds <= 0)
            {
                _timer.Stop();
                _view.ShowMessage("Время вышло! Но не расстраивайтесь, вы можете продолжить игру");
            }
        }
        private void ResetGameState()
        {
            _model.CountMistakes = 0;
            _view.ListViewCorrect.Items.Clear();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _view.Board[i, j].IsEnabled = true;
                }
            }
        }

    }
}
