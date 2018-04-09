namespace Contracts
{
    public interface IUnitOfWork
    {
        IPostRepository PostRepository { get; }
        IUserRepository UserRepository { get; }
        IFriendRepository FriendRepository { get; }
        IMessageRepository MessageRepository { get; }
        void Complete();
    }
}