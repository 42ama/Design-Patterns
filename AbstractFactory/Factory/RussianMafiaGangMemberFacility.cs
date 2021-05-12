using AbstractFactory.Instance;
using AbstractFactory.Instance.Interface;

namespace AbstractFactory.Factory
{
	/// <summary>
	/// Фабрика по созданию членов русской мафии.
	/// </summary>
	public class RussianMafiaGangMemberFacility : AbstractGangMemberFactory
	{
        /// <summary>
        /// Типичное имя члена мафии, используется
        /// для формирования имени участников.
        /// </summary>
        private const string GenericName = "Иван";

        /// <summary>
		/// Количество созданных участников мафии, используется
		/// для формирования имени участников.
		/// </summary>
		private static int _memberCount = 0;

		/// <summary>
		/// Фабрика по созданию членов русской мафии с указанным названием.
		/// </summary>
		/// <param name="factoryName">Название мафии.</param>
		public RussianMafiaGangMemberFacility(string factoryName) : base(factoryName)
        { }

		/// <summary>
		/// Создать стрелка русской мафии.
		/// </summary>
		/// <returns>Стрелок русской мафии.</returns>
		public override IShooter CreateShooter()
		{
			_memberCount++;
			return new RussianMafiaShooter(GenericName + $" №{_memberCount}");
		}

		/// <summary>
		/// Создать снайпера русской мафии.
		/// </summary>
		/// <returns>Снайпер русской мафии.</returns>
		public override ISniper CreateSniper()
		{
			_memberCount++;
			return new RussianMafiaSniper(GenericName + $" №{_memberCount}");
		}
	}
}
