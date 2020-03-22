using System;
namespace MultiColorPen.Model
{
	/// <summary>
	/// b_msgattachment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class b_msgattachment
	{
		public b_msgattachment()
		{}
		#region Model
		private int _id;
		private string _msgcode;
		private string _name;
		private string _filename;
		private int? _downtimes;
		private int? _isenable;
		private int? _sort;
		private DateTime? _createtime;
		private string _createman;
		private int? _isdelete;
		private DateTime? _deletetime;
		private string _deleteman;
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
		public string msgcode
		{
			set{ _msgcode=value;}
			get{return _msgcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string filename
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? downtimes
		{
			set{ _downtimes=value;}
			get{return _downtimes;}
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
		public int? isdelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? deletetime
		{
			set{ _deletetime=value;}
			get{return _deletetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string deleteman
		{
			set{ _deleteman=value;}
			get{return _deleteman;}
		}
		#endregion Model

	}
}

