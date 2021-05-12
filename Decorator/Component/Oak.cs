using Decorator.Component.AbstractInterface;

namespace Decorator.Component
{
	/// <summary>
	/// Дуб, под которым можно что-то зарыть.
	/// </summary>
	public class Oak : DecoratorBase
	{
		public Oak(IComponent wrappee) : base(wrappee)
		{
			MessageInner = "Я дуб, заройте под меня что-нибудь.";
		}
	}
}
