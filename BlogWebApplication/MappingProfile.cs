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
		CreateMap<TagCreationDto, Tag>();

		CreateMap<Comment, CommentDto>();
		CreateMap<CommentCreationDto, Comment>();

		CreateMap<User, UserDto>();
	}
}
