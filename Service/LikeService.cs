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

	public LikeDto CreateLike(Guid postId, string userId, bool trackChanges)
	{
		var user = _repository.User.GetUser(userId, trackChanges);
		if (user is null)
			throw new UserNotFoundException(userId);

		var post = _repository.Post.GetPost(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		//var likeEntity = _mapper.Map<Like>(like);

		_repository.Like.CreateLike(postId, userId);
		_repository.Save();

		//var likeToReturn = _mapper.Map<LikeDto>(likeEntity);
		var likeToReturn = new LikeDto(
			Id: new Guid("19a1c51c-5e7d-4126-80e6-c5c1c162680f"),
			PostId: postId
			);

		return likeToReturn;
	}
}
