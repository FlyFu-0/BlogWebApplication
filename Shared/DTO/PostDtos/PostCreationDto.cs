namespace Shared.DTO.PostDtos;

public record PostCreationDto(string Title, string Content, List<Guid> TagIds, string UserId);
