using Models;

namespace Contracts
{
    public interface IUserRepository
    {

        ApplicationUser Read(string userName);
        void Create(ApplicationUser applicationUser);
        void Update(ApplicationUser applicationUser);
        ApplicationUser Delete(string id);




    }
}