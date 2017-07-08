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
   public partial class MemberInfoDal
    {
        public List<MemberInfo> GetList(Dictionary<string, string> dic)
        {
            string sql = @"select mi.*,mti.MDiscount,mti.MTitle as MTypeTitle 
                       from dbo.MemberInfo as mi
                       inner join dbo.MemberTypeInfo1 as mti
                       on mi.MTypeId = mti.MId
                       where mi.MIsDelete = 0 and mti.MIsDelete = 0";
            List<SqlParameter> listP = new List<SqlParameter>();
            if (dic.Count > 0)
            {
                foreach (var pair in dic)
                {
                    sql += " and mi." + pair.Key + " like @" + pair.Key;
                    listP.Add(new SqlParameter("@" + pair.Key,"%" +pair.Value+"%"));
                }
            }
            DataTable table = SqlHelper.GetDataTable(sql,listP.ToArray());
            List<MemberInfo> listT = new List<MemberInfo>();
            foreach (DataRow row in table.Rows)
            {
               listT.Add(new MemberInfo()
               {
                   MId = Convert.ToInt32(row["MId"]),
                   MName = row["MName"].ToString(),
                   MPhone = row["MPhone"].ToString(),
                   MMoney = Convert.ToDecimal(row["MMoney"]),
                   MTypeId = Convert.ToInt32(row["MTypeId"]),
                   MTypeTitle = row["MTypeTitle"].ToString(),
                   MDiscount = Convert.ToDecimal(row["MDiscount"])
               });
            }
            return listT;
        }

       public int Insert(MemberInfo mi)
       {
           //string sql = "insert into dbo.MemberInfo( MTypeId, MName, MPhone, MMoney, MIsDelete) " +
           //             "values(@MTypeId, @MName, @MPhone, @MMoney, 0)";
           //SqlParameter[] paras =
           //{
           //     new SqlParameter("@MTypeId",mi.MTypeId),
           //     new SqlParameter("@MName",mi.MName),
           //     new SqlParameter("@MPhone",mi.MPhone),
           //     new SqlParameter(" @MMoney",mi.MMoney),
           //};
            string sql = "insert into memberinfo(mtypeid,mname,mphone,mmoney,misDelete) values(@tid,@name,@phone,@money,0)";
            SqlParameter[] ps =
            {
                new SqlParameter("@tid", mi.MTypeId),
                new SqlParameter("@name", mi.MName),
                new SqlParameter("@phone", mi.MPhone),
                new SqlParameter("@money", mi.MMoney)
            };
            return SqlHelper.ExecuteNonQuery(sql, ps);
          

       }

       public int Update(MemberInfo mi)
       {
           string sql = "update dbo.MemberInfo set MTypeId=@MTypeId, MName=@MName, MPhone=@MPhone, MMoney=@MMoney" +
                        "where MId=@id";
           SqlParameter[] paras =
           {
                new SqlParameter("@MTypeId",mi.MTypeTitle),
                new SqlParameter("@MName",mi.MName),
                new SqlParameter("@MPhone",mi.MPhone),
                new SqlParameter(" @MMoney",mi.MMoney),
                new SqlParameter("@id",mi.MId)
           };
           return SqlHelper.ExecuteNonQuery(sql, paras);
       }

       public int Delete(int id)
       {
           string sql = "update dbo.MemberInfo set MIsDelete=1 where MId=@id";
           SqlParameter para=new SqlParameter("@id",id);
           return SqlHelper.ExecuteNonQuery(sql, para);
       }
    }
}
