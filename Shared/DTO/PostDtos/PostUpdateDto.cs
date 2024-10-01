namespace Shared.DTO.PostDtos;

public record PostUpdateDto(string Title, string Content, List<Guid> TagIds);