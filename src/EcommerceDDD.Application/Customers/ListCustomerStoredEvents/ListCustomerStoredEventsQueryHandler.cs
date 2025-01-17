﻿using System.Threading;
using EcommerceDDD.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;
using EcommerceDDD.Application.Core.CQRS.QueryHandling;
using EcommerceDDD.Application.Core.EventSourcing;
using EcommerceDDD.Application.Core.EventSourcing.StoredEventsData;

namespace EcommerceDDD.Application.Customers.ListCustomerStoredEvents;

public class ListCustomerStoredEventsQueryHandler : QueryHandler<ListCustomerStoredEventsQuery, 
    IList<CustomerStoredEventData>> 
{
    private readonly IEcommerceUnitOfWork _unitOfWork;

    public ListCustomerStoredEventsQueryHandler(IEcommerceUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public override async Task<IList<CustomerStoredEventData>> ExecuteQuery(ListCustomerStoredEventsQuery request, 
        CancellationToken cancellationToken)
    {
        var storedEvents = await _unitOfWork.StoredEvents
            .GetByAggregateId(request.CustomerId, cancellationToken);

        IList<CustomerStoredEventData> customerStoredEvents = StoredEventPrettier<CustomerStoredEventData>
            .ToPretty(storedEvents);

        return customerStoredEvents;
    }
}
