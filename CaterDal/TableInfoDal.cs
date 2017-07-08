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
   public  partial class TableInfoDal
    {
        
       public List<TableInfo> GetList(Dictionary<string, string> dic)
       {
           string sql = "select ti.*,hi.HTitle as THallTitle " + "from dbo.TableInfo as ti" +
                        "  inner  join dbo.HallInfo as hi" +
                        " on ti.THallId = hi.HId" + 
                        " where ti.TIsDelete = 0 and hi.HIsDelete = 0";
            List<SqlParameter> listP=new List<SqlParameter>();
            if (dic.Count > 0)
            {
                foreach (var pair in dic)
                {
                    sql += " and " + pair.Key + " =@" + pair.Key;
                    listP.Add(new SqlParameter("@" + pair.Key, pair.Value));
                }
            }
           DataTable table = SqlHelper.GetDataTable(sql,listP.ToArray());
           List<TableInfo> listT=new List<TableInfo>();
           foreach (DataRow row in table.Rows)
           {
               listT.Add(new TableInfo()
               {
                   TId = int.Parse(row["TId"].ToString()),
                   TTitle = row["TTitle"].ToString(),
                   THallTitle = row["THallTitle"].ToString(),
                   THallId =int.Parse( row["THallId"].ToString()),
                   TIsFree =bool.Parse( row["TIsFree"].ToString())
               });
           }
           return  listT;
       }

       public int Insert(TableInfo ti)
       {
           string sql = @"insert into dbo.TableInfo( TTitle,TIsFree,THallId, TIsDelete) 
                        values(@TTitle,@TIsFree,@THallId,0)";
            SqlParameter[] paras =
            {
                 new SqlParameter("@TTitle",ti.TTitle),
                 new SqlParameter("@TIsFree",ti.TIsFree),
                 new SqlParameter("@THallId",ti.THallId)
            };
            //SqlParameter para =new SqlParameter("@TTitle", ti.TTitle);
           return SqlHelper.ExecuteNonQuery(sql,paras);
       }

       public int Update(TableInfo ti)
       {
           string sql = "update dbo.TableInfo set TTitle=@TTitle,TIsFree=@TIsFree,THallId=@THallId where TId=@TId";
           SqlParameter[] paras =
           {
                new SqlParameter("@TTitle",ti.TTitle),
                new SqlParameter("@TIsFree",ti.TIsFree), 
                new SqlParameter("@THallId",ti.THallId), 
                new SqlParameter("@TId",ti.TId)
           };
           return SqlHelper.ExecuteNonQuery(sql, paras);
       }

       public int Remove(int id)
       {
           string sql = "update dbo.TableInfo set TIsDelete=1 where TId=@TId";
           SqlParameter para=new SqlParameter("@TId",id);
           return SqlHelper.ExecuteNonQuery(sql, para);
       }

       //public int SetState(int tableId,bool isFree)
       //{
       //    string sql = "update dbo.TableInfo set TIsFree=@isFree where TId=@id";
       //    SqlParameter[] paras =
       //    {
       //         new SqlParameter("@isFree",isFree?0:1), 
       //         new SqlParameter("@id",tableId), 
       //    };
       //    return SqlHelper.ExecuteNonQuery(sql, paras);
       //}
    }
}
