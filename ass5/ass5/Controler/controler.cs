﻿using ass5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ass5.Controler
{
    public class controler
    {
        public model m;
        public MainWindow v;
        public bool teacher;

        public controler() { teacher = false; }

        public void setModel(model model) { m = model; }
        public void setView(MainWindow view) { v = view; }

        public void addNewUser(string fname, string lname, string id, string phone, string address, string password, string email, bool isTeacher)
        {
            m.addUser(fname, lname, id, phone, address, password, email, isTeacher);

        }

        public bool login(string username, string password)
        {
            if (m.checkPassword(username, password))
                return true;
            return false;
        }

        public bool addNewMaterial(string path, string user, string teacher)
        {
           string id= m.findUserId(user);
            return (m.addMaterial(path, id, teacher));
        }

        public List<user> searchTeacher(string city)
        {
            return m.searchByCity(city);
        }

        internal List<user> findStudents(string t)
        {
            return m.findAvilableStudents(t);
        }
    }
}
