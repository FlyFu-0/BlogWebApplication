namespace Shared.DTO.CommetDtos;

public record CommentCreationDto(string Content, Guid PostId, string UserId);