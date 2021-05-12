

namespace Observer.Observer.Interface
{
	/// <summary>
	/// Интересующийся интересным состоянием.
	/// </summary>
	public interface IObserverOfAggression
	{
		/// <summary>
		/// Реакция на интересное состояние.
		/// </summary>
		/// <returns>Сообщение-реакция на интересное состояние.</returns>
		string AggressionResponse();
	}
}
