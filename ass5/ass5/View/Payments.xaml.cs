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
    /// Interaction logic for Payments.xaml
    /// </summary>
    public partial class Payments : Window
    {
        string teacherLogin;
        controler c;
        public Payments(string t, controler c1)
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

        private void Payment_Request_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("payment request opened");
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("payment confirmed");
        }

        private void Create_coupon_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" copun created");
        }
    }
}
