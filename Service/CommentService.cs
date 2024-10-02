using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DTO.CommetDtos;

namespace Service;

public class CommentService : ICommentService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;
	private readonly IMapper _mapper;

	public CommentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
	{
		_repository = repository;
		_logger = logger;
		_mapper = mapper;
	}

	public async Task<IEnumerable<CommentDto>> GetPostCommentsAsync(Guid postId, bool trackChanges)
	{
		var post = await _repository.Post.GetPostAsync(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		var commets = await _repository.Comment.GetPostCommentsAsync(postId, trackChanges: false);
		var commentsDto = _mapper.Map<IEnumerable<CommentDto>>(commets);

		return commentsDto;
	}

	public async Task<CommentDto> GetCommentAsync(Guid postId, Guid commentId, bool trackChanges)
	{
		var post = await _repository.Post.GetPostAsync(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		var comment = await _repository.Comment.GetCommentAsync(postId, commentId, trackChanges);
		if (comment is null)
			throw new CommentNotFoundException(commentId);

		var commentDto = _mapper.Map<CommentDto>(comment);

		return commentDto;
	}

	public async Task<CommentDto> CreateCommentAsync(Guid postId, string userId, CommentCreationDto comment, bool trackChanges)
	{
		var user = await _repository.User.GetUserAsync(userId, trackChanges);
		if (user is null)
			throw new UserNotFoundException(userId);

		var post = await _repository.Post.GetPostAsync(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		var commentEntity = _mapper.Map<Comment>(comment);

		_repository.Comment.CreateComment(postId, userId, commentEntity);
		await _repository.SaveAsync();

		var commentToReturn = _mapper.Map<CommentDto>(commentEntity);

		return commentToReturn;
	}

	public async Task DeletePostCommentAsync(Guid postId, string userId, Guid commentId, bool trackChanges)
	{
		var user = await _repository.User.GetUserAsync(userId, trackChanges);
		if (user is null)
			throw new UserNotFoundException(userId);

		var post = await _repository.Post.GetPostAsync(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		var comment = await _repository.Comment.GetCommentAsync(postId, commentId, trackChanges);

		if (comment is null)
			throw new CommentNotFoundException(commentId);

		_repository.Comment.DeleteComment(comment);
		await _repository.SaveAsync();
	}

	public async Task UpdatePostCommentAsync(Guid postId, string userId, Guid commentId, CommentUpdateDto commentForUpdate, bool postTrackChanges, bool commentTrackChanges)
	{
		var user = await _repository.User.GetUserAsync(userId, trackChanges: false);
		if (user is null)
			throw new UserNotFoundException(userId);

		var post = await _repository.Post.GetPostAsync(postId, postTrackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		var comment = await _repository.Comment.GetCommentAsync(postId, commentId, commentTrackChanges);
		if (comment is null)
			throw new CommentNotFoundException(commentId);

		_mapper.Map(commentForUpdate, comment);
		await _repository.SaveAsync();
	}

	public async Task<(CommentUpdateDto commentToPatch, Comment commentEntity)> GetCommentForPatchAsync(Guid postId, Guid commentId,
		bool postTrackChanges, bool commentTrackChanges)
	{
		var post = await _repository.Post.GetPostAsync(postId, postTrackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		var commentEntity = await _repository.Comment.GetCommentAsync(postId, commentId, commentTrackChanges);
		if (commentEntity is null)
			throw new PostNotFoundException(commentId);

		var commentToPatch = _mapper.Map<CommentUpdateDto>(commentEntity);

		return (commentToPatch, commentEntity);
	}

	public async Task SaveForPatchAsync(CommentUpdateDto commentToPatch, Comment commentEntity)
	{
		_mapper.Map(commentToPatch, commentEntity);
		await _repository.SaveAsync();
	}
}
