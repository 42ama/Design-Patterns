using DI_IoC_Autofac.BodyPart.Interface;

namespace DI_IoC_Autofac.BodyPart.Implementation
{
    /// <summary>
    /// Конечность - рука.
    /// </summary>
    public class Arm : ILimb
    {
        /// <summary>
        /// Название конечности.
        /// </summary>
        public string Name { get; } = $"{nameof(Arm)}";
    }
}
