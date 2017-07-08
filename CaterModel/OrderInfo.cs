using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// OrderInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrderInfo
	{
		public OrderInfo()
		{}
		#region Model
		private int _old;
		private int? _memberid;
		private DateTime? _odate;
		private decimal? _omoney;
		private int? _ispay;
		private int? _tableid;
		private decimal? _discount;
		/// <summary>
		/// 
		/// </summary>
		public int Old
		{
			set{ _old=value;}
			get{return _old;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MemberId
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ODate
		{
			set{ _odate=value;}
			get{return _odate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OMoney
		{
			set{ _omoney=value;}
			get{return _omoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsPay
		{
			set{ _ispay=value;}
			get{return _ispay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TableId
		{
			set{ _tableid=value;}
			get{return _tableid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Discount
		{
			set{ _discount=value;}
			get{return _discount;}
		}
		#endregion Model

	}
}

