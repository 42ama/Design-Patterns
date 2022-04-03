using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Data;

namespace CQRS.Logic.Command
{
    /// <summary>
    /// Обработчик команды создания собаки.
    /// </summary>
    public class CreateCommandHandler : AbstractCommandHandler<CreateCommand>
    {
        /// <summary>
        /// Конструктор обработчика команды создания собаки.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        public CreateCommandHandler(Context context) : base(context) { }

        /// <summary>
        /// Создает собаку на основании команды.
        /// </summary>
        /// <param name="command">Команда.</param>
        public override void Handle(CreateCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            if (Context.Dogs.ContainsKey(command.Nickname))
            {
                throw new ArgumentException($"Собака с кличкой как у добавляемой ({command.Nickname}), уже существует.");
            }

            Context.Dogs.Add(command.Nickname, new Dog(command));
        }
    }
}
