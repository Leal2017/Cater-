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
    public partial class MemberTypeInfoFrm : Form
    {
        public MemberTypeInfoFrm()
        {
            InitializeComponent();
            //LoadList();
        }
        private MemberTypeInfoBll mtiBll=new MemberTypeInfoBll();
        private int rowIndex = -1;
        public event Action MyUpdateFrm;
        private void MemberTypeInfoFrm_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            this.dgvMemberTypeInfo.AutoGenerateColumns = false;
            this.dgvMemberTypeInfo.DataSource = mtiBll.GetList();
            if (rowIndex >= 0)
            {
                this.dgvMemberTypeInfo.Rows[rowIndex].Selected = true;
            }
        }

        private void dgvMemberTypeInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = this.dgvMemberTypeInfo.Rows[e.ColumnIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            txtDiscount.Text = row.Cells[2].Value.ToString();
            this.rowIndex = e.RowIndex;
            btnAdd.Text = "修改";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                return;
            }
            MemberTypeInfo mti = new MemberTypeInfo()
            {
                MTitle = txtTitle.Text.Trim(),
                MDiscount = decimal.Parse(txtDiscount.Text.Trim())
            };
            
            if (txtId.Text.Equals("添加时无编号"))
            {
                if (mtiBll.Insert(mti))
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
                mti.MId = int.Parse(txtId.Text);
                if (mtiBll.Update(mti))
                {
                    LoadList();
                }
            }
            txtId.Text = "添加时无编号";
            txtTitle.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            btnAdd.Text = "添加";
            MyUpdateFrm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtTitle.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            btnAdd.Text = "添加";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvMemberTypeInfo.SelectedRows.Count <= 0)
            {
                return;
            }
            DialogResult result = MessageBox.Show("确定要删除吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            int id = Convert.ToInt32(this.dgvMemberTypeInfo.SelectedRows[0].Cells[0].Value.ToString());
            if (result == DialogResult.OK)
            {
                if (mtiBll.Remove(id))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("请选择要操作的行");
                }
            }
            MyUpdateFrm();
        }
    }
}
