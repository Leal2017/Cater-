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
using CaterCommon;
using CaterModel;

namespace CaterUI
{
    public partial class DishInfoFrm : Form
    {
        private DishInfoFrm()
        {
            InitializeComponent();
        }

        private static DishInfoFrm _diFrm=null;

        public static DishInfoFrm Create()
        {
            if (_diFrm==null)
            {
                _diFrm=new DishInfoFrm();
            }
            return _diFrm;
        }
        private DishInfoBll dib=new DishInfoBll();
        private void DishInfoFrm_Load(object sender, EventArgs e)
        {
            LoadTypeList();
            LoadList();
        }

        private void LoadList()
        {
            Dictionary<string, string> dic = new Dictionary<string,string>();
            if (!string.IsNullOrEmpty(txtTitleSearch.Text))
            {
                dic.Add("DTitle",txtTitleSearch.Text);
            }
            if (ddlTypeSearch.SelectedValue.ToString()!="0")
            {
                dic.Add("DTypeId", ddlTypeSearch.SelectedValue.ToString());
            }
            this.dgvDishInfo.AutoGenerateColumns = false;
            this.dgvDishInfo.DataSource = dib.GetList(dic);
        }

        private void LoadTypeList()
        {
            DishTypeInfoBll dti=new DishTypeInfoBll();
            List<DishTypeInfo> list=dti.GetList();
            list.Insert(0, new DishTypeInfo()
            {
                DId = 0,
                DTitle = "全部"
            });
            this.ddlTypeSearch.DataSource = list;
            this.ddlTypeSearch.DisplayMember = "DTitle";
            this.ddlTypeSearch.ValueMember = "DId";

            this.ddlTypeAdd.DataSource = dti.GetList();
            this.ddlTypeAdd.ValueMember = "DId";
            this.ddlTypeAdd.DisplayMember = "DTitle";

        }

        private void txtTitleSearch_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtTitleSearch.Text = string.Empty;
            ddlTypeSearch.SelectedIndex = 0;
            LoadList();
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            DishTypeFrm dtFrm=new DishTypeFrm();
            DialogResult result = dtFrm.ShowDialog();
            if (result==DialogResult.OK)
            {
                LoadTypeList();
                LoadList();;
               
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitleSave.Text.Trim())||string.IsNullOrEmpty(txtPrice.Text.Trim()))
            {
                MessageBox.Show("添加失败");
                return;
            }
            DishInfo di=new DishInfo()
            {
                DTitle=txtTitleSave.Text.Trim(),
                DChar = txtChar.Text.Trim(),
                DPrice = double.Parse(txtPrice.Text.Trim()),
                DTypeId = int.Parse(ddlTypeAdd.SelectedValue.ToString())
            };
            if (txtId.Text.Equals("添加时无编号"))
            {
                if (dib.Insert(di))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("操作失败，请稍后再试试");
                }


            }
            else
            {
                di.DId = int.Parse(txtId.Text);
                if (dib.Edit(di))
                {
                    LoadList();
                }
            }
            txtId.Text = "添加时无编号";
            txtChar.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtTitleSave.Text = string.Empty;
            btnAdd.Text = "添加";
            ddlTypeAdd.SelectedIndex = 0;

        }

        private void dgvDishInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //var rows = this.dgvDishInfo.SelectedRows[0];
            var rows = this.dgvDishInfo.Rows[e.RowIndex];
            txtId.Text = rows.Cells[0].Value.ToString();
            ddlTypeAdd.Text = rows.Cells[2].Value.ToString();
            txtChar.Text = rows.Cells[4].Value.ToString();
            txtPrice.Text = rows.Cells[3].Value.ToString();
            txtTitleSave.Text = rows.Cells[1].Value.ToString();
            btnAdd.Text = "修改";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtChar.Text = string.Empty;
            txtTitleSave.Text = string.Empty;
            txtPrice.Text = string.Empty;
            btnAdd.Text = "添加";
            ddlTypeAdd.SelectedIndex = 0;
        }

        private void txtTitleSave_Leave(object sender, EventArgs e)
        {
            txtChar.Text = PinyinsHelper.GetFirstLetter(txtTitleSave.Text.Trim());
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvDishInfo.SelectedRows.Count<=0)
            {
                MessageBox.Show("请选择要操作的行");
                return;
            }
            if (MessageBox.Show("确定要删除吗？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                int id = int.Parse(this.dgvDishInfo.SelectedRows[0].Cells[0].Value.ToString());
                if (dib.Remove(id))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("操作失败");
                }
            }
        }

        private void ddlTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }
    }
}
