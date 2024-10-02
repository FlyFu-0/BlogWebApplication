using Entities;

namespace Contracts.ModelsInterfaces;

public interface ICommentRepository
{
	Task<IEnumerable<Comment>> GetPostComments(Guid postId, bool trackChanges);

	Task<Comment> GetComment(Guid postId, Guid commentId, bool trackChanges);

	void CreateComment(Guid postId, string userId, Comment comment);

	void DeleteComment(Comment comment);
}
