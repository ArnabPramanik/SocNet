using Contracts;
using Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Implementations
{
    public class FriendRepository : IFriendRepository
    {

        private readonly ApplicationDbContext _context;


        public FriendRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public void Create(Friends friends)
        {
            _context.FriendsTable.Add(friends);
        }

        public IEnumerable<Friends> ReadAll(string userA)
        {
            return _context.FriendsTable.Where(p => p.UserA.Equals(userA) || p.UserB.Equals(userA));
        }

        public Friends Read(string userNameA, string userNameB)
        {
            return _context.FriendsTable.SingleOrDefault(p =>( p.UserA.Equals(userNameA) && p.UserB.Equals(userNameB)));
        }

       

        public void Update(Friends friends)
        {
            _context.FriendsTable.Attach(friends);

            _context.Entry(friends).State = EntityState.Modified;

        }

        public Friends Delete(string userNameA, string userNameB)
        {
            var friends = Read(userNameA,userNameB);
            var friends2 = Read(userNameB, userNameA);
            Friends friends3 = null;
            if (friends == null && friends2 != null)
            {

                friends3 = friends2;
                
            }
            if(friends != null && friends2 == null)
            {
                friends3 = friends;
            }

            if(friends == null && friends2 == null)
            {
                return null;
            }
            if (_context.Entry(friends3).State == EntityState.Detached)
                _context.FriendsTable.Attach(friends3);

            _context.FriendsTable.Remove(friends3);
            return friends3;

        }

        
    }
}
