using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Logic
{
    /// <summary>
    /// Интерфейс Прототипов, отвечающий за клонирование.
    /// </summary>
    public interface IPrototype
    {
        /// <summary>
        /// Создает глубокую копию текущего экземпляра.
        /// </summary>
        /// <returns>Глубокая копия этого экземпляра.</returns>
        IPrototype Clone();
    }
}
