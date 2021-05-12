

namespace Iterator.Interface
{
	/// <summary>
	/// Итератор, используемый для обхода коллекции.
	/// </summary>
	/// <typeparam name="T">Тип элементов в коллекции.</typeparam>
	public interface IIterator<out T>
	{
		/// <summary>
		/// Текущий выбранный элемент.
		/// </summary>
		T Current { get; }

		/// <summary>
		/// Выбрать следующий элемент в коллекции.
		/// </summary>
		/// <returns>
		/// true - если, следующий элемент был выбран, 
		/// false - если текущий элемент последний в коллекции.
		/// </returns>
		bool MoveNext();

		/// <summary>
		/// Выбирает первый элемент из коллекции.
		/// </summary>
		void Reset();
	}
}
