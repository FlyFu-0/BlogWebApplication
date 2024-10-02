using Shared.DTO.TagDtos;

namespace Service.Contracts;

public interface ITagService
{
	Task<IEnumerable<TagDto>> GetAllTags(bool trackChanges);

	Task<TagDto> GetTag(Guid tagId, bool trackChanges);

	Task<TagDto> CreateTag(TagCreationDto tag);

	Task DeleteTag(Guid tagId, bool trackChanges);

	Task UpdateTag(Guid tagId, TagUpdateDto tagForUpdate, bool trackChanges);
}
