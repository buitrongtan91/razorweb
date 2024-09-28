using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webappEF.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
    }
}