using Entities;
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

	public IEnumerable<Tag> GetAllTags(bool trackChanges)
		=> FindAll(trackChanges)
			.OrderBy(x => x.Name)
			.ToList();

	public Tag GetTag(Guid tagId, bool trackChanges)
		=> FindByCondition(t => t.Id.Equals(tagId), trackChanges)
			.SingleOrDefault();

	public IEnumerable<Tag> GetTags(IEnumerable<Guid> tagId, bool trackChanges)
		=> FindByCondition(t => tagId.Contains(t.Id), trackChanges)
			.ToList();
}
