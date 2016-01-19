using ass5.Controler;
using Microsoft.Win32;
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
    /// Interaction logic for addMaterial.xaml
    /// </summary>
    public partial class addMaterial : Window
    {
        string sFileName;
        private class Item
        {
            public string first;
            public string last;
            public Item(string f, string l)
            {
                first = f; last = l;
            }
            public string toString() { return first + " " + last;  }
        }

        string teacherLogin;
        controler c;
        public addMaterial(string t, controler c)
        {
            this.c = c;
            InitializeComponent();
            teacherLogin = t;
            List<user> students = c.findStudents(t);
            ComboBox studentsList = new ComboBox();
            foreach (user u in students)
            {
                Item i = new Item(u.fname, u.lname);
                studentsList.Items.Add(i.toString());
            }
            studentsList.Height=50;
            studentsList.Width=100;
            addM.canv.Children.Add(studentsList);
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = " All Files|*.*";
            if (f.ShowDialog() == true)
            {
                sFileName = f.FileName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            c.addNewAssigment(sFileName, "yarden", teacherLogin);
        }
    }
}
