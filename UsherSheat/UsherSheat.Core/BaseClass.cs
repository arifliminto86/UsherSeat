using System;

namespace UsherSheat.Core
{
    public class BaseClass
    {
        /// <summary>
        /// Id of objects
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Created date
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Default Ctor assigned created to be current date
        /// </summary>
        public BaseClass()
        {
            DateCreated = DateTime.Now;
        }
    }
}
