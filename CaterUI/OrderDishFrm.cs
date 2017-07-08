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
    public partial class OrderDishFrm : Form
    {
        public OrderDishFrm()
        {
            InitializeComponent();
        }
        private  OrderInfoBll oiBll=new OrderInfoBll();
        //private static OrderDishFrm _odFrm = null;

        //public static OrderDishFrm Create()
        //{
        //    if (_odFrm==null)
        //    {
        //        _odFrm=new OrderDishFrm();
        //    }
        //    return _odFrm;
        //}
        private void OrderDishFrm_Load(object sender, EventArgs e)
        {
            LoadDishTypeInfo();
            LoadDishInfo();
            LoadDetailList();
        }

        private void LoadDishInfo()
        {
            Dictionary<string,string> dic=new Dictionary<string, string>();
            if (txtFirstWord.Text!="")
            {
                dic.Add("DChar",txtFirstWord.Text);
            }
            if (ddlType.SelectedValue.ToString()!="0")
            {
                dic.Add("DTypeId",ddlType.SelectedValue.ToString());
            }
            DishInfoBll diBll=new DishInfoBll();
            this.dgvAllDish.AutoGenerateColumns = false;
            this.dgvAllDish.DataSource = diBll.GetList(dic);
        }

        private void LoadDishTypeInfo()
        {
            DishTypeInfoBll dtiBll=new DishTypeInfoBll();
            var list = dtiBll.GetList();
            list.Insert(0,new DishTypeInfo()
            {
                DId =0,
                DTitle = "全部"
            });
            ddlType.ValueMember = "DId";
            ddlType.DisplayMember = "DTitle";
            ddlType.DataSource =list;
        }

        private void LoadDetailList()
        {
            int tableId = Convert.ToInt32(this.Tag);
            this.dgvOrderDetail.AutoGenerateColumns = false;
            this.dgvOrderDetail.DataSource = oiBll.GetDetailList(tableId);
            GetTotalMoneyByOrderId();
        }

        private void GetTotalMoneyByOrderId()
        {
            int orderId = Convert.ToInt32(this.Tag);
            lblMoney.Text = oiBll.GetTotalMoneyByOrderId(orderId).ToString();
        }
        private void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDishInfo();
        }

        private void txtFirstWord_TextChanged(object sender, EventArgs e)
        {
            LoadDishInfo();
        }

        private void dgvAllDish_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int orderId = Convert.ToInt32(this.Tag);
            int dishId = Convert.ToInt32(dgvAllDish.Rows[e.RowIndex].Cells[0].Value.ToString());
            if (oiBll.DianChai(orderId,dishId))
            {
                LoadDetailList();
               
            }
        }

        private void dgvOrderDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = this.dgvOrderDetail.Rows[e.RowIndex];
            if (e.ColumnIndex==2)
            {
                
                 OrderDetailInfo odi=new OrderDetailInfo()
                 {
                     OId = Convert.ToInt32(row.Cells[0].Value),
                     Count = Convert.ToInt32(row.Cells[2].Value)
                 };
                oiBll.UpdateCountByOId(odi);
            }
            GetTotalMoneyByOrderId();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvOrderDetail.SelectedRows.Count<0)
            {
                return;
            }
            int oId = int.Parse(this.dgvOrderDetail.SelectedRows[0].Cells[0].Value.ToString());
            DialogResult result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result==DialogResult.Cancel)
            {
                return;
            }
            if (oiBll.DeleteDetailByOId(oId))
            {
                LoadDetailList();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            int orderId = Convert.ToInt32(this.Tag);
            decimal money = Convert.ToDecimal(lblMoney.Text);
            if (oiBll.SetOrderMoney(orderId,money))
            {
                MessageBox.Show("下单成功");
            }
        }
    }
}
