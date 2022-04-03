using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Logic.Command
{
    /// <summary>
    /// Команда создания собаки.
    /// </summary>
    public class CreateCommand
    {
        /// <summary>
        /// Кличка.
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Порода.
        /// </summary>
        public string Breed { get; set; }
    }
}
