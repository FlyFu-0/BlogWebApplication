using Entities;

namespace Repository.ModelsRepository;

public interface ITagRepository
{
	IEnumerable<Tag> GetAllTags(bool trackChanges);
}
