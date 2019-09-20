using System;
using System.Collections.Generic;

namespace Gemini.IRepositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 根据主键查找一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find(int id);

        /// <summary>
        /// 查找多条符合条件的数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(Func<T, bool> predicate = null);

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// 添加多条数据
        /// </summary>
        /// <param name="list"></param>
        void AddRange(IEnumerable<T> list);

        /// <summary>
        /// 根据主键删除一条数据
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// 根据给定的实体，删掉一条数据
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
    }
}
