using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork.Data;

namespace UnitOfWork.Logic
{
    /// <summary>
    /// Интерфейс для работы с хранилищем данных о собаках.
    /// </summary>
    public interface IDogCRUD
    {
        /// <summary>
        /// Добавить запись о собаке.
        /// </summary>
        /// <param name="dog">Информация о собаке.</param>
        void Create(Dog dog);

        /// <summary>
        /// Прочитать информацию о собаке.
        /// </summary>
        /// <param name="dogId">Id собаки.</param>
        /// <returns>Информация о собаке.</returns>
        Dog Read(Guid dogId);

        /// <summary>
        /// Обновляет информацию о собаке.
        /// </summary>
        /// <param name="dogId">Id собаки.</param>
        /// <param name="dog">Новая информация о собаке.</param>
        void Update(Guid dogId, Dog dog);

        /// <summary>
        /// Удаляет информацию о собаке.
        /// </summary>
        /// <param name="dogId">Id собаки.</param>
        void Delete(Guid dogId);
    }
}
