using AbstractFactory.Instance;
using AbstractFactory.Instance.Interface;

namespace AbstractFactory.Factory
{
	/// <summary>
	/// Фабрика по созданию членов банды из гетто.
	/// </summary>
	public class GhettoGangMemberFacility : AbstractGangMemberFactory
	{
		/// <summary>
		/// Создаёт фабрику по созданию членов банды из гетто с указанным названием.
		/// </summary>
		/// <param name="factoryName">Название банды</param>
		public GhettoGangMemberFacility(string factoryName) : base(factoryName)
        { }

		/// <summary>
		/// Создать стрелка банды из гетто.
		/// </summary>
		/// <returns>Стрелок банды из гетто.</returns>
		public override IShooter CreateShooter()
		{
			return new GhettoShooter("Карл");
		}

		/// <summary>
		/// Создать снайпера банды из гетто.
		/// </summary>
		/// <returns>Снайпер банды из гетто.</returns>
		public override ISniper CreateSniper()
		{
			return new GhettoSniper("Мелвин");
		}
	}
}
