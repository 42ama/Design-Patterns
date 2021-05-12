using System;
using Iterator.Instance;
using Iterator.Interface;

namespace Iterator
{
	class Program
	{
		static void Main(string[] args)
		{
			// Содержимое магазина.
			string[] candyStoreContent = 
			{ 
				"Мятная конфета", 
				"Жвачка", 
				"Сахарный кубик", 
				"Лакричная палочка" 
			};

			// Создаём итерируемую коллекцию - магазин.
			IIterableCollection<string> candyStoreCollection = new IterableCollection<string>(candyStoreContent);

			// Создаём итератор для обхода коллекции.
			var candyStoreIterator = candyStoreCollection.GetIterator();

			// Обходим коллекцию с помощью итератора.
			do
			{
				var candy = candyStoreIterator.Current;
				Console.WriteLine(
					"Ты однажды мне принёс" +
					$"\n{candy}" +
					"\nИ сказал мне что это ландыши" +
					"\nНо меня не проведёшь" +
					$"\n{candy} на ландыш не похож" +
					$"\n{candy} большой, а ландыш маленький" +
					"\n");
			}
			while (candyStoreIterator.MoveNext());

			Console.WriteLine("Нажмите клавишу для завершения...");
			Console.ReadKey();
		}
	}
}