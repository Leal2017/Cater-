using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
  public partial class DishTypeInfoBll
    {
       DishTypeInfoDal dishTypeInfoDal=new DishTypeInfoDal();
      public List<DishTypeInfo> GetList()
      {
          return dishTypeInfoDal.GetList();
      }

      public bool Add(DishTypeInfo dishTypeInfo)
      {
          return dishTypeInfoDal.Insert(dishTypeInfo)>0;
      }

      public bool Update(DishTypeInfo dishTypeInfo)
      {
          return dishTypeInfoDal.Update(dishTypeInfo)>0;
      }

      public bool Remove(int id)
      {
          return dishTypeInfoDal.Delete(id)>0;
      }
    }
}
