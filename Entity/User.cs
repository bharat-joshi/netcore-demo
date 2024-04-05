using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Entity
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }

        public List<Blog> Blogs { get; set; } = [];
    }
}
