using DI_IoC.BusinessLogic.Interface;

namespace DI_IoC.BusinessLogic
{
	/// <summary>
	/// Генерирует очень плохой хэш для пароля.
	/// </summary>
	public class BadPasswordHashGenerator : IPasswordHashGenerator
	{
		/// <summary>
		/// Генерирует плохой хэш для предоставленного пароля.
		/// </summary>
		/// <param name="password">Пароль, для которого будет сгенерирован хэш.</param>
		/// <returns>Строка "hash"</returns>
		public string GenerateHash(string password)
		{
			return "hash";
		}

		/// <summary>
		/// Проверяет является ли строка savedPasswordHash - строкой "hash".
		/// </summary>
		/// <param name="password">Пароль для которого будет проверен хэш.</param>
		/// <param name="savedPasswordHash">Хэш который будет сравниваться с строкой "hash".</param>
		/// <returns>
		/// true - если хэш пароля совпадает с "hash", false - в обратном случае.
		/// </returns>
		public bool IsPasswordMatchingHash(string password, string savedPasswordHash)
		{
			return savedPasswordHash == "hash";
		}
	}
}
