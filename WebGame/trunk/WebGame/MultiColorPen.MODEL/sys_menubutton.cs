using System;
namespace MultiColorPen.Model
{
	/// <summary>
	/// sys_menubutton:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sys_menubutton
	{
		public sys_menubutton()
		{}
		#region Model
		private int _id;
		private string _menucode;
		private string _btncode;
		private DateTime? _createtime;
		private string _createman;
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
		public string menucode
		{
			set{ _menucode=value;}
			get{return _menucode;}
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
		#endregion Model

	}
}

