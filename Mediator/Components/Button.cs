using System;

namespace Mediator.Components
{
	/// <summary>
	/// Активный компонент, использующийся пользователем.
	/// </summary>
	public class Button : Component
	{
		/// <summary>
		/// Клик на кнопку.
		/// </summary>
		public void Click()
		{
			Console.WriteLine("(**клик-клик**)");
			Mediator.Notify(this);
		}
	}
}
