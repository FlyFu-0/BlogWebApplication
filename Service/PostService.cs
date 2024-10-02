using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DTO.PostDtos;
using Shared.RequestFeatures;

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

	public async Task<IEnumerable<PostDto>> GetAllPosts(PostParameters postParameters, bool trackChanges)
	{
		var posts = await _repository.Post.GetAllPostsAsync(postParameters, trackChanges);
		var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);

		return postsDto;
	}

	public async Task<PostDto> GetPost(Guid postId, bool trackChanges)
	{
		var post = await GetPostAndCheckIfExist(postId, trackChanges);
		var postDto = _mapper.Map<PostDto>(post);

		return postDto;
	}

	private async Task<Post?> GetPostAndCheckIfExist(Guid postId, bool trackChanges)
	{
		var post = await _repository.Post.GetPostAsync(postId, trackChanges);
		if (post is null)
			throw new PostNotFoundException(postId);
		return post;
	}

	public async Task<PostDto> CreatePost(string userId, PostCreationDto post, bool trackChanges)
	{
		var postEntity = _mapper.Map<Post>(post);
		var tags = await GetTagsAndCheckIfExist(post.TagIds, trackChanges);

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

		var post = await GetPostAndCheckIfExist(postId, trackChanges);

		_repository.Post.DeletePost(post);
		await _repository.SaveAsync();
	}

	public async Task UpdatePost(Guid postId, PostUpdateDto postForUpdate, bool trackChanges)
	{
		var post = await GetPostAndCheckIfExist(postId, trackChanges);

		var tags = await GetTagsAndCheckIfExist(postForUpdate.TagIds, trackChanges);

		post.Tags = tags.ToList();

		_mapper.Map(postForUpdate, post);
		await _repository.SaveAsync();
	}

	private async Task<IEnumerable<Tag>> GetTagsAndCheckIfExist(IEnumerable<Guid> tagIds, bool trackChanges)
	{
		var tags = await _repository.Tag.GetTagsAsync(tagIds, trackChanges);

		var missingTags = tagIds.Except(tags.Select(t => t.Id));

		if (missingTags.Any())
			throw new TagNotFoundException(String.Join(", ", missingTags));
		return tags;
	}

	public async Task<(PostUpdateDto postToPatch, Post postEntity)> GetPostForPatch(Guid postId, bool trackChanges)
	{
		var postEntity = await GetPostAndCheckIfExist(postId, trackChanges);

		var postToPatch = _mapper.Map<PostUpdateDto>(postEntity);

		return (postToPatch, postEntity);
	}

	public async Task SaveToPatch(PostUpdateDto postToPatch, Post postEntity, bool trackChanges)
	{
		var tags = await GetTagsAndCheckIfExist(postToPatch.TagIds, trackChanges);

		postEntity.Tags = tags.ToList();

		_mapper.Map(postToPatch, postEntity);
		await _repository.SaveAsync();
	}
}