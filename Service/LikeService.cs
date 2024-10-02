using AutoMapper;
using Contracts;
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

	public async Task<LikeDto> ToggleLike(Guid postId, string userId, bool trackChanges)
	{
		var user = await _repository.User.GetUserAsync(userId, trackChanges);
		if (user is null)
			throw new UserNotFoundException(userId);

		var post = await _repository.Post.GetPostAsync(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		var like = await _repository.Like.GetLikeAsync(postId, userId, trackChanges);

		if (like is null)
		{
			_repository.Like.CreateLike(postId, userId);
			await _repository.SaveAsync();

			var likeToReturn = new LikeDto(PostId: postId);

			return likeToReturn;
		}
		else
		{
			_repository.Like.DeleteLike(like);
			await _repository.SaveAsync();

			var likeToReturn = _mapper.Map<LikeDto>(like);

			return likeToReturn;
		}
	}
}
