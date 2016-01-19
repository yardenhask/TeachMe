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
    /// Interaction logic for Materials.xaml
    /// </summary>
    public partial class Materials : Window
    {
        string teacherLogin;
        controler c;
        public Materials(string t, controler c1)
        {
            InitializeComponent();
            c = c1;
            teacherLogin = t;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Menu0 main = new Menu0(teacherLogin, c);
            main.Show();
            this.Close();
        }

        private void Add_Assigment_Click(object sender, RoutedEventArgs e)
        {
            addMaterial add = new addMaterial(teacherLogin, c);
            add.Show();
        }

        private void Add_Solution_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("solution was added");
        }

        private void Add_Material_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("add metirial");
        }

        private void Retrieval_Material_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("matrial retrieved");
        }

        private void Delete_Material_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("metrial deleted");
        }
    }
}
