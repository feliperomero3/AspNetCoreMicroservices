using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart
{
    [Route("events")]
    [ApiController]
    public class EventFeedController : ControllerBase
    {
        private readonly EventStore _eventStore;

        public EventFeedController(EventStore eventStore)
        {
            _eventStore = eventStore;
        }

        [HttpGet]
        public Event[] Get(long start, long end = long.MaxValue)
        {
            return _eventStore.GetEvents(start, end).ToArray();
        }
    }
}
