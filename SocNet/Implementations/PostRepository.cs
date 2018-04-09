using Contracts;
using Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Implementations
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;


        public PostRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public void Create(Post post)
        {
            _context.PostTable.Add(post);
        }

        public IEnumerable<Post> ReadAll()
        {
            return _context.PostTable.ToList();
        }

        public Post Read(int id)
        {
            return _context.PostTable.SingleOrDefault(p => p.Id == id);
        }

        public Post ReadLast()
        {
            return _context.PostTable.ToList().LastOrDefault();
        }

        public void Update(Post product)
        {
            _context.PostTable.Attach(product);

            _context.Entry(product).State = EntityState.Modified;

        }

        public Post Delete(int id)
        {
            var product = Read(id);
            if (product == null)
            {
                return null;
            }
            if (_context.Entry(product).State == EntityState.Detached)
                _context.PostTable.Attach(product);

            _context.PostTable.Remove(product);
            return product;

        }
    }
}
