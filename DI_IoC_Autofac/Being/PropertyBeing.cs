using DI_IoC_Autofac.BodyPart.Interface;

namespace DI_IoC_Autofac.Being
{
    /// <summary>
    /// Сущность подверженная Property injection.
    /// </summary>
    public class PropertyBeing
    {
        /// <summary>
        /// Конечность сущности.
        /// </summary>
        public ILimb Limb { get; set; }

        /// <summary>
        /// Мозг сущности.
        /// </summary>
        public IBrain Brain { get; set; }

        /// <summary>
        /// Орган сущности.
        /// </summary>
        public IOrgan Organ { get; set; }
    }
}
