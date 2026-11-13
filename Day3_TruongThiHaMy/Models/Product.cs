using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day3_TruongThiHaMy.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Phai nhap ten san pham")]
        [StringLength(100)]  //gioi han do dai ten san pham
        public string ProductName { get; set; } = String.Empty;
        [Range(0.01, 100000, ErrorMessage = "Gia san pham phai lon hon 0 va nho hon 100000")]
        public decimal ProductPrice { get; set; }
        //foreign key to Category - khoa ngoai
        [ForeignKey("Category")]

        public int CategoryId { get; set; }
        public Category? Category { get; set; }


    }
}
