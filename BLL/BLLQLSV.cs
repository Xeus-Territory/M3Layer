using _3LayerQLSV.DAL;
using _3LayerQLSV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3LayerQLSV.BLL
{
    class BLLQLSV
    {
        private static BLLQLSV _Instance;

        public static BLLQLSV Instance 
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLLQLSV();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public BLLQLSV() { }
        public List<LSH> GetAllLSH_BLL()
        {
            return DALQLSV.Instance.GetAllLSH_DAL();
        }
        public List<SV> GetAllSV_BLL()
        {
            return DALQLSV.Instance.GetAllSV_DAL();
        }
        public List<string> GetColumnName_BLL()
        {
            return DALQLSV.Instance.GetColumnName_DAL();
        }
        public List<SV> GetListSV(int ID_Lop, string Name)
        {
            List<SV> listSV = new List<SV>();
            foreach(SV i in GetAllSV_BLL())
            {
                if (Name == null)
                {
                    if (i.ID_Lop == ID_Lop)
                    {
                        listSV.Add(i);
                    }
                }
                else
                {
                    if (i.NameSV.Contains(Name))
                    {
                        listSV.Add(i);
                    }    
                }    
            }
            return listSV;
        }
        public void DelSV_BLL(List<string> MSSV)
        {
            DALQLSV.Instance.DelSV_DAL(MSSV);
        }
        public List<SV> SortSV_BLL(List<SV> listSV, string Columnname)
        {
            for (int i = 0; i < listSV.Count; i++)
            {
                for (int j = i + 1; j < listSV.Count; j++)
                {
                    switch(Columnname)
                    {
                        case "MSSV":
                            {
                                if(String.Compare(listSV[i].MSSV, listSV[j].MSSV) > 0)
                                {
                                    SV temp = listSV[i];
                                    listSV[i] = listSV[j];
                                    listSV[j] = temp;
                                }
                            }
                            break;
                        case "NameSV":
                            {
                                if (String.Compare(listSV[i].NameSV, listSV[j].NameSV) > 0)
                                {
                                    SV temp = listSV[i];
                                    listSV[i] = listSV[j];
                                    listSV[j] = temp;
                                }
                            }
                            break;
                        case "Gender":
                            {
                                if (Boolean.Equals(listSV[i].Gender, listSV[j].Gender) == false)
                                {
                                    SV temp = listSV[i];
                                    listSV[i] = listSV[j];
                                    listSV[j] = temp;
                                }
                            }
                            break;
                        case "NS":
                            {
                                if(DateTime.Compare(listSV[i].NS, listSV[j].NS) > 0)
                                {
                                    SV temp = listSV[i];
                                    listSV[i] = listSV[j];
                                    listSV[j] = temp;
                                }
                            }
                            break;
                        case "ID_Lop":
                            {
                                if(listSV[i].ID_Lop > listSV[j].ID_Lop)
                                {
                                    SV temp = listSV[i];
                                    listSV[i] = listSV[j];
                                    listSV[j] = temp;
                                }
                            }
                            break;
                    }
                }
            }
            return listSV;
        }
        public DataRow GetRowSV_BLL(string MSSV)
        {
            return DALQLSV.Instance.GetRowSV_DAL(MSSV);
        }
        public bool AccessSV_BLL(string MSSV)
        {
            bool check = false;
            foreach(SV i in GetAllSV_BLL())
            {
                while(i.MSSV == MSSV)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        public void AddSV_BLL(SV s)
        {
            DALQLSV.Instance.AddSV_DAL(s);
        }
        public void EditSV_BLL(SV s)
        {
            DALQLSV.Instance.EditSV_DAL(s);
        }
        public List<SVView> ChangeSVIntoGridViewItemBLL(List<SV> listSV)
        {
            List<SVView> result = new List<SVView>();
            foreach (SV s in listSV)
            {
                SVView item = s.ToSVView();
                foreach (LSH l in GetAllLSH_BLL())
                {
                    if (l.ID_Lop == s.ID_Lop)
                    {
                        item.NameLop = l.NameLop;
                    }
                }
                result.Add(item);
            }
            return result;
        }
    }
}
