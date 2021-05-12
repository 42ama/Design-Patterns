using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitOfWork.Data;
using UnitOfWork.Logic;

namespace UnitOfWork
{
    [TestClass]
    public class UnitOfWorkTests
    {
        /// <summary>
        /// Подготовленные данные о собаках.
        /// </summary>
        private List<Dog> _data { get; set; } = new List<Dog>()
        {
            new Dog
            {
                Age = 7,
                Breed = Breed.Bulldog,
                Name = "Булли",
                Sex = Sex.Male
            },
            new Dog
            {
                Age = 3,
                Breed = Breed.FrenchBulldog,
                Name = "Ля Булли",
                Sex = Sex.Male
            },
            new Dog
            {
                Age = 12,
                Breed = Breed.GermanShepherd,
                Name = "Балбес",
                Sex = Sex.Male
            },
            new Dog
            {
                Age = 5,
                Breed = Breed.GoldenRetriever,
                Name = "Лайка",
                Sex = Sex.Female
            },
            new Dog
            {
                Age = 6,
                Breed = Breed.LabradorRetriever,
                Name = "Челси",
                Sex = Sex.Female
            }
        };

        /// <summary>
        /// Чистый экземпляр базы данных.
        /// </summary>
        private DogDatabase _cleanDatabase;

        /// <summary>
        /// Экземпляр базы данных с подготовленными данными.
        /// </summary>
        private DogDatabase _seededDatabase;

        /// <summary>
        /// Подготовка состояния перед каждым тестом.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _cleanDatabase = new DogDatabase();
            _seededDatabase = new DogDatabase(_data);
        }

        #region Create

        /// <summary>
        /// Создаем и коммитим запись в базе, ожидаемая запись равна полученной.
        /// </summary>
        [TestMethod]
        public void Create_CleanDatabaseCommit_ExpectedEqualActual()
        {
            var database = _cleanDatabase;
            var unitOfWork = new DogUnitOfWork(database);
            var expected = _data.First();

            unitOfWork.Create(expected);
            unitOfWork.Commit();
            var actual = database.Read(expected.Id);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Создаем и не коммитим запись в базе, полученная запись пустая.
        /// </summary>
        [TestMethod]
        public void Create_CleanDatabaseNoCommit_ActualNull()
        {
            var database = _cleanDatabase;
            var unitOfWork = new DogUnitOfWork(database);
            var expected = _data.First();

            unitOfWork.Create(expected);
            var actual = database.Read(expected.Id);

            Assert.IsNull(actual);
        }

        /// <summary>
        /// Создаем уже существующую запись в базе, получаем исключение.
        /// </summary>
        [TestMethod]
        public void Create_SeededDatabaseDataAlreadyExistsCommit_ExceptionThrown()
        {
            var unitOfWork = new DogUnitOfWork(_seededDatabase);
            var expected = _data.First();

            unitOfWork.Create(expected);
            Assert.ThrowsException<Exception>(() => unitOfWork.Commit());
        }

        #endregion

        #region Read

        /// <summary>
        /// Читаем запись по правильному Id из базы данных, ожидаемая запись равна полученной.
        /// </summary>
        [TestMethod]
        public void Read_SeededDatabaseCorrectData_ExpectedEqualActual()
        {
            var unitOfWork = new DogUnitOfWork(_seededDatabase);
            var expected = _data.First();

            var actual = unitOfWork.Read(expected.Id);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Читаем запись по неправильному Id из базы данных, полученная запись пустая.
        /// </summary>
        [TestMethod]
        public void Read_CleanDatabaseIncorrectData_ActualNull()
        {
            var unitOfWork = new DogUnitOfWork(_cleanDatabase);

            var actual = unitOfWork.Read(Guid.NewGuid());

            Assert.IsNull(actual);
        }

        #endregion

        #region Update

        /// <summary>
        /// Обновляем и коммитим запись в базе, ожидаемая запись равна полученной.
        /// </summary>
        [TestMethod]
        public void Update_SeededDatabaseCommit_ExpectedEqualActual()
        {
            var database = _seededDatabase;
            var unitOfWork = new DogUnitOfWork(database);
            var notExpected = _data.First();
            var expected = new Dog(notExpected);
            expected.Age += 1;

            unitOfWork.Update(expected.Id, expected);
            unitOfWork.Commit();
            var actual = database.Read(expected.Id);

            Assert.AreNotEqual(notExpected, actual);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Обновляем и не коммитим запись в базе, ожидаемая запись (старая) равна полученной.
        /// </summary>
        [TestMethod]
        public void Update_SeededDatabaseNoCommit_ExpectedEqualActual()
        {
            var database = _seededDatabase;
            var unitOfWork = new DogUnitOfWork(database);
            var expected = _data.First();
            var notExpected = new Dog(expected);
            notExpected.Age += 1;

            unitOfWork.Update(notExpected.Id, notExpected);
            var actual = database.Read(notExpected.Id);

            Assert.AreNotEqual(notExpected, actual);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Обновляем не существующую запись в базе, получаем исключение.
        /// </summary>
        [TestMethod]
        public void Update_CleanDatabaseCommit_ExceptionThrown()
        {
            var unitOfWork = new DogUnitOfWork(_cleanDatabase);
            var expected = _data.First();

            unitOfWork.Update(expected.Id, expected);
            Assert.ThrowsException<Exception>(() => unitOfWork.Commit());
        }

        #endregion

        #region Delete

        /// <summary>
        /// Удаляем и коммитим запись в базе, полученная запись пустая.
        /// </summary>
        [TestMethod]
        public void Delete_SeededDatabaseCommit_ActualNull()
        {
            var database = _seededDatabase;
            var unitOfWork = new DogUnitOfWork(database);
            var notExpected = _data.First();

            unitOfWork.Delete(notExpected.Id);
            unitOfWork.Commit();
            var actual = database.Read(notExpected.Id);

            Assert.IsNotNull(notExpected);
            Assert.IsNull(actual);
        }

        /// <summary>
        /// Удаляем и не коммитим запись в базе, ожидаемая запись (не удаленная) равна полученной.
        /// </summary>
        [TestMethod]
        public void Delete_SeededDatabaseNoCommit_ExpectedEqualActual()
        {
            var database = _seededDatabase;
            var unitOfWork = new DogUnitOfWork(database);
            var expected = _data.First();

            unitOfWork.Delete(expected.Id);
            var actual = database.Read(expected.Id);

            Assert.IsNotNull(expected);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Удаляем не существующую запись в базе, получаем исключение.
        /// </summary>
        [TestMethod]
        public void Delete_CleanDatabaseCommit_ExceptionThrown()
        {
            var unitOfWork = new DogUnitOfWork(_cleanDatabase);
            var expected = _data.First();

            unitOfWork.Delete(expected.Id);
            Assert.ThrowsException<Exception>(() => unitOfWork.Commit());
        }

        #endregion

        #region MultipleActions

        /// <summary>
        ///  Производим серию действий: Создать, Обновить, Обновить, Закоммитить.
        /// Ожидаемая запись равна полученной.
        /// </summary>
        [TestMethod]
        public void MultipleActions_CreateUpdateUpdateCommit_ExpectedEqualActual()
        {
            var database = _cleanDatabase;
            var unitOfWork = new DogUnitOfWork(database);
            var originalDog = _data.First();
            var updatedADog = new Dog(originalDog) { Age = originalDog.Age + 1 };
            var updatedBDog = new Dog(updatedADog) { Name = "Буль" };

            unitOfWork.Create(originalDog);
            unitOfWork.Update(updatedADog.Id, updatedADog);
            unitOfWork.Update(updatedBDog.Id, updatedBDog);
            unitOfWork.Commit();
            var actual = database.Read(updatedBDog.Id);

            Assert.AreEqual(updatedBDog, actual);
        }

        /// <summary>
        /// Производим серию действий: Создать, Обновить, Прочитать.
        /// Прочитаны ещё не зафиксированные данные.
        /// </summary>
        [TestMethod]
        public void MultipleActions_CreateUpdateRead_ExpectedEqualActual()
        {
            var database = _cleanDatabase;
            var unitOfWork = new DogUnitOfWork(database);
            var originalDog = _data.First();
            var updatedDog = new Dog(originalDog) { Age = originalDog.Age + 1 };
            var notExpected = database.Read(updatedDog.Id);

            unitOfWork.Create(originalDog);
            unitOfWork.Update(updatedDog.Id, updatedDog);
            var actual = unitOfWork.Read(updatedDog.Id);

            Assert.AreNotEqual(notExpected, actual);
            Assert.AreEqual(updatedDog, actual);
        }

        /// <summary>
        ///  Производим серию действий: Создать, Удалить, Создать, Обновить, Закоммитить.
        /// Ожидаемая запись равна полученной.
        /// </summary>
        [TestMethod]
        public void MultipleActions_CreateDeleteCreateUpdateCommit_ExpectedEqualActual()
        {
            var database = _cleanDatabase;
            var unitOfWork = new DogUnitOfWork(database);
            var originalDog = _data.First();
            var updatedDog = new Dog(originalDog) { Age = originalDog.Age + 1 };

            unitOfWork.Create(originalDog);
            unitOfWork.Delete(originalDog.Id);
            unitOfWork.Create(originalDog);
            unitOfWork.Update(updatedDog.Id, updatedDog);
            unitOfWork.Commit();
            var actual = database.Read(updatedDog.Id);

            Assert.AreEqual(updatedDog, actual);
        }

        /// <summary>
        ///  Производим серию действий: Создать, Удалить, Удалить, Закоммитить.
        /// Получаем исключение.
        /// </summary>
        [TestMethod]
        public void MultipleActions_CreateDeleteDeleteCommit_ExceptionThrown()
        {
            var database = _cleanDatabase;
            var unitOfWork = new DogUnitOfWork(database);
            var originalDog = _data.First();

            unitOfWork.Create(originalDog);
            unitOfWork.Delete(originalDog.Id);
            unitOfWork.Delete(originalDog.Id);

            Assert.ThrowsException<Exception>(() => unitOfWork.Commit()); ;
        }

        #endregion
    }
}
