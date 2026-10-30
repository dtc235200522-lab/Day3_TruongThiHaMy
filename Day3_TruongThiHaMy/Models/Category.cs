using System.ComponentModel.DataAnnotations;

namespace Day3_TruongThiHaMy.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Id is required")]

        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; } = String.Empty;
        // Navigation property
        public List<Product> Products { get; set; } //hien thi danh sach cac san pham thuoc category nay
    }
}
