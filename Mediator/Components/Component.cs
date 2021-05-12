using System;
using Mediator.Mediator.Interface;

namespace Mediator.Components
{
	/// <summary>
	/// Базовый компонент, связанный с посредником.
	/// </summary>
	public abstract class Component
	{
		/// <summary>
		/// Экземпляр посредника.
		/// </summary>
		protected IMediator Mediator { get; private set; }

		/// <summary>
		/// Установить экземпляр посредника у текущего компонента.
		/// </summary>
		/// <param name="mediator">
		/// Экземпляр посредник, который будет связан с текущим компонентом.
		/// </param>
		public void SetMediator(IMediator mediator)
		{
			Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}
	}
}
