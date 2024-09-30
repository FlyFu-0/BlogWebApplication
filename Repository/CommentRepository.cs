using Contracts.ModelsInterfaces;
using Entities;

namespace Repository;

public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
{
	public CommentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
	{
	}

	public Comment GetComment(Guid commentId, bool trackChanges)
		=> FindByCondition(c => c.Id.Equals(commentId), trackChanges)
			.SingleOrDefault();

	public IEnumerable<Comment> GetPostComments(Guid postId, bool trackChanges)
		=> FindByCondition(c => c.PostId.Equals(postId), trackChanges)
			.ToList();
}
