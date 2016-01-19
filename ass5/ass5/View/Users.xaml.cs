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
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        string teacherLogin;
        controler c;
        public Users(string t, controler c1)
        {
            InitializeComponent();
            teacherLogin = t;
            c = c1;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Menu0 main = new Menu0(teacherLogin, c);
            main.Show();
            this.Close();
        }

        private void Update_User_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("user updated");
        }

        private void Delete_User_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("user deleted");
        }

        private void Techer_Management_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("teacher managment opend");
        }
    }
}
