using System.Collections.Generic;
using Visitor.Node.Interface;
using Visitor.Visitor.Interface;

namespace Visitor.Node
{
    /// <summary>
    /// Базовый класс для ноды дерева.
    /// </summary>
    public abstract class AbstractNode : IVisited
    {
        /// <summary>
        /// Общее количество созданных нод.
        /// </summary>
        private static int _nodeCount = 0;

        /// <summary>
        /// Номер текущей ноды.
        /// </summary>
        public int NodeNumber { get; }
        
        /// <summary>
        /// Список дочерних нод для ноды.
        /// </summary>
        public IList<AbstractNode> ChildNodes { get; } = new List<AbstractNode>();

        public AbstractNode()
        {
            NodeNumber = ++_nodeCount;
        }

        /// <summary>
        /// Добавляет одну дочернюю ноду.
        /// </summary>
        /// <param name="node">Дочерняя нода.</param>
        public void AddChild(AbstractNode node)
        {
            if (node == null)
            {
                throw new System.ArgumentNullException(nameof(node));
            }


            ChildNodes.Add(node);
        }

        /// <summary>
        /// Добавляет набор дочерних нод.
        /// </summary>
        /// <param name="nodes">Дочерние ноды.</param>
        public void AddChild(params AbstractNode[] nodes)
        {
            if (nodes == null)
            {
                throw new System.ArgumentNullException(nameof(nodes));
            }


            foreach (var node in nodes)
            {
                ChildNodes.Add(node);
            }
        }

        /// <summary>
        /// Вызвать метод у посетителя, специфичный для конкретного класса.
        /// </summary>
        /// <param name="visitor">Посетитель.</param>
        public abstract void Accept(IVisitor visitor);
    }
}
