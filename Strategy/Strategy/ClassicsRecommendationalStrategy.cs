using System;
using Strategy.Strategy.Interface;

namespace Strategy.Strategy
{
    /// <summary>
    /// Стратегия рекомендации Классики кино.
    /// </summary>
    public class ClassicsRecommendationalStrategy : IRecommendationalStrategy
    {
        /// <summary>
        /// Коллекция Классики кино, один фильм, из которых, будет рекомендован.
        /// </summary>
        private static string[] _cinemaCollection = { "8 1/2", "Godfather", "Ivan's childhood",
            "The Lady Vanishes", "The Big Lebowski" };

        /// <summary>
        /// Название стратегии рекомендации.
        /// </summary>
        public string StrategyName { get; } = "Classics";

        /// <summary>
        /// Рекомендовать конкретную Классику кино.
        /// </summary>
        /// <returns>Название фильма.</returns>
        public string Recommend()
        {
            // Рекомендуем согласно какому-то внутреннему алгоритму.
            return _cinemaCollection[DateTime.UtcNow.Ticks % _cinemaCollection.Length];
        }
    }
}
