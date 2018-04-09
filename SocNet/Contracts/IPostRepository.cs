using Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IPostRepository
    {
        void Create(Post post);


        IEnumerable<Post> ReadAll();


        Post Read(int id);


        Post ReadLast();


        void Update(Post product);


        Post Delete(int id);
        
    }
}