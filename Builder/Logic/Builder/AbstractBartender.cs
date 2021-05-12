using System.Collections.Generic;
using System.Linq;
using System.Text;
using Builder.Data;

namespace Builder.Logic.Builder
{
    /// <summary>
    /// Бармен. Базовый класс "Строителя".
    /// </summary>
    /// <inheritdoc cref="IBartender"/>
    public abstract class AbstractBartender : IBartender
    {
        /// <summary>
        /// Перемешан ли напиток.
        /// </summary>
        protected bool IsShaken { get; set; } = false;

        /// <summary>
        /// Описание текущего коктейля.
        /// </summary>
        protected StringBuilder Cocktail { get; set; } = new StringBuilder();

        /// <summary>
        /// Список рецептов, которые знает Бармен.
        /// </summary>
        protected IDictionary<string, ISet<Ingredients>> Recipes { get; } = new Dictionary<string, ISet<Ingredients>>()
        {
            {
                CocktailNames.WhiteRussian,
                new HashSet<Ingredients>()
                {
                    Ingredients.Vodka, Ingredients.CoffeeLiqueur, Ingredients.Cream
                }
            },
            {
                CocktailNames.B52,
                new HashSet<Ingredients>()
                {
                    Ingredients.IrishCream, Ingredients.CoffeeLiqueur, Ingredients.TripleSec
                }

            },
            {
                CocktailNames.LongIcelandIceTea,
                new HashSet<Ingredients>() 
                {
                    Ingredients.Gin, Ingredients.Vodka, Ingredients.Rum, Ingredients.Tequila,
                    Ingredients.TripleSec, Ingredients.Lemon, Ingredients.Sugar, Ingredients.Cola

                }
            },
            {
                CocktailNames.Appletini,
                new HashSet<Ingredients>()
                {
                    Ingredients.Vodka, Ingredients.Lemon, Ingredients.AppleCider, Ingredients.AppleJuice, Ingredients.Sugar
                }

            },
        };

        /// <summary>
        /// Список ингредиентов текущего коктейля.
        /// </summary>
        protected ISet<Ingredients> CurrentIngredients { get; set; } = new HashSet<Ingredients>();

        /// <summary>
        /// Начать процесс смешивания коктейля заново.
        /// </summary>
        public void ResetCocktail()
        {
            IsShaken = false;
            Cocktail = new StringBuilder();
            CurrentIngredients = new HashSet<Ingredients>();
        }

        /// <summary>
        /// Закончить смешивание коктейля и предоставить результат.
        /// </summary>
        /// <returns>Результат смешивания коктейля.</returns>
        public string GetCocktail()
        {
            var acceptableRecipes = Recipes.Where(kvp => kvp.Value.SetEquals(CurrentIngredients)).ToList();

            var message = acceptableRecipes.Count switch
            {
                0 => "Коктейль из всех возможных вариантов не напоминает ничего конкретного, но довольно вкусный.",
                1 => $"М-м-м! Это же {acceptableRecipes.First().Key}.",
                _ => $"Коктейль отдаленно напоминает {string.Join(", и ", acceptableRecipes.Select(kvp => kvp.Key))}.",
            };

            var consistencyMessage = IsShaken
                ? "Напиток хорошо перемешан до однородности."
                : "Жидкость в напитке отчетливо разделена на слои.";

            Cocktail.AppendLine(consistencyMessage);
            Cocktail.AppendLine();
            Cocktail.AppendLine("Вердикт:");
            Cocktail.AppendLine(message);
            return Cocktail.ToString();
        }


        /// <summary>
        /// Добавить Водку в коктейль.
        /// </summary>
        public virtual void AddVodka()
        {
            CurrentIngredients.Add(Ingredients.Vodka);
        }

        /// <summary>
        /// Добавить Ром в коктейль.
        /// </summary>
        public virtual void AddRum()
        {
            CurrentIngredients.Add(Ingredients.Rum);
        }

        /// <summary>
        /// Добавить Джин в коктейль.
        /// </summary>
        public virtual void AddGin()
        {
            CurrentIngredients.Add(Ingredients.Gin);
        }

        /// <summary>
        /// Добавить Текилу в коктейль.
        /// </summary>
        public virtual void AddTequila()
        {
            CurrentIngredients.Add(Ingredients.Tequila);
        }

        /// <summary>
        /// Добавить Трипл Сек в коктейль.
        /// </summary>
        public virtual void AddTripleSec()
        {
            CurrentIngredients.Add(Ingredients.TripleSec);
        }

        /// <summary>
        /// Добавить Айриш крим в коктейль.
        /// </summary>
        public virtual void AddIrishCream()
        {
            CurrentIngredients.Add(Ingredients.IrishCream);
        }

        /// <summary>
        /// Добавить Яблочный сок в коктейль.
        /// </summary>
        public virtual void AddAppleJuice()
        {
            CurrentIngredients.Add(Ingredients.AppleJuice);
        }

        /// <summary>
        /// Добавить Яблочный сидр в коктейль.
        /// </summary>
        public virtual void AddAppleCider()
        {
            CurrentIngredients.Add(Ingredients.AppleCider);
        }

        /// <summary>
        /// Добавить Лимон в коктейль.
        /// </summary>
        public virtual void AddLemon()
        {
            CurrentIngredients.Add(Ingredients.Lemon);
        }

        /// <summary>
        /// Добавить Кофейный ликер в коктейль.
        /// </summary>
        public virtual void AddCoffeeLiqueur()
        {
            CurrentIngredients.Add(Ingredients.CoffeeLiqueur);
        }

        /// <summary>
        /// Добавить Сливки в коктейль.
        /// </summary>
        public virtual void AddCream()
        {
            CurrentIngredients.Add(Ingredients.Cream);
        }

        /// <summary>
        /// Добавить Сахар в коктейль.
        /// </summary>
        public virtual void AddSugar()
        {
            CurrentIngredients.Add(Ingredients.Sugar);
        }

        /// <summary>
        /// Добавить Кока-колу в коктейль.
        /// </summary>
        public virtual void AddCola()
        {
            CurrentIngredients.Add(Ingredients.Cola);
        }

        /// <summary>
        /// Добавить Сахар в коктейль.
        /// </summary>
        public virtual void Shake()
        {
            IsShaken = true;
        }

        /// <summary>
        /// Добавить Лёд в коктейль.
        /// </summary>
        public abstract void AddRocks();
    }
}
