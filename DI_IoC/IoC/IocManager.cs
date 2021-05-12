using System;
using System.Collections.Generic;
using System.ComponentModel;
using DI_IoC.IoC.Exception;

namespace DI_IoC.IoC
{
	/// <summary>
	/// Простейший IoC контейнер. 
	/// Используется для хранения сервисов с конструктором без параметров.
	/// </summary>
	public class IocManager
	{
		/// <summary>
		/// Тип внедрённой зависимости.
		/// </summary>
		public enum InjectionType
		{
			Transient,
			Singleton
		}

		/// <summary>
		/// Хранилище информации о внедрённых зависимостях.
		/// </summary>
		private readonly Dictionary<Type, (Type implementationType, InjectionType injectionType)> _types = 
			new Dictionary<Type, (Type, InjectionType)>();

		/// <summary>
		/// Хранилище экземпляров внедрённых singleton зависимостей.
		/// </summary>
		private readonly Dictionary<Type, object> _singletons = new Dictionary<Type, object>();

		/// <summary>
		/// Регистрирует сервис в менеджере. 
		/// При каждом обращении к сервису будет создан новый экземпляр.
		/// </summary>
		/// <typeparam name="TInterface">Тип интерфейса сервиса.</typeparam>
		/// <typeparam name="TInstance">
		/// Тип реализации сервиса, должен иметь конструктор без параметров.
		/// </typeparam>
		public void RegisterTransient<TInterface, TInstance>() where TInstance : TInterface
		{
			Register<TInterface, TInstance>(InjectionType.Transient);
		}

		/// <summary>
		/// Регистрирует сервис в менеджере. 
		/// При каждом обращении к сервису будет возвращён один и тот же экземпляр.
		/// </summary>
		/// <typeparam name="TInterface">Тип интерфейса сервиса.</typeparam>
		/// <typeparam name="TInstance">
		/// Тип реализации сервиса, должен иметь конструктор без параметров.
		/// </typeparam>
		public void RegisterSingleton<TInterface, TInstance>() where TInstance : TInterface
		{
			Register<TInterface, TInstance>(InjectionType.Singleton);
			_singletons[typeof(TInterface)] = Activator.CreateInstance(typeof(TInstance));
		}

		/// <summary>
		/// Производит экземпляр зарегистрированного типа интерфейса
		/// по установленным при его регистрации правилам.
		/// </summary>
		/// <typeparam name="T">Тип интерфейса, экземпляр которого будет получен.</typeparam>
		/// <returns>Экземпляр заданного типа интерфейса.</returns>
		public T ProduceByType<T>()
		{
			T instance;

			try
			{
				instance = (T)FindByType(typeof(T));
			}
			catch (ArgumentException innerException)
			{
				throw new InvalidTypeParameterException("T", "Данный тип не найден в менеджере.", innerException);
			}

			return instance;
		}

		/// <summary>
		/// Сохраняет в системе для последующего доступа комбинацию тип интерфейса-тип реализации.
		/// </summary>
		/// <typeparam name="TInterface">Тип интерфейса.</typeparam>
		/// <typeparam name="TImplement">Тип реализации данного интерфейса.</typeparam>
		/// <param name="injectionType">Тип доступа к зависимости.</param>
		private void Register<TInterface, TImplement>(InjectionType injectionType)
		{
			// Тип доступа зависимости должен быть определен в перечислении.
            if (!Enum.IsDefined(typeof(InjectionType), injectionType))
            {
                throw new InvalidEnumArgumentException(nameof(injectionType), (int)injectionType,
                    typeof(InjectionType));
			}
                
            var interfaceType = typeof(TInterface);

			if (_types.ContainsKey(interfaceType))
			{
				throw new InvalidTypeParameterException("TInterface", "Данный тип уже содержится в менеджере.");
			}

			var implementationType = typeof(TImplement);

			// Находим конструктор без параметров.
			var parameterlessConstructor = implementationType.GetConstructor(Type.EmptyTypes);

			if (parameterlessConstructor == null)
			{
				throw new InvalidTypeParameterException
					(
						"TImplementation", 
						"Реализация интерфейса должна иметь конструктор по умолчанию, без параметров."
					);
			}

			// Сохраняем информацию о сервисе.
			_types[interfaceType] = (implementationType, injectionType);
		}

		/// <summary>
		/// Возвращает экземпляр, находя его по типу интерфейса, согласно правилам, по которым
		/// данный интерфейс был зарегистрирован.
		/// </summary>
		/// <param name="interfaceType">Тип интерфейса.</param>
		/// <returns>Экземпляр интерфейса, в общем виде.</returns>
		private object FindByType(Type interfaceType)
		{
            if (interfaceType == null)
            {
                throw new ArgumentNullException(nameof(interfaceType));
            }

            if (!_types.ContainsKey(interfaceType))
			{
				throw new ArgumentException("Данный тип не найден в менеджере.", $"{nameof(interfaceType)}");
			}

			var (implementationType, injectionType) = _types[interfaceType];

			return injectionType == InjectionType.Singleton 
				? _singletons[interfaceType] 
				: Activator.CreateInstance(implementationType);
		}
	}
}