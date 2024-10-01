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

	//TODO: Can't add tags to post
	public PostDto CreatePost(PostCreationDto post)
	{
		var postEntity = _mapper.Map<Post>(post);

		//var tags = _repository.Tag.GetTags(post.TagIds, trackChanges: false);

		//var missingTags = post.TagIds.Except(tags.Select(t => t.Id)).ToList();

		//if (missingTags.Any())
		//	throw new TagNotFoundException(String.Join(", ", missingTags));

		//postEntity.Tags = tags.ToList();

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

	public void UpdatePost(Guid postId, PostUpdateDto postForUpdate, bool trackChanges)
	{
		var post = _repository.Post.GetPost(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		_mapper.Map(postForUpdate, post);
		_repository.Save();
	}

	public (PostUpdateDto postToPatch, Post postEntity) GetPostForPatch(Guid postId, bool trackChanges)
	{
		var postEntity = _repository.Post.GetPost(postId, trackChanges);
		if (postEntity is null)
			throw new PostNotFoundException(postId);

		var postToPatch = _mapper.Map<PostUpdateDto>(postEntity);

		return (postToPatch, postEntity);
	}

	public void SaveToPatch(PostUpdateDto postToPatch, Post postEntity)
	{
		_mapper.Map(postToPatch, postEntity);
		_repository.Save();
	}
}