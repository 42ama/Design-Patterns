using Decorator.Component.AbstractInterface;

namespace Decorator.Component
{
	/// <summary>
	/// Иголка, на кончик которой можно что-то положить.
	/// </summary>
	public class Needle : DecoratorBase
	{
		public Needle(IComponent wrappee) : base(wrappee)
		{
			MessageInner = "Я игла, положите мне на кончик что-нибудь.";
		}
	}
}
