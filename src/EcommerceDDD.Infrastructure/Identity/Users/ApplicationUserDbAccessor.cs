﻿using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EcommerceDDD.Infrastructure.Database.Context;

namespace EcommerceDDD.Infrastructure.Identity.Users;

public interface IApplicationUserDbAccessor
{
    Task<ApplicationUser> GetUserByEmail(string email);
}

public class ApplicationUserDbAccessor : IApplicationUserDbAccessor
{
    private readonly IdentityContext _dbContext;

    public ApplicationUserDbAccessor(IdentityContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApplicationUser> GetUserByEmail(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(c => c.Email == email);
    }
}