using System.Collections.Generic;
using System.Text;
using Builder.Data;
using Builder.Logic;
using Builder.Logic.Builder;
using Builder.Logic.Director;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Builder
{
    /// <summary>
    /// Показательные для работы системы тесты.
    /// </summary>
    [TestClass]
    public class BuilderTests
    {
        /// <summary>
        /// Бар.
        /// </summary>
        private Bar _bar { get; set; }

        /// <summary>
        /// Дешевый бармен.
        /// </summary>
        private IBartender _cheapBartender { get; set; }

        /// <summary>
        /// Профессиональный и дорогой бармен.
        /// </summary>
        private IBartender _professionalBartender { get; set; }

        /// <summary>
        /// Финальные версии дешевых коктейлей для сравнения.
        /// </summary>
        private readonly Dictionary<string, string> _cheapCocktailsReference = new Dictionary<string, string>()
        {
            {
                CocktailNames.WhiteRussian,
                @"Чувствуется дешевая водка, более горькая чем нужно.
Чувствуется вкус отдающий спиртом, кофе и чем-то молочным.
Вкус напитка имеется молочные нотки.
Плохо замороженный лёд скорее придаёт коктейлю водянистости, чем охлаждает его.
Напиток хорошо перемешан до однородности.

Вердикт:
М-м-м! Это же Белый Русский."
            },
            {
                CocktailNames.B52,
                @"Чувствуется вкус отдающий спиртом, кофе и чем-то молочным.
Чувствуется вкус отдающий спиртом, кофе и чем-то молочным.
Чувствуется вкус спирта и апельсинного сока.
Жидкость в напитке отчетливо разделена на слои.

Вердикт:
М-м-м! Это же Б52."

            },
            {
                CocktailNames.LongIcelandIceTea,
                @"Чувствуется вкус спирта и запах ели.
Чувствуется дешевая водка, более горькая чем нужно.
Чувствуется вкус чего-то напоминающего водку.
Чувствуется вкус чего-то напоминающего водку.
Чувствуется вкус спирта и апельсинного сока.
Чувствуется небольшая кислинка в напитке
Чувствуется, что напиток специально подслащён.
Чувствуется вкус Кока-колы.
Плохо замороженный лёд скорее придаёт коктейлю водянистости, чем охлаждает его.
Напиток хорошо перемешан до однородности.

Вердикт:
М-м-м! Это же Айс Лонг-Айленд Ти."
            },
            {
                CocktailNames.Appletini,
                @"Чувствуется дешевая водка, более горькая чем нужно.
Чувствуется небольшая кислинка в напитке
Чувствуется немного переслащенный яблочный сок.
Чувствуется дешевый яблочный сидр, как будто добавили пиво и яблочный сок.
Чувствуется, что напиток специально подслащён.
Плохо замороженный лёд скорее придаёт коктейлю водянистости, чем охлаждает его.
Напиток хорошо перемешан до однородности.

Вердикт:
М-м-м! Это же Эпплтини."
            }
        };

        /// <summary>
        /// Финальные версии профессиональных коктейлей для сравнения.
        /// </summary>
        private readonly Dictionary<string, string> _professionalCocktailsReference = new Dictionary<string, string>()
        {
            {
                CocktailNames.WhiteRussian,
                @"Чувствуется дешевая водка, более горькая чем нужно.
Чувствуется вкус отдающий спиртом, кофе и чем-то молочным.
Вкус напитка имеется молочные нотки.
Коктейль хорошо охлажден льдом, что делает его вкуснее.
Напиток хорошо перемешан до однородности.

Вердикт:
М-м-м! Это же Белый Русский."
            },
            {
                CocktailNames.B52,
                @"Чувствуется вкус отдающий спиртом, кофе и чем-то молочным.
Чувствуется вкус отдающий спиртом, кофе и чем-то молочным.
Чувствуется вкус спирта и апельсинного сока.
Жидкость в напитке отчетливо разделена на слои.

Вердикт:
М-м-м! Это же Б52."

            },
            {
                CocktailNames.LongIcelandIceTea,
                @"Чувствуется вкус спирта и запах ели.
Чувствуется дешевая водка, более горькая чем нужно.
Чувствуется вкус чего-то напоминающего водку.
Чувствуется вкус чего-то напоминающего водку.
Чувствуется вкус спирта и апельсинного сока.
Чувствуется небольшая кислинка в напитке
Чувствуется, что напиток специально подслащён.
Чувствуется вкус Кока-колы.
Коктейль хорошо охлажден льдом, что делает его вкуснее.
Напиток хорошо перемешан до однородности.

Вердикт:
М-м-м! Это же Айс Лонг-Айленд Ти."
            },
            {
                CocktailNames.Appletini,
                @"Чувствуется дешевая водка, более горькая чем нужно.
Чувствуется небольшая кислинка в напитке
Чувствуется немного переслащенный яблочный сок.
Чувствуется дешевый яблочный сидр, как будто добавили пиво и яблочный сок.
Чувствуется, что напиток специально подслащён.
Коктейль хорошо охлажден льдом, что делает его вкуснее.
Напиток хорошо перемешан до однородности.

Вердикт:
М-м-м! Это же Эпплтини."
            }
        };

        /// <summary>
        /// Подготовка состояния перед каждым тестом.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _bar = new Bar();
            _cheapBartender = new CheapBartender();
            _professionalBartender = new ProfessionalBartender();
        }

        #region CheapBartender

        /// <summary>
        /// Белый русский у дешевого бармена равен эталону.
        /// </summary>
        [TestMethod]
        public void CheapBartender_WhiteRussian_EqualToReference()
        {
            // Arrange
            var expected = _cheapCocktailsReference[CocktailNames.WhiteRussian];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareWhiteRussian(_cheapBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Б52 у дешевого бармена равен эталону.
        /// </summary>
        [TestMethod]
        public void CheapBartender_B52_EqualToReference()
        {
            // Arrange
            var expected = _cheapCocktailsReference[CocktailNames.B52];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareB52(_cheapBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Лонг айленд айс ти у дешевого бармена равен эталону.
        /// </summary>
        [TestMethod]
        public void CheapBartender_LongIcelandIceTea_EqualToReference()
        {
            // Arrange
            var expected = _cheapCocktailsReference[CocktailNames.LongIcelandIceTea];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareLongIcelandIceTea(_cheapBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Эплтини у дешевого бармена равен эталону.
        /// </summary>
        [TestMethod]
        public void CheapBartender_Appletini_EqualToReference()
        {
            // Arrange
            var expected = _cheapCocktailsReference[CocktailNames.Appletini];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareAppletini(_cheapBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region ProfessionalBartender

        /// <summary>
        /// Белый русский у профессионального бармена равен эталону.
        /// </summary>
        [TestMethod]
        public void ProfessionalBartender_WhiteRussian_EqualToReference()
        {
            // Arrange
            var expected = _professionalCocktailsReference[CocktailNames.WhiteRussian];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareWhiteRussian(_professionalBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Б52 у профессионального бармена равен эталону.
        /// </summary>
        [TestMethod]
        public void ProfessionalBartender_B52_EqualToReference()
        {
            // Arrange
            var expected = _professionalCocktailsReference[CocktailNames.B52];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareB52(_professionalBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Лонг айленд айс ти у профессионального бармена равен эталону.
        /// </summary>
        [TestMethod]
        public void ProfessionalBartender_LongIcelandIceTea_EqualToReference()
        {
            // Arrange
            var expected = _professionalCocktailsReference[CocktailNames.LongIcelandIceTea];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareLongIcelandIceTea(_professionalBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Эплтини у профессионального бармена равен эталону.
        /// </summary>
        [TestMethod]
        public void ProfessionalBartender_Appletini_EqualToReference()
        {
            // Arrange
            var expected = _professionalCocktailsReference[CocktailNames.Appletini];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareAppletini(_professionalBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        /// <summary>
        /// Лонг айсленд айс ти у дешевого и дорогого барменов отличаются.
        /// </summary>
        [TestMethod]
        public void BartendersCompare_LongIcelandIceTea_DifferentResult()
        {
            //  Какие-то коктейли могут получиться одинаковыми, но самый сложный
            // Лонг-Айсленд Айс Ти точно будет разным у дешевого и профессионального бармена.

            // Act
            var cheapLongIcelandIceTea = _bar.PrepareLongIcelandIceTea(_cheapBartender);
            var professionalLongIcelandIceTea = _bar.PrepareLongIcelandIceTea(_professionalBartender);

            // Assert
            Assert.AreNotEqual(cheapLongIcelandIceTea, professionalLongIcelandIceTea);
        }
    }
}
