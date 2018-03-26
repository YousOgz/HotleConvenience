using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotleConvenience.Dao
{
    public interface IBaseDao<T> where T : class, new()
    {

        /// <summary>
        /// 用于获取指定数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> where);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="pagecount"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        IQueryable<T> GetPaging(Expression<Func<T, bool>> where, int pagecount = 1, int pagesize = 10);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="IsAsc"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IQueryable<T> GetPaging(Expression<Func<T, bool>> where, Expression<Func<T, T>> orderBy, bool IsAsc = false, int pageNum = 1, int pageSize = 10);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        Task<bool> AddAsync(IEnumerable<T> entities, bool isCommit = true);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        Task<bool> AddAsync(T entity, bool isCommit = true);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(T entity, bool isCommit = true);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(IEnumerable<T> entities, bool isCommit = true);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T entities, bool isCommit = true);

        /// <summary>
        /// 统计
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<T, bool>> where);

        /// <summary>
        /// 统计 大数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<double> LongCountAsync(Expression<Func<T, bool>> where);

        /// <summary>
        /// 是否有
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> where);

        /// <summary>
        /// 提交上下文
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveAsync();
    }
}
