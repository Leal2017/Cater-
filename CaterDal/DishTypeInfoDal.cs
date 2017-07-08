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
  public partial class DishTypeInfoDal
    {
      public List<DishTypeInfo> GetList()
      {
          string sql = "select DId, DTitle, DIsDelete from dbo.DishTypeInfo where DIsDelete=0";
          DataTable table = SqlHelper.GetDataTable(sql);
           List<DishTypeInfo> list=new List<DishTypeInfo>();
          foreach (DataRow row in table.Rows)
          {
               DishTypeInfo dishTypeInfo=new DishTypeInfo()
              {
                  DId =int.Parse(row["DId"].ToString()),
                  DTitle = row["DTitle"].ToString(),
              };
              list.Add(dishTypeInfo);
          }
          return list;
      }

      public int Insert(DishTypeInfo dishTypeInfo)
      {
          string sql = "insert into dbo.DishTypeInfo(DTitle,DIsDelete) values(@DTitle,0) ";
          SqlParameter para=new SqlParameter("@DTitle",dishTypeInfo.DTitle);
          return SqlHelper.ExecuteNonQuery(sql, para);
      }

      public int Update(DishTypeInfo dishTypeInfo)
      {
          string sql = "update dbo.DishTypeInfo set DTitle=@DTitle where DId=@DId ";
          SqlParameter[] paras =
          {
                new SqlParameter("@DTitle",dishTypeInfo.DTitle), 
                new SqlParameter("@DId",dishTypeInfo.DId) 
          };
          return SqlHelper.ExecuteNonQuery(sql, paras);
      }

      public int Delete(int id)
      {
          string sql = "update  dbo.DishTypeInfo set DIsDelete=1 where DId=@id";
          SqlParameter para=new SqlParameter("@id",id);
          return SqlHelper.ExecuteNonQuery(sql, para);
      }
    }
}
