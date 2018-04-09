namespace Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
