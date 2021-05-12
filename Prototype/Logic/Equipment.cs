using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Logic
{
    /// <summary>
    /// Обмундирование клона-штурмовика.
    /// </summary>
    /// <inheritdoc cref="IPrototype"/>
    public class Equipment : IPrototype
    {
        /// <summary>
        /// Обмундирование клона-штурмовика.
        /// </summary>
        /// <param name="hiddenState">Секретное состояние обмундирования.</param>
        /// <param name="visibleState">Видимое состояние обмундирования.</param>
        public Equipment(string hiddenState, string visibleState)
        {
            _hiddenState = hiddenState ?? throw new ArgumentNullException(nameof(hiddenState));
            VisibleState = visibleState ?? throw new ArgumentNullException(nameof(visibleState));
        }

        /// <summary>
        /// Секретное состояние обмундирования.
        /// </summary>
        private readonly string _hiddenState;

        /// <summary>
        /// Видимое состояние обмундирования.
        /// </summary>
        public string VisibleState { get; set; }

        /// <summary>
        /// Создает полную копию текущего обмундирования.
        /// </summary>
        /// <returns>Полную копия текущего обмундирования.</returns>
        public IPrototype Clone()
        {
            return new Equipment(_hiddenState, VisibleState);
        }

        /// <summary>
        /// Возвращает информацию о секретном состоянии обмундирования.
        /// </summary>
        /// <returns>Секретное состояние обмундирования.</returns>
        public string ShowHiddenState()
        {
            return _hiddenState;
        }

        /// <summary>
        /// Сравнивает два обмундирования.
        /// </summary>
        /// <param name="obj1">Обмундирование #1</param>
        /// <param name="obj2">Обмундирование #2</param>
        /// <returns>True, если обмундирование идентично и false в противном случае.</returns>
        public static bool operator ==(Equipment obj1, Equipment obj2)
        {
            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }
            if (ReferenceEquals(obj1, null))
            {
                return false;
            }
            if (ReferenceEquals(obj2, null))
            {
                return false;
            }

            return obj1.Equals(obj2);
        }

        /// <summary>
        /// Проверяет два обмундирования на неравенство.
        /// </summary>
        /// <param name="obj1">Обмундирование #1</param>
        /// <param name="obj2">Обмундирование #2</param>
        /// <returns>False, если обмундирование идентично и true в противном случае.</returns>
        public static bool operator !=(Equipment obj1, Equipment obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        /// Сравнивает текущее обмундирование с переданным объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения с обмундированием.</param>
        /// <returns>
        /// True, если передано идентичное обмундирование и false в противном случае.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is Equipment otherEquipment &&
                   otherEquipment.VisibleState == VisibleState &&
                   otherEquipment.ShowHiddenState() == _hiddenState;
        }
    }
}
