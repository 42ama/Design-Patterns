namespace Builder.Logic.Builder
{
    /// <summary>
    /// Бармен, использующий дешевые ингредиенты в коктейлях.
    /// </summary>
    public class CheapBartender : AbstractBartender
    {
        /// <summary>
        /// Добавить Лёд в коктейль.
        /// </summary>
        public override void AddRocks()
        {
            Cocktail.AppendLine("Плохо замороженный лёд скорее придаёт коктейлю водянистости, чем охлаждает его.");
        }

        /// <summary>
        /// Добавить Водку в коктейль.
        /// </summary>
        public override void AddVodka()
        {
            base.AddVodka();
            Cocktail.AppendLine("Чувствуется дешевая водка, более горькая чем нужно.");
        }

        /// <summary>
        /// Добавить Яблочный сидр в коктейль.
        /// </summary>
        public override void AddAppleCider()
        {
            base.AddAppleCider();
            Cocktail.AppendLine("Чувствуется дешевый яблочный сидр, как будто добавили пиво и яблочный сок.");
        }

        /// <summary>
        /// Добавить Яблочный сок в коктейль.
        /// </summary>
        public override void AddAppleJuice()
        {
            base.AddAppleJuice();
            Cocktail.AppendLine("Чувствуется немного переслащенный яблочный сок.");
        }

        /// <summary>
        /// Добавить Айриш крим в коктейль.
        /// </summary>
        public override void AddIrishCream()
        {
            base.AddIrishCream();
            Cocktail.AppendLine("Чувствуется вкус отдающий спиртом, кофе и чем-то молочным.");
        }

        /// <summary>
        /// Добавить Трипл Сек в коктейль.
        /// </summary>
        public override void AddTripleSec()
        {
            base.AddTripleSec();
            Cocktail.AppendLine("Чувствуется вкус спирта и апельсинного сока.");
        }

        /// <summary>
        /// Добавить Текилу в коктейль.
        /// </summary>
        public override void AddTequila()
        {
            base.AddTequila();
            Cocktail.AppendLine("Чувствуется вкус чего-то напоминающего водку.");
        }

        /// <summary>
        /// Добавить Джин в коктейль.
        /// </summary>
        public override void AddGin()
        {
            base.AddGin();
            Cocktail.AppendLine("Чувствуется вкус спирта и запах ели.");
        }

        /// <summary>
        /// Добавить Ром в коктейль.
        /// </summary>
        public override void AddRum()
        {
            base.AddRum();
            Cocktail.AppendLine("Чувствуется вкус чего-то напоминающего водку.");
        }

        /// <summary>
        /// Добавить Кока-колу в коктейль.
        /// </summary>
        public override void AddCola()
        {
            base.AddCola();
            Cocktail.AppendLine("Чувствуется вкус Кока-колы.");
        }

        /// <summary>
        /// Добавить Сахар в коктейль.
        /// </summary>
        public override void AddSugar()
        {
            base.AddSugar();
            Cocktail.AppendLine("Чувствуется, что напиток специально подслащён.");
        }

        /// <summary>
        /// Добавить Сливки в коктейль.
        /// </summary>
        public override void AddCream()
        {
            base.AddCream();
            Cocktail.AppendLine("Вкус напитка имеется молочные нотки.");
        }

        /// <summary>
        /// Добавить Кофейный ликер в коктейль.
        /// </summary>
        public override void AddCoffeeLiqueur()
        {
            base.AddCoffeeLiqueur();
            Cocktail.AppendLine("Чувствуется вкус отдающий спиртом, кофе и чем-то молочным.");
        }

        /// <summary>
        /// Добавить Лимон в коктейль.
        /// </summary>
        public override void AddLemon()
        {
            base.AddLemon();
            Cocktail.AppendLine("Чувствуется небольшая кислинка в напитке");
        }
    }
}
