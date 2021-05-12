using System;
using AbstractFactory.Instance.Interface;

namespace AbstractFactory.Factory
{
	/// <summary>
	/// Абстрактная фабрика по созданию членов конкретной банды.
	/// </summary>
	public abstract class AbstractGangMemberFactory
	{
		/// <summary>
		/// Название банды.
		/// </summary>
		public string GangName { get; protected set; }

        protected AbstractGangMemberFactory(string factoryName)
        {
			GangName = !string.IsNullOrEmpty(factoryName)
				? factoryName
				: throw new ArgumentException("Нельзя установить фабрике пустое название.", nameof(factoryName));
        }

		/// <summary>
		/// Создать стрелка банды.
		/// </summary>
		/// <returns>Стрелок банды.</returns>
		public abstract IShooter CreateShooter();

		/// <summary>
		/// Создать снайпера банды.
		/// </summary>
		/// <returns>Снайпер банды.</returns>
		public abstract ISniper CreateSniper();
	}
}
