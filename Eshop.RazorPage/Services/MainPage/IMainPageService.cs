using Eshop.RazorPage.Models;

namespace Eshop.RazorPage.Services.MainPage
{
    public interface IMainPageService
    {
        Task<MainPageDto> GetMainPageData();
    }
}
