using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Models
{
    public class ApplicationUser : IdentityUser
    {

        public ICollection<Post> Posts { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<ApplicationUser> Friends { get; set; }
        public ICollection<Message> Messages { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
