using System;
using System.Collections.Generic;
using AbstractFactory.Factory;
using AbstractFactory.Instance.Interface;

namespace AbstractFactory
{
	class Program
	{
		static void Main(string[] args)
		{
			// Создаём необходимые фабрики.
			var gangMemberFactories = new List<AbstractGangMemberFactory>
			{
				new GhettoGangMemberFacility("Бла-адс"),
				new RussianMafiaGangMemberFacility("Товарищеская Братия")
			};

			// Подготавливаем коллекции для хранения экземпляров произведённых на фабриках.
			var snipers = new ISniper[gangMemberFactories.Count];
			var shooters = new IShooter[gangMemberFactories.Count];

			// Создаём по участнику каждого типа, для каждой фабрики.
			int counter = 0;
			foreach (var gangMemberFactory in gangMemberFactories)
			{
				snipers[counter] = gangMemberFactory.CreateSniper();
				shooters[counter] = gangMemberFactory.CreateShooter();
				counter++;
			}

			Console.WriteLine("(**где-то на улицах Нью-Йорках на нейтральной территории между " +
				"кварталами Брайтон-Бич и Бруклин, снайперы занимают исходные позиции**)");

			// Отдаём приказ снайперам занять позицию.
			foreach (var sniper in snipers)
			{
				var sniperMessage = sniper.TakeAim();
				Console.WriteLine($"{sniper.Name}: {sniperMessage}");
			}

			Console.WriteLine();
			Console.WriteLine("(**со сторон обоих кварталов выходят бандиты, и бряцают пушками**)");

			// Отдаём приказ стрелкам "побряцать" оружием.
			foreach (var shooter in shooters)
			{
				Console.WriteLine($"{shooter.Name} держит в руках {shooter.CurrentGun}");
				Console.WriteLine("Брат, доставай другое оружие!");
				shooter.ChangeGun();
				Console.WriteLine($"{shooter.Name} держит в руках {shooter.CurrentGun}");
				Console.WriteLine("Брат, доставай другое оружие!");
				shooter.ChangeGun();
				Console.WriteLine($"{shooter.Name} держит в руках {shooter.CurrentGun}");
			}

			Console.WriteLine("Нажмите клавишу для завершения...");
			Console.ReadKey();
		}
	}
}
