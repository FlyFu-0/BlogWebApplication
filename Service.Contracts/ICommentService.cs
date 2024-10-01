using Shared.DTO.CommetDtos;

namespace Service.Contracts;

public interface ICommentService
{
	CommentDto GetComment(Guid postId, Guid commentId, bool trackChanges);

	IEnumerable<CommentDto> GetPostComments(Guid postId, bool trackChanges);

	CommentDto CreateComment(Guid postId, string userId, CommentCreationDto comment, bool trackChanges);

	void DeletePostComment(Guid postId, string userId, Guid commentId, bool trackChanges);

	void UpdatePostComment(Guid postId, string userId,
		Guid commentId, CommentUpdateDto commentForUpdate,
		bool postTrackChanges, bool commentTrackChanges);
}
