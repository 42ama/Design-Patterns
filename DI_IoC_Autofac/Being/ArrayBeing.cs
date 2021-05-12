using System;
using System.Collections.Generic;
using System.Linq;
using DI_IoC_Autofac.BodyPart.Interface;

namespace DI_IoC_Autofac.Being
{
    /// <summary>
    /// Сущность подверженная внедрению массивов.
    /// </summary>
    public class ArrayBeing
    {
        /// <summary>
        /// Список конечностей сущности.
        /// </summary>
        private readonly IEnumerable<ILimb> _limbs;

        public ArrayBeing(IEnumerable<ILimb> limbs)
        {
            _limbs = limbs ?? throw new ArgumentNullException(nameof(limbs));
        }

        /// <summary>
        /// Выводит названия всех конечностей сущности.
        /// </summary>
        /// <returns>Названия всех конечностей сущности.</returns>
        public string GetNamesOfLimbs()
        {
            return string.Join(" ", _limbs.Select(i => i.Name));
        }
    }
}
