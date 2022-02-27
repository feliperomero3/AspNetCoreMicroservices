using System;

namespace ShoppingCart
{
    public record Event(long SequenceNumber, DateTimeOffset OccuredAt, string Name, object Content);
}
