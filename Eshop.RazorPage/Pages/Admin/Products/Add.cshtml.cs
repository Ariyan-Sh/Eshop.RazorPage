using Common.Application.Validation.CustomValidation.IFormFile;
using Eshop.RazorPage.Services.Products;
using Eshop.RazorPage.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Eshop.RazorPage.Models.Products.Command;
using Eshop.RazorPage.Infrastructure.RazorUtils;

namespace Eshop.RazorPage.Pages.Admin.Products
{
    [BindProperties]
    public class AddModel : BaseRazorPage
    {
        private readonly IProductService _productService;

        public AddModel(IProductService productService)
        {
            _productService = productService;
        }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "عکس محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [FileImage(ErrorMessage ="عکس نامعتبر است")]
        public IFormFile ImageFile { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [UIHint("Ckeditor4")]
        public string Description { get; set; }
        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Range(1, long.MaxValue, ErrorMessage = "دسته بندی را وارد کنید")]
        public long CategoryId { get; set; }
        [Display(Name = "زیردسته بندی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Range(1, long.MaxValue, ErrorMessage = "زیردسته بندی را وارد کنید")]
        public long SubCategoryId { get; set; }
        [Display(Name = "دسته بندی سوم")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public long? SecondarySubCategoryId { get; set; }
        [Display(Name = "Slug")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Slug { get; set; }
        public SeoDataViewModel SeoData { get; set; }

        public List<string> Keys { get; set; } = new();
        public List<string> Values { get; set; } = new();
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(SecondarySubCategoryId == 0)
            {
                SecondarySubCategoryId = null;
            }
            var result = await _productService.CreateProduct(new CreateProductCommand()
            {
                Title = Title,
                Description = Description,
                CategoryId = CategoryId,
                SubCategoryId = SubCategoryId,
                ImageFile = ImageFile,
                Slug = Slug,
                SeoData = SeoData.MapToSeoData(),
                SecondarySubCategoryId = SecondarySubCategoryId,
                Specifications = ConvertSpecifications()
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }

        private Dictionary<string, string> ConvertSpecifications()
        {
            var specifications = new Dictionary<string, string>();
            Keys.RemoveAll(r => r == null || string.IsNullOrWhiteSpace(r));
            Values.RemoveAll(r => r == null || string.IsNullOrWhiteSpace(r));
            for (var i = 0; i < Keys.Count; i++)
            {
                specifications.Add(Keys[i], Values[i]);
            }

            return specifications;
        }
    }
}
