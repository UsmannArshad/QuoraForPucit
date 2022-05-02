using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace WebApplication10.Models
{
    public class UserRepository
    {
        public static void AddUser(User u)
        {
            string constring = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=QuoraForPucit_UserData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string query = "Insert into Users(Email,Password,Name,Age) VALUES(@a,@b,@c,@d)";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlParameter p1 = new SqlParameter("a", u.Username);
            SqlParameter p2 = new SqlParameter("b", u.Password);
            SqlParameter p3 = new SqlParameter("c", u.Name);
            SqlParameter p4 = new SqlParameter("d", u.Age);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            int insertedrows = cmd.ExecuteNonQuery();
        }
        public static bool CheckCredentials(string username, int pwd)
        {
            string constring = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=QuoraForPucit_UserData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string query = "Select * from Users where Email=@u AND Password=@p";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlParameter p1 = new SqlParameter("u", username);
            SqlParameter p2 = new SqlParameter("p", pwd);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static List<User> DisplayAllUsers()
        {
            List<User> listofuser = new List<User>();
            string constring = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=QuoraForPucit_UserData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string query = "Select * from Users";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                User user = new User();
                user.Username = Convert.ToString(dr[1]);
                user.Password = Convert.ToInt32(dr[2]);
                user.Name = Convert.ToString(dr[4]);
                user.Age = Convert.ToInt32(dr[3]);
                listofuser.Add(user);
            }
            return listofuser;
        }
        public static bool IsUsernameUnique(string username)
        {
            string constring = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=QuoraForPucit_UserData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string query = "Select * from Users where Email=@u";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlParameter p1 = new SqlParameter("u", username);
            cmd.Parameters.Add(p1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}