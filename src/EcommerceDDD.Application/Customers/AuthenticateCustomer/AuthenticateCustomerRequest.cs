﻿using System.ComponentModel.DataAnnotations;

namespace EcommerceDDD.Application.Customers.AuthenticateCustomer;

public record class AuthenticateCustomerRequest
{
    [Required(ErrorMessage = "The {0} field is mandatory.")]
    [EmailAddress(ErrorMessage = "The field {0} is in an invalid format")]
    public string Email { get; init; }

    [Required(ErrorMessage = "The {0} field is mandatory.")]
    [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 6)]
    public string Password { get; init; }
}