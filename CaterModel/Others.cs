using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
   
       public partial class MemberInfo
       {
           private string _mTypeTitle;
           private decimal _mDiscount;
           public string MTypeTitle
          {
            get
            {
                return _mTypeTitle;
            }

            set
            {
                _mTypeTitle = value;
            }
        }

           public decimal MDiscount
        {
            get
            {
                return _mDiscount;
            }

            set
            {
                _mDiscount = value;
            }
        }
         }
        //public partial class TableInfo
        //{
        //    private string _tHallTitle;

        //    public string THallTitle
        //    {
        //        get
        //        {
        //            return _tHallTitle;
        //        }

        //        set
        //        {
        //            _tHallTitle = value;
        //        }
        //    }
        //}
        public  partial class OrderDetailInfo
        {
            private string _dTitle;
            private decimal _dPrice;

            public string DTitle
        {
            get
            {
                return _dTitle;
            }

            set
            {
                _dTitle = value;
            }
        }

           public decimal DPrice
        {
            get
            {
                return _dPrice;
            }

            set
            {
                _dPrice = value;
            }
        }
          }
    
}
