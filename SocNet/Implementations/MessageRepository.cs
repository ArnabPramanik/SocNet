using Contracts;
using Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Implementations
{
    public class MessageRepository : IMessageRepository
    {

        private readonly ApplicationDbContext _context;


        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public void Create(Message message)
        {
            _context.MessageTable.Add(message);
        }

        public IEnumerable<Message> ReadAll(string userNameReceiver)
        {
            return _context.MessageTable.Where(p => p.Receiver.Equals(userNameReceiver));
        }

        public Message Read(int id)
        {
            return _context.MessageTable.SingleOrDefault(p => p.Id == id);
        }


        public void Update(Message message)
        {
            _context.MessageTable.Attach(message);

            _context.Entry(message).State = EntityState.Modified;

        }

        public Message Delete(int id)
        {
            var message = Read(id);
            if (message == null)
            {
                return null;
            }
            if (_context.Entry(message).State == EntityState.Detached)
                _context.MessageTable.Attach(message);

            _context.MessageTable.Remove(message);
            return message;

        }
    }
}
