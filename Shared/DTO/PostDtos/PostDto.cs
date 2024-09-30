using Shared.DTO.TagDtos;

namespace Shared.DTO.PostDtos;

public record PostDto(Guid Id, string Title, string Content, List<TagDto> Tags, DateTime CreatedAt);
