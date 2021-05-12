using System;
using System.Collections.Generic;
using Command.Army;
using Command.Command;
using Command.Command.Interface;
using Command.Controller;

namespace Command
{
    class Program
    {
        /// <summary>
        /// Единственный экземпляр генератора чисел для программы.
        /// </summary>
        public static Random Random = new Random();

        static void Main(string[] args)
        {
            // Создаем экземпляр контроллера атаки.
            var attackController = new AttackController();

            // Набираем список используемых команд.
            var commands = new List<ICommand>
            {
                new StayIdleCommand(),
                new DesertCommand("Комсомольск на амуре"),
                new AttackCommand(attackController, "США")
            };

            // Создаем экземпляр Лидера, и коллекцию Пехотинцев.
            Console.WriteLine("(**Лидер выходит на поле**)");
            var leader = new Leader();
            var battalion = new List<Infantry>();

            // Раздаём случайные команды пехотинцам.
            for (int i = 0; i < 15; i++)
            {
                var commandPosition = Random.Next(0, 3);
                var infantry = new Infantry();
                infantry.Command = commands[commandPosition];
                leader.GiveOrdersEvent += infantry.OnLeaderOrder;
            }

            // Лидер отдаёт приказ выполнить команды.
            Console.WriteLine("(**Лидер командует**)");
            leader.StartAttack();

            Console.ReadKey();
        }
    }
}
