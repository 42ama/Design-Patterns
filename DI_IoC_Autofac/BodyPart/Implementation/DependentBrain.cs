using DI_IoC_Autofac.BodyPart.Interface;
using System;

namespace DI_IoC_Autofac.BodyPart.Implementation
{
    /// <summary>
    /// Мозг зависимый от своей конечности.
    /// </summary>
    public class DependentBrain : IBrain
    {
        /// <summary>
        /// Конечность прикрепленная к мозгу.
        /// </summary>
        private readonly ILimb _limb;

        public DependentBrain(ILimb limb)
        {
            _limb = limb ?? throw new ArgumentNullException(nameof(limb));
        }

        /// <summary>
        /// Возвращает мысль о своей конечности.
        /// </summary>
        /// <returns>Мысль о своей конечности.</returns>
        public string ProduceThought()
        {
            return $"I got pretty looking {_limb.Name}!";
        }
    }
}
