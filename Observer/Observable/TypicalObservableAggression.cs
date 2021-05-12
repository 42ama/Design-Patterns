using System;
using System.Collections.Generic;
using Observer.Observable.Interface;

namespace Observer.Observable
{
	/// <summary>
	/// Класс обладающий интересным состоянием.
	/// </summary>
	public class TypicalObservableAggression : IObservableAggression<Func<string>>
	{
		/// <summary>
		/// Коллекция подписанных реакций на произошедшее интересное состояние.
		/// </summary>
		private readonly ISet<Func<string>> _aggressionResponses = new HashSet<Func<string>>();

		/// <summary>
		/// Подписаться на интересное состояние.
		/// </summary>
		/// <param name="aggressionResponse">Метод оповещения.</param>
		public void Subscribe(Func<string> aggressionResponse)
        {
			if (aggressionResponse == null) { throw new ArgumentNullException(nameof(aggressionResponse)); };

            _aggressionResponses.Add(aggressionResponse);
        }

		/// <summary>
		/// Отписаться от интересного состояния.
		/// </summary>
		/// <param name="aggressionResponse">Метод оповещения.</param>
		public void Unsubscribe(Func<string> aggressionResponse)
		{
			if (aggressionResponse == null) { throw new ArgumentNullException(nameof(aggressionResponse)); };

			_aggressionResponses.Remove(aggressionResponse);
		}

		/// <summary>
		/// Уведомить подписчиков об интересном состоянии.
		/// </summary>
		public void Notify()
		{
			Console.WriteLine("(..кто-то по тихому пытается в ответ достать пушку..)");

			foreach (var aggressionResponse in _aggressionResponses)
			{
				var responseResult = aggressionResponse.Invoke();
				Console.WriteLine($"{responseResult}");
			}
		}
	}
}