using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DTO.PostDtos;

namespace Service;

public sealed class PostService : IPostService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;
	private readonly IMapper _mapper;

	public PostService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
	{
		_repository = repository;
		_logger = logger;
		_mapper = mapper;
	}

	public IEnumerable<PostDto> GetAllPosts(bool trackChanges)
	{
		var posts = _repository.Post.GetAllPosts(trackChanges);
		var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);

		return postsDto;
	}

	public PostDto GetPost(Guid postId, bool trackChanges)
	{
		var post = _repository.Post.GetPost(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);
		var postDto = _mapper.Map<PostDto>(post);

		return postDto;
	}

	public PostDto CreatePost(PostCreationDto post)
	{
		var postEntity = _mapper.Map<Post>(post);

		_repository.Post.CreatePost(postEntity);
		_repository.Save();

		var postToReturn = _mapper.Map<PostDto>(postEntity);

		return postToReturn;
	}

	public void DeletePost(string userId, Guid postId, bool trackChanges)
	{
		var user = _repository.User.GetUser(userId, trackChanges);
		if (user is null)
			throw new UserNotFoundException(userId);

		var post = _repository.Post.GetPost(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		_repository.Post.DeletePost(post);
		_repository.Save();
	}
}