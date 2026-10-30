namespace Day3_TruongThiHaMy.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public String Description { get; set; }
        public string CategoryId { get; set; }
        // Navigation property_Dieu huong den Category tu Product
        public Category? Category { get; set; }


    }
}
