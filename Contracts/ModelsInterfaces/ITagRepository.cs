using Entities;

namespace Repository.ModelsRepository;

public interface ITagRepository
{
	IEnumerable<Tag> GetAllTags(bool trackChanges);

	Tag GetTag(Guid tagId, bool trackChanges);

	IEnumerable<Tag> GetTags(IEnumerable<Guid> tagIds, bool trackChanges);

	void CreateTag(Tag tag);

	void DeleteTag(Tag tagId);
}
