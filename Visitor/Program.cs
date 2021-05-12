using System;
using Visitor.Node;
using Visitor.Visitor;

namespace Visitor
{
    class Program
    {
        /// <summary>
        /// Единственный экземпляр генератора чисел для программы.
        /// </summary>
        public static Random Random = new Random();

        static void Main(string[] args)
        {
            #region Сборка структуры дерева

            // Хотел написать генератор деревьев для данной задачи, но это явно выходит за её
            // пределы и на тестовые версии, которые не дали желаемого результата я потратил достаточно
            // времени, чтобы решить просто ручками собрать тестовый стенд :)
            var branchNodes = new [] { new BranchNode(), new BranchNode(), new BranchNode(), new BranchNode(), new BranchNode() };
            var fruitNodes = new [] { new FruitNode(), new FruitNode() };
            var leafNodes = new [] { new LeafNode(), new LeafNode() };

            var firstNode = branchNodes[0];
            firstNode.AddChild(branchNodes[1], branchNodes[2], branchNodes[3]);

            branchNodes[1].AddChild(leafNodes[0], branchNodes[4]);
            branchNodes[4].AddChild(fruitNodes[0]);

            branchNodes[2].AddChild(leafNodes[1]);

            branchNodes[3].AddChild(fruitNodes[1]);

            #endregion

            // Создаем обычного посетителя.
            var worm = new TreeWorm(Random);

            // Запустить обычного посетителя на первую ноду.
            Console.WriteLine("Запускаем обычного посетителя:");
            firstNode.Accept(worm);

            // Создаем придирчивого посетителя.
            var pickyWorm = new PickyTreeWorm(Random);

            // Запустить придирчивого посетителя на первую ноду.
            Console.WriteLine("\n\nЗапускаем придирчивого посетителя:");
            firstNode.Accept(pickyWorm);

            Console.ReadKey();
        }
    }
}
