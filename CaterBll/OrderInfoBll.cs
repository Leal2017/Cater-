using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
   public partial class OrderInfoBll
    {
        private OrderInfoDal oiDal=new OrderInfoDal();
       public int OpenOrder(int tableId)
       {
           return oiDal.OpenOrder(tableId);
       }

       public bool DianChai(int orderId,int dishId)
       {
           return oiDal.DianChai(orderId, dishId) > 0;
       }

       public List<OrderDetailInfo> GetDetailList(int orderId)
       {
           return oiDal.GetDetailList(orderId);
       }

       public int GetOrderIdByTableId(int tableId)
       {
           return oiDal.GetOrderIdByTableId(tableId);
       }

       public bool UpdateCountByOId(OrderDetailInfo odi)
       {
           return oiDal.UpdateCountByOId(odi) > 0;
       }

       public decimal GetTotalMoneyByOrderId(int orderId)
       {
           return oiDal.GetTotalMoneyByOrderId(orderId);
       }

       public bool DeleteDetailByOId(int oId)
       {
           return oiDal.DeleteDetailByOId(oId) > 0;
       }

       public bool SetOrderMoney(int orderId,decimal money)
       {
           return oiDal.SetOrderMoney(orderId, money) > 0;
       }

       public int Pay(bool isUseMoney, decimal payMoney, int memberId, decimal discount, int orderId)
       {
           return oiDal.Pay(isUseMoney,payMoney,memberId,discount,orderId);
       }
    }
}
