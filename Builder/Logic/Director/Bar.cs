using System;
using Builder.Logic.Builder;

namespace Builder.Logic.Director
{
    /// <summary>
    ///  Директор, определяет порядок вызова строительных шагов, для
    /// выбранного строителя.
    /// </summary>
    public class Bar
    {
        /// <summary>
        /// Приготовить Белый русский.
        /// </summary>
        /// <param name="bartender">Бармен, который будет готовить коктейль.</param>
        /// <returns>Смешанный коктейль.</returns>
        public string PrepareWhiteRussian(IBartender bartender)
        {
            if (bartender == null)
            {
                throw new ArgumentNullException(nameof(bartender));
            }

            bartender.ResetCocktail();
            bartender.AddVodka();
            bartender.AddCoffeeLiqueur();
            bartender.AddCream();
            bartender.Shake();
            bartender.AddRocks();
            return bartender.GetCocktail();
        }

        /// <summary>
        /// Приготовить Б52.
        /// </summary>
        /// <param name="bartender">Бармен, который будет готовить коктейль.</param>
        /// <returns>Смешанный коктейль.</returns>
        public string PrepareB52(IBartender bartender)
        {
            if (bartender == null)
            {
                throw new ArgumentNullException(nameof(bartender));
            }

            bartender.ResetCocktail();
            bartender.AddIrishCream();
            bartender.AddCoffeeLiqueur();
            bartender.AddTripleSec();
            return bartender.GetCocktail();
        }

        /// <summary>
        /// Приготовить Лонг-Айленд Ти.
        /// </summary>
        /// <param name="bartender">Бармен, который будет готовить коктейль.</param>
        /// <returns>Смешанный коктейль.</returns>
        public string PrepareLongIcelandIceTea(IBartender bartender)
        {
            if (bartender == null)
            {
                throw new ArgumentNullException(nameof(bartender));
            }

            bartender.ResetCocktail();
            bartender.AddGin();
            bartender.AddVodka();
            bartender.AddRum();
            bartender.AddTequila();
            bartender.AddTripleSec();
            bartender.AddLemon();
            bartender.AddSugar();
            bartender.AddCola();
            bartender.Shake();
            bartender.AddRocks();
            return bartender.GetCocktail();
        }

        /// <summary>
        /// Приготовить Эпплтини.
        /// </summary>
        /// <param name="bartender">Бармен, который будет готовить коктейль.</param>
        /// <returns>Смешанный коктейль.</returns>
        public string PrepareAppletini(IBartender bartender)
        {
            if (bartender == null)
            {
                throw new ArgumentNullException(nameof(bartender));
            }

            bartender.ResetCocktail();
            bartender.AddVodka();
            bartender.AddLemon();
            bartender.AddAppleJuice();
            bartender.AddAppleCider();
            bartender.AddSugar();
            bartender.Shake();
            bartender.AddRocks();
            return bartender.GetCocktail();
        }
    }
}
