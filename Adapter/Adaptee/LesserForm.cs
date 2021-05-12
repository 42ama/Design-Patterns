using System;
using Adapter.Adaptee.Interface;

namespace Adapter.Adaptee
{
	/// <summary>
	/// Низшее существо, способное к возвышению.
	/// </summary>
	public class LesserForm : ILesserForm
	{
		/// <summary>
		/// Количество трудностей, которые необходимо преодолеть.
		/// </summary>
		public int DifficultyCount { get; private set; }

		public LesserForm()
		{
			var random = new Random();
			DifficultyCount = random.Next(4,17);
		}

		/// <summary>
		/// Преодолевает трудность и сообщает о своем состоянии.
		/// </summary>
		/// <returns>Сообщение о состоянии существа.</returns>
		public string AscendDifficulty()
		{
			string message;
			if (DifficultyCount == 0)
			{
				message = "Я уже чист и готов к возвышению!";
			}
			else
			{
				DifficultyCount--;
				message = "Я очистился ещё немного!";
			}
			return message;
		}


	}
}
