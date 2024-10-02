using Entities;
using Shared.DTO.CommetDtos;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface ICommentService
{
	Task<CommentDto> GetCommentAsync(Guid postId, Guid commentId, bool trackChanges);

	Task<(IEnumerable<CommentDto> commentDtos, MetaData metaData)> GetPostCommentsAsync(Guid postId, CommentParameters commentParameters, bool trackChanges);

	Task<CommentDto> CreateCommentAsync(Guid postId, string userId, CommentCreationDto comment, bool trackChanges);

	Task DeletePostCommentAsync(Guid postId, string userId, Guid commentId, bool trackChanges);

	Task UpdatePostCommentAsync(Guid postId, string userId,
		Guid commentId, CommentUpdateDto commentForUpdate,
		bool postTrackChanges, bool commentTrackChanges);

	Task<(CommentUpdateDto commentToPatch, Comment commentEntity)> GetCommentForPatchAsync(Guid postId, Guid commentId,
		bool postTrackChanges, bool commentTrackChanges);

	Task SaveForPatchAsync(CommentUpdateDto commentToPatch, Comment commentEntity);
}
