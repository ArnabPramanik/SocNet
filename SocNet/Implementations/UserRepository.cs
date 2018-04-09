using Contracts;
using Models;
using System.Data.Entity;
using System.Linq;

namespace Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public ApplicationUser Read(string userName)
        {
            return _context.Users.Include(p => p.Posts).SingleOrDefault(p => p.UserName.Equals(userName));
        }

        public void Create(ApplicationUser applicationUser)
        {
            _context.Users.Add(applicationUser);
        }


        public void Update(ApplicationUser applicationUser)
        {
            _context.Users.Attach(applicationUser);
            _context.Entry(applicationUser).State = EntityState.Modified;
        }

        public ApplicationUser Delete(string id)
        {
            var applicationUser = Read(id);
            if (applicationUser == null)
            {
                return null;
            }
            if (_context.Entry(applicationUser).State == EntityState.Detached)
                _context.Users.Attach(applicationUser);

            _context.Users.Remove(applicationUser);
            return applicationUser;

        }

    }
}
