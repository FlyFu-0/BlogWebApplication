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

	public IEnumerable<CommentDto> GetPostComments(Guid postId, bool trackChanges)
	{
		var post = _repository.Post.GetPost(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		var commets = _repository.Comment.GetPostComments(postId, trackChanges: false);
		var commentsDto = _mapper.Map<IEnumerable<CommentDto>>(commets);

		return commentsDto;
	}

	public CommentDto GetComment(Guid postId, Guid commentId, bool trackChanges)
	{
		var post = _repository.Post.GetPost(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		var comment = _repository.Comment.GetComment(commentId, trackChanges);
		if (comment is null)
			throw new CommentNotFoundException(commentId);
		var commentDto = _mapper.Map<CommentDto>(comment);

		return commentDto;
	}

	public CommentDto CreateComment(Guid postId, string userId, CommentCreationDto comment, bool trackChanges)
	{
		var user = _repository.User.GetUser(userId, trackChanges);
		if (user is null)
			throw new UserNotFoundException(userId);

		var post = _repository.Post.GetPost(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		var commentEntity = _mapper.Map<Comment>(comment);

		_repository.Comment.CreateComment(postId, userId, commentEntity);
		_repository.Save();

		var commentToReturn = _mapper.Map<CommentDto>(commentEntity);

		return commentToReturn;
	}

	public void DeletePostComment(Guid postId, string userId, Guid commentId, bool trackChanges)
	{
		var user = _repository.User.GetUser(userId, trackChanges);
		if (user is null)
			throw new UserNotFoundException(userId);

		var post = _repository.Post.GetPost(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		var comment = _repository.Comment.GetComment(commentId, trackChanges);

		if (comment is null)
			throw new CommentNotFoundException(commentId);

		_repository.Comment.DeleteComment(comment);
		_repository.Save();
	}
}
