﻿using EcommerceDDD.Domain.Core.Messaging;

namespace EcommerceDDD.Domain.Customers.Events
{
    public class CustomerRegisteredEvent : Event
    {
        public CustomerId CustomerId { get; private set; }
        public string Name { get; private set; }

        public CustomerRegisteredEvent(CustomerId customerId, string name)
        {
            CustomerId = customerId;
            Name = name;
            AggregateId = customerId.Value;
        }
    }
}
