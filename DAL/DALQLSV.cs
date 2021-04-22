using _3LayerQLSV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3LayerQLSV.DAL
{
    class DALQLSV
    {
        private static DALQLSV _Instance;

        public static DALQLSV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DALQLSV();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public DALQLSV() { }
        public SV GetSV(DataRow i)
        {
            SV s = new SV();
            s.MSSV = i["MSSV"].ToString();
            s.NameSV = i["NameSV"].ToString();
            s.Gender = Convert.ToBoolean(i["Gender"].ToString());
            s.NS = Convert.ToDateTime(i["NS"].ToString());
            s.ID_Lop = Convert.ToInt32(i["ID_Lop"].ToString());
            return s;
        }
        public List<SV> GetAllSV_DAL()
        {
            List<SV> listsv = new List<SV>();
            string querry = "Select * from SV";
            foreach (DataRow i in DBHelper.Instance.GetRecord(querry).Rows)
            {
                listsv.Add(GetSV(i));
            }
            return listsv;
        }
        public LSH GetLSH(DataRow i)
        {
            LSH lsh = new LSH();
            lsh.ID_Lop = Convert.ToInt32(i["ID_Lop"].ToString());
            lsh.NameLop = i["NameLop"].ToString();
            return lsh;
        }
        public List<LSH> GetAllLSH_DAL()
        {
            List<LSH> listlsh = new List<LSH>();
            string querry = "Select * from LSH";
            foreach (DataRow i in DBHelper.Instance.GetRecord(querry).Rows)
            {
                listlsh.Add(GetLSH(i));
            }
            return listlsh;
        }
        public void DelSV_DAL(List<string> MSSV)
        {
            foreach (string i in MSSV)
            {
                string querry = "Delete from SV Where SV.MSSV = N'" + i + "' ";
                DBHelper.Instance.ExcuteDB(querry);
            }
        }
        public List<string> GetColumnName_DAL()
        {
            List<string> columnname = new List<string>();
            string querry = "Select * from SV";
            foreach (DataColumn i in DBHelper.Instance.GetRecord(querry).Columns)
            {
                columnname.Add(i.ColumnName);
            }
            return columnname;
        }
        public void AddSV_DAL(SV s)
        {
            if(s.Gender == true)
            {
                string querry = "Insert into SV Values(N'" + s.MSSV + "', N'" + s.NameSV + "', " + 1 + ", N'" + s.NS + "', " + s.ID_Lop + ")";
                DBHelper.Instance.ExcuteDB(querry);
            }
            else
            {
                string querry = "Insert into SV Values(N'" + s.MSSV + "', N'" + s.NameSV + "', " + 0 + ", N'" + s.NS + "', " + s.ID_Lop + ")";
                DBHelper.Instance.ExcuteDB(querry);
            }
        }
        public void EditSV_DAL(SV s)
        {
            if(s.Gender == true)
            {
                string querry = "Update SV Set SV.NameSV = N'" + s.NameSV + "', SV.Gender = " + 1 + ", SV.NS = N'" + s.NS + "', SV.ID_Lop = " + s.ID_Lop + " Where SV.MSSV = N'" + s.MSSV + "'";
                DBHelper.Instance.ExcuteDB(querry);
            }
            else
            {
                string querry = "Update SV Set SV.NameSV = N'" + s.NameSV + "', SV.Gender = " + 0 + ", SV.NS = N'" + s.NS + "', SV.ID_Lop = " + s.ID_Lop + " Where SV.MSSV = N'" + s.MSSV + "'";
                DBHelper.Instance.ExcuteDB(querry);
            }
        }
        public DataRow GetRowSV_DAL(string MSSV)
        {
            string querry = "Select * from SV";
            DataRow dr = DBHelper.Instance.GetRecord(querry).NewRow();
            foreach(DataRow i in DBHelper.Instance.GetRecord(querry).Rows)
            {
                if (i["MSSV"].ToString() == MSSV)
                {
                    dr = i;
                }
            }
            return dr;
        }
    }
}
