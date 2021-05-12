using System;

namespace Command.Army
{
    /// <summary>
    /// Лидер, Командует пехотой.
    /// </summary>
    public class Leader
    {
        /// <summary>
        /// Выдает приказ на исполнение команды.
        /// </summary>
        public event Action GiveOrdersEvent;

        public Leader()
        {
            // Flavor text при создании Лидера.
            Console.WriteLine("Мы - не будем рабами! Но будем - завоевателями!\n");
        }

        /// <summary>
        /// Начинает атаку.
        /// </summary>
        public void StartAttack()
        {
            Console.WriteLine("В АТАКУ!\n");
            GiveOrdersEvent?.Invoke();
        }
    }
}
