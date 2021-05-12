using System;
using Visitor.Node;
using Visitor.Visitor.Interface;

namespace Visitor.Visitor
{
    /// <summary>
    /// Посетитель, ищущий ноды фрукта и листочка, перемещается по нодам ветки.
    /// </summary>
    public class TreeWorm : IVisitor
    {
        /// <summary>
        /// Экземпляр генератора чисел.
        /// </summary>
        private readonly Random _random;

        /// <param name="random">Экземпляр генератора чисел.</param>
        public TreeWorm(Random random)
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

            Console.WriteLine("Поползу-ка я дальше.");
            var nextNodeNumber = _random.Next(0, node.ChildNodes.Count);
            node.ChildNodes[nextNodeNumber].Accept(this);
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
        /// Остается на листочке, чтобы съесть его.
        /// </summary>
        /// <param name="node">Нода листочка.</param>
        public void DoForLeafNode(LeafNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }


            Console.WriteLine($"Листочек {node.NodeNumber}, в принципе неплохо, останусь здесь ненадолго.");
        }
    }
}
