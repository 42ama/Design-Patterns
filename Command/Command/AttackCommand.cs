using System;
using Command.Command.Interface;
using Command.Controller;

namespace Command.Command
{
    /// <summary>
    /// Команда - Атаковать в локацию.
    /// </summary>
    public class AttackCommand : ICommand
    {
        /// <summary>
        /// Контроллер Атаки, которому будет передан вызов команды.
        /// </summary>
        private readonly AttackController _attackController;

        /// <summary>
        /// Локация, которая будет атакована.
        /// </summary>
        private readonly string _targetPosition;

        /// <param name="attackController">Контроллер Атаки, которому будет передан вызов команды.</param>
        /// <param name="targetPosition">Локация, которая будет атакована.</param>
        public AttackCommand(AttackController attackController, string targetPosition)
        {
            if (string.IsNullOrEmpty(targetPosition))
            {
                throw new ArgumentNullException(nameof(targetPosition));
            }

            _attackController = attackController ?? throw new ArgumentNullException(nameof(attackController));
            _targetPosition = targetPosition;
        }

        public void Execute()
        {
            var attackResult = _attackController.AttackToPosition(_targetPosition);
            var message = attackResult
                ? $"Атака на {_targetPosition} была произведена успешно!"
                : $"Атака на {_targetPosition} провалилась...";

            Console.WriteLine(message);
        }
    }
}
