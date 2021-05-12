using Decorator.Component.AbstractInterface;

namespace Decorator.Component
{
	/// <summary>
	/// Заяц, в которого можно что-то положить.
	/// </summary>
	public class Rabbit : DecoratorBase
	{
		public Rabbit(IComponent wrappee) : base(wrappee)
		{
			MessageInner = "Я заяц, положите в меня что-нибудь.";
		}
	}
}
