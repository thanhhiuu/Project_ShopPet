using System.ComponentModel.DataAnnotations;

namespace EstoreWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public String Name { get; set; }

        [Range(1,100, ErrorMessage ="Vui lòng nhập trong khoảng từ 0 đến 100" )]
        public int DisplayOrder { get; set; }

    }
}
