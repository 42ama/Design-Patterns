using System;
using Mediator.Components;
using Mediator.Mediator;

namespace Mediator
{
	class Program
	{
		static void Main(string[] args)
		{
			// Создаём элементы управления.
			var buttonA = new Button();
			var buttonB = new Button();

			// Создаём элементы отображения.
			var imageFormA = new ImageForm();
			var imageFormB = new ImageForm();

			// Связываем их в диалоге.
			var dialog = new Dialog(buttonA, buttonB, imageFormA, imageFormB);

			// Нажимаем на кнопки для получения реакции.
			buttonA.Click();
			buttonB.Click();

			Console.WriteLine("Нажмите клавишу для завершения...");
			Console.ReadKey();
		}
	}
}
