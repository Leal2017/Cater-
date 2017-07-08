using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
    [Serializable]
   public  partial class TableInfo
    {
        public TableInfo()
        {
            
        }

        private int _tId;
        private string _tTitle;
        private int _tHallId;
        private bool _tIsFree;
        private short _tIsDelete;
        private string _tHallTitle;

        public int TId
        {
            get
            {
                return _tId;
            }

            set
            {
                _tId = value;
            }
        }

        public string TTitle
        {
            get
            {
                return _tTitle;
            }

            set
            {
                _tTitle = value;
            }
        }

        public int THallId
        {
            get
            {
                return _tHallId;
            }

            set
            {
                _tHallId = value;
            }
        }

        public bool TIsFree
        {
            get
            {
                return _tIsFree;
            }

            set
            {
                _tIsFree = value;
            }
        }

        public short TIsDelete
        {
            get
            {
                return _tIsDelete;
            }

            set
            {
                _tIsDelete = value;
            }
        }

        public string THallTitle
        {
            get
            {
                return _tHallTitle;
            }

            set
            {
                _tHallTitle = value;
            }
        }
    }
}
