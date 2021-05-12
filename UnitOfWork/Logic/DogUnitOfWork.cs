using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitOfWork.Data;

namespace UnitOfWork.Logic
{
    /// <summary>
    /// Транзакционная работа с хранилищем данных о собаках.
    /// </summary>
    /// <inheritdoc cref="IDogUnitOfWork"/>
    public class DogUnitOfWork : IDogUnitOfWork
    {
        /// <summary>
        /// Экземпляр базы данных.
        /// </summary>
        private readonly DogDatabase _database;

        /// <summary>
        /// Список текущих операций для исполнения.
        /// </summary>
        private List<Operation<Dog>> _operations { get; set; } = new List<Operation<Dog>>();

        /// <summary>
        /// Транзакционная работа с хранилищем данных о собаках.
        /// </summary>
        /// <param name="database">База данных о собаках.</param>
        public DogUnitOfWork(DogDatabase database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
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


            _operations.Add(new Operation<Dog>
            {
                OperationType = OperationType.Create,
                Entity =  dog,
                EntityId = dog.Id
            });
        }

        /// <summary>
        /// Прочитать информацию о собаке, с учётом ожидаемых изменений.
        /// </summary>
        /// <param name="dogId">Id собаки.</param>
        /// <returns>Информация о собаке, с учётом ожидаемых изменений.</returns>
        public Dog Read(Guid dogId)
        {
            if (dogId == Guid.Empty)
            {
                throw new ArgumentException($"Forbidden to pass empty Id as {nameof(dogId)}.", nameof(dogId));
            }


            var dog = _database.Read(dogId);

            var operations = _operations.Where(operation => operation.EntityId == dogId);
            foreach (var operation in operations)
            {
                switch (operation.OperationType)
                {

                    case OperationType.Create:
                    case OperationType.Update:
                        dog = operation.Entity;
                        break;
                    case OperationType.Delete:
                        dog = null;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

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


            _operations.Add(new Operation<Dog>
            {
                OperationType = OperationType.Update,
                Entity = dog,
                EntityId = dog.Id
            });
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


            _operations.Add(new Operation<Dog>
            {
                OperationType = OperationType.Delete,
                EntityId = dogId
            });
        }

        /// <summary>
        /// Сохраняет внесенные изменения в хранилище.
        /// </summary>
        public void Commit()
        {
            foreach (var operation in _operations)
            {
                switch (operation.OperationType)
                {
                    case OperationType.Create:
                        _database.Create(operation.Entity);
                        break;
                    case OperationType.Update:
                        _database.Update(operation.EntityId, operation.Entity);
                        break;
                    case OperationType.Delete:
                        _database.Delete(operation.EntityId);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            Rollback();
        }

        /// <summary>
        /// Очищает список изменений на внесение.
        /// </summary>
        public void Rollback()
        {
            _operations = new List<Operation<Dog>>();
        }
    }
}
