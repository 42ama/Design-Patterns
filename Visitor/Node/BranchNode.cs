using Visitor.Visitor.Interface;

namespace Visitor.Node
{
    /// <summary>
    /// Нода - ветка, соединяет другие ноды между собой.
    /// </summary>
    public class BranchNode : AbstractNode
    {
        /// <summary>
        /// Вызвать метод у посетителя, посещение ветки.
        /// </summary>
        /// <param name="visitor">Посетитель.</param>
        public override void Accept(IVisitor visitor)
        {
            if (visitor == null)
            {
                throw new System.ArgumentNullException(nameof(visitor));
            }

            visitor.DoForBranchNode(this);
        }
    }
}
