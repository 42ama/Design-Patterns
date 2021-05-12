using Observer.Observable;
using Observer.Observer.Interface;

namespace Observer.Observer
{
	/// <summary>
	/// Стрелок из русской мафии.
	/// </summary>
	public class RussianMafiaShooter : TypicalObservableAggression, IObserverOfAggression
	{
		/// <summary>
		/// Реакция на интересное состояние.
		/// </summary>
		/// <returns>Сообщение-реакция на интересное состояние.</returns>
		public string AggressionResponse()
		{
			return "Иван достаёт из под шапки-ушанки Пистолет Макарова.";
		}
	}
}
