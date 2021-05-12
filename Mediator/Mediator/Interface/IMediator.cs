using Mediator.Components;

namespace Mediator.Mediator.Interface
{
	/// <summary>
	/// Посредник, использующийся для связывания компонентов.
	/// </summary>
	public interface IMediator
	{
		/// <summary>
		/// Получить уведомление о действии в компоненте.
		/// </summary>
		/// <param name="component">Компонент, в котором произошло действие.</param>
		void Notify(Component component);
	}
}
