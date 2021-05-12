namespace Builder.Logic.Builder
{
    /// <summary>
    /// Интерфейс взаимодействий Бармена - смешивание коктейлей.
    /// </summary>
    public interface IBartender
    {
        /// <summary>
        /// Начать процесс смешивания коктейля заново.
        /// </summary>
        void ResetCocktail();

        /// <summary>
        /// Добавить Водку в коктейль.
        /// </summary>
        void AddVodka();

        /// <summary>
        /// Добавить Ром в коктейль.
        /// </summary>
        void AddRum();

        /// <summary>
        /// Добавить Джин в коктейль.
        /// </summary>
        void AddGin();

        /// <summary>
        /// Добавить Текилу в коктейль.
        /// </summary>
        void AddTequila();

        /// <summary>
        /// Добавить Трипл Сек в коктейль.
        /// </summary>
        void AddTripleSec();

        /// <summary>
        /// Добавить Айриш крим в коктейль.
        /// </summary>
        void AddIrishCream();

        /// <summary>
        /// Добавить Яблочный сок в коктейль.
        /// </summary>
        void AddAppleJuice();

        /// <summary>
        /// Добавить Яблочный сидр в коктейль.
        /// </summary>
        void AddAppleCider();

        /// <summary>
        /// Добавить Лимон в коктейль.
        /// </summary>
        void AddLemon();

        /// <summary>
        /// Добавить Лёд в коктейль.
        /// </summary>
        void AddRocks();

        /// <summary>
        /// Добавить Кофейный ликер в коктейль.
        /// </summary>
        void AddCoffeeLiqueur();

        /// <summary>
        /// Добавить Сливки в коктейль.
        /// </summary>
        void AddCream();

        /// <summary>
        /// Перемешать коктейль.
        /// </summary>
        void Shake();

        /// <summary>
        /// Добавить Сахар в коктейль.
        /// </summary>
        void AddSugar();

        /// <summary>
        /// Добавить Кока-колу в коктейль.
        /// </summary>
        void AddCola();

        /// <summary>
        /// Закончить смешивание коктейля и предоставить результат.
        /// </summary>
        /// <returns>Результат смешивания коктейля.</returns>
        string GetCocktail();
    }
}
