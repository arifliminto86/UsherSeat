using System.Collections.Generic;
using UsherSheat.Core;

namespace UsherSheat.Service
{
    /// <summary>
    /// Base interface that do basic CRUD operations
    /// </summary>
    /// <typeparam name="T">object </typeparam>
    public interface IBaseInterface<T> where T : BaseClass
    {
        /// <summary>
        /// Get T object based on id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>an object</returns>
        T Get(int id);

        /// <summary>
        /// Get all T object
        /// </summary>
        /// <returns>List of T objects</returns>
        List<T> Gets();

        /// <summary>
        /// Update object given an id
        /// </summary>
        /// <param name="id">object Id</param>
        /// <param name="oldObj">old object</param>
        /// <returns>updated object</returns>
        T Update(int id, T oldObj);

        /// <summary>
        /// Create object
        /// </summary>
        /// <param name="newItem">new object</param>
        /// <returns>nothing</returns>
        void Create(T newItem);
    }
}
