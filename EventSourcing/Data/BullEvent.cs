using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing.Data
{
    /// <summary>
    /// Событие роста рынка.
    /// </summary>
    /// <inheritdoc cref="MarketEvent"/>
    public class BullEvent : MarketEvent
    {
        /// <summary>
        /// Событие роста рынка.
        /// </summary>
        /// <param name="stock">Акция на росте.</param>
        /// <param name="delta">Величина роста.</param>
        public BullEvent(Stock stock, decimal delta)
        {
            if (delta <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(delta));
            }

            Stock = stock ?? throw new ArgumentNullException(nameof(stock));
            Delta = delta;
        }

        /// <summary>
        /// Применить событие к акции.
        /// </summary>
        public override void Process()
        {
            Stock.HandleBull(this);
        }

        /// <summary>
        /// Отменить событие у акции.
        /// </summary>
        public override void Rollback()
        {
            Stock.RollbackBull(this);
        }
    }
}
