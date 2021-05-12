using DI_IoC_Autofac.BodyPart.Interface;

namespace DI_IoC_Autofac.BodyPart.Implementation
{
    /// <summary>
    /// Конечность - хвост.
    /// </summary>
    public class Tail : ILimb
    {
        /// <summary>
        /// Название конечности.
        /// </summary>
        public string Name { get; } = $"{nameof(Tail)}";
    }
}
