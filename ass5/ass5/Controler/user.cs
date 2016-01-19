using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ass5.Controler
{
    public class user
    {
        public string fname;
        public string lname;
        public string id;
        public string phone;
        public string address;
        public string password;
        public string email;
        public char teacher;
        public user(string fname1, string lname1, string id1, string phone1, string address1, string password1, string email1, bool isTeacher1)
        {
            fname = fname1;
            lname = lname1;
            id = id1;
            phone = phone1;
            address = address1;
            password = password1;
            email = email1;
            if (isTeacher1)
                teacher = 't';
            else
                teacher = 's';
        }

    }
}
