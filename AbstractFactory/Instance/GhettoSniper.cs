using System;
using AbstractFactory.Instance.Interface;

namespace AbstractFactory.Instance
{
	/// <summary>
	/// Снайпер банды из гетто.
	/// </summary>
	public class GhettoSniper : ISniper
	{
		/// <summary>
		/// Имя снайпера из гетто.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Создаёт снайпера банды из гетто.
		/// </summary>
		/// <param name="name">Имя снайпера.</param>
		public GhettoSniper(string name)
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
			return "Хоуми, у меня нет винтовки, но я готов кидаться камнями.";
		}
	}
}
