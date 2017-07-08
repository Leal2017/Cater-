using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using CaterModel;
using CaterCommon;

namespace CaterDal
{
 
   public partial class ManagerInfoDal
    {
       /// <summary>
       /// 获取查询结果集
       /// </summary>
       public List<ManagerInfo> GetList()
       {
           string sql = "select  MId, MName, MPwd, MType from dbo.ManagerInfo";
           DataTable table = SqlHelper.GetDataTable(sql);
           List<ManagerInfo> managerList = new List<ManagerInfo>();
           foreach (DataRow row in table.Rows)
           {
               managerList.Add(new ManagerInfo()
               {
                   MId = int.Parse(row["MId"].ToString()),
                   MName = row["MName"].ToString(),
                   MPwd = row["MPwd"].ToString(),
                   MType = int.Parse(row["MType"].ToString())
               });
           }
           return managerList;
       }
/// <summary>
/// 添加管理员
/// </summary>
/// <param name="managerInfo"></param>
/// <returns></returns>
       public int Insert(ManagerInfo managerInfo)
       {
           string sql = "insert into ManagerInfo(MName, MPwd, MType) values(@MName,@MPwd,@MType)";
            #region list<>实现
           // List<SqlParameter> parameters = new List<SqlParameter>();
           // SqlParameter parameter = new SqlParameter();
           // parameter.ParameterName = "@MName";
           //parameter.Value = managerInfo.MName;
           // parameters.Add(parameter);
           // parameter.ParameterName = "@MPwd";
           // parameter.Value = managerInfo.MPwd;
           // parameters.Add(parameter);
           // parameter.ParameterName = "@MType";
           // parameter.Value = managerInfo.MType;
           // parameters.Add(parameter);
            #endregion
            SqlParameter[] para =
           {
                
                
                new SqlParameter("@MName",managerInfo.MName), 
                new SqlParameter("@MPwd",MD5Helper.EncrytString(managerInfo.MPwd)), 
                new SqlParameter("@MType",managerInfo.MType), 
           };
            return SqlHelper.ExecuteNonQuery(sql,para);
       }
/// <summary>
/// 修改管理员
/// </summary>
/// <param name="managerInfo"></param>
/// <returns></returns>
       public int Update(ManagerInfo managerInfo)
       {
           List<SqlParameter> list=new List<SqlParameter>();
           StringBuilder builder=new StringBuilder();
           string sql = "Update ManagerInfo set MName=@MName";
           list.Add(new SqlParameter("@MName",managerInfo.MName));
           if (!managerInfo.MPwd.Equals("这是原来的密码吗"))
           {
                string str1=sql +",MPwd=@MPwd";
                list.Add(new SqlParameter("@MPwd",MD5Helper.EncrytString(managerInfo.MPwd)));
                string str2 = str1 + ",MType=@MType where MId=@MId";
                list.Add(new SqlParameter("@MType",managerInfo.MType));
                list.Add(new SqlParameter("@MId",managerInfo.MId));
                builder.Append(str2);
           }
         return SqlHelper.ExecuteNonQuery(builder.ToString(),list.ToArray());
       }

       public int Delete(int id)
       {
           string sql = "delete ManagerInfo where MId=@MId";
           SqlParameter para=new SqlParameter("@MId",id);
           return SqlHelper.ExecuteNonQuery(sql, para);
       }

       public ManagerInfo GetByName (string name)
       {
           string sql = "select  MId, MName, MPwd, MType from dbo.ManagerInfo where MName=@MName";
           SqlParameter para=new SqlParameter("@MName",name);
           DataTable table = SqlHelper.GetDataTable(sql, para);
           ManagerInfo mi = null;
           if (table.Rows.Count > 0)
           {
                mi=new ManagerInfo()
               {
                   MId =Convert.ToInt32(table.Rows[0][0]),
                   MName = table.Rows[0][1].ToString(),
                   MPwd = table.Rows[0][2].ToString(),
                   MType =int.Parse( table.Rows[0][3].ToString()),
               };
           }
           return mi;
       }
    }
}
