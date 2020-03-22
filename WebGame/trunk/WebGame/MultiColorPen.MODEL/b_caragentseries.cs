/**  版本信息模板在安装目录下，可自行修改。
* b_caragentseries.cs
*
* 功 能： N/A
* 类 名： b_caragentseries
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/9/22 17:45:51   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace MultiColorPen.Model
{
	/// <summary>
	/// b_caragentseries:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class b_caragentseries
	{
		public b_caragentseries()
		{}
		#region Model
		private int _id;
		private string _caragentcode;
		private string _seriescode;
		private string _brandcode;
		private string _brandname;
		private int? _isenable;
		private int? _sort;
		private string _remark;
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
		public string caragentcode
		{
			set{ _caragentcode=value;}
			get{return _caragentcode;}
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

