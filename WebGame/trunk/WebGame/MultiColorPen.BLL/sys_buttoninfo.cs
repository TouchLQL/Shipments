/*
* sys_buttoninfo.cs
* 2015-05-17
* 功 能： 按钮管理
* 类 名： sys_buttoninfo
*/
using System;
using System.Data;
using System.Collections.Generic;
using MultiColorPen.Model;
namespace MultiColorPen.BLL
{
	/// <summary>
	/// 按钮管理
	/// </summary>
	public partial class sys_buttoninfo
	{
		private readonly MultiColorPen.DAL.sys_buttoninfo dal=new MultiColorPen.DAL.sys_buttoninfo();
		public sys_buttoninfo()
		{}

        /// <summary>
        /// 获取菜单编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxNo()
        {
            return dal.GetMaxNo();
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(MultiColorPen.Model.sys_buttoninfo MODEL)
		{
			return dal.Add(MODEL)?1:0;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MultiColorPen.Model.sys_buttoninfo MODEL)
		{
			return dal.Update(MODEL);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MultiColorPen.Model.sys_buttoninfo GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public MultiColorPen.Model.sys_buttoninfo GetModelByCache(int id)
		{
            return dal.GetModel(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		//public DataSet GetList(int Top,string strWhere,string filedOrder)
		//{
		//	return dal.GetList(Top,strWhere,filedOrder);
		//}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MultiColorPen.Model.sys_buttoninfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MultiColorPen.Model.sys_buttoninfo> DataTableToList(DataTable dt)
		{
			List<MultiColorPen.Model.sys_buttoninfo> modelList = new List<MultiColorPen.Model.sys_buttoninfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				MultiColorPen.Model.sys_buttoninfo MODEL;
				for (int n = 0; n < rowsCount; n++)
				{
					MODEL = dal.DataRowToModel(dt.Rows[n]);
					if (MODEL != null)
					{
						modelList.Add(MODEL);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
	}
}

