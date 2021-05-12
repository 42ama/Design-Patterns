

namespace Observer.Observable.Interface
{
	/// <summary>
	/// На класс реализующий данный интерфейс можно подписаться, и тогда если в нем
	/// произойдёт смена интересного состояния, то он оповестит подписанные экземпляры
	/// вызывав подписанные методы.
	/// </summary>
	/// <typeparam name="T">Тип делегата метода оповещения.</typeparam>
	public interface IObservableAggression<T>
	{
		/// <summary>
		/// Подписаться на интересное состояние.
		/// </summary>
		/// <param name="aggressionResponse">Метод оповещения.</param>
		public void Subscribe(T aggressionResponse);

		/// <summary>
		/// Отписаться от интересного состояния.
		/// </summary>
		/// <param name="aggressionResponse">Метод оповещения.</param>
		public void Unsubscribe(T aggressionResponse);

		/// <summary>
		/// Уведомить подписчиков об интересном состоянии.
		/// </summary>
		public void Notify();
	}
}
