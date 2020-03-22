/**  版本信息模板在安装目录下，可自行修改。
* order_detail.cs
*
* 功 能： N/A
* 类 名： order_detail
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
	/// order_detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class order_detail
	{
		public order_detail()
		{}
		#region Model
		private int _id;
		private int? _commodity_id;
		private string _commodity_name;
		private decimal? _commodity_price;
		private string _commodity_unit;
		private int? _commodity_count;
		private string _order_number;
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
		public int? commodity_id
		{
			set{ _commodity_id=value;}
			get{return _commodity_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string commodity_name
		{
			set{ _commodity_name=value;}
			get{return _commodity_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? commodity_price
		{
			set{ _commodity_price=value;}
			get{return _commodity_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string commodity_unit
		{
			set{ _commodity_unit=value;}
			get{return _commodity_unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? commodity_count
		{
			set{ _commodity_count=value;}
			get{return _commodity_count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string order_number
		{
			set{ _order_number=value;}
			get{return _order_number;}
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

