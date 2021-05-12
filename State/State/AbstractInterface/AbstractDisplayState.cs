using System;
using System.Collections.Generic;
using State.Context;

namespace State.State.AbstractInterface
{
    /// <summary>
    /// Базовый класс для состояний отображения.
    /// </summary>
    public abstract class AbstractDisplayState : IDisplayState
    {
        /// <summary>
        /// Контекст отображения.
        /// </summary>
        public DisplayContext DisplayContext { get; protected set; }

        /// <summary>
        /// Набор тэгов состояний в которые можно перейти.
        /// </summary>
        public ISet<string> AvalibleTransitionsTags { get; protected set; }

        /// <summary>
        /// Тэг текущего состояния.
        /// </summary>
        public string Tag { get; protected set; } = "abstract";

        /// <param name="displayContext">Контекст отображения.</param>
        /// <param name="avalibleTransitions">Набор тэгов состояний в которые можно перейти.</param>
        public AbstractDisplayState(DisplayContext displayContext, ISet<string> avalibleTransitions)
        {
            DisplayContext = displayContext ?? throw new ArgumentNullException(nameof(displayContext));
            AvalibleTransitionsTags = avalibleTransitions ?? throw new ArgumentNullException(nameof(avalibleTransitions));
        }

        /// <summary>
        /// Вывести текущее состояние в консоль.
        /// </summary>
        public virtual void Render()
        {
            Console.BackgroundColor = DisplayContext.ConsoleBackgroundColor;
            Console.ForegroundColor = DisplayContext.ConsoleForegroundColor;
        }
    }
}
