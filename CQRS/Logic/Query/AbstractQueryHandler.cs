using System;
using CQRS.Data;

namespace CQRS.Logic.Query
{
    /// <summary>
    /// Абстрактный обработчик запроса.
    /// </summary>
    /// <typeparam name="TQuery">Тип запроса.</typeparam>
    /// <typeparam name="TResult">Результат запроса.</typeparam>
    public abstract class AbstractQueryHandler<TQuery, TResult>
    {
        /// <summary>
        /// Контекст данных.
        /// </summary>
        protected Context Context { get; }

        /// <summary>
        /// Конструктор абстрактного обработчика запроса.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        protected AbstractQueryHandler(Context context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Выполняет запрос.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <returns>Результат запроса.</returns>
        public abstract TResult Handle(TQuery query);
    }
}
