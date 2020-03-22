using System;
namespace MultiColorPen.Model
{
	/// <summary>
	/// b_promotions:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class b_promotions
	{
		public b_promotions()
		{}
		#region Model
		private int _id;
		private string _promotioncode;
		private string _caragentcode;
		private string _caragentname;
		private string _brandcode;
		private string _brandname;
		private string _seriescode;
		private string _seriesname;
		private string _title;
		private string _detail;
		private string _url;
		private string _keywords;
		private DateTime? _begintime;
		private DateTime? _endtime;
		private int? _isenable;
		private int? _sort;
		private string _remark;
		private DateTime? _createtime;
		private string _createman;
		private DateTime? _updatetime;
		private string _updateman;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string promotioncode
		{
			set{ _promotioncode=value;}
			get{return _promotioncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string caragentcode
		{
			set{ _caragentcode=value;}
			get{return _caragentcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string caragentname
		{
			set{ _caragentname=value;}
			get{return _caragentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string brandcode
		{
			set{ _brandcode=value;}
			get{return _brandcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string brandname
		{
			set{ _brandname=value;}
			get{return _brandname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seriescode
		{
			set{ _seriescode=value;}
			get{return _seriescode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seriesname
		{
			set{ _seriesname=value;}
			get{return _seriesname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string keywords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? begintime
		{
			set{ _begintime=value;}
			get{return _begintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? endtime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isenable
		{
			set{ _isenable=value;}
			get{return _isenable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string createman
		{
			set{ _createman=value;}
			get{return _createman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? updatetime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string updateman
		{
			set{ _updateman=value;}
			get{return _updateman;}
		}
		#endregion Model

	}
}

