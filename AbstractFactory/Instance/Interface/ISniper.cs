

namespace AbstractFactory.Instance.Interface
{
	/// <summary>
	/// Снайпер банды.
	/// </summary>
	public interface ISniper : IHumanBeing
	{
		/// <summary>
		/// Занять снайперскую позицию.
		/// </summary>
		/// <returns>Сообщение о статусе занятия позиции.</returns>
		string TakeAim();
	}
}
