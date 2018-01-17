using System.Collections.Generic;

namespace UsherSheat.Service
{
    /// <summary>
    /// Base interface that do basic CRUD operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseInterface<T>
    {
        /// <summary>
        /// Get T object based on id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Get all T object
        /// </summary>
        /// <returns>List of T objects</returns>
        List<T> Gets();

        void Update(int id, T oldObj);
    }
}
