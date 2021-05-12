﻿using System;
using System.Collections.Generic;
using State.Context;
using State.State.AbstractInterface;

namespace State.State
{
    /// <summary>
    /// Состояние в Присяде.
    /// </summary>
    public class SitDisplayState : AbstractDisplayState
    {
        /// <summary>
        /// Инициализирует новый экземпляр Состояния в Присяде.
        /// </summary>
        /// <param name="displayContext">Контекст отображения.</param>
        /// <param name="avalibleTransitions">Набор тэгов состояний в которые можно перейти.</param>
        public SitDisplayState(DisplayContext displayContext, ISet<string> avalibleTransitions) : base(displayContext, avalibleTransitions)
        {
            Tag = "sit";
        }

        public override void Render()
        {
            base.Render();

            var b = DisplayContext.BodySymbol;
            var e = DisplayContext.EyeSymbol;
            var c = DisplayContext.CapeSymbol;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"        {b}{b}{b}");
            Console.WriteLine($"     {b}{b}{b}{b}{b}{b}{b}{b}");
            Console.WriteLine($"  {b}{b}{b}{b}{b}{b}{b}{b}{b}{b}{b}{b}");
            Console.WriteLine($"   {b}{b}{b}{b}{b}{b}{b}{b}{b}{b}{b}");
            Console.WriteLine($"    {b}{b}{b}{e}{e}{b}{b}{e}{b}{b}");
            Console.WriteLine($"    {b}{b}{b}{e}{e}{b}{b}{e}{b}{b}");
            Console.WriteLine($"    {b}{b}{b}{e}{e}{b}{b}{e}{b}{b}");
            Console.WriteLine($"     {b}{b}{b}{b}{b}{b}{b}{b}");
            Console.WriteLine($"      {b}{b}{b}{b}{b}{b}");
            Console.WriteLine($"     {c}{c}{c}{c}{c}{c}{c}");
            Console.WriteLine($"     {c}{c}{b}{b}{b}{b}{c}");
            Console.WriteLine($"     {c}{c}{b}{b}{b}{b}{c}");
            Console.WriteLine($"     {c}{c}{b}{b}{b}{b}{c}");
            Console.WriteLine($"     {c}{c}{b}{b}{b}{b}{c}");
            Console.WriteLine($"     {c}{c}{b}{c}{b}{b}{c}");

        }
    }
}
