using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LMS_MVC
{
    public static class SqlServer
    {
        static string con_str = "Data Source=DESKTOP-7GLTIU6\\MYSSQLSERVER;Initial Catalog=\"Learning Management System\";Integrated Security=True";

        public static DataTable GetDataTable(string cmd)
        {

            DataTable DT = new DataTable();
            using (SqlConnection con = new SqlConnection(con_str))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd, con);
                sda.Fill(DT);


                return DT;
            }

        }

        public static int ExecScalar(string cmd) {

            int status;
            using (SqlConnection con = new SqlConnection(con_str))
            {

                con.Open();

                SqlCommand command = new SqlCommand(cmd, con);
                status = (int)command.ExecuteScalar();

                con.Close();
            }

            return status;


        }

        public static void ExecQuery(string cmd)
        {

            using (SqlConnection con = new SqlConnection(con_str))
            {

                con.Open();

                SqlCommand command = new SqlCommand(cmd, con);
                command.ExecuteNonQuery();

                con.Close();
            }
        }




    }
}