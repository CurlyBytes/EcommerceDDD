﻿using EcommerceDDD.Domain.Payments;

namespace EcommerceDDD.Domain.Orders;

/// <summary>
/// Domain service for calculating Order status
/// </summary>
public class OrderStatusWorkflow : IOrderStatusWorkflow
{        
    public void CalculateOrderStatus(Order order, Payment payment)
    {
        if (order == null)
            throw new ArgumentNullException("Order cannot be null.");

        if (payment == null)
            throw new ArgumentNullException("Payment cannot be null.");

        //Order Status Workflow
        if (order.Status == OrderStatus.Placed && payment.Status == PaymentStatus.ToPay)
            order.ChangeStatus(OrderStatus.WaitingForPayment);
            
        if (order.Status == OrderStatus.WaitingForPayment && payment.Status == PaymentStatus.Paid)
            order.ChangeStatus(OrderStatus.ReadyToShip);
    }        
}
