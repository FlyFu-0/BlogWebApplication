﻿using Contracts.ModelsInterfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
	public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
	{
	}

	public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges)
		=> await FindAll(trackChanges).ToListAsync();

	public async Task<User> GetUserAsync(string userId, bool trackChanges)
		=> await FindByCondition(u => u.Id.Equals(userId), trackChanges)
			.SingleOrDefaultAsync();
}
