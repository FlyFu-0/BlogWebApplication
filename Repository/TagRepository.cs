using Entities;
using Repository.ModelsRepository;

namespace Repository;

public class TagRepository : RepositoryBase<Tag>, ITagRepository
{
	public TagRepository(RepositoryContext repositoryContext) : base(repositoryContext)
	{
	}

	public IEnumerable<Tag> GetAllTags(bool trackChanges)
		=> FindAll(trackChanges)
			.OrderBy(x => x.Name)
			.ToList();

	public Tag GetTag(Guid tagId, bool trackChanges)
		=> FindByCondition(t => t.Id.Equals(tagId), trackChanges)
			.SingleOrDefault();
}
