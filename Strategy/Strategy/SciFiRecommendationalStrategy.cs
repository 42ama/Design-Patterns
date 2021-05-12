using Strategy.Strategy.Interface;

namespace Strategy.Strategy
{
    /// <summary>
    /// Стратегия рекомендации Научной фантастики.
    /// </summary>
    public class SciFiRecommendationalStrategy : IRecommendationalStrategy
    {
        /// <summary>
        /// Название стратегии рекомендации.
        /// </summary>
        public string StrategyName { get; } = "SciFi";

        /// <summary>
        /// Рекомендовать конкретную Научную фантастику.
        /// </summary>
        /// <returns>Название фильма.</returns>
        public string Recommend()
        {
            return "Извините, у нас есть только StarWars";
        }
    }
}
