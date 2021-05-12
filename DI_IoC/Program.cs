using System;
using DI_IoC.BusinessLogic;
using DI_IoC.BusinessLogic.Interface;
using DI_IoC.IoC;

namespace DI_IoC
{
	class Program
	{
		static void Main(string[] args)
		{
			// Записываем проверяемые пароли.
			var mySecurePassword = "iR3a||yL0v3MyD0g";
			var notMyPassword = "qwerty";

			// Создаём экземпляр IoC контейнера.
			var manager = new IocManager();

			// Регистрируем сервис в менеджере.
			manager.RegisterTransient<IPasswordHashGenerator, BadPasswordHashGenerator>();

			// Получаем экземпляр сервиса.
			var passwordHashGenerator = manager.ProduceByType<IPasswordHashGenerator>();

			// Получаем и выводим хэш пароля.
			var hash = passwordHashGenerator.GenerateHash(mySecurePassword);
			Console.WriteLine($"Хэш: {hash}");

			// Проверяем пароль на соответствие хэшу.
            var responseLine = passwordHashGenerator.IsPasswordMatchingHash(notMyPassword, hash)
                ? "Пароль совпадает!"
                : "Пароль не совпадает.";

			Console.WriteLine(responseLine);

            Console.WriteLine("Нажмите клавишу для завершения...");
			Console.ReadKey();
		}
	}
}
