namespace Labka2.Models
{
    public class Sub
    {
        public int Id { get; set; }
        public int PublicId { get; set; }
        public int UserId { get; set; }
        public virtual Public Public { get; set; }
        public virtual User User { get; set; }
    }
}
