namespace Labka2.Models
{
    public class User
    {
        public User()
        {
            Subs = new List<Sub>();
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Sub> Subs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
