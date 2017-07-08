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
    public partial class MemberInfoFrm : Form
    {
        private MemberInfoFrm()
        {
            InitializeComponent();
            
        }
        private  MemberInfoBll miBll=new MemberInfoBll();
        private int rowIndex = -1;
        private static MemberInfoFrm _miFrm;
        public static MemberInfoFrm Create()
        {
            if (_miFrm==null)
            {
                _miFrm=new MemberInfoFrm();
            }
            return _miFrm;
        }
        private void MemberInfoFrm_Load(object sender, EventArgs e)
        {
            LoadTypeList();
            LoadList();
        }

        private void LoadList()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(txtSearchName.Text.Trim()))
            {
                dic.Add("MName",txtSearchName.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtSeachPhoneNumber.Text.Trim()))
            {
                dic.Add("MPhone", txtSeachPhoneNumber.Text.Trim());
            }
            this.dgvMemberInfo.AutoGenerateColumns = false;
            this.dgvMemberInfo.DataSource = miBll.GetList(dic);
            if (rowIndex >= 0)
            {
                this.dgvMemberInfo.Rows[rowIndex].Selected = true;
            }
        }

        private void LoadTypeList()
        {
            MemberTypeInfoBll mtiBll=new MemberTypeInfoBll();
            ddlType.DataSource = mtiBll.GetList();
            ddlType.ValueMember = "MId";
            ddlType.DisplayMember = "MTitle";
        }

        private void txtSearchName_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void txtSeachPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtSearchName.Text = string.Empty;
            txtSeachPhoneNumber.Text = string.Empty;
        }

        private void dgvMemberInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = this.dgvMemberInfo.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            ddlType.Text = row.Cells[2].Value.ToString();
            txtPhone.Text = row.Cells[3].Value.ToString();
            txtMoney.Text = row.Cells[4].Value.ToString();
            this.rowIndex = e.RowIndex;
            btnAdd.Text = "修改";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("请您输入会员姓名");
                return;
            }
            MemberInfo mi=new MemberInfo()
            {
                MName = txtName.Text.Trim(),
                MTypeId = Convert.ToInt32(ddlType.SelectedValue),
                MPhone = txtPhone.Text.Trim(),
                MMoney = Convert.ToDecimal(txtMoney.Text.Trim())
            };
            if (txtId.Text.Equals("添加时无编号"))
            {
                if (miBll.Add(mi))
                {
                    LoadList();
                }
            }
            else
            {
                mi.MId = int.Parse(txtId.Text.Trim());
                if (miBll.Edit(mi))
                {
                    LoadList();
                }
            }
            txtId.Text = "添加时无编号";
            txtPhone.Text = string.Empty;
            txtName.Text = string.Empty;
            txtMoney.Text = string.Empty;
            ddlType.SelectedIndex = 0;
            btnAdd.Text = "添加";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtPhone.Text = string.Empty;
            txtName.Text = string.Empty;
            txtMoney.Text = string.Empty;
            ddlType.SelectedIndex = 0;
            btnAdd.Text = "添加";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvMemberInfo.SelectedRows.Count<0)
            {
                return;
            }
            int id = int.Parse(this.dgvMemberInfo.SelectedRows[0].Cells[0].Value.ToString());
            DialogResult result = MessageBox.Show("确定要删除吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (result==DialogResult.No)
            {
                return;
            }
            if (miBll.Remove(id))
            {
                LoadList();
            }
            else
            {
                MessageBox.Show("操作失败");
            }
           
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            MemberTypeInfoFrm mtifrFrm=new MemberTypeInfoFrm();
            mtifrFrm.MyUpdateFrm += LoadList;
            mtifrFrm.MyUpdateFrm += LoadTypeList;
            mtifrFrm.Show();
        }

        //private void MtifrFrm_MyUpdateFrm()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
