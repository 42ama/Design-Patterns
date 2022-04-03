using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRS.Data;

namespace CQRS.Logic.Query
{
    /// <summary>
    /// Обработчик запроса получение собак по породе.
    /// </summary>
    public class GetDogsByBreedQueryHandler : AbstractQueryHandler<GetDogsByBreedQuery, IEnumerable<Dog>>
    {
        /// <summary>
        /// Конструктор обработчика запроса получение собак по породе.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        public GetDogsByBreedQueryHandler(Context context) : base(context) { }

        /// <summary>
        /// Выполняет запрос на получение собак по породе.
        /// </summary>
        /// <param name="query">Запрос на получения собак по породе.</param>
        /// <returns>Собаки, полученная по породе.</returns>
        public override IEnumerable<Dog> Handle(GetDogsByBreedQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            return Context.Dogs.Values.Where(i => i.Breed == query.Breed);
        }
    }
}
