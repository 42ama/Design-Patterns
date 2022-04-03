using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Data;

namespace CQRS.Logic.Command
{
    /// <summary>
    /// Обработчик команды увеличения возраста собаки.
    /// </summary>
    public class IncreaseAgeCommandHandler : AbstractCommandHandler<IncreaseAgeCommand>
    {
        /// <summary>
        /// Конструктор обработчика команды увеличения возраста собаки.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        public IncreaseAgeCommandHandler(Context context) : base(context) { }

        /// <summary>
        /// Увеличивает возраст собаки на основании команды.
        /// </summary>
        /// <param name="command">Команда.</param>
        public override void Handle(IncreaseAgeCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            if (!Context.Dogs.TryGetValue(command.Nickname, out var dog))
            {
                throw new ArgumentException($"Не найдена собака по её кличке: {command.Nickname}.");
            }

            dog.Age += 1;
        }
    }
}
