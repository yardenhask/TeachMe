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
using ass5.View;
using ass5.Controler;

namespace ass5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool flag;
        private controler c;
        public MainWindow()
        {
            InitializeComponent();

        }

        public MainWindow(controler c)
        {
            InitializeComponent();

            // TODO: Complete member initialization
            this.c = c;
            this.Show();
        }

        private void Log_In_Click(object sender, RoutedEventArgs e)
        {
            if (username_text.Text.Equals("") || Password_text.Text.Equals(""))
            {
                MessageBox.Show("Please Enter User name and Password");
            }
            else
            {
                if (c.login(username_text.Text, Password_text.Text))
                {
                    c.teacher = c.m.teacher;
                    Menu0 main = new Menu0(username_text.Text.ToString(), c);
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("wrong password or username");
                }

            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_User_Click(object sender, RoutedEventArgs e)
        {
            string s = ID_text.Text;
            bool flag1 = true;
            int num;
            if (s.Length < 9 || !Int32.TryParse(s, out num))
            {
                MessageBox.Show("invalid Id");
                flag1 = false;
            }
            s = phone_text.Text;
            if (s.Length < 10 || !Int32.TryParse(s, out num))
            {
                MessageBox.Show("invalid phone");
                flag1 = false;
            }
            s = email_text.Text;
            string[] s1 = s.Split('@');
            if (s1.Length == 1)
            {
                MessageBox.Show("invlid email");
                flag1 = false;
            }
            if (fName_text.Equals(""))
            {
                MessageBox.Show("enter First Name");
                flag1 = false;
            }
            if (lName_text.Equals(""))
            {
                MessageBox.Show("enter Last Name");
                flag1 = false;
            }
            if (address_text.Equals(""))
            {
                MessageBox.Show("enter address");
                flag1 = false;
            }
           
            if (New_Password_text.Text.Equals(""))
            {
                MessageBox.Show("enter address");
                flag1 = false;
            }
            if (flag1)
            {
                c.addNewUser(fName_text.Text, lName_text.Text, ID_text.Text, phone_text.Text, address_text.Text, New_Password_text.Text, email_text.Text, flag);
                MessageBox.Show("user was added");
            }

        }

        private void teacher_Checked(object sender, RoutedEventArgs e)
        {
            flag = true;
        }

        private void teacher_Unchecked(object sender, RoutedEventArgs e)
        {
            flag = false;
        }

        private void fName_text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
