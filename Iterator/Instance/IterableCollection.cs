using System;
using System.Collections.Generic;
using System.Linq;
using Iterator.Interface;

namespace Iterator.Instance
{
	/// <summary>
	/// Конкретная коллекция, поддерживающая обход своих элементов.
	/// </summary>
	/// <typeparam name="T">Тип элементов коллекции.</typeparam>
	public class IterableCollection<T> : IIterableCollection<T>
	{
		/// <summary>
		/// Хранящаяся коллекция.
		/// </summary>
		private readonly T[] _collection;

		/// <summary>
		/// Длина коллекции.
		/// </summary>
		public int Length
		{
			get
			{
				return _collection.Length;
			}
		}

		/// <summary>
		/// Создаёт итерируемую коллекцию из экземпляра IEnumerable.
		/// </summary>
		/// <param name="collection">Оригинальная коллекция.</param>
		public IterableCollection(IEnumerable<T> collection)
        {
            _collection = collection?.ToArray() ?? throw new NullReferenceException(nameof(collection));
        }

		/// <summary>
		/// Получить элемент по его индексу.
		/// </summary>
		/// <param name="index">Индекс элемента.</param>
		/// <returns>Элемент содержащийся на позиции с значением индекса.</returns>
		public T GetItem(int index)
		{
			return _collection[index];
		}

		/// <summary>
		/// Установить элемент, на месте индекса.
		/// </summary>
		/// <param name="index">Индекс элемента.</param>
		/// <param name="item">
		/// Элемент который будет установлен на позиции с индексом <c>index</c>.
		/// </param>
		public void SetItem(int index, T item)
		{
			_collection[index] = item ?? throw new NullReferenceException(nameof(item));
		}

		/// <summary>
		/// Получить итератор, используемый для обхода коллекции.
		/// </summary>
		/// <returns>Итератор, используемый для обхода коллекции.</returns>
		public IIterator<T> GetIterator()
		{
			return new Iterator<T>(this);
		}
	}
}
