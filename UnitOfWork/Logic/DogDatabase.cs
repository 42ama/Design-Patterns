using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork.Data;

namespace UnitOfWork.Logic
{
    /// <summary>
    /// База данных о собаках
    /// </summary>
    /// <inheritdoc cref="IDogCRUD"/>
    public class DogDatabase : IDogCRUD
    {
        /// <summary>
        /// Хранилище данных о собаках.
        /// </summary>
        private readonly Dictionary<Guid, Dog> _data = new Dictionary<Guid, Dog>();

        public DogDatabase() { }

        /// <summary>
        /// База данных о собаках
        /// </summary>
        /// <param name="data">Информация о собаках.</param>
        public DogDatabase(IEnumerable<Dog> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }


            foreach (var dog in data)
            {
                _data.Add(dog.Id, dog);
            }
        }

        /// <summary>
        /// Добавить запись о собаке.
        /// </summary>
        /// <param name="dog">Информация о собаке.</param>
        public void Create(Dog dog)
        {
            if (dog == null)
            {
                throw new ArgumentNullException(nameof(dog));
            }

            if (_data.ContainsKey(dog.Id))
            {
                throw new Exception("Dog with this Id already exists.");
            }


            _data.Add(dog.Id, dog);
        }

        /// <summary>
        /// Прочитать информацию о собаке.
        /// </summary>
        /// <param name="dogId">Id собаки.</param>
        /// <returns>Информация о собаке.</returns>
        public Dog Read(Guid dogId)
        {
            if (dogId == Guid.Empty)
            {
                throw new ArgumentException($"Forbidden to pass empty Id as {nameof(dogId)}.", nameof(dogId));
            }


            _data.TryGetValue(dogId, out var dog);

            return dog;
        }

        /// <summary>
        /// Обновляет информацию о собаке.
        /// </summary>
        /// <param name="dogId">Id собаки.</param>
        /// <param name="dog">Новая информация о собаке.</param>
        public void Update(Guid dogId, Dog dog)
        {
            if (dog == null)
            {
                throw new ArgumentNullException(nameof(dog));
            }

            if (dogId == Guid.Empty)
            {
                throw new ArgumentException($"Forbidden to pass empty Id as {nameof(dogId)}.", nameof(dogId));
            }

            if (!_data.ContainsKey(dogId))
            {
                throw new Exception("Dog with this Id is not found.");
            }


            if (dog.Id != dogId)
            {
                dog.Id = dogId;
            }

            _data[dogId] = dog;
        }

        /// <summary>
        /// Удаляет информацию о собаке.
        /// </summary>
        /// <param name="dogId">Id собаки.</param>
        public void Delete(Guid dogId)
        {
            if (dogId == Guid.Empty)
            {
                throw new ArgumentException($"Forbidden to pass empty Id as {nameof(dogId)}.", nameof(dogId));
            }

            if (!_data.ContainsKey(dogId))
            {
                throw new Exception("Dog with this Id is not found.");
            }
            

            _data.Remove(dogId);
        }
    }
}
