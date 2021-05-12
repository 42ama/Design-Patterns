using System;

namespace Decorator.Component.AbstractInterface
{
	/// <summary>
	/// Базовый класс декоратора.
	/// </summary>
	public abstract class DecoratorBase : IComponent
	{
		/// <summary>
		/// Обёртываемый компонент.
		/// </summary>
        protected readonly IComponent Wrappee;

		/// <summary>
		/// Сообщение текущего компонента.
		/// </summary>
		protected string MessageInner;

		/// <summary>
		/// Сообщение из текущего компонента плюс сообщение 
		/// из обёртываемого компонента.
		/// </summary>
		public string Message
		{
			get
			{
				return $"{MessageInner}\n{Wrappee.Message}";
			}
		}

		/// <summary>
		/// Создаёт декоратор, обёртывая компонент <c>wrapee</c>.
		/// </summary>
		/// <param name="wrappee">Компонент, обёртываемый декоратором.</param>
		protected DecoratorBase (IComponent wrappee)
		{
			Wrappee = wrappee ?? throw new ArgumentNullException(nameof(wrappee));
        }
	}
}
