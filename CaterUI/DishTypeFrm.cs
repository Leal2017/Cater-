using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaterBll;
using CaterModel;

namespace CaterUI
{
    public partial class DishTypeFrm : Form
    {
        DishTypeInfoBll dishTypeInfoBll=new DishTypeInfoBll();
        private int rowIndex = -1;
        private DialogResult result = System.Windows.Forms.DialogResult.Cancel;
        public DishTypeFrm()
        {
            InitializeComponent();
        }

        private void DishTypeFrm_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            this.dgvDishTypeInfo.AutoGenerateColumns = false;
            this.dgvDishTypeInfo.DataSource= dishTypeInfoBll.GetList();
            if (rowIndex>=0)
            {
                this.dgvDishTypeInfo.Rows[rowIndex].Selected = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                MessageBox.Show("请您添加要的菜系");
                return;
            }
            DishTypeInfo dishTypeInfo=new DishTypeInfo();
            dishTypeInfo.DTitle = txtTitle.Text.Trim();
            if (txtId.Text.Equals("添加时无编号"))
            {
                if (dishTypeInfoBll.Add(dishTypeInfo))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("添加失败，请稍后再试");
                }
            }
            else
            {
                dishTypeInfo.DId = int.Parse(txtId.Text);
                if (dishTypeInfoBll.Update(dishTypeInfo))
                {
                    LoadList();
                }
            }
            txtId.Text = "添加时无编号";
            txtTitle.Text = string.Empty;
            btnAdd.Text = "添加";
            this.result = DialogResult.OK;

        }

        private void dgvDishTypeInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rows=this.dgvDishTypeInfo.SelectedRows[0];
            txtId.Text = rows.Cells[0].Value.ToString();
            txtTitle.Text = rows.Cells[1].Value.ToString();
            btnAdd.Text = "修改";
            rowIndex = e.RowIndex;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtTitle.Text = string.Empty;
            btnAdd.Text = "添加";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvDishTypeInfo.SelectedRows.Count<=0)
            {
                MessageBox.Show("请选择要操作的行");
                return;
            }
            if (MessageBox.Show("确定要删除吗","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.Cancel)
            {
                return;
            }
            int id = int.Parse(this.dgvDishTypeInfo.SelectedRows[0].Cells[0].Value.ToString());
            if (dishTypeInfoBll.Remove(id))
            {
                LoadList();
            }
            else
            {
                MessageBox.Show("请选择要删除的行");
            }
            this.result = DialogResult.OK;
        }

        private void DishTypeFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = this.result;
        }
    }
}
