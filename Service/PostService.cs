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
}