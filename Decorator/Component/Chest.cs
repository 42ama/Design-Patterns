using Decorator.Component.AbstractInterface;

namespace Decorator.Component
{
	/// <summary>
	/// Сундук, в который можно что-то положить.
	/// </summary>
	public class Chest : DecoratorBase
	{
		public Chest(IComponent wrappee) : base(wrappee)
		{
			MessageInner = "Я заяц, положите в меня что-нибудь.";
		}
	}
}
