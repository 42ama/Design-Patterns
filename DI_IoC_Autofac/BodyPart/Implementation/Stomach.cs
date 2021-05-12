using DI_IoC_Autofac.BodyPart.Interface;

namespace DI_IoC_Autofac.BodyPart.Implementation
{
    /// <summary>
    /// Орган - желудок.
    /// </summary>
    public class Stomach : IOrgan
    {
        /// <summary>
        /// Смысл использования органа.
        /// </summary>
        public string Usage { get; } = "Пищеварение";
    }
}
