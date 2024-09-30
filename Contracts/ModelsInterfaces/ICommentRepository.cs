using Entities;

namespace Contracts.ModelsInterfaces;

public interface ICommentRepository
{
	IEnumerable<Comment> GetPostComments(Guid postId, bool trackChanges);

	Comment GetComment(Guid commentId, bool trackChanges);

	void CreateComment(Guid postId, Comment comment);
}
