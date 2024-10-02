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

	public async Task<IEnumerable<PostDto>> GetAllPosts(bool trackChanges)
	{
		var posts = await _repository.Post.GetAllPostsAsync(trackChanges);
		var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);

		return postsDto;
	}

	public async Task<PostDto> GetPost(Guid postId, bool trackChanges)
	{
		var post = await _repository.Post.GetPostAsync(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);
		var postDto = _mapper.Map<PostDto>(post);

		return postDto;
	}

	public async Task<PostDto> CreatePost(string userId, PostCreationDto post, bool trackChanges)
	{
		var postEntity = _mapper.Map<Post>(post);

		var tags = await _repository.Tag.GetTagsAsync(post.TagIds, trackChanges);

		var missingTags = post.TagIds.Except(tags.Select(t => t.Id));

		if (missingTags.Any())
			throw new TagNotFoundException(String.Join(", ", missingTags));

		postEntity.Tags = tags.ToList();

		postEntity.UserId = userId;

		_repository.Post.CreatePost(postEntity);
		await _repository.SaveAsync();

		var postToReturn = _mapper.Map<PostDto>(postEntity);

		return postToReturn;
	}

	public async Task DeletePost(string userId, Guid postId, bool trackChanges)
	{
		var user = await _repository.User.GetUserAsync(userId, trackChanges);
		if (user is null)
			throw new UserNotFoundException(userId);

		var post = await _repository.Post.GetPostAsync(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		_repository.Post.DeletePost(post);
		await _repository.SaveAsync();
	}

	public async Task UpdatePost(Guid postId, PostUpdateDto postForUpdate, bool trackChanges)
	{
		var post = await _repository.Post.GetPostAsync(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);

		var tags = await _repository.Tag.GetTagsAsync(postForUpdate.TagIds, trackChanges);

		var missingTags = postForUpdate.TagIds.Except(tags.Select(t => t.Id));

		if (missingTags.Any())
			throw new TagNotFoundException(String.Join(", ", missingTags));

		post.Tags = tags.ToList();

		_mapper.Map(postForUpdate, post);
		await _repository.SaveAsync();
	}

	public async Task<(PostUpdateDto postToPatch, Post postEntity)> GetPostForPatch(Guid postId, bool trackChanges)
	{
		var postEntity = await _repository.Post.GetPostAsync(postId, trackChanges);
		if (postEntity is null)
			throw new PostNotFoundException(postId);

		var postToPatch = _mapper.Map<PostUpdateDto>(postEntity);

		return (postToPatch, postEntity);
	}

	public async Task SaveToPatch(PostUpdateDto postToPatch, Post postEntity, bool trackChanges)
	{
		var tags = await _repository.Tag.GetTagsAsync(postToPatch.TagIds, trackChanges);

		var missingTags = postToPatch.TagIds.Except(tags.Select(t => t.Id));

		if (missingTags.Any())
			throw new TagNotFoundException(String.Join(", ", missingTags));

		postEntity.Tags = tags.ToList();

		_mapper.Map(postToPatch, postEntity);
		await _repository.SaveAsync();
	}
}