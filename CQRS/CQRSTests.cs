using System;
using System.Collections.Generic;
using System.Linq;
using CQRS.Data;
using CQRS.Logic.Command;
using CQRS.Logic.Query;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CQRS
{
    /// <summary>
    /// Проверки реализации паттерна CQRS.
    /// </summary>
    [TestClass]
    public class CQRSTests
    {
        #region Private Fields

        /// <summary>
        /// Подготовленные данные о собаках.
        /// </summary>
        private readonly Dictionary<string, Dog> _data = new Dictionary<string, Dog>
        {
            {
                "Булли",
                new Dog("Булли", "Бульдог", 7)
            },
            {
                "Ля Булли",
                new Dog("Ля Булли", "Бульдог", 3)
            },
            {
                "Балбес",
                new Dog("Балбес", "Немецкая овчарка", 12)
            },
            {
                "Лайка",
                new Dog("Лайка", "Ретривер", 5)
            },
            {
                "Челси",
                new Dog("Челси", "Ретривер", 6)
            }
        };

        /// <summary>
        /// Контекст данных о собачьем питомнике.
        /// </summary>
        private Context _context;

        /// <summary>
        /// Обработчик команды создания собаки.
        /// </summary>
        private CreateCommandHandler _createCommandHandler;

        /// <summary>
        /// Обработчик команды удаления собаки.
        /// </summary>
        private DeleteCommandHandler _deleteCommandHandler;

        /// <summary>
        /// Обработчик команды повышения возраста собаки.
        /// </summary>
        private IncreaseAgeCommandHandler _increaseAgeCommandHandler;

        /// <summary>
        /// Обработчик запроса получения собаки по кличке.
        /// </summary>
        private GetDogByNicknameQueryHandler _getDogByNicknameQueryHandler;

        /// <summary>
        /// Обработчик запроса получения собак по породе.
        /// </summary>
        private GetDogsByBreedQueryHandler _getDogsByBreedQueryHandler;

        /// <summary>
        /// Обработчик запроса получения собак.
        /// </summary>
        private GetDogsQueryHandler _getDogsQueryHandler;

        #endregion

        /// <summary>
        /// Подготовка состояния перед каждым тестом.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _context = new Context(_data);

            _createCommandHandler = new CreateCommandHandler(_context);
            _deleteCommandHandler = new DeleteCommandHandler(_context);
            _increaseAgeCommandHandler = new IncreaseAgeCommandHandler(_context);

            _getDogByNicknameQueryHandler = new GetDogByNicknameQueryHandler(_context);
            _getDogsByBreedQueryHandler = new GetDogsByBreedQueryHandler(_context);
            _getDogsQueryHandler = new GetDogsQueryHandler(_context);
        }

        #region Command

        /// <summary>
        /// Выполняем команду создания собаки с корректными данными, как результат - собака создана.
        /// </summary>
        [TestMethod]
        public void Command_Create_NotExisting_ExpectedEqualActual()
        {
            var createCommand = new CreateCommand
            {
                Age = 15,
                Breed = "Ретривер",
                Nickname = "Золотко"
            };
            var expected = new Dog(createCommand);

            _createCommandHandler.Handle(createCommand);

            var actual = _context.Dogs[createCommand.Nickname];
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Выполняем команду создания собаки с существующей кличкой, как результат - ошибка.
        /// </summary>
        [TestMethod]
        public void Command_Create_Existing_ThrowsException()
        {
            var createCommand = new CreateCommand
            {
                Age = 15,
                Breed = "Бульдог",
                Nickname = _data.First().Key
            };

            Assert.ThrowsException<ArgumentException>(() => _createCommandHandler.Handle(createCommand));
        }

        /// <summary>
        /// Выполняем команду удаления существующей собаки, как результат - собака удалена.
        /// </summary>
        [TestMethod]
        public void Command_Delete_Existing_Deleted()
        {
            var deleteCommand = new DeleteCommand
            {
                Nickname = _data.First().Key
            };
            Assert.IsTrue(_context.Dogs.ContainsKey(deleteCommand.Nickname));

            _deleteCommandHandler.Handle(deleteCommand);

            Assert.IsFalse(_context.Dogs.ContainsKey(deleteCommand.Nickname));
        }

        /// <summary>
        /// Выполняем команду удаления не существующей собаки, как результат - собака удалена.
        /// </summary>
        [TestMethod]
        public void Command_Delete_NotExisting_Deleted()
        {
            var deleteCommand = new DeleteCommand
            {
                Nickname = Guid.NewGuid().ToString()
            };
            Assert.IsFalse(_context.Dogs.ContainsKey(deleteCommand.Nickname));

            _deleteCommandHandler.Handle(deleteCommand);

            Assert.IsFalse(_context.Dogs.ContainsKey(deleteCommand.Nickname));
        }

        /// <summary>
        /// Выполняем команду увеличения возраста существующей собаки, как результат - возраст изменился.
        /// </summary>
        [TestMethod]
        public void Command_IncreaseAge_Existing_Increased()
        {
            var increaseAgeCommand = new IncreaseAgeCommand
            {
                Nickname = _data.First().Key
            };
            var oldDogAge = _data[increaseAgeCommand.Nickname].Age;

            _increaseAgeCommandHandler.Handle(increaseAgeCommand);

            var newDogAge = _data[increaseAgeCommand.Nickname].Age;
            Assert.AreNotEqual(oldDogAge, newDogAge);
        }

        /// <summary>
        /// Выполняем команду увеличения возраста не существующей собаки, как результат - ошибка.
        /// </summary>
        [TestMethod]
        public void Command_IncreaseAge_NotExisting_ThrowsException()
        {
            var increaseAgeCommand = new IncreaseAgeCommand
            {
                Nickname = Guid.NewGuid().ToString()
            };

            Assert.ThrowsException<ArgumentException>(() => _increaseAgeCommandHandler.Handle(increaseAgeCommand));
        }

        #endregion

        #region Query

        /// <summary>
        /// Выполняем запрос на существующую собаку, по её кличке, как результат - собака найдена.
        /// </summary>
        [TestMethod]
        public void Query_GetDogByNickname_Existing_ExpectedEqualActual()
        {
            var expected = _data.First().Value;
            var query = new GetDogByNicknameQuery
            {
                Nickname = expected.Nickname
            };

            var actual = _getDogByNicknameQueryHandler.Handle(query);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Выполняем запрос на не существующую собаку, по её кличке, как результат - ошибка.
        /// </summary>
        [TestMethod]
        public void Query_GetDogByNickname_NotExisting_ThrowsException()
        {
            var query = new GetDogByNicknameQuery
            {
                Nickname = Guid.NewGuid().ToString()
            };

            Assert.ThrowsException<ArgumentException>(() => _getDogByNicknameQueryHandler.Handle(query));
        }

        /// <summary>
        /// Выполняем запрос на на поиск собак по существующей породе, как результат - собаки найдены.
        /// </summary>
        [TestMethod]
        public void Query_GetDogByBreed_Existing_ExpectedEquivalentActual()
        {
            var dogsBreed = _data.First().Value.Breed;
            var expected = _data.Values.Where(i => i.Breed == dogsBreed);
            var query = new GetDogsByBreedQuery
            {
                Breed = dogsBreed
            };

            var actual = _getDogsByBreedQueryHandler.Handle(query);

            CollectionAssert.AreEquivalent(expected.ToArray(), actual.ToArray());
        }

        /// <summary>
        /// Выполняем запрос на на поиск собак по существующей породе, как результат - собаки найдены (в количестве 0).
        /// </summary>
        [TestMethod]
        public void Query_GetDogByBreed_NotExisting_ExpectedEquivalentActual()
        {
            var dogsBreed = Guid.NewGuid().ToString();
            var expected = _data.Values.Where(i => i.Breed == dogsBreed);
            var query = new GetDogsByBreedQuery
            {
                Breed = dogsBreed
            };

            var actual = _getDogsByBreedQueryHandler.Handle(query);

            CollectionAssert.AreEquivalent(expected.ToArray(), actual.ToArray());
        }

        /// <summary>
        /// Выполняем запрос на на поиск собак, как результат - собаки найдены.
        /// </summary>
        [TestMethod]
        public void Query_GetDogs_Existing_ExpectedEquivalentActual()
        {
            var expected = _data.Values;
            var query = new GetDogsQuery();

            var actual = _getDogsQueryHandler.Handle(query);

            CollectionAssert.AreEquivalent(expected.ToArray(), actual.ToArray());
        }

        #endregion
    }
}
