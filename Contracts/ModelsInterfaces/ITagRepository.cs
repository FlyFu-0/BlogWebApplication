using Entities;

namespace Repository.ModelsRepository;

public interface ITagRepository
{
	Task<IEnumerable<Tag>> GetAllTags(bool trackChanges);

	Task<Tag> GetTag(Guid tagId, bool trackChanges);

	Task<IEnumerable<Tag>> GetTags(IEnumerable<Guid> tagIds, bool trackChanges);

	void CreateTag(Tag tag);

	void DeleteTag(Tag tagId);
}
