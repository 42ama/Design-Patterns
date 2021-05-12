using System;
using Decorator.Component;

namespace Decorator
{
	class Program
	{
		static void Main(string[] args)
		{
			// Прячем Кощееву смерть.
			var koscheiDeath = new KoscheiDeath();
			var needle = new Needle(koscheiDeath);
			var egg = new Egg(needle);
			var duck = new Duck(egg);
			var rabbit = new Rabbit(duck);
			var chest = new Chest(rabbit);
			var oak = new Oak(chest);
			var island = new Island(oak);
			var ocean = new Ocean(island);

			// Показываем сообщение из верхнего компонента, который
			//  хранит все сообщения обёрнутые по цепочке.
			Console.WriteLine(ocean.Message);

			Console.WriteLine("Нажмите клавишу для завершения...");
			Console.ReadKey();
		}
	}
}
