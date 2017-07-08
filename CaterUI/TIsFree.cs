using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterUI
{
   public partial class TIsFree
   {
       public TIsFree(int id,string title)
       {
           this.Id = id;
           this.Title = title;
       }
       private int _id;
       private string _title;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }
    }
}
