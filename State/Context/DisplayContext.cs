using System;
using System.Collections.Generic;
using State.State.AbstractInterface;

namespace State.Context
{
    /// <summary>
    /// Состояние отображения для отрисовки человечка.
    /// </summary>
    public class DisplayContext
    {
        /// <summary>
        /// Символ используемый для отрисовки тела.
        /// </summary>
        public char BodySymbol { get; set; } = '.';

        /// <summary>
        /// Символ используемый для отрисовки глаза.
        /// </summary>
        public char EyeSymbol { get; set; } = '0';

        /// <summary>
        /// Символ используемый для отрисовки плаща.
        /// </summary>
        public char CapeSymbol { get; set; } = '#';

        /// <summary>
        /// Цвет заднего фона консоли.
        /// </summary>
        public ConsoleColor ConsoleBackgroundColor { get; set; } = ConsoleColor.Black;

        /// <summary>
        /// Цвет текста консоли.
        /// </summary>
        public ConsoleColor ConsoleForegroundColor { get; set; } = ConsoleColor.White;

        /// <summary>
        /// Словарь всевозможных состояний отображения.
        /// </summary>
        public IDictionary<string, IDisplayState> DisplayStates { get; } = new Dictionary<string, IDisplayState>();

        /// <summary>
        /// Текущее состояние.
        /// </summary>
        public IDisplayState CurrentDisplayState { get; private set; }

        /// <summary>
        /// Сменить текущее состояние отображения на выбранное.
        /// </summary>
        /// <param name="displayState">Новое состояние отображения.</param>
        public void ChangeState(IDisplayState displayState)
        {
            CurrentDisplayState = displayState ?? throw new ArgumentNullException(nameof(displayState));
        }

        /// <summary>
        /// Выполнить отрисовку текущего состояния.
        /// </summary>
        public void RenderState()
        {
            CurrentDisplayState.Render();
        }

        /// <summary>
        /// Зарегистрировать тег и состояние в контексте.
        /// </summary>
        /// <param name="tag">Тэг состояния.</param>
        /// <param name="state">Состояние.</param>
        public void Add(string tag, IDisplayState state)
        {
            if (string.IsNullOrEmpty(tag))
            {
                throw new ArgumentNullException(nameof(tag));
            }

            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            if (DisplayStates.ContainsKey(tag))
            {
                throw new Exception("Тэг уже зарегистрирован в контексте. Допускается только единичная регистрация.");
            }

            DisplayStates.Add(tag, state);
        }

        /// <summary>
        /// Изменить состояние на зарегистрированное, по тэгу состояния.
        /// </summary>
        /// <param name="tag">Тэг нового состояния.</param>
        /// <returns>true - если тэг найден и состояние изменилось, false - иначе.</returns>
        public bool ChangeStateByTag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                throw new ArgumentNullException(nameof(tag));
            }

            var isTagFound = DisplayStates.TryGetValue(tag, out IDisplayState state);
            if (isTagFound)
            {
                CurrentDisplayState = state;
            }

            return isTagFound;
        }
    }
}
