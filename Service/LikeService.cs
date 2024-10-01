using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DTO.LikeDtos;

namespace Service;

public sealed class LikeService : ILikeService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;
	private readonly IMapper _mapper;

	public LikeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
	{
		_repository = repository;
		_logger = logger;
		_mapper = mapper;
	}

	public LikeDto ToggleLike(Guid postId, string userId, bool trackChanges)
	{
		var user = _repository.User.GetUser(userId, trackChanges);
		if (user is null)
			throw new UserNotFoundException(userId);

		var post = _repository.Post.GetPost(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		var like = _repository.Like.GetLike(postId, userId, trackChanges);

		if (like is null)
		{
			_repository.Like.CreateLike(postId, userId);
			_repository.Save();

			var likeToReturn = new LikeDto(PostId: postId);

			return likeToReturn;
		}
		else
		{
			_repository.Like.DeleteLike(like);
			_repository.Save();

			var likeToReturn = _mapper.Map<LikeDto>(like);

			return likeToReturn;
		}
	}

	//public LikeDto CreateLike(Guid postId, string userId, bool trackChanges)
	//{
	//	var user = _repository.User.GetUser(userId, trackChanges);
	//	if (user is null)
	//		throw new UserNotFoundException(userId);

	//	var post = _repository.Post.GetPost(postId, trackChanges);
	//	if (post is null)
	//		throw new PostNotFoundException(postId);

	//	//var likeEntity = _mapper.Map<Like>(like);

	//	_repository.Like.CreateLike(postId, userId);
	//	_repository.Save();

	//	//var likeToReturn = _mapper.Map<LikeDto>(likeEntity);
	//	var likeToReturn = new LikeDto(PostId: postId);

	//	return likeToReturn;
	//}

	//public void DeleteLike(Guid postId, string userId, bool trackChanges)
	//{
	//	var user = _repository.User.GetUser(userId, trackChanges);
	//	if (user is null)
	//		throw new UserNotFoundException(userId);

	//	var post = _repository.Post.GetPost(postId, trackChanges);
	//	if (post is null)
	//		throw new PostNotFoundException(postId);

	//	var like = _repository.Like.GetLike(postId, userId, trackChanges);
	//	if (like is null)
	//		throw new Exception("like not found");

	//	_repository.Like.DeleteLike(like);
	//	_repository.Save();
	//}
}
