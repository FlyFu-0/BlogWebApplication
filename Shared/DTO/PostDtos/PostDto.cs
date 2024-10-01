using Shared.DTO.TagDtos;

namespace Shared.DTO.PostDtos;

public record PostDto(Guid Id, string Title, string Content, List<Guid> Tags, DateTime CreatedAt);
