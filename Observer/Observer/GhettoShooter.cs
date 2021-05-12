using Observer.Observable;
using Observer.Observer.Interface;

namespace Observer.Observer
{
	/// <summary>
	/// Стрелок из гетто.
	/// </summary>
	public class GhettoShooter : TypicalObservableAggression, IObserverOfAggression
	{
		/// <summary>
		/// Реакция на интересное состояние.
		/// </summary>
		/// <returns>Сообщение-реакция на интересное состояние.</returns>
		public string AggressionResponse()
		{
			return "Карл в ответ достаёт узи, щи-ит.";
		}
	}
}
