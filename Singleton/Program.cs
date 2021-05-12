using System;

namespace Singleton
{
	class Program
	{
		static void Main(string[] args)
		{
			// Создаём первый экземпляр кассы.
			var oldCashRegister = CashRegister.OpenNewCashRegister();

			Console.WriteLine("На этой кассе очередь, откройте ещё одну!");

			// Пытаемся получить другой экземпляр кассы.
			var newCashRegister = CashRegister.OpenNewCashRegister();

			// Проверяем, то является ли экземпляр новой кассы, экземпляром старой кассы.
			if (ReferenceEquals(oldCashRegister, newCashRegister))
			{
				Console.WriteLine("Извините, касса всего одна.");
			}

			Console.WriteLine("Нажмите клавишу для завершения...");
			Console.ReadKey();
		}
	}
}
