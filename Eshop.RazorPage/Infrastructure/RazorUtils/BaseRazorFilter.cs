using Eshop.RazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop.RazorPage.Infrastructure.RazorUtils
{
    public class BaseRazorFilter<TFilterParams> : PageModel where TFilterParams : BaseFilterParam//, new()
    {
        [BindProperty(SupportsGet = true)]
        public TFilterParams FilterParams { get; set; }

        //public BaseRazorFilter()
        //{
            //اگر ایراد داشت این کامنت هارو برگردون
        //}
    }
}
