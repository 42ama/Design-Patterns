

namespace DI_IoC_Autofac.BodyPart.Interface
{
    /// <summary>
    /// Интерфейс объединяющий все органы.
    /// </summary>
    public interface IOrgan
    {
        /// <summary>
        /// Смысл использования органа.
        /// </summary>
        public string Usage { get; }
    }
}
