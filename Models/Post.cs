namespace Labka2.Models
{
    public class Post
    {
        public Post()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Likes { get; set; }
        public int CategoryId { get; set; }
        public int PublicId { get; set; }
        public virtual Public? Public { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
