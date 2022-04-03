using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Data;

namespace CQRS.Logic.Command
{
    /// <summary>
    /// Обработчик команды удаления собаки.
    /// </summary>
    public class DeleteCommandHandler : AbstractCommandHandler<DeleteCommand>
    {
        /// <summary>
        /// Конструктор обработчика команды удаления собаки.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        public DeleteCommandHandler(Context context) : base(context) { }

        /// <summary>
        /// Удаляет собаку на основании команды.
        /// </summary>
        /// <param name="command">Команда.</param>
        public override void Handle(DeleteCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            Context.Dogs.Remove(command.Nickname);
        }
    }
}
