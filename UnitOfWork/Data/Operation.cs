using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Data
{
    /// <summary>
    /// Операция в Unit of Work.
    /// </summary>
    /// <typeparam name="T">Тип обрабатываемой сущности.</typeparam>
    public class Operation<T>
    {
        /// <summary>
        /// Тип операции.
        /// </summary>
        public OperationType OperationType { get; set; }
        
        /// <summary>
        /// Id сущности.
        /// </summary>
        public Guid EntityId { get; set; }
        
        /// <summary>
        /// Сущность.
        /// </summary>
        public T Entity { get; set; }
    }
}
