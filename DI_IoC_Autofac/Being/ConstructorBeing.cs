using System;
using DI_IoC_Autofac.BodyPart.Interface;

namespace DI_IoC_Autofac.Being
{
    /// <summary>
    /// Сущность подверженная Constructor injection.
    /// </summary>
    public class ConstructorBeing
    {
        /// <summary>
        /// Сообщение о внутреннем состоянии сущности.
        /// </summary>
        public string ConstructStatus { get; private set; }

        /// <summary>
        /// Создание сущности без частей тела.
        /// </summary>
        public ConstructorBeing()
        {
            ConstructStatus = "I've got no roots, but my home was never on the ground.";
        }

        /// <summary>
        /// Создание сущности с мозгом.
        /// </summary>
        /// <param name="brain">Мозг сущности.</param>
        public ConstructorBeing(IBrain brain)
        {
            if (brain == null) { throw new ArgumentNullException(nameof(brain)); };

            ConstructStatus = $"Мозг говорит: {brain.ProduceThought()}";
        }

        /// <summary>
        /// Создание сущности с мозгом и конечностью.
        /// </summary>
        /// <param name="brain">Мозг сущности.</param>
        /// <param name="limb">Конечность сущности.</param>
        public ConstructorBeing(IBrain brain, ILimb limb) : this(brain)
        {
            if (limb == null) { throw new ArgumentNullException(nameof(limb)); };

            ConstructStatus += $" Конечность называется {limb.Name}.";
        }

        /// <summary>
        /// Создание сущности с мозгом, конечностью и органом.
        /// </summary>
        /// <param name="brain">Мозг сущности.</param>
        /// <param name="limb">Конечность сущности.</param>
        /// <param name="organ">Орган сущности.</param>
        public ConstructorBeing(IBrain brain, ILimb limb, IOrgan organ) : this(brain, limb)
        {
            if (organ == null) { throw new ArgumentNullException(nameof(organ)); };

            ConstructStatus += $" Орган используется с целью {organ.Usage}.";
        }
    }
}
