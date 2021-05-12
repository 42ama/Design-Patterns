using System;
using Iterator.Interface;

namespace Iterator.Instance
{
	/// <summary>
	/// Конкретный итератор, используемый для последовательного обхода коллекции.
	/// </summary>
	/// <typeparam name="T">Тип элементов в коллекции.</typeparam>
	public class Iterator<T> : IIterator<T>
	{
		/// <summary>
		/// Коллекция, которую необходимо обойти.
		/// </summary>
		private readonly IterableCollection<T> _collection;

		/// <summary>
		/// Индекс текущего элемента.
		/// </summary>
		private int _index;

		/// <summary>
		/// Текущий выбранный элемент.
		/// </summary>
		public T Current
		{
			get
			{
				return _collection.GetItem(_index);
			}
		}

		/// <summary>
		/// Создаёт итератор для обхода коллекции <c>collection</c>.
		/// </summary>
		/// <param name="collection">Коллекция, для которой создаётся итератор.</param>
		public Iterator(IterableCollection<T> collection)
		{
			_collection = collection ?? throw new NullReferenceException(nameof(collection));
			_index = 0;
		}

		/// <summary>
		/// Выбрать следующий элемент в коллекции.
		/// </summary>
		/// <returns>
		/// true - если, следующий элемент был выбран, 
		/// false - если текущий элемент последний в коллекции.
		/// </returns>
		public bool MoveNext()
		{
			if (_index + 1 < _collection.Length)
			{
				_index++;
				return true;
			}

			return false;
		}

		/// <summary>
		/// Выбирает первый элемент из коллекции.
		/// </summary>
		public void Reset()
		{
			_index = 0;
		}
	}
}
