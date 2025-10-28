using Common.Application.Validation.CustomValidation.IFormFile;
using Eshop.RazorPage.Infrastructure.RazorUtils;
using Eshop.RazorPage.Models.Products;
using Eshop.RazorPage.Models.Products.Command;
using Eshop.RazorPage.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Eshop.RazorPage.Pages.Admin.Products.Galleries
{
    public class IndexModel : BaseRazorPage
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<ProductImageDto> Images { get; set; }
        [Display(Name ="عکس محصول")]
        [Required(ErrorMessage ="{0} را وارد کنید")]
        [FileImage(ErrorMessage ="عکس نامعتبر است")]
        [BindProperty]
        public IFormFile ImageFile { get; set; }
        [Display(Name ="ترتیب نمایش")]
        [BindProperty]
        [Required(ErrorMessage ="{0} را وارد کنید")]
        public int Sequence { get; set; }

        public async Task<IActionResult> OnGet(long productId)
        {
            var product = await _productService.GetProductById(productId);
            if(product == null)
            {
                return RedirectToPage("Index");
            }
            Images = product.Images;
            return Page();
        }

        public async Task<IActionResult> OnPost(long productId)
        {
            return await AjaxTryCatch(() =>
            {
                return _productService.AddImage(new AddProductImageCommand()
                {
                    ProductId = productId,
                    ImageFile = ImageFile,
                    Sequence = Sequence
                });
            });
        }

        public async Task<IActionResult> OnPostDeleteItem(long productId, long id)
        {
            Sequence = 1;
            return await AjaxTryCatch(() => _productService.DeleteProductImage(new DeleteProductImageCommand()
            {
                ProductId = productId,
                ImageId = id,
            }), checkModelState: false);
        }
    }
}
