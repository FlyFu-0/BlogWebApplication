using Entities;
using Shared.RequestFeatures;

namespace Contracts.ModelsInterfaces;

public interface ICommentRepository
{
	Task<IEnumerable<Comment>> GetPostCommentsAsync(Guid postId, CommentParameters commentParametrs, bool trackChanges);

	Task<Comment> GetCommentAsync(Guid postId, Guid commentId, bool trackChanges);

	void CreateComment(Guid postId, string userId, Comment comment);

	void DeleteComment(Comment comment);
}
