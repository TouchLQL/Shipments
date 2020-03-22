using System;
namespace MultiColorPen.Model
{
	/// <summary>
	/// sys_menuinfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sys_menuinfo
	{
		public sys_menuinfo()
		{}
		#region Model
		private int _id;
		private string _pmenucode;
		private string _menucode;
		private string _menuname;
		private string _linkaddress;
		private string _menuicon;
		private int? _menusort;
		private int? _isenable;
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
		public string pmenucode
		{
			set{ _pmenucode=value;}
			get{return _pmenucode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string menucode
		{
			set{ _menucode=value;}
			get{return _menucode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string menuname
		{
			set{ _menuname=value;}
			get{return _menuname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string linkaddress
		{
			set{ _linkaddress=value;}
			get{return _linkaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string menuicon
		{
			set{ _menuicon=value;}
			get{return _menuicon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? menusort
		{
			set{ _menusort=value;}
			get{return _menusort;}
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

