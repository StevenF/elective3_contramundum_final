using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WpfApp1
{
    class SQLAdapter
    {
        public static MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
        //SQL connections
        private string sql_server = "localhost";
        private string sql_port = "3306";
        private string sql_uid = "root";
        private string sql_pwd = "abcd";
        private string sql_database = "elective3_db";
        public static string sql_table = "elective3db_table";

        //SQL Columns
        public static string col_bikeNumber = "bike_number";
        private string col_userName = "user_name";
        private string col_timeStart = "time_start";
        private string col_time = "time_time";
        private string col_timeEnd = "time_end";
        private string col_isAvailable = "isAvailable";
        private string col_isPaid = "isPaid";
        private string col_bikeType = "bike_type";


        public SQLAdapter()
        {
            string sss = "server=localhost;port=3306;pwd=abcd;database=elective3_server";
            string strSQLConnection = 
                "server=" + sql_server+
                ";uid="+sql_uid+
                ";port="+sql_port+
                ";pwd="+sql_pwd+
                ";database="+sql_database;
            Debug.Write("sqlAdapter: strSQLConnection : " + strSQLConnection + "\n");
            try
            {
                mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection();
                mySqlConnection.ConnectionString = strSQLConnection;
                mySqlConnection.Open();

            }catch(MySql.Data.MySqlClient.MySqlException e)
            {
                Debug.Write("sqlAdapter: sqlException : " + e + "\n");
            }

        }


        public void updateRow(string bikeNumber, string bikeUser, string timeLeft, string timeStart, string timeEnd, bool isAvailable, bool isPaid, string bike_type)
        {
            

            string updateQuery = "UPDATE `"+sql_database+"`.`"+sql_table+"` SET "+col_userName+"='"+bikeUser+"',"+col_time+"='"+timeLeft.ToString()+"', "+col_timeStart+"='"+timeStart+"', "+col_timeEnd+"='"+timeEnd+"', "+col_isAvailable+"='"+isAvailable+"', "+col_isPaid+"='"+isPaid+"' , "+col_isPaid+"='"+isPaid+ "', " + col_bikeType + "='" + bike_type + "'  WHERE " + col_bikeNumber+"='"+bikeNumber+"'";

            Debug.Write("sqlAdapter: updateQuery : " + updateQuery);
            MySql.Data.MySqlClient.MySqlCommand mySqlCommand = new MySql.Data.MySqlClient.MySqlCommand(updateQuery, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
           
        }

       

    }
}
