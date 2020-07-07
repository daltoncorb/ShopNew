
using System.ComponentModel.DataAnnotations;

namespace ShopNew.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage = "Tamanho máximo 40 chars")]
        [MinLength(3, ErrorMessage = "Tamanho mínimo 3 chars")]
        public string Username { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Tamanho máximo 20 chars")]
        [MinLength(3, ErrorMessage = "Tamanho mínimo 3 chars")]
        public string Password { get; set; }

        public string Role { get; set; }

    }    
}
