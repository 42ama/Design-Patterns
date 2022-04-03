using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Logic.Query
{
    /// <summary>
    /// Запрос на получение собаки по кличке.
    /// </summary>
    public class GetDogByNicknameQuery
    { 
        /// <summary>
        /// Кличка.
        /// </summary>
        public string Nickname { get; set; }
    }
}
