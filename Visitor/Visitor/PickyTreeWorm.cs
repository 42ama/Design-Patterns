using System;
using System.Collections.Generic;
using System.Text;
using Visitor.Node;
using Visitor.Visitor.Interface;

namespace Visitor.Visitor
{
    /// <summary>
    /// Посетитель, ищущий только ноду фрукта.
    /// </summary>
    public class PickyTreeWorm : IVisitor
    {
        /// <summary>
        /// Экземпляр генератора чисел.
        /// </summary>
        private readonly Random _random;

        /// <param name="random">Экземпляр генератора чисел.</param>
        public PickyTreeWorm(Random random)
        {
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        /// <summary>
        /// Ищет дочерние ноды у ветки и переползает на случайную из них.
        /// </summary>
        /// <param name="node">Нода ветки.</param>
        public void DoForBranchNode(BranchNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }


            Console.WriteLine($"Ползу по ветке... Какая кла-а-асная ветка с номером {node.NodeNumber}.");
            if (node.ChildNodes.Count == 0)
            {
                Console.WriteLine("Ничего не нашёл, похоже умру голодным.");
                return;
            }

            SearchForChildNode(node);
        }

        /// <summary>
        /// Остается на фрукте, чтобы съесть его.
        /// </summary>
        /// <param name="node">Нода фрукта.</param>
        public void DoForFruitNode(FruitNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }


            Console.WriteLine($"ФРУКТ {node.NodeNumber}! Как говорится, из груши выползал червячок, а из подушки сновидение.");
        }

        /// <summary>
        /// Ищет дочерние ноды у листка и переползает на случайную из них.
        /// </summary>
        /// <param name="node">Нода листочка.</param>
        public void DoForLeafNode(LeafNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            Console.WriteLine("Листок, но такому гурману как я, это не по вкусу...");
            if (node.ChildNodes.Count == 0)
            {
                Console.WriteLine("Эх, умру голодным, но до низкосортной еды не опущусь.");
                return;
            }

            SearchForChildNode(node);
        }

        /// <summary>
        /// Ищет дочернюю ноду у переданной ноды и принимается на неё.
        /// </summary>
        /// <param name="node">Нода</param>
        private void SearchForChildNode(AbstractNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (node.ChildNodes.Count == 0)
            {
                throw new Exception("Не удается переползти на ноду, потому что переданная нода не имеет дочерних нод.");
            }

            Console.WriteLine("Поползу-ка я дальше.");
            var nextNodeNumber = _random.Next(0, node.ChildNodes.Count);
            node.ChildNodes[nextNodeNumber].Accept(this);
        }
    }
}
