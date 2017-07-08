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
    public partial class OrderPayFrm : Form
    {
        public OrderPayFrm()
        {
            InitializeComponent();
        }
        private OrderInfoBll oiBll=new OrderInfoBll();
        private int orderId;
        public event Action Refresh;
        private void OrderPayFrm_Load(object sender, EventArgs e)
        {
            orderId = Convert.ToInt32(this.Tag);
            gbMember.Enabled = false;
            GetMoneyByOrderId();
        }

        private void GetMoneyByOrderId()
        {
            lblPayMoney.Text = oiBll.GetTotalMoneyByOrderId(orderId).ToString();
            lblPayMoneyDiscount.Text = oiBll.GetTotalMoneyByOrderId(orderId).ToString();
        }

        private void LoadMember()
        {
            MemberInfoBll miBll=new MemberInfoBll();
            Dictionary<string,string> dic=new Dictionary<string, string>();
            if (txtId.Text=="")
            {
                dic.Add("MId",txtId.Text);
            }
            if (txtPhone.Text=="")
            {
                dic.Add("MPhone",txtPhone.Text);
            }
            var list = miBll.GetList(dic);
            if (list.Count>0)
            {
                MemberInfo mi = list[0];
                lblMoney.Text = mi.MMoney.ToString();
                lblTypeTitle.Text = mi.MTypeTitle;
                lblDiscount.Text = mi.MDiscount.ToString();
                lblPayMoneyDiscount.Text= 
                    (Convert.ToDecimal(lblPayMoney.Text) * Convert.ToDecimal(lblDiscount.Text)).ToString();
            }
            else
            {
                MessageBox.Show("会员信息有误");
            }
        }

        private void cbkMember_CheckedChanged(object sender, EventArgs e)
        {
            gbMember.Enabled = cbkMember.Checked;
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            LoadMember();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            LoadMember();
        }
       
        private void btnOrderPay_Click(object sender, EventArgs e)
        {
            //bool isUseMoney,decimal payMoney,int memberId,decimal discount,int orderId
            bool isUseMoney = cbkMoney.Checked;
            decimal payMoney = Convert.ToDecimal(lblPayMoney.Text);
            int memberId = int.Parse(txtId.Text.Trim());
            decimal discount = Convert.ToDecimal(lblDiscount.Text);
            int oid = orderId;
            if (oiBll.Pay(isUseMoney,payMoney,memberId,discount,oid)>0)
            {
                //MessageBox.Show("支付成功");
                Refresh();
                
                this.Close();
            }
            else
            {
                MessageBox.Show("结账失败");
            }
        }
    }
}
