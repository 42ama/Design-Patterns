using Decorator.Component.AbstractInterface;

namespace Decorator.Component
{
	/// <summary>
	/// Яйцо, в которое можно что-то положить.
	/// </summary>
	public class Egg : DecoratorBase
	{
		public Egg(IComponent wrappee) : base(wrappee)
		{
			MessageInner = "Я яйцо, положите в меня что-нибудь.";
		}
	}
}
