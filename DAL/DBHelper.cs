using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3LayerQLSV.DAL
{
    class DBHelper
    {
        private SqlConnection cnn;
        private static DBHelper _Instance;

        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    string cnnstrr = @"Data Source=XOT\SQLEXPRESS;Initial Catalog=QLSV;User ID=sa;Password=123456";
                    _Instance = new DBHelper(cnnstrr);
                }
                return _Instance;
            }
            private set
            {

            }
        }
        private DBHelper(string querry)
        {
            cnn = new SqlConnection(querry);
        }
        public DataTable GetRecord(string querry)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(querry, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cnn.Open();
            //da.Fill(ds);
            //da.Fill(ds, "SV");
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        public void ExcuteDB(string querry)
        {
            SqlCommand cmd = new SqlCommand(querry, cnn);
            cnn.Open();
            //da.Fill(ds);
            //da.Fill(ds, "SV");
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
