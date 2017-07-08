using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    /// <summary>
    /// DishInfoBll
    /// </summary>
    public partial class DishInfoBll
    {
       private DishInfoDal did=new DishInfoDal();
       public List<DishInfo> GetList(Dictionary<string,string>  dic)
       {
           return did.GetList(dic);
       }

       public bool Insert(DishInfo di)
       {
           return did.Insert(di) > 0;
       }

       public bool Edit(DishInfo di)
       {
           return did.Update(di) > 0;
       }

       public bool Remove(int id)
       {
           return did.Delete(id) > 0;
       }
    }
}
