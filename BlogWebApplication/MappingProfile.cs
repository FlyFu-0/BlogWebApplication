using AutoMapper;
using Entities;
using Shared.DataTransferObjects;

namespace BlogWebApplication;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Post, PostDto>();
		CreateMap<Tag, TagDto>();
	}
}
