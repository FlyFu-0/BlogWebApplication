using Shared.DTO.TagDtos;

namespace Service.Contracts;

public interface ITagService
{
	IEnumerable<TagDto> GetAllTags(bool trackChanges);

	TagDto GetTag(Guid tagId, bool trackChanges);

	TagDto CreateTag(TagCreationDto tag);
}
