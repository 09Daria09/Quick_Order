using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Quick_Order
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow form = new MainWindow();
            IModel model = new Model();
            Presenter presenter = new Presenter(form, model);

            this.MainWindow = form; // Устанавливаем главное окно
            form.Show(); // Отображаем главное окно
        }
    }
}
