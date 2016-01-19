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
    /// Interaction logic for Class.xaml
    /// </summary>
    public partial class Class_Menu : Window
    {
        string teacherLogin;
        controler c;
        public Class_Menu(string t, controler c1)
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

        private void Open_Lesson_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Lesson opened");
        }

        private void Add_Student_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("student added");
        }

        private void Delete_Lesson_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("lesson deleted");
        }

        private void OnLine_Lesson_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("online lesson was added");
        }

        private void Close_Lesson_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("lesson closed");
        }
    }
}
