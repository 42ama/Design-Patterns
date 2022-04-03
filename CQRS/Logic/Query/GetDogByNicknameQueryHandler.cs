using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Data;
using Exception = System.Exception;

namespace CQRS.Logic.Query
{
    /// <summary>
    /// Обработчик запроса получения собаки по кличке.
    /// </summary>
    public class GetDogByNicknameQueryHandler : AbstractQueryHandler<GetDogByNicknameQuery, Dog>
    {
        /// <summary>
        /// Конструктор обработчика запроса получения собаки по кличке.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        public GetDogByNicknameQueryHandler(Context context) : base(context) { }

        /// <summary>
        /// Выполняет запрос на получение собаки по кличке.
        /// </summary>
        /// <param name="query">Запрос на получение собаки по кличке.</param>
        /// <returns>Собака, полученная по кличке.</returns>
        public override Dog Handle(GetDogByNicknameQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            if (Context.Dogs.TryGetValue(query.Nickname, out var dog))
            {
                return dog;
            }

            throw new ArgumentException($"Не найдена собака по её кличке: {query.Nickname}.");
        }
    }
}
