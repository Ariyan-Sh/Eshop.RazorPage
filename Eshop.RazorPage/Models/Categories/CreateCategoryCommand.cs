namespace Eshop.RazorPage.Models.Categories
{
    public class CreateCategoryCommand
    {
        public string Title { get; set; }
        public string Slug  { get; set; }
        public SeoData SeoData { get; set; }
    }
}
