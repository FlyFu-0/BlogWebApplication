using AutoMapper;
using Entities;
using Shared.DTO.PostDtos;
using Shared.DTO.TagDtos;

namespace BlogWebApplication;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Post, PostDto>();
		CreateMap<Tag, TagDto>();
	}
}
