using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 数据层(Model)
/// </summary>
namespace CaterModel
{
    public partial class DishInfo
    {
        public DishInfo()
        {
        }
        private int _did;
        private string _dtitle;
        private short _disdelete;
        private double _dPrice;
        private string _dChar;
        private int _dTypeId;
        private string _dTypeTitle;

        public int DId
        {
            set { _did = value; }
            get { return _did; }
        }

        public string DTitle
        {
            set { _dtitle = value; }
            get { return _dtitle; }
        }

        public short DIsDelete
        {
            set { _disdelete = value; }
            get { return _disdelete; }
        }

        public double DPrice
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

        public string DChar
        {
            get
            {
                return _dChar;
            }

            set
            {
                _dChar = value;
            }
        }

        public int DTypeId
        {
            get
            {
                return _dTypeId;
            }

            set
            {
                _dTypeId = value;
            }
        }

        public string DTypeTitle
        {
            get
            {
                return _dTypeTitle;
            }

            set
            {
                _dTypeTitle = value;
            }
        }
    }
}
