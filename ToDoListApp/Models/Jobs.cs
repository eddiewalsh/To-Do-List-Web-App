using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListApp.Models
{
    public class Jobs
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Job Title field is required.")]
        public string? JobTitle { get; set; }

        [Required(ErrorMessage = "The Job Description field is required.")]
        public string? JobDescription { get; set; }

        [Required]
        public bool isCompleted { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
