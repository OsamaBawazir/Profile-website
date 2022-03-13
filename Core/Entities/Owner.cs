namespace Core.Entities
{
    public class Owner : MainEntity
    {
        public string FullName { get; set; }
        public string Profile { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public Contact contact { get; set; }
    }


}
