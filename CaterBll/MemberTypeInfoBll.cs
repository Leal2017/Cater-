using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
   public  partial class MemberTypeInfoBll
    {
       private MemberTypeInfoDal mtiDal=new MemberTypeInfoDal(); 
       public List<MemberTypeInfo> GetList()
       {
           return mtiDal.GetList();
       }

       public bool Insert(MemberTypeInfo mti)
       {
           return mtiDal.Insert(mti)>0;
       }
        public bool Update(MemberTypeInfo mti)
        {
            return mtiDal.Modify(mti)>0 ;
        }
        public bool Remove(int id)
        {
            return mtiDal.Delete(id)>0;
        }
    }
}
