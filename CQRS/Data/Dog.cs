using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Logic.Command;

namespace CQRS.Data
{
    /// <summary>
    /// Собака
    /// </summary>
    public class Dog
    {
        /// <summary>
        /// Кличка.
        /// </summary>
        public string Nickname { get; }

        /// <summary>
        /// Возраста.
        /// </summary>
        public int Age { get; set; } = 0;

        /// <summary>
        /// Порода.
        /// </summary>
        public string Breed { get; }

        /// <summary>
        /// Создает собаку на основании данных о ней.
        /// </summary>
        /// <param name="nickname">Кличка.</param>
        /// <param name="breed">Порода.</param>
        /// <param name="age">Возраст.</param>
        public Dog(string nickname, string breed, int age)
        {
            Nickname = nickname ?? throw new ArgumentNullException(nameof(nickname));
            Breed = breed ?? throw new ArgumentNullException(nameof(breed));
            Age = age;
        }

        /// <summary>
        /// Создает собаку на основании команды создания собаки.
        /// </summary>
        /// <param name="createCommand">Команда создания собаки.</param>
        public Dog(CreateCommand createCommand)
        {
            if (createCommand == null) throw new ArgumentNullException(nameof(createCommand));

            Age = createCommand.Age;
            Nickname = createCommand.Nickname;
            Breed = createCommand.Breed;
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
        public override bool Equals(object obj)
        {
            var dog = obj as Dog;
            if (dog == null)
            {
                return base.Equals(obj);
            }

            return dog.Nickname == Nickname &&
                   dog.Breed == Breed &&
                   dog.Age == Age;
        }

        /// <summary>
        /// Служит как базовая хэш-функция для объекта.
        /// </summary>
        /// <returns>Хэш код для текущего объекта.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Nickname, Breed);
        }
    }
}
