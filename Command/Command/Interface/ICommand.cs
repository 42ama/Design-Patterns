

namespace Command.Command.Interface
{
    /// <summary>
    /// Предоставляет интерфейс для исполнения команд.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Выполнить команду.
        /// </summary>
        public void Execute();
    }
}
