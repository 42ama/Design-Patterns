using System;
using Mediator.Components;
using Mediator.Mediator.Interface;

namespace Mediator.Mediator
{
	/// <summary>
	/// Посредник, связывающий компоненты.
	/// </summary>
	public class Dialog : IMediator
	{
		/// <summary>
		/// Активный компонент - кнопка.
		/// </summary>
		private readonly Component _buttonA;

		/// <summary>
		/// Активный компонент - кнопка.
		/// </summary>
		private readonly Component _buttonB;

		/// <summary>
		/// Компонент, в котором будет проявляться реакция.
		/// </summary>
		private readonly ImageForm _imageFormA;

		/// <summary>
		/// Компонент, в котором будет проявляться реакция.
		/// </summary>
		private readonly ImageForm _imageFormB;

		/// <summary>
		/// Создаём диалог, обрабатывающий передачу сигналов.
		/// между компонентами.
		/// </summary>
		/// <param name="buttonA">
		/// Кнопка, вызывающая положительное поведение на <c>imageFormA</c>.
		/// </param>
		/// <param name="buttonB">
		/// Кнопка, вызывающая отрицательное поведение на <c>imageFormB</c>.
		/// </param>
		/// <param name="imageFormA">
		/// Форма, отображающая положительное сообщение.
		/// </param>
		/// <param name="imageFormB">
		/// Форма, отображающая отрицательное сообщение.
		/// </param>
		public Dialog(Component buttonA, Component buttonB, ImageForm imageFormA, ImageForm imageFormB)
        {
			_buttonA = buttonA ?? throw new ArgumentNullException(nameof(buttonA));
			_buttonB = buttonB ?? throw new ArgumentNullException(nameof(buttonB));
			_imageFormA = imageFormA ?? throw new ArgumentNullException(nameof(imageFormA));
			_imageFormB = imageFormB ?? throw new ArgumentNullException(nameof(imageFormB));

			_buttonA.SetMediator(this);
			_buttonB.SetMediator(this);
			_imageFormA.SetMediator(this);
			_imageFormB.SetMediator(this);
		}

		/// <summary>
		/// Получить уведомление о действии в компоненте.
		/// </summary>
		/// <param name="component">Компонент, в котором произошло действие.</param>
		public void Notify(Component component)
        {
			if (component == null) { throw new ArgumentNullException(nameof(component)); };

            if (ReferenceEquals(component, _buttonA))
			{
				_imageFormA.DoSomethingGood();
			}
			else if (ReferenceEquals(component, _buttonB))
			{
				_imageFormB.DoSomethingBad();
			}
        }
	}
}
