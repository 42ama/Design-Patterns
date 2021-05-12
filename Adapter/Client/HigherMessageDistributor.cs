using System;
using Adapter.Adaptee.Interface;

namespace Adapter.Client
{
	/// <summary>
	/// Распространяет правду Высшего существа.
	/// </summary>
	public class HigherMessageDistributor
	{
		/// <summary>
		/// Распространяет правду Высшего существа.
		/// </summary>
		/// <param name="higherForm">Высшее существо, которое произносит высшую правду.</param>
		public void TellTruthOneMoreTime(IHigherForm higherForm)
		{
			if (higherForm == null) { throw new NullReferenceException(nameof(higherForm)); };

			Console.WriteLine($"И сказало Оно: \"{higherForm.TellHigherTruth()}\".");
		}
	}
}
