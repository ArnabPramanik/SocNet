using Contracts;
using Microsoft.AspNet.Identity;
using Models;
using System.Web.Mvc;
using ViewModels;

namespace Controllers
{
    public class UserController : Controller
    {
        // GET: User

        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public ActionResult RetrieveUser2(ApplicationUserViewModel viewModel1)
        {

            var userInDb = _unitOfWork.UserRepository.Read(viewModel1.Email);
            var friendList = _unitOfWork.FriendRepository.ReadAll(viewModel1.Email);
            bool isFriends = false;
            foreach (Friends friends in friendList)
            {
                if(friends.UserA.Equals(viewModel1.Email) || friends.UserB.Equals(viewModel1.Email))
                {
                    isFriends = true;
                    break;
                }
            }

            ApplicationUserViewModel viewModel2 = new ApplicationUserViewModel()
            {
                ApplicationUser = userInDb,
                FriendList = friendList,
                IsFriends = isFriends
                
            };


            return View("ShowUser", viewModel2);
        }
        public ActionResult RetrieveUser(string userName)
        {

            var userInDb = _unitOfWork.UserRepository.Read(userName);
            var friendList = _unitOfWork.FriendRepository.ReadAll(userName);
            bool isFriends = false;
            foreach (Friends friends in friendList)
            {
                if (friends.UserA.Equals(userName) || friends.UserB.Equals(userName))
                {
                    isFriends = true;
                    break;
                }
            }
            ApplicationUserViewModel viewModel = new ApplicationUserViewModel()
            {
                ApplicationUser = userInDb,
                FriendList = friendList,
                IsFriends = isFriends
            };


            return View("ShowUser",viewModel);
        }


        public ActionResult ShowMessages()
        {
            var userInDb = _unitOfWork.MessageRepository.ReadAll(User.Identity.GetUserId());
            return View(userInDb);
        }

        [HttpPost]
        public ActionResult SavePost(ApplicationUserViewModel viewModel)
        {
           
            Post post = new Post()
            {
                PostContent = viewModel.PostContent,
                UserNameOfReceiver = viewModel.ApplicationUser.UserName,
                UserNameOfSender = User.Identity.GetUserName(),
                ApplicationUserId = viewModel.ApplicationUser.Id
                
            };

            _unitOfWork.PostRepository.Create(post);
            _unitOfWork.Complete();
            return RedirectToAction("RetrieveUser", "User", new { userName = viewModel.ApplicationUser.UserName });
        }
        
        public ActionResult DeletePost(int id)
        {
            _unitOfWork.PostRepository.Delete(id);
            _unitOfWork.Complete();
            return RedirectToAction("RetrieveUser", "User", new {userName = User.Identity.GetUserName() });
        }


        
        public ActionResult AddFriend(string userName)
        {

            var friends = new Friends()
            {
                UserA = User.Identity.GetUserName(),
                UserB = userName,
                IsFriends = true
            };


            _unitOfWork.FriendRepository.Create(friends);
            _unitOfWork.Complete();
            return RedirectToAction("RetrieveUser","User",new {userName = userName });
        }


        
        public ActionResult DeleteFriend(string userName)
        {
            _unitOfWork.FriendRepository.Delete(User.Identity.GetUserName(), userName);
            _unitOfWork.Complete();
            return RedirectToAction("RetrieveUser", "User", new { userName = userName });
        }


    }
}