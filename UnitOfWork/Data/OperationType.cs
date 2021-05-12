using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Data
{
    /// <summary>
    /// Тип операции.
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// Создать.
        /// </summary>
        Create,

        /// <summary>
        /// Обновить.
        /// </summary>
        Update,

        /// <summary>
        /// Удалить.
        /// </summary>
        Delete
    }
}
