using System;
using EventSourcing.Data;
using EventSourcing.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventSourcing
{
    /// <summary>
    /// Показательные для работы системы тесты.
    /// </summary>
    [TestClass]
    public class EventSourcingTests
    {
        /// <summary>
        /// Обработчик событий рынка.
        /// </summary>
        private EventProcessor _eventProcessor { get; set; }

        /// <summary>
        /// Тестируемая акция.
        /// </summary>
        private Stock _baseAppleStock { get; set; }

        /// <summary>
        /// Подготовка состояния перед каждым тестом.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _eventProcessor = new EventProcessor();
            _baseAppleStock = new Stock()
            {
                Price = 137.4M,
                Ticker = "AAPL"
            };
        }

        /// <summary>
        /// Происходят несколько событий роста рынков, новая цена равна ожидаемой.
        /// </summary>
        [TestMethod]
        public void SeveralEvents_BullMarket_NewPriceEqualExpected()
        {
            var expectedPrice = _baseAppleStock.Price + 15;
            _eventProcessor.Process(new BullEvent(_baseAppleStock, 5));
            _eventProcessor.Process(new BullEvent(_baseAppleStock, 5));
            _eventProcessor.Process(new BullEvent(_baseAppleStock, 5));

            Assert.AreEqual(expectedPrice, _baseAppleStock.Price);
        }

        /// <summary>
        /// Происходит несколько крупных событий роста рынков, произошла автоматическая продажа акции.
        /// </summary>
        [TestMethod]
        public void SeveralEvents_HugeBullMarket_TakeProfitCompleted()
        {
            _eventProcessor.Process(new BullEvent(_baseAppleStock, 50));
            _eventProcessor.Process(new BullEvent(_baseAppleStock, 50));
            _eventProcessor.Process(new BullEvent(_baseAppleStock, 50));

            Assert.IsTrue(_baseAppleStock.IsTradingFinished);
        }

        /// <summary>
        /// Происходит несколько разных событий, новая цена равна ожидаемой.
        /// </summary>
        [TestMethod]
        public void SeveralEvents_MixedMarket_NewPriceEqualExpected()
        {
            var expectedPrice = _baseAppleStock.Price + 5;
            _eventProcessor.Process(new BullEvent(_baseAppleStock, 5));
            _eventProcessor.Process(new BearEvent(_baseAppleStock, 5));
            _eventProcessor.Process(new BullEvent(_baseAppleStock, 5));

            Assert.AreEqual(expectedPrice, _baseAppleStock.Price);
        }

        /// <summary>
        /// Происходит несколько крупных падений рынков, произошла автоматическая продажа акции.
        /// </summary>
        [TestMethod]
        public void SeveralEvents_HugeBearMarket_StopLossCompleted()
        {
            _eventProcessor.Process(new BearEvent(_baseAppleStock, 50));
            _eventProcessor.Process(new BearEvent(_baseAppleStock, 50));
            _eventProcessor.Process(new BearEvent(_baseAppleStock, 50));

            Assert.IsTrue(_baseAppleStock.IsTradingFinished);
        }

        /// <summary>
        /// Происходит серия событий на рынке, потом происходит корректный откат на одно из них.
        /// </summary>
        [TestMethod]
        public void SeveralEvents_MixedMarket_RollbackCorrect()
        {
            var expectedIntermediatePrice = _baseAppleStock.OriginalPrice + 4 + 6 + 5 + 12 - 6;
            var expectedPrice = _baseAppleStock.OriginalPrice + 4 + 6 + 5;
            _eventProcessor.Process(new BullEvent(_baseAppleStock, 4));
            _eventProcessor.Process(new BullEvent(_baseAppleStock, 6));
            var rollbackEvent = new BullEvent(_baseAppleStock, 5);
            _eventProcessor.Process(rollbackEvent);
            _eventProcessor.Process(new BullEvent(_baseAppleStock, 12));
            _eventProcessor.Process(new BearEvent(_baseAppleStock, 6));
            var intermediatePrice = _baseAppleStock.Price;

            _eventProcessor.RollbackToDateTime(rollbackEvent.Recorded);

            Assert.AreEqual(expectedIntermediatePrice, intermediatePrice);
            Assert.AreEqual(expectedPrice, _baseAppleStock.Price);
        }

        /// <summary>
        /// Откат на незаписанное событие вызывает ошибку.
        /// </summary>
        [TestMethod]
        public void ThrowsExceptionOnRollbackToIncorrectDate()
        {
            _eventProcessor.Process(new BullEvent(_baseAppleStock, 6));

            Assert.ThrowsException<Exception>(() => _eventProcessor.RollbackToDateTime(DateTime.Now));
        }
    }
}
