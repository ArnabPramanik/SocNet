namespace Models
{
    public class Post
    {
        public int Id { get; set; }
        public string PostContent { get; set; }
        public string UserNameOfReceiver { get; set; }
        public string UserNameOfSender { get; set; }
        public ApplicationUser ApplicationUser { get; set; } 
        public string ApplicationUserId { get; set; }

        
    }
}
