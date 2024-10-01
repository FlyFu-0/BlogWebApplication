using Entities;

namespace Contracts.ModelsInterfaces;

public interface ICommentRepository
{
	IEnumerable<Comment> GetPostComments(Guid postId, bool trackChanges);

	Comment GetComment(Guid commentId, bool trackChanges);

	void CreateComment(Guid postId, string userId, Comment comment);

	void DeleteComment(Comment comment);
}
