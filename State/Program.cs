using System;
using System.Collections.Generic;
using State.Context;
using State.State;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ExitCode = "exit";
            
            // Инциализируем Контекст и состояния.
            var context = new DisplayContext();

            var idleTags = new HashSet<string> { "run", "sit" };
            var idleState = new IdleDisplayState(context, idleTags);
            context.Add(idleState.Tag, idleState);

            var sitTags = new HashSet<string> { "idle", "jump" };
            var sitState = new SitDisplayState(context, sitTags);
            context.Add(sitState.Tag, sitState);

            var runTags = new HashSet<string> { "idle" };
            var runState = new RunDisplayState(context, runTags);
            context.Add(runState.Tag, runState);

            var jumpTags = new HashSet<string> { "idle" };
            var jumpState = new JumpDisplayState(context, jumpTags);
            context.Add(jumpState.Tag, jumpState);

            // Устанавливаем стандартное состояние - idle.
            context.ChangeState(idleState);

            Console.WriteLine("Максим Алонов представляет:\nВеликая \"АНИМАЦИЯ\".");

            // Цикл коммуникации с пользователем.
            var userInput = "";
            while (userInput != ExitCode)
            {
                Console.Clear();
                Console.WriteLine($"Введите [{ExitCode}], чтобы завершить...");

                // Отрисовываем текущее состояние.
                context.RenderState();

                // Получаем новое состояние от пользователя и
                //  меняем состояние на него, если такая возможность есть.
                var tagsString = string.Join(" ", context.CurrentDisplayState.AvalibleTransitionsTags);
                Console.WriteLine($"Напишите одно из следующих слов :[{tagsString}]. Для смены состояния.");

                userInput = Console.ReadLine().Trim();
                if (context.CurrentDisplayState.AvalibleTransitionsTags.Contains(userInput))
                {
                    context.ChangeStateByTag(userInput);
                }
            }
        }
    }
}
