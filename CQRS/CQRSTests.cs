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
    /// �������� ���������� �������� CQRS.
    /// </summary>
    [TestClass]
    public class CQRSTests
    {
        #region Private Fields

        /// <summary>
        /// �������������� ������ � �������.
        /// </summary>
        private readonly Dictionary<string, Dog> _data = new Dictionary<string, Dog>
        {
            {
                "�����",
                new Dog("�����", "�������", 7)
            },
            {
                "�� �����",
                new Dog("�� �����", "�������", 3)
            },
            {
                "������",
                new Dog("������", "�������� �������", 12)
            },
            {
                "�����",
                new Dog("�����", "��������", 5)
            },
            {
                "�����",
                new Dog("�����", "��������", 6)
            }
        };

        /// <summary>
        /// �������� ������ � �������� ���������.
        /// </summary>
        private Context _context;

        /// <summary>
        /// ���������� ������� �������� ������.
        /// </summary>
        private CreateCommandHandler _createCommandHandler;

        /// <summary>
        /// ���������� ������� �������� ������.
        /// </summary>
        private DeleteCommandHandler _deleteCommandHandler;

        /// <summary>
        /// ���������� ������� ��������� �������� ������.
        /// </summary>
        private IncreaseAgeCommandHandler _increaseAgeCommandHandler;

        /// <summary>
        /// ���������� ������� ��������� ������ �� ������.
        /// </summary>
        private GetDogByNicknameQueryHandler _getDogByNicknameQueryHandler;

        /// <summary>
        /// ���������� ������� ��������� ����� �� ������.
        /// </summary>
        private GetDogsByBreedQueryHandler _getDogsByBreedQueryHandler;

        /// <summary>
        /// ���������� ������� ��������� �����.
        /// </summary>
        private GetDogsQueryHandler _getDogsQueryHandler;

        #endregion

        /// <summary>
        /// ���������� ��������� ����� ������ ������.
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
        /// ��������� ������� �������� ������ � ����������� �������, ��� ��������� - ������ �������.
        /// </summary>
        [TestMethod]
        public void Command_Create_NotExisting_ExpectedEqualActual()
        {
            var createCommand = new CreateCommand
            {
                Age = 15,
                Breed = "��������",
                Nickname = "�������"
            };
            var expected = new Dog(createCommand);

            _createCommandHandler.Handle(createCommand);

            var actual = _context.Dogs[createCommand.Nickname];
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ��������� ������� �������� ������ � ������������ �������, ��� ��������� - ������.
        /// </summary>
        [TestMethod]
        public void Command_Create_Existing_ThrowsException()
        {
            var createCommand = new CreateCommand
            {
                Age = 15,
                Breed = "�������",
                Nickname = _data.First().Key
            };

            Assert.ThrowsException<ArgumentException>(() => _createCommandHandler.Handle(createCommand));
        }

        /// <summary>
        /// ��������� ������� �������� ������������ ������, ��� ��������� - ������ �������.
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
        /// ��������� ������� �������� �� ������������ ������, ��� ��������� - ������ �������.
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
        /// ��������� ������� ���������� �������� ������������ ������, ��� ��������� - ������� ���������.
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
        /// ��������� ������� ���������� �������� �� ������������ ������, ��� ��������� - ������.
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
        /// ��������� ������ �� ������������ ������, �� � ������, ��� ��������� - ������ �������.
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
        /// ��������� ������ �� �� ������������ ������, �� � ������, ��� ��������� - ������.
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
        /// ��������� ������ �� �� ����� ����� �� ������������ ������, ��� ��������� - ������ �������.
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
        /// ��������� ������ �� �� ����� ����� �� ������������ ������, ��� ��������� - ������ ������� (� ���������� 0).
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
        /// ��������� ������ �� �� ����� �����, ��� ��������� - ������ �������.
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
