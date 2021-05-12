using System;
using System.Collections.Generic;
using Strategy.Controller;
using Strategy.User;

namespace Strategy
{
    class Program
    {
        /// <summary>
        /// Единственный экземпляр генератора чисел для программы.
        /// </summary>
        public static Random Random = new Random();

        static void Main(string[] args)
        {
            // Имена пользователей, которые хотят зарегистрироваться в Netflix.
            var userNamesList = new List<string> { "Pavel Panfilov",
                "Oleg Kharitonov", "Alexey Klokov", "Ivan Simonov",
                "Alexander Azarenok", "Egor Kirnos", "Egor Ter'ehin",
                "Daniil Gulak"};

            // Выставить оценки каждому пользователю и порекомендовать фильм.
            foreach (var userName in userNamesList)
            {
                // Создать пользователя Нетфликса.
                var netflixUser = new NetflixUser
                {
                    Name = userName,
                    ComedyAppeal = Random.Next(0, 11),
                    DramaAppeal = Random.Next(0, 11),
                    MusicalAppeal = Random.Next(0, 11)
                };

                // Выбрать стратегию в зависимости от предпочтений.
                var strategy = StrategyPicker.PickStrategyForUser(netflixUser);
                // Порекомендовать в зависимости от стратегии.
                var strategyRecommendation = strategy.Recommend();

                Console.WriteLine($"Я {netflixUser.Name}, мои оценки Драма: {netflixUser.DramaAppeal}, Комедия: {netflixUser.ComedyAppeal}, Мюзикл: {netflixUser.MusicalAppeal}\n" +
                    $"  С помощью стратегии {strategy.StrategyName}, мне порекомендовали {strategyRecommendation}.\n");
            }


        }
    }
}
