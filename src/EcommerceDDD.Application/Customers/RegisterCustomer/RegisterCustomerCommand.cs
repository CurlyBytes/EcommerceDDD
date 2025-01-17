﻿using EcommerceDDD.Application.Core.CQRS.CommandHandling;

namespace EcommerceDDD.Application.Customers.RegisterCustomer;

public record class RegisterCustomerCommand : Command<Guid>
{
    public string Email { get; init; }
    public string Password { get; init; }
    public string PasswordConfirm { get; init; }
    public string Name { get; init; }

    public RegisterCustomerCommand(string email, string name, string password, string passwordConfirm)
    {
        Name = name;
        Email = email;
        Password = password;
        PasswordConfirm = passwordConfirm;
    }

    public override ValidationResult Validate()
    {
        return new RegisterCustomerCommandValidator().Validate(this);
    }
}

public class RegisterCustomerCommandValidator : AbstractValidator<RegisterCustomerCommand>
{
    public RegisterCustomerCommandValidator()
    {
        RuleFor(c => c.Email)
        .NotEmpty().WithMessage("Email is empty.")
        .Length(5, 100).WithMessage("The Email must have between 5 and 100 characters.");

        RuleFor(c => c.Name)
        .NotEmpty().WithMessage("Name is empty.")
        .Length(2, 100).WithMessage("The Name must have between 2 and 100 characters.");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is empty.");
        RuleFor(x => x.PasswordConfirm).NotEmpty().WithMessage("PasswordConfirm is empty.");
    }
}