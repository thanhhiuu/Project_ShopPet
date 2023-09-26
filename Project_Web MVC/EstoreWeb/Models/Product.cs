using EstoreWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ChuThich { get; set; }
        [Required]
        public double Gia { get; set; }
        public int CategoryId { get; set; }

        // Khai báo mối kết hợp 1-n
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public string ImageUrl { get; set; }
    }
public class ProductViewModel
{
    public Product Product { get; set; }
    public List<Product> RelatedProducts { get; set; }
}
