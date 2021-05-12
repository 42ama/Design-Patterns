using System;
using DI_IoC.Tests.TestServices.Interface;

namespace DI_IoC.Tests.TestServices
{
	/// <summary>
	/// Тестируемый сервис с конструктором без параметров.
	/// </summary>
	public class ServiceWithParameterlessConstructor : IService
	{
		/// <summary>
		/// Общая функциональность сервисов.
		/// </summary>
		public void DisplayMessage()
		{
			Console.WriteLine("My parameters are vacant");
		}
	}
}
