using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
  public  partial class HallInfoBll
    {
        HallInfoDal hiDal=new HallInfoDal();
        public List<HallInfo> GetlList()
        {
            return hiDal.GetList();
        }

      public bool Add(HallInfo hi)
      {
          return hiDal.Insert(hi) > 0;
      }

      public bool Edit(HallInfo hi)
      {
            return hiDal.Update(hi) > 0;
       }

      public bool Remove(int id)
      {
            return hiDal.Remove(id) > 0;
        }
    }
}
