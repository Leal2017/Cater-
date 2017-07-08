using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaterBll;
using CaterDal;
using CaterModel;


namespace CaterUI
{
    public partial class MainFrm : Form
    {
        private MainFrm()
        {
            InitializeComponent();

        }
        private  static  MainFrm _form=null;

        public static MainFrm Create()
        {
            if (_form==null)
            {
                _form=new MainFrm();
            }
            return _form;
        }
        private ManagerInfoBll managerInfoBll = new ManagerInfoBll();

        private void MainFrm_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            this.dgvManagerInfo.AutoGenerateColumns = false;
            this.dgvManagerInfo.DataSource = managerInfoBll.GetList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()) || string.IsNullOrEmpty(txtPwd.Text.Trim()))
            {
                return;
            }
            ManagerInfo managerInfo = new ManagerInfo()
            {
                MName = txtName.Text.Trim(),
                MPwd = txtPwd.Text.Trim(),
                MType = rbManager.Checked ? 1 : 0
            };
            if (txtId.Text.Trim() == "添加时无编号")
            {
                if (managerInfoBll.Add(managerInfo))
                {
                    MessageBox.Show("添加成功");
                    LoadList();

                }
                else
                {
                    MessageBox.Show("添加失败,稍后再试");
                }
            }
            else
            {
                managerInfo.MId = int.Parse(txtId.Text);
                if (managerInfoBll.Edit(managerInfo))
                {
                    LoadList();
                }
            }

            txtName.Text = string.Empty;
            txtPwd.Text = string.Empty;
            btnAdd.Text = "添加";
            txtId.Text = "添加时无编号";
            rbEmployee.Checked = true;
        }

        private void dgvManagerInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                e.Value = Convert.ToInt32(e.Value) == 1 ? "经理" : "店员";
            }
        }

        private void dgvManagerInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
            var row = this.dgvManagerInfo.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            if (row.Cells[2].Value.Equals("1"))
            {
                rbManager.Checked = true;
            }
            else
            {
                rbEmployee.Checked = true;
            }
            txtPwd.Text = "这是原来的密码吗";
            btnAdd.Text = "修改";

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtPwd.Text = string.Empty;
            txtName.Text = string.Empty;
            btnAdd.Text = "添加";
            rbEmployee.Checked = true;
        }

        private void btnDeleteSelectEmployee_Click(object sender, EventArgs e)
        {
            #region 第二种方法
            if (this.dgvManagerInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选中要操作的行");
                return;
            }
            if (MessageBox.Show("确定要删除吗","提示信息",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.Cancel)
            {
                return;
            }
            else
            {
                int id = int.Parse(this.dgvManagerInfo.SelectedRows[0].Cells["MId"].Value.ToString());
                if (managerInfoBll.Delete(id))
                {
                    MessageBox.Show("删除成功");
                    LoadList();
                }
            }
           
            #endregion
            #region 第二种方法
            var rows = dgvManagerInfo.SelectedRows;
            if (rows.Count > 0)
            {
                //删除前的确认提示
                DialogResult result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    //用户取消删除
                    return;
                }

                //获取选中行的编号
                int id = int.Parse(rows[0].Cells[0].Value.ToString());
                //调用删除的操作
                if (managerInfoBll.Delete(id))
                {
                    //删除成功，重新加载数据
                    LoadList();
                }
            }
            else
            {
                MessageBox.Show("请先选择要删除的行");
            } 
            #endregion
        }
    }
}

