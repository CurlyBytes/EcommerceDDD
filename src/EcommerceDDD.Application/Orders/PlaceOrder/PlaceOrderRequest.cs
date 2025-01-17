﻿using System.ComponentModel.DataAnnotations;

namespace EcommerceDDD.Application.Orders.PlaceOrder
{
    public record class PlaceOrderRequest
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public Guid CustomerId { get; init; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Currency { get; init; }
    }
}
