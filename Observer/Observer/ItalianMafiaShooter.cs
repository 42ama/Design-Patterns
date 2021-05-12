using Observer.Observable;
using Observer.Observer.Interface;

namespace Observer.Observer
{
	/// <summary>
	/// Стрелок из итальянской мафии.
	/// </summary>
	public class ItalianMafiaShooter : TypicalObservableAggression, IObserverOfAggression
	{
		/// <summary>
		/// Реакция на интересное состояние.
		/// </summary>
		/// <returns>Сообщение-реакция на интересное состояние.</returns>
		public string AggressionResponse()
		{
			return "Марио в ответ достаёт томми-ган, мамая мия!";
		}
	}
}
