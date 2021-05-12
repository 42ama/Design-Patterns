using System;

namespace Mediator.Components
{
	/// <summary>
	/// Пассивный компонент, в котором будет проявляться реакция.
	/// </summary>
	public class ImageForm : Component
	{
		/// <summary>
		/// Демонстрирует положительную реакцию.
		/// </summary>
		public void DoSomethingGood()
		{
			Console.WriteLine("(**картинка с котятами**)");
		}

		/// <summary>
		/// Демонстрирует отрицательную реакцию.
		/// </summary>
		public void DoSomethingBad()
		{
			Console.WriteLine("(**картинка с котятами рядом с автоматом**)");
		}
	}
}
