﻿using Shared.DTO.LikeDtos;

namespace Service.Contracts;

public interface ILikeService
{
	Task<LikeDto> ToggleLike(Guid postId, string userId, bool trackChanges);
}
