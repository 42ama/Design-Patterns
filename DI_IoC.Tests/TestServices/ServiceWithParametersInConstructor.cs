using System;
using DI_IoC.Tests.TestServices.Interface;

namespace DI_IoC.Tests.TestServices
{
	/// <summary>
	/// Тестируемый сервис у которого нет конструктора без параметров.
	/// </summary>
	public class ServiceWithParametersInConstructor : IService
	{
		/// <summary>
		/// Создаёт сервис, принимая два параметра.
		/// </summary>
		public ServiceWithParametersInConstructor(int parameterOne, string parameterTwo) { }

		/// <summary>
		/// Общая функциональность сервисов.
		/// </summary>
		public void DisplayMessage()
		{
			Console.WriteLine("I have parameters");
		}
	}
}
