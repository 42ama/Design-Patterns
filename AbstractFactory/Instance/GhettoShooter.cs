using System;
using AbstractFactory.Instance.Interface;

namespace AbstractFactory.Instance
{
	/// <summary>
	/// Стрелок банды из гетто.
	/// </summary>
	public class GhettoShooter : IShooter
	{
		/// <summary>
		/// Имя стрелка из гетто.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Текущие оружие стрелка из гетто.
		/// </summary>
		public string CurrentGun { get; } = "Узи";

		/// <summary>
		/// Создаёт стрелка банды из гетто с указанным именем.
		/// </summary>
		/// <param name="name">Имя стрелка.</param>
		public GhettoShooter(string name)
		{
			Name = !string.IsNullOrEmpty(name)
				? name
				: throw new ArgumentException("Нельзя создать стрелка с пустым именем.", nameof(name));
        }

		/// <summary>
		/// Попытаться сменить оружие стрелку.
		/// </summary>
		public void ChangeGun()
		{
			Console.WriteLine("У меня нету другого оружия, fool!");
		}
	}
}
