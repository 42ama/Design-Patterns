using Decorator.Component.AbstractInterface;

namespace Decorator.Component
{
	/// <summary>
	/// Океан, в котором можно что-то разместить.
	/// </summary>
	public class Ocean : DecoratorBase
	{
		public Ocean(IComponent wrappee) : base(wrappee)
		{
			MessageInner = "Я океан, разместите во мне что-нибудь.";
		}
	}
}
