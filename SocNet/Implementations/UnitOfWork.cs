using Contracts;

namespace Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IPostRepository PostRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public IFriendRepository FriendRepository { get; private set; }

        public IMessageRepository MessageRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            PostRepository = new PostRepository(context);
            UserRepository = new UserRepository(context);
            FriendRepository = new FriendRepository(context);
            MessageRepository = new MessageRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}
