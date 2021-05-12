using System;

namespace Command.Controller
{
    /// <summary>
    /// Контроллер Атаки, производит атаку в локацию
    /// </summary>
    public class AttackController
    {
        /// <summary>
        /// Общее количество Атак в сессии.
        /// </summary>
        private static int _totalAttackCount = 0;

        /// <summary>
        /// Атакует позицию и возвращает информацию - была ли атака успешной.
        /// </summary>
        /// <param name="targetPosition">Локация, в которую будет произведена атака.</param>
        /// <returns>true - если атака успешна, false - в противном случае.</returns>
        public bool AttackToPosition(string targetPosition)
        {
            if (string.IsNullOrEmpty(targetPosition))
            {
                throw new ArgumentNullException(nameof(targetPosition));
            }

            _totalAttackCount++;
            return (targetPosition.Length + _totalAttackCount) % 2 == 0;
        }
    }
}
