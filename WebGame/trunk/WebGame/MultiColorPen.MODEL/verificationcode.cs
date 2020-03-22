using System;
namespace MultiColorPen.Model
{
	/// <summary>
	/// verificationcode:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class verificationcode
	{
		public verificationcode()
		{}
		#region Model
		private int _id;
		private string _mobile;
		private string _code;
		private DateTime? _gettime;
		private DateTime? _outtime;
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
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? gettime
		{
			set{ _gettime=value;}
			get{return _gettime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? outtime
		{
			set{ _outtime=value;}
			get{return _outtime;}
		}
		#endregion Model

	}
}

