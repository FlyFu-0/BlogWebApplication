﻿using Entities;

namespace Repository.ModelsRepository;

public interface ILikeRepository
{
	void CreateLike(Guid postId, string userId);

	void DeleteLike(Like like);

	Task<Like> GetLike(Guid postId, string userId, bool trackChanges);
}
