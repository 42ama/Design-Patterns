using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Logic.Command
{
    /// <summary>
    /// Команда на увеличение возраста собаки.
    /// </summary>
    public class IncreaseAgeCommand
    {
        /// <summary>
        /// Кличка.
        /// </summary>
        public string Nickname { get; set; }
    }
}
