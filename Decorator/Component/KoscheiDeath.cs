using Decorator.Component.AbstractInterface;

namespace Decorator.Component
{
	/// <summary>
	/// Смерть Кощея, которую надо спрятать.
	/// </summary>
	public class KoscheiDeath : IComponent
	{
		public string Message { get; } = "Я кощеева смерть, хуже меня нет.";
	}
}
