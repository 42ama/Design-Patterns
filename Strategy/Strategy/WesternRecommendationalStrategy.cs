using System;
using Strategy.Strategy.Interface;

namespace Strategy.Strategy
{
    /// <summary>
    /// Стратегия рекомендации Вестернов.
    /// </summary>
    public class WesternRecommendationalStrategy : IRecommendationalStrategy
    {
        /// <summary>
        /// Коллекция Вестернов, один из которых будет рекомендован.
        /// </summary>
        private static readonly string[] _cinemaCollection = 
        {
            "High Noon", "The Good, the Bad and the Ugly", "Unforgiven",
            "A Fistful of Dollars", "Johnny Guitar"
        };

        /// <summary>
        /// Название стратегии рекомендации.
        /// </summary>
        public string StrategyName { get; } = "Western";

        /// <summary>
        /// Рекомендовать конкретный Вестерн.
        /// </summary>
        /// <returns>Название фильма.</returns>
        public string Recommend()
        {
            // Рекомендуем согласно какому-то внутреннему алгоритму.
            var ticks = DateTime.UtcNow.Ticks;

            long cinemaRating = 0;
            var selectedCinema = "";
            foreach (var cinema in _cinemaCollection)
            {
                var pretenderRating = ticks % cinema.Length;
                if (pretenderRating > cinemaRating)
                {
                    selectedCinema = cinema;
                    cinemaRating = pretenderRating;
                }
            }

            return selectedCinema;
        }
    }
}
