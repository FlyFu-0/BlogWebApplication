using AutoMapper;
using Entities;
using Shared.DTO.CommetDtos;
using Shared.DTO.LikeDtos;
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
		CreateMap<PostUpdateDto, Post>().ReverseMap();

		CreateMap<Tag, TagDto>();
		CreateMap<TagCreationDto, Tag>();
		CreateMap<TagUpdateDto, Tag>();

		CreateMap<Comment, CommentDto>();
		CreateMap<CommentCreationDto, Comment>();
		CreateMap<CommentUpdateDto, Comment>().ReverseMap();

		CreateMap<Like, LikeDto>();
		CreateMap<LikeCreationDto, Like>();

		CreateMap<User, UserDto>();
	}
}
