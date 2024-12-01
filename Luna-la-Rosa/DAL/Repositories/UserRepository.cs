﻿using System.Linq.Dynamic.Core;
using DAL.Context;
using DAL.Entities;
using DAL.Helpers.Params;
using DAL.Helpers.Search;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ISearchHelper<User> _searchHelper;
    public UserRepository(LunaContext context, ISearchHelper<User> searchHelper) : base(context)
    {
        _searchHelper = searchHelper;
    }

    public async Task<IQueryable<User>> GetAllUserAsync(UserParams userParams, IEnumerable<string> searchFields)
    {
        var query = context.Users.AsQueryable();
        if (!string.IsNullOrWhiteSpace(userParams.SearchQuery))
            query = _searchHelper.ApplySearch(query, userParams.SearchQuery, searchFields);
        return await Task.FromResult(query);
    }

    public async Task<User> AuthenticateAsync(string login, string password)
    {
        var userAccount = context.Users.FirstOrDefault(x => x.Email == login);
        if (userAccount != null && userAccount.PasswordHash == password)
        {
            return userAccount;
        }

        return null;
    }

}