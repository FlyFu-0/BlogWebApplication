using Contracts;
using Contracts.ModelsInterfaces;
using Repository.ModelsRepository;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
	private readonly RepositoryContext _context;
	private readonly Lazy<ILikeRepository> _likeRepository;
	private readonly Lazy<IPostRepository> _postRepository;
	private readonly Lazy<ITagRepository> _tagRepository;
	private readonly Lazy<ICommentRepository> _commentRepository;
	private readonly Lazy<IUserRepository> _userRepository;

	public RepositoryManager(RepositoryContext repositoryContext)
	{
		_context = repositoryContext;
		_likeRepository = new Lazy<ILikeRepository>(() => new LikeRepository(repositoryContext));
		_postRepository = new Lazy<IPostRepository>(() => new PostRepository(repositoryContext));
		_tagRepository = new Lazy<ITagRepository>(() => new TagRepository(repositoryContext));
		_commentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(repositoryContext));
		_userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
	}

	public IPostRepository Post => _postRepository.Value;
	public ITagRepository Tag => _tagRepository.Value;
	public ILikeRepository Like => _likeRepository.Value;
	public ICommentRepository Comment => _commentRepository.Value;
	public IUserRepository User => _userRepository.Value;

	public void Save() => _context.SaveChanges();
}
