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
    public partial class TableInfoFrm : Form
    {
        private TableInfoFrm()
        {
            InitializeComponent();
            this.rowIndex = -1;
            this.tiBll=new TableInfoBll();
        }
        private static TableInfoFrm tiFrm=null;
        public event Action Refresh;
        public static TableInfoFrm Create()
        {
            if (tiFrm==null)
            {
                tiFrm=new TableInfoFrm();
            }
            return tiFrm;
        }
        private int rowIndex;
        private TableInfoBll tiBll;
        private void TableInfoFrm_Load(object sender, EventArgs e)
        {
            LoadHallList();
            //ddlSearchHall.SelectedIndex = 1;
            //ddlSearchFree.SelectedIndex = 1;
            LoadList();
        }

        private void LoadList()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            
            if (ddlSearchHall.SelectedIndex > 0)
            {
                dic.Add("THallId", ddlSearchHall.SelectedValue.ToString());
            }
            if (ddlSearchFree.SelectedIndex > 0)
            {
                dic.Add("TIsFree", ddlSearchFree.SelectedValue.ToString());
            }
            this.dgvTableInfo.AutoGenerateColumns = false;
            this.dgvTableInfo.DataSource = tiBll.GetList(dic);
            if (rowIndex>=0)
            {
                this.dgvTableInfo.Rows[rowIndex].Selected = true;
            }
        }
         

        private void LoadHallList()
        {
            HallInfoBll hiBll = new HallInfoBll();
            List<TIsFree> ListF = new List<TIsFree>()
            {
                new TIsFree(-1,"全部"),
                new TIsFree(1,"空闲"),
                new TIsFree(0,"使用中")
            };

            #region MyRegion
            //ListF.Add(new TIsFree(-1, "全部"));
            //ListF.Add(new TIsFree(1, "空闲"));
            //ListF.Add(new TIsFree(0, "使用中"));
            //{
            //    { -1,"全部"};
            //    { 1,"空闲"},
            //    { 0,"使用中"}

            //}; 
            #endregion
            List<HallInfo> list = hiBll.GetlList();
          
            list.Insert(0, new HallInfo()
            {
                HId = 0,
                HTitle = "全部"
            });
            this.ddlSearchHall.DataSource = list;
            this.ddlSearchHall.ValueMember = "HId";
            this.ddlSearchHall.DisplayMember = "HTitle";

            this.ddlHall.DataSource = hiBll.GetlList();
            this.ddlHall.ValueMember = "HId";
            this.ddlHall.DisplayMember = "HTitle";
            
            this.ddlSearchFree.DataSource = ListF;
            this.ddlSearchFree.ValueMember = "id";
            this.ddlSearchFree.DisplayMember = "title";

        }
        private void dgvTableInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex==3)
            {
                e.Value = Convert.ToBoolean(e.Value) ? "√" : "×";
            }
        }

        private void dgvTableInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = this.dgvTableInfo.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            ddlHall.Text = row.Cells[2].Value.ToString();
            if (Convert.ToBoolean(row.Cells[3].Value))
            {
                rbFree.Checked = true;
            }
            else
            {
                rbUse.Checked = true;
            }
            btnAdd.Text = "修改";
            this.rowIndex = e.RowIndex;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TableInfo ti=new TableInfo()
            {
               TTitle = txtName.Text,
               THallId = int.Parse(ddlHall.SelectedValue.ToString()),
               //TIsFree =short.Parse( rbFree.Checked.ToString())
               TIsFree = rbFree.Checked
            };
            if (txtId.Text=="添加时无编号")
            {
                if (tiBll.Add(ti))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("操作失败，请稍后重试");
                }
            }
            else
            {
                ti.TId = Convert.ToInt32(txtId.Text);
                if (tiBll.Edit(ti))
                {
                    LoadList();
                }
            }
            txtId.Text = "添加时无编号";
            txtName.Text = string.Empty;
            ddlHall.SelectedIndex = 0;
            rbFree.Checked = true;
            btnAdd.Text = "添加";
            Refresh();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtName.Text = string.Empty;
            ddlHall.SelectedIndex = 0;
            rbFree.Checked = true;
            btnAdd.Text = "添加";
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            ddlSearchHall.SelectedIndex = 0;
            ddlSearchFree.SelectedIndex = 0;
            LoadList();
            
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e==Keys.Enter)
            //{
                
            //}
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.dgvTableInfo.SelectedRows[0].Cells[0].Value.ToString());
            if (this.dgvTableInfo.SelectedRows.Count<0)
            {
                return;
            }
          
            DialogResult result = MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result==DialogResult.OK)
            {
                if (tiBll.Remove(id))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("请选择要删除的行");
                }
            }
            Refresh();

        }

        private void btnManagerHall_Click(object sender, EventArgs e)
        {

            #region 模态窗口实现
            //HallInfoFrm hiFrm=new HallInfoFrm();
            //DialogResult result= hiFrm.ShowDialog();
            //if (result.Equals(DialogResult.OK))
            //{
            //    LoadHallList();
            //    LoadList();
            //}

            #endregion
            //发布订阅模式
            HallInfoFrm hiFrm = new HallInfoFrm();
            hiFrm.MyUpDateFrm += LoadHallList;
            hiFrm.MyUpDateFrm += LoadList;
            hiFrm.Show();
        }

        private void TableInfoFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //LoadList();
            
        }
        
        private void ddlSearchHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadHallList();
            LoadList();
        }

        private void ddlSearchFree_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }
    }
}
