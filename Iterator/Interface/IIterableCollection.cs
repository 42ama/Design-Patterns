

namespace Iterator.Interface
{
	/// <summary>
	/// Коллекция, поддерживающая итерацию по своим элементам.
	/// </summary>
	/// <typeparam name="T">Тип содержащихся элементов.</typeparam>
	public interface IIterableCollection<T>
	{
		/// <summary>
		/// Получить итератор, используемый для обхода коллекции.
		/// </summary>
		/// <returns>Итератор, используемый для обхода коллекции.</returns>
		IIterator<T> GetIterator();
	}
}
