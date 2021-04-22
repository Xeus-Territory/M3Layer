using _3LayerQLSV.BLL;
using _3LayerQLSV.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3LayerQLSV.GUI
{
    public partial class Form2 : Form
    {
        public delegate void Mydel(string _MSSV, int _ID_Lop);
        public Mydel d;
        string MSSV = "";
        int ID_Lop = 0;
        private void GetDelegate(string _MSSV, int _ID_Lop)
        {
            MSSV = _MSSV;
            ID_Lop = _ID_Lop;
        }
        public Form2()
        {
            d = new Mydel(GetDelegate);
            InitializeComponent();
            Form1 f1 = new Form1();
            f1.SetCBB(cbbLopSH2);
            cbbLopSH2.SelectedIndex = 0;
        }
        private void btOke_Click(object sender, EventArgs e)
        {
            if (MSSV == "")
            {
                if (BLLQLSV.Instance.AccessSV_BLL(txbMSSV.Text) == true)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    BLLQLSV.Instance.AddSV_BLL(getsSV());
                }
            }
            else
            {
                BLLQLSV.Instance.EditSV_BLL(getsSV());
            }
            this.Dispose();
        }
        public void SetDetail_ByMSSV(DataRow data)
        {
            txbMSSV.Text = data["MSSV"].ToString();
            txbMSSV.Enabled = false;
            txbNameSV.Text = data["NameSV"].ToString();
            dtNS.Value = Convert.ToDateTime(data["NS"].ToString());
            if (Convert.ToBoolean(data["Gender"].ToString()))
                rbm.Checked = true;
            else
                rbfe.Checked = true;
            int ID = Convert.ToInt32(data["ID_Lop"].ToString());
            for (int i = 0; i < cbbLopSH2.Items.Count; i++)
            {
                if (((CBBItem)cbbLopSH2.Items[i]).Value == ID)
                {
                    cbbLopSH2.SelectedIndex = i;
                }
            }
        }
        private SV getsSV()
        {
            SV s = new SV();
            s.MSSV = txbMSSV.Text;
            s.NameSV = txbNameSV.Text;
            if (rbm.Checked)
                s.Gender = true;
            else
                s.Gender = false;
            s.NS = Convert.ToDateTime(dtNS.Value);
            s.ID_Lop = ((CBBItem)cbbLopSH2.SelectedItem).Value;
            return s;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
