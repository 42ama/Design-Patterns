using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Logic.Command
{
    /// <summary>
    /// Команда на удаление собаки.
    /// </summary>
    public class DeleteCommand
    {
        /// <summary>
        /// Кличка.
        /// </summary>
        public string Nickname { get; set; }
    }
}
