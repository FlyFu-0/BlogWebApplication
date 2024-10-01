using Shared.DTO.TagDtos;

namespace Service.Contracts;

public interface ITagService
{
	IEnumerable<TagDto> GetAllTags(bool trackChanges);

	TagDto GetTag(Guid tagId, bool trackChanges);

	TagDto CreateTag(TagCreationDto tag);

	void DeleteTag(Guid tagId, bool trackChanges);

	void UpdateTag(Guid tagId, TagUpdateDto tagForUpdate, bool trackChanges);
}
