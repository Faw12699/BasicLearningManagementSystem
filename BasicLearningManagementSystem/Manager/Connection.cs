using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace BasicLearningManagementSystem.Manager
{
    public static class Connection
    {
        static string connection = @"Data Source=DESKTOP-I5537DP\SQLEXPRESS;Initial Catalog=LMSDatabase;Integrated Security=True";
        static SqlConnection con;

        public static void OpenConnection() 
        {
            con = new SqlConnection(connection);
            con.Open();
        }

        public static void CloseConnection() 
        {
            con.Close();
        }

        public static void ExecuteQueries(string query) 
        {
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        public static SqlDataReader DataReader(string query) 
        {
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public static DataTable DataView(string query) 
        {
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            return dt;
        }
    }
}