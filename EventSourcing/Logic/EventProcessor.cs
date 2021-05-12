using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventSourcing.Data;

namespace EventSourcing.Logic
{
    /// <summary>
    /// Обработчик событий рынка.
    /// </summary>
    public class EventProcessor
    {
        /// <summary>
        /// Коллекция произошедших событий рынка.
        /// </summary>
        public List<MarketEvent> MarketEvents { get; set; } = new List<MarketEvent>();

        /// <summary>
        /// Набор дат-времени произошедших событий рынка.
        /// </summary>
        public HashSet<DateTime> UsedDateTimes { get; set; } = new HashSet<DateTime>();

        /// <summary>
        /// Применяет и запоминает информацию о событии рынка.
        /// </summary>
        /// <param name="marketEvent">Событие рынка.</param>
        public void Process(MarketEvent marketEvent)
        {
            if (marketEvent == null)
            {
                throw new ArgumentNullException(nameof(marketEvent));
            }

            marketEvent.Process();
            MarketEvents.Add(marketEvent);
            UsedDateTimes.Add(marketEvent.Recorded);
        }

        /// <summary>
        /// Откатывает цепочку событий, до события с переданной датой-временем.
        /// </summary>
        /// <param name="rollbackTime">Дата-время события, до которого нужно откатиться.</param>
        public void RollbackToDateTime(DateTime rollbackTime)
        {
            if (!UsedDateTimes.Contains(rollbackTime))
            {
                throw new Exception("Возможно откатиться только на уже добавленную дату.");
            }

            var eventsToProcess = MarketEvents
                .Where(i => i.Recorded > rollbackTime)
                .Reverse()
                .ToArray();

            if (!eventsToProcess.Any())
            {
                return;
            }

            foreach (var eventToProcess in eventsToProcess)
            {
                UsedDateTimes.Remove(eventToProcess.Recorded);
                eventToProcess.Rollback();
            }
        }
    }
}
