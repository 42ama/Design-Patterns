using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Data
{
    /// <summary>
    /// Контекст данных о питомнике.
    /// </summary>
    public class Context
    {
        /// <summary>
        /// Собаки в питомнике.
        /// </summary>
        public IDictionary<string, Dog> Dogs { get; }

        /// <summary>
        /// Конструктор Контекста на основании информации о собаках.
        /// </summary>
        /// <param name="dogs">Собаки в питомнике.</param>
        public Context(IDictionary<string, Dog> dogs)
        {
            Dogs = dogs ?? throw new ArgumentNullException(nameof(dogs));
        }
    }
}
