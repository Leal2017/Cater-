using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
    [Serializable]
   public partial class HallInfo
    {
       public HallInfo()
       {
           
       }

        private int _hId;
        private string _hTitle;
        private bool _hIsDelete; 
        public int HId
        {
            get
            {
                return _hId;
            }

            set
            {
                _hId = value;
            }
        }

        public string HTitle
        {
            get
            {
                return _hTitle;
            }

            set
            {
                _hTitle = value;
            }
        }

        public bool HIsDelete
        {
            get
            {
                return _hIsDelete;
            }

            set
            {
                _hIsDelete = value;
            }
        }
    }
}
