using Shared.DTO.UserDtos;

namespace Shared.DTO.CommetDtos;

public record CommentDto(Guid Id, string Content, UserDto User, DateTime CreatedAt);