using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;
using CaterBll;
using CaterModel;

namespace CaterUI
{
    public partial class HallInfoFrm : Form
    {
        public HallInfoFrm()
        {
            InitializeComponent();
        }
        private  HallInfoBll hiBll=new HallInfoBll();
        private int rowIndex = -1;
        private DialogResult result = DialogResult.Cancel;
        public event Action MyUpDateFrm;
        private void HallInfoFrm_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            this.dgvHallInfo.AutoGenerateColumns = false;
            this.dgvHallInfo.DataSource = hiBll.GetlList();
            if (rowIndex>=0)
            {
                this.dgvHallInfo.Rows[rowIndex].Selected = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                return;
            }
            HallInfo hi=new HallInfo()
            {
                HTitle = txtName.Text.Trim(),
            };
            if (txtId.Text == "添加时无编号")
            {
                if (hiBll.Add(hi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("添加失败，稍后再试");
                }
            }
            else
            {
                hi.HId= int.Parse(txtId.Text.Trim());
                if (hiBll.Edit(hi))
                {
                    
                    LoadList();
                }
            }
            txtId.Text = "添加时无编号";
            txtName.Text = string.Empty;
            btnAdd.Text = "添加";
            this.result = DialogResult.OK;
            MyUpDateFrm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtName.Text = string.Empty;
            btnAdd.Text = "添加";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvHallInfo.SelectedRows.Count<=0)
            {
                return;
            }
            DialogResult result = MessageBox.Show("确定要删除吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            int id = Convert.ToInt32(this.dgvHallInfo.SelectedRows[0].Cells[0].Value.ToString());
            if (result == DialogResult.OK)
            {
                if (hiBll.Remove(id))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("请选择要操作的行");
                }
            }
            MyUpDateFrm();
            this.result = DialogResult.OK;
        }

        private void dgvHallInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = this.dgvHallInfo.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            btnAdd.Text = "修改";
            this.rowIndex = e.RowIndex;
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAdd.Select();
            }

        }

        private void btnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            ////var b = sender as Button;
            //if (e.KeyCode==Keys.Enter)
            //{
            //    this.btnAdd.Focus();
            //}
        }
    }
}
