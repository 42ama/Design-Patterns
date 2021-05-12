using Command.Command;
using Command.Command.Interface;

namespace Command.Army
{
    /// <summary>
    /// Пехота, подчиняющаяся приказам Лидера.
    /// </summary>
    public class Infantry
    {
        /// <summary>
        /// Команда, которую выполнит Пехота при получении приказа.
        /// </summary>
        public ICommand Command { get; set; } = new StayIdleCommand();

        /// <summary>
        /// Выполнить команду при получении приказа Лидера.
        /// </summary>
        public void OnLeaderOrder()
        {
            Command?.Execute();
        }
    }
}
