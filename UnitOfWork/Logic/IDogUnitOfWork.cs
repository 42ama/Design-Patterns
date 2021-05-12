using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Logic
{
    /// <summary>
    /// Интерфейс для транзакционной работы с хранилищем данных о собаках.
    /// </summary>
    /// <inheritdoc cref="IDogCRUD"/>
    public interface IDogUnitOfWork : IDogCRUD
    {
        /// <summary>
        /// Сохраняет внесенные изменения в хранилище.
        /// </summary>
        void Commit();

        /// <summary>
        /// Очищает список изменений на внесение.
        /// </summary>
        void Rollback();
    }
}
