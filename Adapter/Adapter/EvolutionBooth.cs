using System;
using Adapter.Adaptee;
using Adapter.Adaptee.Interface;

namespace Adapter.Adapter
{
	/// <summary>
	/// Адаптирует низшее существо в высшее.
	/// </summary>
	public class EvolutionBooth
	{
		/// <summary>
		/// Адаптирует низшее существо в высшее.
		/// </summary>
		/// <param name="adaptee">Низшее существо, которое будет адаптированно.</param>
		/// <returns>Высшее существо полученное из низшего.</returns>
		public IHigherForm Adapt(ILesserForm adaptee)
		{
			if (adaptee == null) { throw new NullReferenceException(nameof(adaptee)); };

			// Преодолеваем трудности, пока они имеются.
			var evolutionStages = 0;
			while (adaptee.DifficultyCount > 0)
			{
				var adapteeMessage = adaptee.AscendDifficulty();
				evolutionStages++;

				Console.WriteLine($"После {evolutionStages}-ой стадии эволюции, низшее существо говорит: \"{adapteeMessage}\".");
			}

			return new HigherForm(evolutionStages);
		}
	}
}
