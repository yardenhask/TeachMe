using ass5.Controler;
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
using System.Windows.Shapes;

namespace ass5.View
{
    /// <summary>
    /// Interaction logic for Menu0.xaml
    /// </summary>
    public partial class Menu0 : Window
    {
        string teacherLogin;
        controler c;

        public Menu0(string t, controler c1)
        {
            InitializeComponent();
            c = c1;
            teacherLogin = t;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users(teacherLogin, c);
            users.Show();
            this.Close();
        }

        private void Matirials_Click(object sender, RoutedEventArgs e)
        {
            Materials mat = new Materials(teacherLogin, c);
            mat.Show();
            this.Close();
        }

        private void Classes_Click(object sender, RoutedEventArgs e)
        {
            Class_Menu clas = new Class_Menu(teacherLogin, c);
            clas.Show();
            this.Close();
        }

        private void Payments_Click(object sender, RoutedEventArgs e)
        {
            Payments pay = new Payments(teacherLogin, c);
            pay.Show();
            this.Close();
        }
    }
}
