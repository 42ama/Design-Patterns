using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing.Data
{
    /// <summary>
    /// Событие рынка.
    /// </summary>
    public abstract class MarketEvent
    {
        /// <summary>
        /// Дата-время записи события.
        /// </summary>
        public DateTime Recorded { get; protected set; }

        /// <summary>
        /// Акция, на которую действует событие.
        /// </summary>
        public Stock Stock { get; set; }

        /// <summary>
        /// Изменение цены акции.
        /// </summary>
        public decimal Delta { get; set; }

        protected MarketEvent()
        {
            Recorded = DateTime.Now;
        }

        /// <summary>
        /// Применить событие к акции.
        /// </summary>
        public abstract void Process();

        /// <summary>
        /// Отменить событие у акции.
        /// </summary>
        public abstract void Rollback();
    }
}
