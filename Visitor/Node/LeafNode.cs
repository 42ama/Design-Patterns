using Visitor.Visitor.Interface;

namespace Visitor.Node
{
    /// <summary>
    /// Нода - листочек, достаточна ценная нода, на которой можно остановиться.
    /// </summary>
    public class LeafNode : AbstractNode
    {
        /// <summary>
        /// Вызвать метод у посетителя, посещение листка.
        /// </summary>
        /// <param name="visitor">Посетитель.</param>
        public override void Accept(IVisitor visitor)
        {
            if (visitor == null)
            {
                throw new System.ArgumentNullException(nameof(visitor));
            }

            visitor.DoForLeafNode(this);
        }
    }
}
