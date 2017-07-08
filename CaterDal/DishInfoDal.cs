using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterModel;

namespace CaterDal
{
   public partial class DishInfoDal
    {
       public List<DishInfo> GetList(Dictionary<string,string> dic )
       {
            List<DishInfo> list = new List<DishInfo>();
            List<SqlParameter> para=new List<SqlParameter>();
            string sql = @"select di.*,dti.DTitle as DTypeTitle 
                       from DishTypeInfo as dti
                       inner join DishInfo2 as di
                       on dti.DId = di.DId
                       where dti.DIsDelete = 0 and di.DIsDelete = 0";
           if (dic.Count>0)
           {
               foreach (var pair in dic)
               {
                   sql += " and di." + pair.Key + " like "  +"@"+pair.Key;
                    para.Add(new SqlParameter("@"+pair.Key,"%"+pair.Value+"%"));           
               } 
              
           }
           
            DataTable table = SqlHelper.GetDataTable(sql,para.ToArray());
            foreach (DataRow row in table.Rows)
           {
               list.Add(new DishInfo()
               {
                   DId = int.Parse(row["DId"].ToString()),
                   DTitle = row["DTitle"].ToString(),
                   DChar = row["DChar"].ToString(),
                   DPrice = double.Parse(row["DPrice"].ToString()),
                   //DTypeId = int.Parse(row["DTypeId"].ToString()),
                   DTypeTitle = row["DTypeTitle"].ToString()
                   
               });
           }
           return list;
       }

       public int Insert(DishInfo di)
       {
           string sql = @"insert into dbo.DishInfo2(DTitle, DTypeId, DPrice, DChar, DIsDelete) values(@DTitle,@DTypeId,@DPrice,@DChar,0)";

            SqlParameter[] para =
           {
                new SqlParameter("@DTitle",di.DTitle), 
                new SqlParameter("@DTypeId",di.DTypeId), 
                new SqlParameter("@DPrice",di.DPrice), 
                new SqlParameter("@DChar",di.DChar), 
                new SqlParameter("@DId",di.DId)
           };
           return SqlHelper.ExecuteNonQuery(sql, para);
       }

       public int Update(DishInfo di)
       {
           string sql = @"update dbo.DishInfo2 set DTitle=@DTitle,DTypeId=@DTypeId,DPrice=@DPrice,
                           DChar=@DChar where DId=@DId";
           SqlParameter[] para =
           {
               new SqlParameter("@DTitle", di.DTitle),
               new SqlParameter("@DTypeId", di.DTypeId),
               new SqlParameter("@DPrice", di.DPrice),
               new SqlParameter("@DChar", di.DChar),
               new SqlParameter("@DId", di.DId)
           };
           return SqlHelper.ExecuteNonQuery(sql, para);

       }
       public int Delete(int id)
       {
           string sql = "update dbo.DishInfo2 set DIsDelete=1 where DId=@DId";
            SqlParameter para=new SqlParameter("@DId",id);
           return SqlHelper.ExecuteNonQuery(sql,para);
       }
    }
}
