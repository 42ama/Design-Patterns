using System;
using CQRS.Data;

namespace CQRS.Logic.Command
{
    /// <summary>
    /// Абстрактный обработчик команды.
    /// </summary>
    /// <typeparam name="TCommand">Тип команды.</typeparam>
    public abstract class AbstractCommandHandler<TCommand>
    {
        /// <summary>
        /// Контекст данных.
        /// </summary>
        protected Context Context { get; }

        /// <summary>
        /// Конструктор абстрактного обработчика команды.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        protected AbstractCommandHandler(Context context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Обрабатывает команду.
        /// </summary>
        /// <param name="command">Команда.</param>
        public abstract void Handle(TCommand command);
    }
}
