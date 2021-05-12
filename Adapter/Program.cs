using System;
using Adapter.Adaptee;
using Adapter.Adaptee.Interface;
using Adapter.Adapter;
using Adapter.Client;

namespace Adapter
{
	class Program
	{
		static void Main(string[] args)
		{
			// Создаем конечный клиент, который будет использовать адаптированный вариант класса.
			var distributor = new HigherMessageDistributor();

			// Создаем Адаптер.
			var evoluionBooth = new EvolutionBooth();

			Console.WriteLine("И было создано Существо на первый день.");

			// Создаем экземпляр адатируемого класса.
			ILesserForm lesserForm = new LesserForm();

			Console.WriteLine("И возжелало Существо стать выше чем кто-либо посредством эволюции.");

			// С помощью адаптера получаем экземпляр пригодный для использования в конечном клиенте.
			var higherForm = evoluionBooth.Adapt(lesserForm);

			Console.WriteLine("И наконец стало Существом - Им. Принесло Оно благую весть.");

			// Используем адаптированный класс в клиенте.
			distributor.TellTruthOneMoreTime(higherForm);

			Console.WriteLine("Нажмите клавишу для завершения...");
			Console.ReadKey();
		}
	}
}
