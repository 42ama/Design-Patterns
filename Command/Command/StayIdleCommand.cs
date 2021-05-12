using System;
using Command.Command.Interface;

namespace Command.Command
{
    /// <summary>
    /// Команда - Остаться на месте.
    /// </summary>
    public class StayIdleCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Сохраняют боевое построение на месте.");
        }
    }
}
