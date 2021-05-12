

namespace AbstractFactory.Instance.Interface
{
	/// <summary>
	/// Стрелок банды.
	/// </summary>
	public interface IShooter : IHumanBeing
	{
		/// <summary>
		/// Текущие оружие в руках стрелка.
		/// </summary>
		string CurrentGun { get; }

		/// <summary>
		/// Сменить оружие на другое.
		/// </summary>
		void ChangeGun();
	}
}
