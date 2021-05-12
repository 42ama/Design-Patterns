using Decorator.Component.AbstractInterface;

namespace Decorator.Component
{
	/// <summary>
	/// Остров, на котором можно что-то разместить.
	/// </summary>
	public class Island : DecoratorBase
	{
		public Island(IComponent wrappee) : base(wrappee)
		{
			MessageInner = "Я остров, разместите на мне что-нибудь.";
		}
	}
}
