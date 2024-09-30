using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DTO.CommetDtos;

namespace Service;

public class CommentService : ICommentService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;
	private readonly IMapper _mapper;

	public CommentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
	{
		_repository = repository;
		_logger = logger;
		_mapper = mapper;
	}

	public CommentDto GetComment(Guid commentId, bool trackChanges)
	{
		var comment = _repository.Comment.GetComment(commentId, trackChanges);
		var commentDto = _mapper.Map<CommentDto>(comment);

		return commentDto;
	}

	public IEnumerable<CommentDto> GetPostComments(Guid postId, bool trackChanges)
	{
		var commets = _repository.Comment.GetPostComments(postId, trackChanges: false);
		var commentsDto = _mapper.Map<IEnumerable<CommentDto>>(commets);

		return commentsDto;
	}
}
