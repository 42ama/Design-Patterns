

namespace Strategy.Strategy.Interface
{
    /// <summary>
    /// Интерфейс объединяющий стратегии рекомендации фильмов.
    /// </summary>
    public interface IRecommendationalStrategy
    {
        /// <summary>
        /// Название стратегии рекомендации.
        /// </summary>
        string StrategyName { get; }

        /// <summary>
        /// Рекомендовать конкретный фильм, исходя из логики стратегии.
        /// </summary>
        /// <returns>Название фильма.</returns>
        string Recommend();
    }
}
