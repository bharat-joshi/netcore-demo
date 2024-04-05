using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Entity
{
    public class Blog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public int UserId { get; set; }
        public User Users { get; set; } = null;

    }
}
