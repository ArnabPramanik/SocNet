using Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class ApplicationUserViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<Friends> FriendList { get; set; }

        public bool IsFriends { get; set; }

        [Required]
        public string Email { get; set; }

        public string PostContent { get; set; }
    }
}