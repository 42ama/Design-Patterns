using Decorator.Component.AbstractInterface;

namespace Decorator.Component
{
	/// <summary>
	/// Утка, в которую можно что-то положить.
	/// </summary>
	public class Duck : DecoratorBase
	{
		public Duck(IComponent wrappee) : base(wrappee)
		{
			MessageInner = "Я утка, положите в меня что-нибудь.";
		}
	}
}
