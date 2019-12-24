using System.Collections.Generic;

namespace DAL
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Return the list of <typeparamref name="T"/> in this table
        /// </summary>
        List<T> GetList();

        /// <summary>
        /// Return item through a specific ID
        /// </summary>
        /// <param name="id">ID of object</param>
        T GetItem(int? id);

        /// <summary>
        /// Create new record of this object in table
        /// </summary>
        /// <param name="item">new object</param>
        void Create(T item);

        /// <summary>
        /// Update a selected object in the table
        /// </summary>
        /// <param name="item">object that needs updated</param>
        void Update(T item);

        /// <summary>
        /// Delete record of this object in the table
        /// </summary>
        /// <param name="id">ID of this object</param>
        void Delete(int id);

        /// <summary>
        /// return the last added record's ID
        /// </summary>
        /// <returns></returns>
        T GetLastRecord();

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns></returns>
        bool IsSaved();
    }
}
