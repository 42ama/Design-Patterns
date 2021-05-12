using System;
using Adapter.Adaptee.Interface;

namespace Adapter.Adaptee
{
	/// <summary>
	/// Вознесшееся существо, рассказывающее высшую правду.
	/// </summary>
	public class HigherForm : IHigherForm
	{
		/// <summary>
		/// Количество пройденных эволюционных изменений, приведших к возвышению.
		/// </summary>
		private readonly int _evolutionStages;

		public HigherForm(int evolutionStages)
		{
			_evolutionStages = evolutionStages > 0
				? evolutionStages
				: throw new ArgumentException("Количество эволюционных изменений должно быть больше нуля.", nameof(evolutionStages));
		}

		/// <summary>
		/// Возвращает высшую правду.
		/// </summary>
		/// <returns>Возвращает высшую правду.</returns>
		public string TellHigherTruth()
		{
			return $"Только после {_evolutionStages} изменений, ты становишься Богоподобным.";
		}
	}
}
