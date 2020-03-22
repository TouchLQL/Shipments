using System;
namespace MultiColorPen.Model
{
	/// <summary>
	/// b_msg:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class b_msg
	{
		public b_msg()
		{}
		#region Model
		private int _id;
		private string _msgtypecode;
		private string _msgtypename;
		private string _msgcode;
		private string _title;
		private string _detail;
		private string _url;
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
		public string msgtypecode
		{
			set{ _msgtypecode=value;}
			get{return _msgtypecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string msgtypename
		{
			set{ _msgtypename=value;}
			get{return _msgtypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string msgcode
		{
			set{ _msgcode=value;}
			get{return _msgcode;}
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

