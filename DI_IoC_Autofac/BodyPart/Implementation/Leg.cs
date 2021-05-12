using DI_IoC_Autofac.BodyPart.Interface;

namespace DI_IoC_Autofac.BodyPart.Implementation
{
    /// <summary>
    /// Конечность - нога.
    /// </summary>
    public class Leg : ILimb
    {
        /// <summary>
        /// Название конечности.
        /// </summary>
        public string Name { get; } = $"{nameof(Leg)}";
    }
}
