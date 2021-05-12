

namespace Singleton
{
	/// <summary>
	/// Класс-одиночка, единственная открытая касса в магазине.
	/// </summary>
	public class CashRegister
	{
		/// <summary>
		/// Экземпляр кассы.
		/// </summary>
		private static CashRegister _singleCashRegister = null;
		/// <summary>
		/// Объект для обеспечения потокобезопасности при создании сигнлтона.
		/// </summary>
		private static readonly object _padlock = new object();

		/// <summary>
		/// Спрятанный конструктор экземпляров.
		/// </summary>
		private CashRegister() { }

		/// <summary>
		/// Создаёт первый экземпляр кассы или возвращает уже имеющийся.
		/// </summary>
		/// <returns>Экземпляр кассы.</returns>
		public static CashRegister OpenNewCashRegister()
		{
			if (_singleCashRegister == null)
			{
				lock (_padlock)
				{
					// При создании экземпляра кассы, в защищённом потоке проверяем
					// не был ли уже создан экземпляр. Если нет - создаём его.
					_singleCashRegister ??= new CashRegister();
				}
			}

			return _singleCashRegister;
		}
	}
}
