using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
   public partial class TableInfoBll
   {
       public TableInfoBll()
       {
          this.tiDal=new TableInfoDal();
       }
       private TableInfoDal tiDal;
       public List<TableInfo> GetList(Dictionary<string, string> dic)
       {
           return tiDal.GetList(dic);
       }

       public bool Add(TableInfo ti)
       {
           return tiDal.Insert(ti) > 0;
       }

        public bool Edit(TableInfo ti)
        {
            return tiDal.Update(ti) > 0;
        }

        public bool Remove(int id)
        {
            return tiDal.Remove(id) > 0;
        }
    }
}
