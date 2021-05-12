using DI_IoC.IoC;
using DI_IoC.IoC.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DI_IoC.Tests.TestServices;
using DI_IoC.Tests.TestServices.Interface;

namespace DI_IoC.Tests
{
	// В рамках проверки задания на паттерны, тесты можно просто игнорировать.
	/// <summary>
	/// Тесты работоспособности IoC контейнера.
	/// </summary>
	[TestClass]
	public class IocManagerTests
	{
		/// <summary>
		/// Экземпляр IoC контейнера.
		/// </summary>
		private IocManager _iocManager;

		/// <summary>
		/// Предварительная инициализация перед каждым случаем тестирования.
		/// </summary>
		[TestInitialize]
		public void IOCManagerTests_Initialize()
		{
			_iocManager = new IocManager();
		}

		/// <summary>
		/// При регистрации transient сервиса, если у него не найден 
		/// конструктор без параметров, выбросить исключение.
		/// </summary>
		[TestMethod]
		public void IOCManager_RegisterTransientWithoutParameterlessConstructor_ThrowsException()
		{
			Assert.ThrowsException<InvalidTypeParameterException>
				(
					() => 
					{
						_iocManager.RegisterTransient<IService, ServiceWithParametersInConstructor>();
					}
				);
		}

		/// <summary>
		/// При регистрации singleton сервиса, если у него не найден 
		/// конструктор без параметров, выбросить исключение.
		/// </summary>
		[TestMethod]
		public void IOCManager_RegisterSingletonWithoutParameterlessConstructor_ThrowsException()
		{
			Assert.ThrowsException<InvalidTypeParameterException>
				(
					() =>
					{
						_iocManager.RegisterSingleton<IService, ServiceWithParametersInConstructor>();
					}
				);
		}

		/// <summary>
		/// При регистрации одного и того же интерфейса дважды, один раз
		/// как transient, другой раз как singleton, выбросить исключение.
		/// </summary>
		[TestMethod]
		public void IOCManager_RegisterSameInterfaceInTransientAndSingleton_ThrowsException()
		{
			Assert.ThrowsException<InvalidTypeParameterException>
				(
					() =>
					{
						_iocManager.RegisterTransient<IService, ServiceWithParametersInConstructor>();
						_iocManager.RegisterSingleton<IService, ServiceWithParametersInConstructor>();
					}
				);
		}

		/// <summary>
		/// При регистрации одного и того же интерфейса, как transient, дважды, выбросить исключение.
		/// </summary>
		[TestMethod]
		public void IOCManager_RegisterSameInterfaceTransientTwice_ThrowsException()
		{
			Assert.ThrowsException<InvalidTypeParameterException>
				(
					() =>
					{
						_iocManager.RegisterTransient<IService, ServiceWithParametersInConstructor>();
						_iocManager.RegisterTransient<IService, ServiceWithParametersInConstructor>();
					}
				);
		}

		/// <summary>
		/// При регистрации одного и того же интерфейса, как singleton, дважды, выбросить исключение.
		/// </summary>
		[TestMethod]
		public void IOCManager_RegisterSameInterfaceSingletonTwice_ThrowsException()
		{
			Assert.ThrowsException<InvalidTypeParameterException>
				(
					() =>
					{
						_iocManager.RegisterSingleton<IService, ServiceWithParametersInConstructor>();
						_iocManager.RegisterSingleton<IService, ServiceWithParametersInConstructor>();
					}
				);
		}

		/// <summary>
		/// При попытке создать экземпляр не зарегистрированного сервиса, выбросить исключение.
		/// </summary>
		[TestMethod]
		public void IOCManager_FindNotRegisteredInterfaceType_ThrowsException()
		{
			Assert.ThrowsException<InvalidTypeParameterException>
				(
					() =>
					{
						_iocManager.ProduceByType<IService>();
					}
				);
		}

		/// <summary>
		/// При создании экземпляра transient сервиса, экземпляр
		/// соответствует зарегистрированному сервису.
		/// </summary>
		[TestMethod]
		public void IOCManager_RegisterTransientFoundIt_FoundServiceIsRegisteredOne()
		{
			_iocManager.RegisterTransient<IService, ServiceWithParameterlessConstructor>();

			var actual = _iocManager.ProduceByType<IService>();

			Assert.IsTrue(actual is ServiceWithParameterlessConstructor);
		}

		/// <summary>
		/// При создании экземпляра singleton сервиса, экземпляр
		/// соответствует зарегистрированному сервису.
		/// </summary>
		[TestMethod]
		public void IOCManager_RegisterSingletonFoundIt_FoundServiceIsRegisteredOne()
		{
			_iocManager.RegisterSingleton<IService, ServiceWithParameterlessConstructor>();

			var actual = _iocManager.ProduceByType<IService>();

			Assert.IsTrue(actual is ServiceWithParameterlessConstructor);
		}

		/// <summary>
		/// При создании экземпляра singleton сервиса дважды, экземпляры
		/// ссылаются на один объект.
		/// </summary>
		[TestMethod]
		public void IOCManager_RegisterSingletonFoundItTwice_ServicesAreSame()
		{
			_iocManager.RegisterSingleton<IService, ServiceWithParameterlessConstructor>();

			var actualFirst = _iocManager.ProduceByType<IService>();
			var actualSecond = _iocManager.ProduceByType<IService>();

			Assert.AreSame(actualFirst, actualSecond);
		}

		/// <summary>
		/// При создании экземпляра transient сервиса дважды, экземпляры
		/// ссылаются на разные объекты.
		/// </summary>
		[TestMethod]
		public void IOCManager_RegisterTransientFoundItTwice_ServicesAreNotSame()
		{
			_iocManager.RegisterTransient<IService, ServiceWithParameterlessConstructor>();

			var actualFirst = _iocManager.ProduceByType<IService>();
			var actualSecond = _iocManager.ProduceByType<IService>();

			Assert.AreNotSame(actualFirst, actualSecond);
		}
	}
}
