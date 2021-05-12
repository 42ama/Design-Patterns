using Visitor.Node;

namespace Visitor.Visitor.Interface
{
    /// <summary>
    /// Интерфейс позволяющий посещать определенные классы, которые вызывают конкретное
    /// поведение у посетителя.
    /// </summary>
    public interface IVisitor
    {
        /// <summary>
        /// Посетить класс ветки.
        /// </summary>
        /// <param name="node">Нода ветки.</param>
        void DoForBranchNode(BranchNode node);

        /// <summary>
        /// Посетить класс фрукта.
        /// </summary>
        /// <param name="node">Нода фрукта.</param>
        void DoForFruitNode(FruitNode node);

        /// <summary>
        /// Посетить класс листочка.
        /// </summary>
        /// <param name="node">Нода листочка.</param>
        void DoForLeafNode(LeafNode node);
    }
}
