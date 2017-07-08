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
  public  partial class HallInfoDal
    {
      public List<HallInfo> GetList()
      {
          string sql = "select HId, HTitle, HIsDelete from dbo.HallInfo where HIsDelete=0";
          DataTable table = SqlHelper.GetDataTable(sql);
           List<HallInfo> list=new List<HallInfo>();
          foreach (DataRow row in table.Rows)
          {
              list.Add(new HallInfo()
              {
                  HId = int.Parse(row["HId"].ToString()),
                  HTitle = row["HTitle"].ToString()
              });
          }
          return list;
      }

      public int Insert(HallInfo hi)
      {
          string sql = "insert into dbo.HallInfo( HTitle,HIsDelete) values(@HTitle,0 )";
          SqlParameter para=new SqlParameter("@HTitle",hi.HTitle);
          return SqlHelper.ExecuteNonQuery(sql, para);
      }

      public int Update(HallInfo hi)
      {
          string sql = "update dbo.HallInfo set HTitle=@HTitle where HId=@HId ";
          SqlParameter[] paras =
          {
                new SqlParameter("@HTitle",hi.HTitle), 
                new SqlParameter("@HId",hi.HId), 
          };
          return SqlHelper.ExecuteNonQuery(sql, paras);
      }

      public int Remove(int id)
      {
          string sql = "update dbo.HallInfo set HIsDelete=1 where HId=@HId";
           SqlParameter para=new SqlParameter("@HId",id);
          return SqlHelper.ExecuteNonQuery(sql, para);
      }
    }
}
