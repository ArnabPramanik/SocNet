using Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IMessageRepository
    {
        void Create(Message message);
        Message Delete(int id);
        Message Read(int id);
        IEnumerable<Message> ReadAll(string userNameReceiver);
        void Update(Message message);
    }
}