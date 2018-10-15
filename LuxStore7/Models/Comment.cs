namespace LuxStore7.Models
{
    public class Comment
    {
        public virtual int Id { get; set; }
        public virtual string Text { get; set; }
        public virtual int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual int Rating { get; set; }
    }
}
