﻿using Contracts.ModelsInterfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

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

	public async Task<IEnumerable<Comment>> GetPostCommentsAsync(Guid postId, bool trackChanges)
		=> await FindByCondition(c => c.PostId.Equals(postId), trackChanges)
			.ToListAsync();
}
