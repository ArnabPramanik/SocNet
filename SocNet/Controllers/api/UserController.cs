using Contracts;
using Microsoft.AspNet.Identity;
using Models;
using System.Web.Http;

namespace Controllers.api
{
    public class UserController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IHttpActionResult AddFriend(string userName)
        {

            var friends = new Friends()
            {
                UserA = User.Identity.GetUserName(),
                UserB = userName,
                IsFriends = true
            };

            
            _unitOfWork.FriendRepository.Create(friends);
            _unitOfWork.Complete();
            return Ok();
        }


        [HttpGet]
        public IHttpActionResult DeleteFriend(string userName)
        {
            _unitOfWork.FriendRepository.Delete(User.Identity.GetUserName(),userName);
            _unitOfWork.Complete();
            return Ok();
        }

       

        
    }
}
