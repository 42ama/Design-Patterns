using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Data;

namespace CQRS.Logic.Query
{
    /// <summary>
    /// Обработчик запроса получение собак.
    /// </summary>
    public class GetDogsQueryHandler : AbstractQueryHandler<GetDogsQuery, IEnumerable<Dog>>
    {
        /// <summary>
        /// Конструктор обработчика запроса получение собак.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        public GetDogsQueryHandler(Context context) : base(context) { }

        /// <summary>
        /// Выполняет запрос на получение собак.
        /// </summary>
        /// <param name="query">Запрос на получения собак.</param>
        /// <returns>Собаки.</returns>
        public override IEnumerable<Dog> Handle(GetDogsQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            return Context.Dogs.Values;
        }
    }
}
