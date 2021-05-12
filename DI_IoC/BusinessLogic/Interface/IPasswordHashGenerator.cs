

namespace DI_IoC.BusinessLogic.Interface
{
	/// <summary>
	/// Используется для генерации и проверки хэша.
	/// </summary>
	public interface IPasswordHashGenerator
	{
		/// <summary>
		/// Генерирует хэш для предоставленного пароля.
		/// </summary>
		/// <param name="password">Пароль, для которого будет сгенерирован хэш.</param>
		/// <returns>Хэш пароля.</returns>
		string GenerateHash(string password);

		/// <summary>
		/// Проверяет совпадает ли новая генерация хэша для пароля с проверяемым хэшем.
		/// </summary>
		/// <param name="password">Пароль для которого будет проверен хэш.</param>
		/// <param name="savedPasswordHash">Хэш который будет сравниваться с хэшем от пароля.</param>
		/// <returns>
		/// true - если хэш пароля совпадает с предоставленным хэшем, false - в обратном случае.
		/// </returns>
		bool IsPasswordMatchingHash(string password, string savedPasswordHash);
	}
}
