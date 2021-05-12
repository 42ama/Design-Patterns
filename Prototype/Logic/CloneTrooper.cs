using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Logic
{
    /// <summary>
    /// Клон-Штурмовик.
    /// </summary>
    public class CloneTrooper : IPrototype
    {
        /// <summary>
        /// Клон-Штурмовик.
        /// </summary>
        /// <param name="secret">Секрет в голове клона.</param>
        /// <param name="name">Имя клона.</param>
        /// <param name="equipment">Обмундирование клона.</param>
        public CloneTrooper(string secret, string name, Equipment equipment)
        {
            _secret = secret ?? throw new ArgumentNullException(nameof(secret));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Equipment = equipment ?? throw new ArgumentNullException(nameof(equipment));
        }

        /// <summary>
        /// Секрет в голове клона.
        /// </summary>
        private readonly string _secret;

        /// <summary>
        /// Имя клона.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Обмундирование клона.
        /// </summary>
        public Equipment Equipment { get; set; }

        /// <summary>
        /// Создает полную копию клона.
        /// </summary>
        /// <returns>Полная копия данного клона.</returns>
        public IPrototype Clone()
        {
            return new CloneTrooper(_secret, Name, (Equipment)Equipment.Clone());
        }

        /// <summary>
        /// Рассказывает хранимый секрет.
        /// </summary>
        /// <returns>Хранимый секрет.</returns>
        public string TellASecret()
        {
            return _secret;
        }

        /// <summary>
        /// Сравнивает двух клонов.
        /// </summary>
        /// <param name="obj1">Клон #1</param>
        /// <param name="obj2">Клон #2</param>
        /// <returns>True, если клоны идентичны и false в противном случае.</returns>
        public static bool operator ==(CloneTrooper obj1, CloneTrooper obj2)
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
        /// Проверяет двух клонов на неравенство.
        /// </summary>
        /// <param name="obj1">Клон #1</param>
        /// <param name="obj2">Клон #2</param>
        /// <returns>False, если клоны идентичны и true в противном случае.</returns>
        public static bool operator !=(CloneTrooper obj1, CloneTrooper obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        /// Сравнивает текущего клона с переданным объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения с клоном.</param>
        /// <returns>True, если передан идентичный клон и false в противном случае.</returns>
        public override bool Equals(object obj)
        {
            return obj is CloneTrooper otherClone &&
                   otherClone.Name == Name &&
                   otherClone.TellASecret() == _secret &&
                   otherClone.Equipment == Equipment;
        }
    }
}
