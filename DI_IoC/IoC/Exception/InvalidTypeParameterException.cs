using System;

namespace DI_IoC.IoC.Exception
{
	/// <summary>
	/// Исключение возникающее при подаче неправильного типа-параметра.
	/// </summary>
	public class InvalidTypeParameterException : System.Exception
	{
        /// <summary>
        /// Стандартное сообщение, используемое если не задано другое сообщение.
        /// </summary>
        private const string StandardMessage = "Передан неправильный тип-параметр.";

        /// <summary>
		/// Название параметра, с которым имеется проблема.
		/// </summary>
		public string ParameterName { get; }

		/// <summary>
		/// Сообщение об ошибке.
		/// </summary>
		public override string Message { get; }


		/// <summary>
		/// Создаёт исключение со стандартным сообщением.
		/// </summary>
		public InvalidTypeParameterException() : base()	
		{
			Message = StandardMessage;
		}

		/// <summary>
		/// Создаёт исключение со пользовательским сообщением
		/// об ошибке и именем параметра.
		/// </summary>
		/// <param name="parameterName">Имя параметра с ошибкой.</param>
		/// <param name="message">Сообщение об ошибке.</param>
		public InvalidTypeParameterException(string parameterName, string message) : base(message) 
		{
			ParameterName = !string.IsNullOrEmpty(parameterName)
				? parameterName
				: throw new ArgumentException("Необходимо передать имя параметра вызвавшего ошибку.", nameof(parameterName));

			Message = message ?? StandardMessage;
		}

		/// <summary>
		/// Создаёт исключение со пользовательским сообщением
		/// об ошибке, именем параметра и экземпляром внутреннего исключения.
		/// </summary>
		/// <param name="parameterName">Имя параметра с ошибкой.</param>
		/// <param name="message">Сообщение об ошибке.</param>
		/// <param name="innerException">Внутреннее исключение.</param>
		public InvalidTypeParameterException(string parameterName, string message, System.Exception innerException)
			: base(message, innerException)
		{
			ParameterName = !string.IsNullOrEmpty(parameterName)
				? parameterName
				: throw new ArgumentException("Необходимо передать имя параметра вызвавшего ошибку.", nameof(parameterName));

			Message = !string.IsNullOrEmpty(message)
				? message
				: StandardMessage;
		}
    }
}
