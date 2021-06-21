﻿using EcommerceDDD.Domain.Core.Messaging;
using EcommerceDDD.Domain.Customers.Orders;

namespace EcommerceDDD.Domain.Customers.Events
{
    public class OrderPlacedEvent : Event
    {
        public CustomerId CustomerId { get; private set; }
        public OrderId OrderId { get; private set; }

        public OrderPlacedEvent(CustomerId customerId, OrderId orderId)
        {
            CustomerId = customerId;
            OrderId = orderId;
            AggregateId = OrderId.Value;
        }
    }
}
