using System.Collections.Generic;
using State.Context;

namespace State.State.AbstractInterface
{
    /// <summary>
    /// Интерфейс состояний отображений.
    /// </summary>
    public interface IDisplayState
    {
        /// <summary>
        /// Контекст отображения.
        /// </summary>
        DisplayContext DisplayContext { get; }

        /// <summary>
        /// Набор тэгов состояний в которые можно перейти.
        /// </summary>
        ISet<string> AvalibleTransitionsTags { get; }

        /// <summary>
        /// Тэг текущего состояния.
        /// </summary>
        string Tag { get; }

        /// <summary>
        /// Отобразить текущее состояние.
        /// </summary>
        public void Render();
    }
}
