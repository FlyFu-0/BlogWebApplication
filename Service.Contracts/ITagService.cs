using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ITagService
{
	IEnumerable<TagDto> GetAllTags(bool trackChanges);
}
