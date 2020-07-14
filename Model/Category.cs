

using System.ComponentModel.DataAnnotations;

namespace ShopNew.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage="O campo título é obrigatório")]
        [MaxLength(60, ErrorMessage = "Tamanho máximo 60 chars")]
        [MinLength(3, ErrorMessage = "Tamanho mínimo 3 chars")]        
        public string Title { get; set; }

    }
}