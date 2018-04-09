using Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IFriendRepository
    {
        void Create(Friends friends);
        Friends Delete(string userNameA, string userNameB);
        Friends Read(string userNameA, string userNameB);
        IEnumerable<Friends> ReadAll(string userA);
        void Update(Friends friends);
    }
}