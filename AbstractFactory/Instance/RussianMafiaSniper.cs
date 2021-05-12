using System;
using AbstractFactory.Instance.Interface;

namespace AbstractFactory.Instance
{
	/// <summary>
	/// Снайпер русской мафии.
	/// </summary>
	public class RussianMafiaSniper : ISniper
	{
		/// <summary>
		/// Имя снайпера русской мафии.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Создаёт снайпера русской мафии с указанным именем.
		/// </summary>
		/// <param name="name">Имя снайпера.</param>
		public RussianMafiaSniper(string name)
		{
			Name = !string.IsNullOrEmpty(name)
				? name
				: throw new ArgumentException("Нельзя создать снайпера с пустым именем.", nameof(name));
		}

		/// <summary>
		/// Занять снайперскую позицию.
		/// </summary>
		/// <returns>Сообщение о статусе занятия позиции.</returns>
		public string TakeAim()
		{
			return "Так точно, на позиции.";
		}
	}
}
