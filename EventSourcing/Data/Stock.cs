using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing.Data
{
    /// <summary>
    /// Акция в портфеле обладателя, торгуемая на рынке.
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// Закончились ли торги по акции в портфеле обладателя.
        /// </summary>
        public bool IsTradingFinished { get; private set; }

        /// <summary>
        /// Тикер акции.
        /// </summary>
        public string Ticker { get; set; }

        /// <summary>
        /// Первая цена акции с начала торгов.
        /// </summary>
        public decimal OriginalPrice { get; private set; }

        /// <summary>
        /// Получена ли информация о цены акции на начало торгов.
        /// </summary>
        private bool _isOriginalPriceSet = false;

        /// <summary>
        /// Текущая цена акции.
        /// </summary>
        private decimal _price;

        /// <summary>
        /// Текущая цена акции.
        /// </summary>
        public decimal Price
        {
            get { return _price;}
            set
            {
                if (!_isOriginalPriceSet)
                {
                    OriginalPrice = value;
                    _isOriginalPriceSet = true;
                }

                _price = value;
            }
        }

        /// <summary>
        /// Дельта изменения акции от её оригинальной цены в процентах.
        /// </summary>
        public int PercentDelta
        {
            get
            {
                return (int)Math.Ceiling((Price / OriginalPrice - 1) * 100);
            }
        }

        /// <summary>
        /// Процент убытков при котором продаётся акция.
        /// </summary>
        public int StopLossPercent { get; set; } = 80;

        /// <summary>
        /// Процента дохода при котором продаётся акция.
        /// </summary>
        public int TakeProfitPercent { get; set; } = 80;


        /// <summary>
        /// Применить событие роста рынка к акции.
        /// </summary>
        /// <param name="bullEvent">Событие роста рынка.</param>
        public void HandleBull(BullEvent bullEvent)
        {
            if (bullEvent == null)
            {
                throw new ArgumentNullException(nameof(bullEvent));
            }

            if (IsTradingFinished)
            {
                return;
            }

            Price += bullEvent.Delta;

            if (PercentDelta >= 0 && PercentDelta >= TakeProfitPercent)
            {
                IsTradingFinished = true;
            }
        }

        /// <summary>
        /// Отменить событие роста рынка у акции.
        /// </summary>
        /// <param name="bullEvent">Событие роста рынка.</param>
        public void RollbackBull(BullEvent bullEvent)
        {
            if (bullEvent == null)
            {
                throw new ArgumentNullException(nameof(bullEvent));
            }

            Price -= bullEvent.Delta;

            if (PercentDelta < TakeProfitPercent)
            {
                IsTradingFinished = false;
            }
        }

        /// <summary>
        /// Применить событие падения рынка к акции.
        /// </summary>
        /// <param name="bearEvent">Событие падения рынка.</param>
        public void HandleBear(BearEvent bearEvent)
        {
            if (bearEvent == null)
            {
                throw new ArgumentNullException(nameof(bearEvent));
            }

            if (IsTradingFinished)
            {
                return;
            }

            Price -= bearEvent.Delta;

            if (PercentDelta <= 0 && Math.Abs(PercentDelta) >= StopLossPercent)
            {
                IsTradingFinished = true;
            }
        }

        /// <summary>
        /// Отменить событие падения рынка у акции.
        /// </summary>
        /// <param name="bearEvent">Событие падения рынка.</param>
        public void RollbackBear(BearEvent bearEvent)
        {
            if (bearEvent == null)
            {
                throw new ArgumentNullException(nameof(bearEvent));
            }

            Price += bearEvent.Delta;

            if (PercentDelta > 0 || Math.Abs(PercentDelta) < StopLossPercent)
            {
                IsTradingFinished = false;
            }
        }
    }
}
