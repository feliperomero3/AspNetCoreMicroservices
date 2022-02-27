using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ShoppingCart
{
    public class EventStore
    {
        private static long _currentSequenceNumber = 0;
        private static readonly IList<Event> _database = new List<Event>();

        public IEnumerable<Event> GetEvents(long firstEventSequenceNumber, long lastEventSequenceNumber)
        {
            return _database
                .Where(e =>
                  e.SequenceNumber >= firstEventSequenceNumber &&
                  e.SequenceNumber <= lastEventSequenceNumber)
                .OrderBy(e => e.SequenceNumber);
        }

        public void Raise(string eventName, object content)
        {
            var sequenceNumber = Interlocked.Increment(ref _currentSequenceNumber);

            _database.Add(new Event(sequenceNumber, DateTimeOffset.UtcNow, eventName, content));
        }
    }
}
