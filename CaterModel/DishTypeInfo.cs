using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
   public partial class DishTypeInfo
    {
       public int DId { get; set; }
       public string DTitle { get; set; }
       //public int DTypeId { get; set; }
       //public double DPrice { get; set; }
       //public string DChar { get; set; }
       public int DIsDelete { get; set; }
    }
}
