using Entities;

namespace Repository.ModelsRepository;

public interface ITagRepository
{
	Task<IEnumerable<Tag>> GetAllTagsAsync(bool trackChanges);

	Task<Tag> GetTagAsync(Guid tagId, bool trackChanges);

	Task<IEnumerable<Tag>> GetTagsAsync(IEnumerable<Guid> tagIds, bool trackChanges);

	void CreateTag(Tag tag);

	void DeleteTag(Tag tagId);
}
