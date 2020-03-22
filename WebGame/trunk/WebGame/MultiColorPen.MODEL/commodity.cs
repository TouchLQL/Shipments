/**  版本信息模板在安装目录下，可自行修改。
* commodity.cs
*
* 功 能： N/A
* 类 名： commodity
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2020/03/01 13:53:31   N/A    初版
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
	/// commodity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class commodity
	{
		public commodity()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _number;
		private int? _count;
		private decimal? _price;
		private string _type;
		private string _mark;
		private string _unit;
		private string _is_del;
		private string _special_supply;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
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
		public int? count
		{
			set{ _count=value;}
			get{return _count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mark
		{
			set{ _mark=value;}
			get{return _mark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string unit
		{
			set{ _unit=value;}
			get{return _unit;}
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
		public string special_supply
		{
			set{ _special_supply=value;}
			get{return _special_supply;}
		}
		#endregion Model

	}
}

