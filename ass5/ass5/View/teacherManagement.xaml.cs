﻿using ass5.Controler;
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
    /// Interaction logic for teacherManagement.xaml
    /// </summary>
    public partial class teacherManagement : Window
    {
        private class Item
        {
            public string first;
            public string last;
            public Item(string f, string l)
            {
                first = f; last = l;
            }
            public string toString() { return first + " " + last; }
        }

        controler c;
        string teacherLogin;
        public teacherManagement(string t, controler c1)
        {
            InitializeComponent();
            c = c1;
            teacherLogin = t;
        }

        private void empty_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("opened");
        }

        private void search_city_Click(object sender, RoutedEventArgs e)
        {
            List<user> teachers= c.searchTeacher(search_Text.Text);
            //add to canvas
            ListBox l = new ListBox();
            foreach (user s in teachers)
            {
                Item i = new Item(s.fname, s.lname);
                l.Items.Add(i.toString());
            }
            canv.Children.Add(l);
            Canvas.SetLeft(l,190);
            Canvas.SetTop(l, 170);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Users u = new Users(teacherLogin, c);
            u.Show();
            this.Close();
        }
    }
}
