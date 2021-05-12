using System;
using AbstractFactory.Instance.Interface;

namespace AbstractFactory.Instance
{
	/// <summary>
	/// Стрелок русской мафии.
	/// </summary>
	public class RussianMafiaShooter : IShooter
	{
		/// <summary>
		/// Имя стрелка русской мафии.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Текущие оружие стрелка из русской мафии.
		/// </summary>
		public string CurrentGun { get; private set; } = "Дробовик.";

		/// <summary>
		/// Создаёт стрелка русской мафии с указанным именем.
		/// </summary>
		/// <param name="name">Имя стрелка.</param>
		public RussianMafiaShooter(string name)
		{
			Name = !string.IsNullOrEmpty(name)
				? name
				: throw new ArgumentException("Нельзя создать стрелка с пустым именем.", nameof(name));
		}

		/// <summary>
		/// Сменить оружие стрелку.
		/// </summary>
		public void ChangeGun()
		{
			CurrentGun += " ЕЩЁ ОДИН ДРОБОВИК!";
		}
	}
}
