﻿using Entities;

namespace Repository.ModelsRepository;

public interface IPostRepository
{
	IEnumerable<Post> GetAllPosts(bool trackChanges);
	Post GetPost(Guid postId, bool trackChanges);

	void CreatePost(Post post);

	void DeletePost(Post post);
}
