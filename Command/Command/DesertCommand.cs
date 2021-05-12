using System;
using Command.Command.Interface;

namespace Command.Command
{
    /// <summary>
    /// Команда - Дезертировать в локацию.
    /// </summary>
    public class DesertCommand : ICommand
    {
        /// <summary>
        /// Локация, в которую будет произведено дезертирование.
        /// </summary>
        private readonly string _desertLocation;

        /// <param name="desertLocation">Локация, в которую будет произведено дезертирование.</param>
        public DesertCommand(string desertLocation)
        {
            if (string.IsNullOrEmpty(desertLocation))
            {
                throw new ArgumentNullException(nameof(desertLocation));
            }

            _desertLocation = desertLocation;
        }

        public void Execute()
        {
            Console.WriteLine($"С криками дезертирует в сторону {_desertLocation}.");
        }
    }
}
