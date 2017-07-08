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
   public partial class MemberTypeInfoDal
    {
       public List<MemberTypeInfo> GetList()
       {
           string sql =
              "select MId, MTitle, MDiscount, MIsDelete from dbo.MemberTypeInfo1  where MIsDelete = 0";
           DataTable table = SqlHelper.GetDataTable(sql);
           List<MemberTypeInfo> list=new List<MemberTypeInfo>();
           foreach (DataRow row in table.Rows)
           {
               list.Add(new MemberTypeInfo()
               {
                   MId = int.Parse(row["MId"].ToString()),
                   MTitle = row["MTitle"].ToString(),
                   MDiscount = Convert.ToDecimal(row["MDiscount"].ToString()),
                   //MIsDelete = Convert.ToInt32(row["MIsDelete"].ToString())
               });
           }
           return list; 
       }

       public int Insert(MemberTypeInfo mti)
       {
           string sql = "insert into dbo.MemberTypeInfo1(MTitle, MDiscount, MIsDelete)" +
                        "  values(@Title,@Discount,0) ";
           SqlParameter[] paras =
           {
                new SqlParameter("@Title",mti.MTitle), 
                new SqlParameter("@Discount",mti.MDiscount)
           };
           return SqlHelper.ExecuteNonQuery(sql, paras);
       }

       public int Modify(MemberTypeInfo mti)
       {
           string sql = "update dbo.MemberTypeInfo1 set MTitle=@Title, MDiscount=@Discount" +
                        " where MId=@Id";
           SqlParameter[] paras =
           {
               new SqlParameter("@Title", mti.MTitle),
               new SqlParameter("@Discount", mti.MDiscount),
               new SqlParameter("@Id", mti.MId)
           };
           return SqlHelper.ExecuteNonQuery(sql, paras);
       }

       public int Delete(int id)
       {
           string sql = "update dbo.MemberTypeInfo1 set MIsDelete=1 where MId=@Id ";
            SqlParameter para=new SqlParameter("@Id",id);
           return SqlHelper.ExecuteNonQuery(sql, para);
       }
    }
}
