﻿namespace Eshop.RazorPage.Models.Products
{
    public class ProductCategoryDto
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public SeoData SeoData { get; set; }
    }
}
