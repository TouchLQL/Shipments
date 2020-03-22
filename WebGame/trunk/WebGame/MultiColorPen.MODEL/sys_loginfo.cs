using System;
namespace MultiColorPen.Model
{
	/// <summary>
	/// sys_loginfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sys_loginfo
	{
		public sys_loginfo()
		{}
		#region Model
		private int _id;
		private string _logtype;
		private DateTime? _createtime;
		private string _usercode;
		private string _username;
		private string _ipaddress;
		private string _logcontent;
		private string _datatable;
		private string _dataid;
		private string _dataold;
		private string _datanew;
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
		public string logtype
		{
			set{ _logtype=value;}
			get{return _logtype;}
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
		public string usercode
		{
			set{ _usercode=value;}
			get{return _usercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ipaddress
		{
			set{ _ipaddress=value;}
			get{return _ipaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string logcontent
		{
			set{ _logcontent=value;}
			get{return _logcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string datatable
		{
			set{ _datatable=value;}
			get{return _datatable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dataid
		{
			set{ _dataid=value;}
			get{return _dataid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dataold
		{
			set{ _dataold=value;}
			get{return _dataold;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string datanew
		{
			set{ _datanew=value;}
			get{return _datanew;}
		}
		#endregion Model

	}
}

