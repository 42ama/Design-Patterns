using System;
using Observer.Observable.Interface;
using Observer.Observer;
using Observer.Observer.Interface;

namespace Observer
{
	class Program
	{
		static void Main(string[] args)
		{
			// Создаём экземпляры издателей-подписчиков.
			var russianMafiaShooter = new RussianMafiaShooter();
			var ghettoShooter = new GhettoShooter();
			var italianMafiaShooter = new ItalianMafiaShooter();

			// Сохраняем ссылки на экземпляры, как на подписчиков отдельно.
			IObserverOfAggression[] observersOfAggression =
				{
					russianMafiaShooter,
					ghettoShooter,
					italianMafiaShooter
				};

			// Сохраняем ссылки на экземпляры, как на издателей отдельно.
			IObservableAggression<Func<string>>[] observableAggressions =
				{
					russianMafiaShooter,
					ghettoShooter,
					italianMafiaShooter
				};

			// Подпишем всех подписчиков на всех издателей.
			foreach (var observable in observableAggressions)
			{
				foreach (var observer in observersOfAggression)
				{
					if (observable == observer)
					{
						continue;
					}

					observable.Subscribe(observer.AggressionResponse);
				}
			}

			// Оповестим об интересном состоянии какого-то издателя.
			russianMafiaShooter.Notify();

			Console.WriteLine("Нажмите клавишу для завершения...");
			Console.ReadKey();
		}
	}
}
