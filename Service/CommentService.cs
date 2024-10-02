using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DTO.CommetDtos;
using Shared.RequestFeatures;

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

	public async Task<IEnumerable<CommentDto>> GetPostCommentsAsync(Guid postId, 
		CommentParameters commentParameters, bool trackChanges)
	{
		await CheckIfPostExist(postId, trackChanges);

		var commets = await _repository.Comment.GetPostCommentsAsync(postId, commentParameters, trackChanges: false);
		var commentsDto = _mapper.Map<IEnumerable<CommentDto>>(commets);

		return commentsDto;
	}

	private async Task CheckIfPostExist(Guid postId, bool trackChanges)
	{
		var post = await _repository.Post.GetPostAsync(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);
	}

	public async Task<CommentDto> GetCommentAsync(Guid postId, Guid commentId, bool trackChanges)
	{
		await CheckIfPostExist(postId, trackChanges);

		var comment = await GetCommentAndCheckIfExist(postId, commentId, trackChanges);

		var commentDto = _mapper.Map<CommentDto>(comment);

		return commentDto;
	}

	private async Task<Comment?> GetCommentAndCheckIfExist(Guid postId, Guid commentId, bool commentTrackChanges)
	{
		var commentEntity = await _repository.Comment.GetCommentAsync(postId, commentId, commentTrackChanges);
		if (commentEntity is null)
			throw new PostNotFoundException(commentId);
		return commentEntity;
	}

	public async Task<CommentDto> CreateCommentAsync(Guid postId, string userId, CommentCreationDto comment, bool trackChanges)
	{
		var user = await _repository.User.GetUserAsync(userId, trackChanges);
		if (user is null)
			throw new UserNotFoundException(userId);

		await CheckIfPostExist(postId, trackChanges);

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

		await CheckIfPostExist(postId, trackChanges);

		var comment = await GetCommentAndCheckIfExist(postId, commentId, trackChanges);

		_repository.Comment.DeleteComment(comment);
		await _repository.SaveAsync();
	}

	public async Task UpdatePostCommentAsync(Guid postId, string userId, Guid commentId, CommentUpdateDto commentForUpdate, bool postTrackChanges, bool commentTrackChanges)
	{
		var user = await _repository.User.GetUserAsync(userId, trackChanges: false);
		if (user is null)
			throw new UserNotFoundException(userId);

		await CheckIfPostExist(postId, postTrackChanges);

		var comment = await GetCommentAndCheckIfExist(postId, commentId, commentTrackChanges);

		_mapper.Map(commentForUpdate, comment);
		await _repository.SaveAsync();
	}

	public async Task<(CommentUpdateDto commentToPatch, Comment commentEntity)> GetCommentForPatchAsync(Guid postId, Guid commentId,
		bool postTrackChanges, bool commentTrackChanges)
	{
		await CheckIfPostExist(postId, postTrackChanges);

		var commentEntity = await GetCommentAndCheckIfExist(postId, commentId, commentTrackChanges);

		var commentToPatch = _mapper.Map<CommentUpdateDto>(commentEntity);

		return (commentToPatch, commentEntity);
	}

	public async Task SaveForPatchAsync(CommentUpdateDto commentToPatch, Comment commentEntity)
	{
		_mapper.Map(commentToPatch, commentEntity);
		await _repository.SaveAsync();
	}
}
