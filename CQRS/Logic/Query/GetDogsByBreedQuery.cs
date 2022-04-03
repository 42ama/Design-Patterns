﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Logic.Query
{
    /// <summary>
    /// Запрос на получение собак по породе.
    /// </summary>
    public class GetDogsByBreedQuery
    {
        /// <summary>
        /// Порода.
        /// </summary>
        public string Breed { get; set; }
    }
}
