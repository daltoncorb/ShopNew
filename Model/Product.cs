

using System.ComponentModel.DataAnnotations;

namespace ShopNew.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60, ErrorMessage = "Tamanho máximo 60 chars")]
        [MinLength(3, ErrorMessage = "Tamanho mínimo 3 chars")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage= "Máximo de 1024 chars")]
        public string Description { get; set; }

        [Required]
        [Range(0.2, double.MaxValue, ErrorMessage = "Valor mínimo de 0,2 Reais")]
        public decimal Price { get; set; }

        public Category Category { get; set; }



        
    }
}