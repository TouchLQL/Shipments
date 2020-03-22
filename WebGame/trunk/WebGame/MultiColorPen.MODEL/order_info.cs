/**  版本信息模板在安装目录下，可自行修改。
* order_info.cs
*
* 功 能： N/A
* 类 名： order_info
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2020/03/01 11:25:46   N/A    初版
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
	/// order_info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class order_info
	{
		public order_info()
		{}
		#region Model
		private int _id;
		private string _number;
		private string _customer_name;
		private string _customer_address;
		private string _customer_tel;
		private string _customer_person;
		private int? _customer_id;
		private string _create_time;
		private string _delivery_time;
		private string _status;
		private string _is_del;
		private string _mark;
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
		public string number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string customer_name
		{
			set{ _customer_name=value;}
			get{return _customer_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string customer_address
		{
			set{ _customer_address=value;}
			get{return _customer_address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string customer_tel
		{
			set{ _customer_tel=value;}
			get{return _customer_tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string customer_person
		{
			set{ _customer_person=value;}
			get{return _customer_person;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? customer_id
		{
			set{ _customer_id=value;}
			get{return _customer_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string create_time
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string delivery_time
		{
			set{ _delivery_time=value;}
			get{return _delivery_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string is_del
		{
			set{ _is_del=value;}
			get{return _is_del;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mark
		{
			set{ _mark=value;}
			get{return _mark;}
		}
		#endregion Model

	}
}

