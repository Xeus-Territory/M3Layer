using _3LayerQLSV.BLL;
using _3LayerQLSV.DTO;
using _3LayerQLSV.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3LayerQLSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cbbLSH.Items.Add(new CBBItem { Value = 0, Text = "All" });
            SetCBB(cbbLSH);
            cbbLSH.SelectedIndex = 0;
            SetCBBSort();
        }
        public void SetCBB(ComboBox cbb)
        {
            foreach(LSH i in BLLQLSV.Instance.GetAllLSH_BLL())
            {
                cbb.Items.Add(new CBBItem
                {
                    Value = i.ID_Lop,
                    Text = i.NameLop
                });
            }
        }
        public void SetCBBSort()
        {
            foreach(string i in BLLQLSV.Instance.GetColumnName_BLL())
            {
                cbSort.Items.Add(i);
            }
        }
        private void btShow_Click(object sender, EventArgs e)
        {
            if (cbbLSH.SelectedIndex == 0)
            {
                dataGridView1.DataSource = BLLQLSV.Instance.ChangeSVIntoGridViewItemBLL(BLLQLSV.Instance.GetAllSV_BLL());
            }
            else
            {
                dataGridView1.DataSource = BLLQLSV.Instance.ChangeSVIntoGridViewItemBLL(BLLQLSV.Instance.GetListSV(cbbLSH.SelectedIndex, null));
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLQLSV.Instance.ChangeSVIntoGridViewItemBLL(BLLQLSV.Instance.GetListSV(0, txbSearch.Text));
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            List<string> MSSV = new List<string>();
            foreach(DataGridViewRow i in r)
            {
                MSSV.Add(((SVView)i.DataBoundItem).GetMSSV().ToString());
            }
            BLLQLSV.Instance.DelSV_BLL(MSSV);
            dataGridView1.DataSource = BLLQLSV.Instance.ChangeSVIntoGridViewItemBLL(BLLQLSV.Instance.GetAllSV_BLL());
        }

        private void btSort_Click(object sender, EventArgs e)
        {
            if (cbSort.SelectedItem == null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                if (cbbLSH.SelectedIndex == 0)
                {
                    dataGridView1.DataSource = BLLQLSV.Instance.ChangeSVIntoGridViewItemBLL(BLLQLSV.Instance.SortSV_BLL(BLLQLSV.Instance.GetAllSV_BLL(), cbSort.SelectedItem.ToString())) ;
                }
                else
                {
                    dataGridView1.DataSource = BLLQLSV.Instance.ChangeSVIntoGridViewItemBLL(BLLQLSV.Instance.SortSV_BLL(BLLQLSV.Instance.GetListSV(cbbLSH.SelectedIndex, null), cbSort.SelectedItem.ToString()));
                }    
            }    
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.d("", 0);
            f2.ShowDialog();
            dataGridView1.DataSource = BLLQLSV.Instance.ChangeSVIntoGridViewItemBLL(BLLQLSV.Instance.GetAllSV_BLL());
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    Form2 f2 = new Form2();
                    string MSSV = ((SVView)dataGridView1.CurrentRow.DataBoundItem).GetMSSV().ToString();
                    int ClassID = ((SVView)dataGridView1.CurrentRow.DataBoundItem).GetID_Lop();
                    f2.d(MSSV, ClassID);
                    f2.SetDetail_ByMSSV(BLLQLSV.Instance.GetRowSV_BLL(((SVView)dataGridView1.Rows[index].DataBoundItem).GetMSSV().ToString()));
                    f2.ShowDialog();
                    dataGridView1.DataSource = BLLQLSV.Instance.ChangeSVIntoGridViewItemBLL(BLLQLSV.Instance.GetAllSV_BLL());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
