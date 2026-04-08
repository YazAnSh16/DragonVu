using System.ComponentModel.DataAnnotations;

namespace DragonVu.Models
{
    public class Chapter
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Foreign Key
        public int SubjectId { get; set; }

        // Navigation
        public Subject Subject { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
