using Visitor.Visitor.Interface;

namespace Visitor.Node.Interface
{
    /// <summary>
    /// Интерфейс позволяющий объекту быть посещенным - вызвать специфичное поведение
    /// для конкретной реализации объекта у посетителя.
    /// </summary>
    public interface IVisited
    {
        /// <summary>
        /// Вызвать метод у посетителя, специфичный для конкретного класса.
        /// </summary>
        /// <param name="visitor">Посетитель.</param>
        void Accept(IVisitor visitor);
    }
}
