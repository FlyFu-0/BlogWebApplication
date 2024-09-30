using AutoMapper;
using Entities;
using Shared.DTO.CommetDtos;
using Shared.DTO.PostDtos;
using Shared.DTO.TagDtos;
using Shared.DTO.UserDtos;

namespace BlogWebApplication;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Post, PostDto>();
		CreateMap<PostCreationDto, Post>();

		CreateMap<Tag, TagDto>();
		CreateMap<Comment, CommentDto>();
		CreateMap<User, UserDto>();
	}
}
