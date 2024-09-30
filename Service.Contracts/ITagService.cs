using Shared.DTO.TagDtos;

namespace Service.Contracts;

public interface ITagService
{
	IEnumerable<TagDto> GetAllTags(bool trackChanges);
}
