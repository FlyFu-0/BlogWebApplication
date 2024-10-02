using Contracts.ModelsInterfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.DTO.CommetDtos;
using Shared.RequestFeatures;

namespace Repository;

public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
{
	public CommentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
	{
	}

	public void CreateComment(Guid postId, string userId, Comment comment)
	{
		comment.UserId = userId;
		comment.PostId = postId;
		Create(comment);
	}

	public void DeleteComment(Comment comment)
		=> Delete(comment);

	public async Task<Comment> GetCommentAsync(Guid postId, Guid commentId, bool trackChanges)
		=> await FindByCondition(c => c.PostId.Equals(postId) && c.Id.Equals(commentId), trackChanges)
			.SingleOrDefaultAsync();

	public async Task<PagedList<Comment>> GetPostCommentsAsync(Guid postId, CommentParameters commentParameters, bool trackChanges)
	{
		var comments = await FindByCondition(c => c.PostId.Equals(postId), trackChanges)
			.ToListAsync();

		return PagedList<Comment>
			.ToPagedList(comments, commentParameters.PageNumber, commentParameters.PageSize);
	}
}
