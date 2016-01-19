using ass5.Controler;
using ass5.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ass5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public void onStart(object sender, StartupEventArgs e)
        {
            controler c = new controler();
            model m = new model(c);
            MainWindow main = new MainWindow(c);
            c.setModel(m);
            c.setView(main);

        }

    }
}
