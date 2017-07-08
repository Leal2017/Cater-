using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CaterModel;

namespace CaterDal
{
   public partial class OrderInfoDal
    {
        public int OpenOrder(int tableId)
        {
            //写在一起执行，与数据库交互一次，提高效率
            string sql = "insert into dbo.Or" +
                         "derInfo(ODate,IsPay,TableId) " +
                         "values(getdate(),0,@id);" +
                         "update dbo.TableInfo set TIsFree=0 where TId=@id;" +
                         "select top 1 OId from OrderInfo order by OId desc";
            SqlParameter para = new SqlParameter("@id", tableId);
            return SqlHelper.ExecuteScalar<int>(sql, para);
        }

       public int GetOrderIdByTableId(int tableId)
       {
           string sql = "select OId from OrderInfo where tableId=@tableId and isPay=0";
            SqlParameter para=new SqlParameter("@tableId",tableId);
           return SqlHelper.ExecuteScalar<int>(sql, para);

       }
       public int DianChai(int orderId,int dishId)
       {
            string sql = "select count(*) from OrderDetailInfo " +
                         "where orderId=@orderId and dishId=@dishId";
            //string sql = "insert into OrderDetailInfo(orderId,dishId,count)" +
            //               "values(@orderId,@dishId,1)";
            SqlParameter[] paras =
           {
                new SqlParameter("@orderId",orderId),
                new SqlParameter("@dishId",dishId)
           };
            int count = SqlHelper.ExecuteScalar<int>(sql, paras);
            SqlParameter[] p1;
            if (count > 0)
            {
                sql = "update OrderDetailInfo set count=count+1 " +
                      " where orderId=@orderId and dishId=@dishId ";
                p1 =new []
               {
                new SqlParameter("@orderId",orderId),
                new SqlParameter("@dishId",dishId)
               };
              }
             else
            {
                sql = "insert into OrderDetailInfo(orderId,dishId,count)" +
                      "values(@orderId,@dishId,1)";
                 p1 =new []
              {
                new SqlParameter("@orderId",orderId),
                new SqlParameter("@dishId",dishId)
               };
            }
            return SqlHelper.ExecuteNonQuery(sql, p1);
       }

       public List<OrderDetailInfo> GetDetailList(int orderId)
       {
           string sql=@"select odti.OId,di.DTitle,di.DPrice,odti.Count from dbo.OrderDetailInfo as odti
                      inner join dbo.DishInfo2 as di
                      on odti.DishId = di.DId where odti.OrderId = @orderId";
            SqlParameter para=new SqlParameter("@orderId",orderId);
            DataTable table = SqlHelper.GetDataTable(sql, para);
            List<OrderDetailInfo> list=new List<OrderDetailInfo>();
           foreach (DataRow row in table.Rows)
           {
               list.Add(new OrderDetailInfo()
               {
                   OId = Convert.ToInt32(row["OId"]),
                   DTitle=row["DTitle"].ToString(),
                   DPrice = Convert.ToDecimal(row["DPrice"]),
                   Count = Convert.ToInt32(row["count"])
               });
           }
           return list;
       }

       public int UpdateCountByOId(OrderDetailInfo odi)
       {
           string sql = "update OrderDetailInfo set Count=@count where OId=@id";
           SqlParameter[] paras =
           {
                new SqlParameter("@count",odi.Count), 
                new SqlParameter("@id",odi.OId) 
           };
           return SqlHelper.ExecuteNonQuery(sql, paras);
       }

       public decimal GetTotalMoneyByOrderId(int orderId)
       {
           string sql = @"select sum(odi.count * di.DPrice) from OrderDetailInfo as odi
                         inner join DishInfo2 as di
                          on odi.DishId = di.DId
                         where odi.orderId = @orderId";
           SqlParameter para=new SqlParameter("@orderId",orderId);
           object obj = SqlHelper.ExecuteScalar<object>(sql, para);
           if (obj==DBNull.Value)
           {
               return 0;
           }
           return Convert.ToDecimal(obj);

       }

       public int DeleteDetailByOId(int oId)
       {
           string sql = "delete from OrderDetailInfo where OId=@oId";
            SqlParameter para=new SqlParameter("@oId",oId);
           return SqlHelper.ExecuteNonQuery(sql, para);
       }

       public decimal SetOrderMoney(int orderId,decimal money)
       {
           string sql = "update OrderInfo set OMoney=@money where OId=@oid";
           SqlParameter[] paras =
           {
                new SqlParameter("@money",money),
                new SqlParameter("@oid",orderId),  
           };
           return SqlHelper.ExecuteNonQuery(sql, paras);
       }

       public int Pay(bool isUseMoney,decimal payMoney,int memberId,decimal discount,int orderId)
       {
           using (SqlConnection conn=new SqlConnection(SqlHelper.GetsqlTextConnectionString))
           {
               conn.Open();
               int result=0;
               SqlTransaction tran = conn.BeginTransaction();
               SqlCommand cmd = conn.CreateCommand();
               cmd.Transaction = tran;
               string sql = string.Empty;
               SqlParameter[] paras;
               try
               {
                   if (isUseMoney)
                   {
                       sql = "update MemberInfo set MMoney=MMoney-@payMoney where MId=@MId";
                       paras = new SqlParameter[]
                       {
                           new SqlParameter("@payMoney", payMoney),
                           new SqlParameter("MId", memberId)
                       };
                       cmd.CommandText = sql;
                       cmd.Parameters.AddRange(paras);
                       result += cmd.ExecuteNonQuery();
                   }
                   sql = "update orderInfo set isPay=1,memberId=@mid,discount=@discount where oid=@oid";
                   paras = new[]
                   {
                       new SqlParameter("mid", memberId),
                       new SqlParameter("@discount", discount),
                       new SqlParameter("@oid", orderId)
                   };
                   cmd.CommandText = sql;
                   cmd.Parameters.Clear();
                   cmd.Parameters.AddRange(paras);
                   result += cmd.ExecuteNonQuery();
                   sql = "update TableInfo set TIsFree=1 " +
                         "where tid=(select tableId from orderinfo where oid=@oid)";
                   paras = new[]
                   {
                       new SqlParameter("@oid", orderId),
                   };
                   cmd.CommandText = sql;
                   cmd.Parameters.Clear();
                   cmd.Parameters.AddRange(paras);
                   result += cmd.ExecuteNonQuery();
                    tran.Commit();
               } //end try
               catch (Exception)
               {
                   result = 0;
                    tran.Rollback();
               }
               return result;
           }//end conn
        }
    }
}
