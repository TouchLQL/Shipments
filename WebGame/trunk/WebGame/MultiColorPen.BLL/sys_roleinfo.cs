/*
* sys_roleinfo.cs
* 2015-05-17
* 功 能： 角色管理
* 类 名： sys_roleinfo
*/
using System;
using System.Data;
using System.Collections.Generic;
using MultiColorPen.Model;
namespace MultiColorPen.BLL
{
	/// <summary>
	/// 角色管理
	/// </summary>
	public partial class sys_roleinfo
	{
		private readonly MultiColorPen.DAL.sys_roleinfo dal=new MultiColorPen.DAL.sys_roleinfo();
		public sys_roleinfo()
		{}

        /// <summary>
        /// 获取编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxNo()
        {
            return dal.GetMaxNo();
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(MultiColorPen.Model.sys_roleinfo MODEL)
		{
			return dal.Add(MODEL)?1:0;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MultiColorPen.Model.sys_roleinfo MODEL)
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
		public bool Delete(string rolecode)
		{
			
			return dal.Delete(rolecode);
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
		public MultiColorPen.Model.sys_roleinfo GetModel(string rolecode)
		{

            return dal.GetModel(rolecode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public MultiColorPen.Model.sys_roleinfo GetModelByCache(string rolecode)
		{
            return dal.GetModel(rolecode);
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
		public List<MultiColorPen.Model.sys_roleinfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MultiColorPen.Model.sys_roleinfo> DataTableToList(DataTable dt)
		{
			List<MultiColorPen.Model.sys_roleinfo> modelList = new List<MultiColorPen.Model.sys_roleinfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				MultiColorPen.Model.sys_roleinfo MODEL;
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

