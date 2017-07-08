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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private  OrderInfoBll oiBll=new OrderInfoBll();
        private void FrmMain_Load(object sender, EventArgs e)
        {
            int type = Convert.ToInt32(this.Tag);
            if (type == 1)
            {

            }
            else
            {
                menuManagerInfo.Visible = false;
            }
            LoadHallInfo();
        }

        private void LoadHallInfo()
        {
            HallInfoBll hiBll=new HallInfoBll();
            List<HallInfo> list = hiBll.GetlList();
            tcHallInfo.TabPages.Clear();
            TableInfoBll tibBll=new TableInfoBll();
            foreach (var hi in list)
            {
                TabPage tp=new TabPage(hi.HTitle);
                
                ListView lvTableInfo=new ListView();
                //注册双击事件，完成开单功能
                lvTableInfo.DoubleClick += LvTableInfo_DoubleClick;
                lvTableInfo.LargeImageList = imageList1;
                lvTableInfo.Dock=DockStyle.Fill;
                tp.Controls.Add(lvTableInfo);

                Dictionary<string,string> dic=new Dictionary<string, string>();
                dic.Add("THallId",hi.HId.ToString());
                var listTableInfo = tibBll.GetList(dic);
                foreach (var ti in listTableInfo)
                {
                    var lvi = new ListViewItem(ti.TTitle, ti.TIsFree ? 0 : 1);
                    lvi.Tag = ti.TId;
                    lvTableInfo.Items.Add(lvi);
                }
                tcHallInfo.TabPages.Add(tp);
            }
        }

        private void LvTableInfo_DoubleClick(object sender, EventArgs e)
        {
            var lv1 = sender as ListView;
            var lvi = lv1.SelectedItems[0];
            int tableId = Convert.ToInt32(lvi.Tag);
            if (lvi.ImageIndex==0)
            {
                 int orderId=oiBll.OpenOrder(tableId);
                 lvi.Tag = orderId;
                 lv1.SelectedItems[0].ImageIndex = 1;
            }
            else
            {
                lvi.Tag = oiBll.GetOrderIdByTableId(tableId);
            }
            OrderDishFrm odFrm = new OrderDishFrm();
            odFrm.Tag = lvi.Tag;
            odFrm.Show();
        }

        private void menuManagerInfo_Click(object sender, EventArgs e)
        {
            MainFrm frm = MainFrm.Create();
            frm.Show();
            frm.Focus();
            frm.WindowState=FormWindowState.Normal;
        }

        private void menuQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void menuMemberInfo_Click(object sender, EventArgs e)
        {
            MemberInfoFrm miFrm = MemberInfoFrm.Create();
            miFrm.Show();
        }

        private void menuTableInfo_Click(object sender, EventArgs e)
        {
            TableInfoFrm tiFrm = TableInfoFrm.Create();
            tiFrm.Refresh += LoadHallInfo;
            tiFrm.Show();
        }

        private void menuDishInfo_Click(object sender, EventArgs e)
        {
            DishInfoFrm diFrm = DishInfoFrm.Create();
            diFrm.Show();
            diFrm.Focus();
        }

        private void menuOrder_Click(object sender, EventArgs e)
        {
            #region MyRegion
            //先找到选中的标签页，再找到listView,再找到选中的项，
            //项中存储了餐桌编号，由餐桌编号查到订单编号
            //var lv=tcHallInfo.SelectedTab.Controls[0] as ListView;
            //var orderId = lv.SelectedItems[0];
            //if (lv.imagei)
            //{

            //} 
            #endregion
            var listView = tcHallInfo.SelectedTab.Controls[0] as ListView;
            var lvTable = listView.SelectedItems[0];
            //if (lvTable.ImageIndex<0)
            //{
            //    return;
            //}
            if (lvTable.ImageIndex == 0)
            {
                MessageBox.Show("餐桌还未使用，无法结账");
                return;
            }
            int tableId = Convert.ToInt32(lvTable.Tag);
            int orderId = oiBll.GetOrderIdByTableId(tableId);
            OrderPayFrm opFrm = new OrderPayFrm();
            opFrm.Tag = orderId;
            opFrm.Refresh += LoadHallInfo;
            opFrm.Show();
        }
    }
}
