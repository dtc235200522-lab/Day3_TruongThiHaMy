namespace Day3_TruongThiHaMy.Models
{
    public class ProductSearchModel
    {
        public String? Keyword { get; set; }
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 5;
    }
}
