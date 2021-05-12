using System;
using Strategy.Strategy;
using Strategy.Strategy.Interface;
using Strategy.User;

namespace Strategy.Controller
{
    /// <summary>
    /// Система выбора стратегии рекомендации, исходя из оценок пользователя.
    /// </summary>
    public static class StrategyPicker
    {
        /// <summary>
        /// Экземпляр стратегии рекомендации Классики кино.
        /// </summary>
        private static readonly ClassicsRecommendationalStrategy _classics = new ClassicsRecommendationalStrategy();

        /// <summary>
        /// Экземпляр стратегии рекомендации Научной фантастики.
        /// </summary>
        private static readonly SciFiRecommendationalStrategy _sciFi = new SciFiRecommendationalStrategy();

        /// <summary>
        /// Экземпляр стратегии рекомендации Вестернов.
        /// </summary>
        private static readonly WesternRecommendationalStrategy _western = new WesternRecommendationalStrategy();

        /// <summary>
        /// Выбрать стратегию рекомендации, исходя из вкусов пользователя.
        /// </summary>
        /// <param name="user">Пользователь, на основании чьих вкусов будет избрана стратегия.</param>
        /// <returns>Стратегия рекомендации.</returns>
        public static IRecommendationalStrategy PickStrategyForUser(NetflixUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            // Набираем оценки стратегий, исходя из вкусов пользвоателя.
            var classicsRating = (user.ComedyAppeal + user.MusicalAppeal) / (user.DramaAppeal * 0.25);
            var sciFiRating = (user.DramaAppeal + user.MusicalAppeal) / (user.ComedyAppeal * 0.25);
            var westernRating = (user.DramaAppeal + user.ComedyAppeal) / (user.MusicalAppeal * 0.25);

            // Выбираем конкретную стратегию на основании оценок.
            // По-умолчанию рекомендуем классику.
            IRecommendationalStrategy strategy = _classics;
            if (classicsRating > sciFiRating && classicsRating > westernRating)
            {
                strategy = _classics;
            }
            else if (sciFiRating > classicsRating && sciFiRating > westernRating)
            {
                strategy = _sciFi;
            }
            else if (westernRating > classicsRating && westernRating > sciFiRating)
            {
                strategy = _western;
            }

            return strategy;
        }
    }
}
