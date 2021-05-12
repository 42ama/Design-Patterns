using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing.Data
{
    /// <summary>
    /// Событие падения рынка.
    /// </summary>
    /// <inheritdoc cref="MarketEvent"/>
    public class BearEvent : MarketEvent
    {
        /// <summary>
        /// Событие падения рынка.
        /// </summary>
        /// <param name="stock">Акция на падении.</param>
        /// <param name="delta">Величина падения.</param>
        public BearEvent(Stock stock, decimal delta)
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
            Stock.HandleBear(this);
        }

        /// <summary>
        /// Отменить событие у акции.
        /// </summary>
        public override void Rollback()
        {
            Stock.RollbackBear(this);
        }
    }
}
