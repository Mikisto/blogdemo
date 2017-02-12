using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Blog
{
    public class AddCommentViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        public string Comment { get; set; }
    }
}