using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApproach1.Models
{
    public class StudentModel
    {
        [Key]
        [Required]
     
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="varchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column("Class",TypeName = "varchar(50)")]
        public string standard { get; set; }
        [Required]
        [Range(1, 100)]
        public int age { get; set; }
    }
}
