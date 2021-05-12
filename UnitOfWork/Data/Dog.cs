using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Data
{
    /// <summary>
    /// Информация о собаке.
    /// </summary>
    public class Dog
    {
        /// <summary>
        /// Id собаки.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Имя собаки.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Порода собаки.
        /// </summary>
        public Breed Breed { get; set; }

        /// <summary>
        /// Пол собаки.
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Возраст собаки.
        /// </summary>
        public int Age { get; set; }

        public Dog() {}

        /// <summary>
        /// Собака.
        /// </summary>
        /// <param name="dog">Собака на основе которой создается собака.</param>
        public Dog(Dog dog)
        {
            if (dog == null)
            {
                throw new ArgumentNullException(nameof(dog));
            }

            Id = dog.Id;
            Name = dog.Name;
            Breed = dog.Breed;
            Sex = dog.Sex;
            Age = dog.Age;
        }

        /// <summary>
        /// Сравнивает две собаки.
        /// </summary>
        /// <param name="obj1">Собака #1</param>
        /// <param name="obj2">Собака #2</param>
        /// <returns>True, если собаки идентичны и false в противном случае.</returns>
        public static bool operator ==(Dog obj1, Dog obj2)
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
        /// Проверяет две собаки на неравенство.
        /// </summary>
        /// <param name="obj1">Собака #1</param>
        /// <param name="obj2">Собака #2</param>
        /// <returns>False, если собаки идентичны и true в противном случае.</returns>
        public static bool operator !=(Dog obj1, Dog obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        /// Сравнивает текущую собаку с переданным объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения с собакой.</param>
        /// <returns>
        /// True, если передана идентичная собака и false в противном случае.
        /// </returns>
        public override bool Equals(object? obj)
        {
            var dog = obj as Dog;
            if (dog == null)
            {
                return base.Equals(obj);
            }

            return dog.Id == Id &&
                   dog.Name == Name &&
                   dog.Breed == Breed &&
                   dog.Sex == Sex &&
                   dog.Age == Age;
        }
    }
}
