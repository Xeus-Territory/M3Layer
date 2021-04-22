using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3LayerQLSV.DTO
{
    class SVView
    {
        private string MSSV;
        public string NameSV { get; set; }
        public bool Gender { get; set; }
        public DateTime NS { get; set; }
        private int ID_Lop { get; set; }
        public string NameLop { get; set; }

        public SVView(SV s)
        {
            MSSV = s.MSSV;
            NameSV = s.NameSV;
            Gender = s.Gender;
            NS = s.NS;
            ID_Lop = s.ID_Lop;
            NameLop = "";
        }

        public string GetMSSV()
        {
            return MSSV;
        }
        public int GetID_Lop()
        {
            return ID_Lop;
        }
    }
}
