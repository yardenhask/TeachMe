using ass5.Controler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ass5.Model
{
    public class model
    {
        public controler c;
        public int MaterialCode;

        public model(controler controler)
        {
            c = controler;
            readMaterialCode();
        }

        private void readMaterialCode()
        {
            string insert = @"SELECT * FROM [Material] ";
            int max = 0;
            SqlConnection connect = getConnection();
            SqlCommand command = new SqlCommand(insert, connect);
            try
            {
                connect.Open();
                SqlDataReader read = command.ExecuteReader();
                string s;
                while (read.Read())
                {
                    s = read["mId"].ToString();
                    if (max < Int32.Parse(s))
                        max = Int32.Parse(s);
                }

                //   MaterialCode = Int32.Parse(read["maxid"].ToString()) + 1;
                //       MaterialCode =  1;
            }
            catch (SqlException ex) { throw ex; }
            finally
            {
                connect.Close();
            }
        }

        public static SqlConnection getConnection()
        {
            string connect = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ירדן\Documents\GitHub\TeachMe\ass5\ass5\Model\Database\TeachMeDB.mdf;Integrated Security=True";
            SqlConnection data = new SqlConnection(connect);
            return data;
        }

        public void addUser(string fname, string lname, string id, string phone, string address, string password, string email, bool isTeacher)
        {
            char @t = 's';
            if (isTeacher)
                @t = 't';
            string insert = "INSERT INTO[Users] ([userId] ,[userPassword],[userFirstName],[userLastName],[userPhoneNumber],[userAddress],[userEmail],[isTeacher]) VALUES (@id,@password,@fname,@lastn, @phone,@address,@email,@isTeacher)";
            SqlConnection connect = getConnection();
            SqlCommand command = new SqlCommand(insert, connect);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@fname", fname);
            command.Parameters.AddWithValue("@lastn", lname);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@isTeacher", @t);
            try
            {
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw ex; }
            finally { connect.Close(); }

        }

        public bool checkPassword(string username, string password)
        {
            bool ans = false;
            string insert = @"SELECT * FROM [Users] WHERE [userId]=" + username;
            SqlConnection connect = getConnection();
            SqlCommand command = new SqlCommand(insert, connect);
            try
            {
                connect.Open();
                SqlDataReader read = command.ExecuteReader();
                read.Read();
                string userP = read["userPassword"].ToString();
                if (password.Equals(userP))
                    ans = true;
            }
            catch (SqlException ex) { throw ex; }
            finally
            {
                connect.Close();
            }

            return ans;
        }

        public bool addMaterial(string path, string user, string teacher)
        {
            bool ans = false;
            string insert = "INSERT INTO[Material] ([mId],[teacherId],[studentId],[mPublishDate],[mGrade],[mDeadlineDate],[mURL],[mSolutionURL]) VALUES (@mId,@teacherId,@studentId,@mPublishDate,@mGrade,@mDeadlineDate,@mURL,@mSolutionURL)";

            SqlConnection connect = getConnection();
            SqlCommand command = new SqlCommand(insert, connect);
            command.Parameters.AddWithValue("@mId", MaterialCode);
            command.Parameters.AddWithValue("@teacherId", teacher);
            command.Parameters.AddWithValue("@studentId", user);
            command.Parameters.AddWithValue("@mPublishDate", DateTime.Now);
            command.Parameters.AddWithValue("@mGrade", "");
            command.Parameters.AddWithValue("@mDeadlineDate", "");
            command.Parameters.AddWithValue("@mURL", path);
            command.Parameters.AddWithValue("@mSolutionURLr", "");
            try
            {
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw ex; }
            finally { connect.Close(); }
            return ans;
        }

        public List<user> searchByCity(string city)
        {
            List<user> ans = new List<user>();
            string insert = @"SELECT * FROM [Users] WHERE [isTeacher]='t' AND [userAddress]='" + city+"'";
            SqlConnection connect = getConnection();
            SqlCommand command = new SqlCommand(insert, connect);
            try
            {
                connect.Open();
                SqlDataReader read = command.ExecuteReader();
                string currcity;
                while (read.Read())
                {
                    currcity = read["userAddress"].ToString();
                    if (currcity.Equals(city))
                    {
                        ans.Add(new user(read["userFirstName"].ToString(), read["userLastName"].ToString(), read["userId"].ToString(), read["userPhoneNumber"].ToString(), read["userADDRESS"].ToString(), read["userPassword"].ToString(), read["userEmail"].ToString(), true));
                    }

                }
            }
            catch (SqlException ex) { throw ex; }
            finally
            {
                connect.Close();
            }
            return ans;
        }

        public List<user> findAvilableStudents(string teacher)
        {
            List<user> ans = new List<user>();

            string insert = "SELECT [studentId] FROM [dbo].[teacheStudent] WHERE [teacherId]=" + teacher;
            SqlConnection connect = getConnection();
            SqlCommand command = new SqlCommand(insert, connect);

            try
            {
                connect.Open();
                SqlDataReader read = command.ExecuteReader();
                string studentId;
                while (read.Read())
                {
                    studentId = read["studentId"].ToString();
                    ans.Add(findUserDetails(studentId));
                }
            }
            catch (SqlException ex) { throw ex; }
            finally
            {
                connect.Close();
            }
            return ans;
        }

        private user findUserDetails(string studentId)
        {
            user u;
            string insert = @"SELECT * FROM [Users] WHERE [userId]=" + studentId;
            SqlConnection connect = getConnection();
            SqlCommand command = new SqlCommand(insert, connect);
            try
            {
                connect.Open();
                SqlDataReader read = command.ExecuteReader();
                read.Read();
                string userFname = read["userFirstName"].ToString();
                string userLname = read["userLastName"].ToString();
                u = new user(userFname, userLname, "", "", "", "", "", false);
            }
            catch (SqlException ex) { throw ex; }
            finally
            {
                connect.Close();
            }
            return u;
        }


    }
}
