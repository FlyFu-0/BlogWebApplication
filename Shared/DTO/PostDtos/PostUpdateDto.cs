namespace Shared.DTO.PostDtos;

public record PostUpdateDto(Guid Id, string Title, string Content, List<Guid> TagIds);