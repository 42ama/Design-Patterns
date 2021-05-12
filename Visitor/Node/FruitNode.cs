using Visitor.Visitor.Interface;

namespace Visitor.Node
{
    /// <summary>
    /// Нода - фрукт, самая ценная с точки зрения посетителя.
    /// </summary>
    public class FruitNode : AbstractNode
    {
        /// <summary>
        /// Вызвать метод у посетителя, посещение фрукта.
        /// </summary>
        /// <param name="visitor">Посетитель.</param>
        public override void Accept(IVisitor visitor)
        {
            if (visitor == null)
            {
                throw new System.ArgumentNullException(nameof(visitor));
            }

            visitor.DoForFruitNode(this);
        }
    }
}
