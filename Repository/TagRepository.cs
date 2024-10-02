﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.ModelsRepository;

namespace Repository;

public class TagRepository : RepositoryBase<Tag>, ITagRepository
{
	public TagRepository(RepositoryContext repositoryContext) : base(repositoryContext)
	{
	}

	public void CreateTag(Tag tag)
		=> Create(tag);

	public void DeleteTag(Tag tag)
		=> Delete(tag);

	public async Task<IEnumerable<Tag>> GetAllTags(bool trackChanges)
		=> await FindAll(trackChanges)
			.OrderBy(x => x.Name)
			.ToListAsync();

	public async Task<Tag> GetTag(Guid tagId, bool trackChanges)
		=> await FindByCondition(t => t.Id.Equals(tagId), trackChanges)
			.SingleOrDefaultAsync();

	public async Task<IEnumerable<Tag>> GetTags(IEnumerable<Guid> tagId, bool trackChanges)
		=> await FindByCondition(t => tagId.Contains(t.Id), trackChanges)
			.ToListAsync();
}
