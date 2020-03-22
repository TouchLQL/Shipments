using System;
namespace MultiColorPen.Model
{
	/// <summary>
	/// sys_buttoninfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sys_buttoninfo
	{
		public sys_buttoninfo()
		{}
		#region Model
		private int _id;
		private string _btncode;
		private string _btnname;
		private string _btnclass;
		private string _btnicon;
		private string _btnmethod;
		private int? _btnsort;
		private int? _isenable;
		private DateTime? _createtime;
		private string _createman;
		private DateTime? _updatetime;
		private string _updateman;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string btncode
		{
			set{ _btncode=value;}
			get{return _btncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string btnname
		{
			set{ _btnname=value;}
			get{return _btnname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string btnclass
		{
			set{ _btnclass=value;}
			get{return _btnclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string btnicon
		{
			set{ _btnicon=value;}
			get{return _btnicon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string btnmethod
		{
			set{ _btnmethod=value;}
			get{return _btnmethod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? btnsort
		{
			set{ _btnsort=value;}
			get{return _btnsort;}
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

