using Shared.DTO.CommetDtos;

namespace Service.Contracts;

public interface ICommentService
{
	CommentDto GetComment(Guid commentId, bool trackChanges);

	IEnumerable<CommentDto> GetPostComments(Guid postId, bool trackChanges);
}
