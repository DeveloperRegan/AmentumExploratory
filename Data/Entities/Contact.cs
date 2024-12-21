using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmentumExploratory.Data.Entities
{
    public class Contact
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(100), MinLength(1)]
        public string? Name { get; set; }
        [Required, MaxLength(1024)]
        public string? Email { get; set; }
        [Required]
        public ContactReason Reason { get; set; }
        [Required]
        public string? Comments { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ContactDateTime { get; set; }
    }
}
