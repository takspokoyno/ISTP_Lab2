namespace Labka2.Models
{
    public class Public
    {
        public Public()
        {
            Posts = new List<Post>();
            Subs = new List<Sub>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Sub> Subs { get; set; }
    }
}
