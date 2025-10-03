using Eshop.RazorPage.Infrastructure.RazorUtils;
using Eshop.RazorPage.Services.Auth;
using Eshop.RazorPage.Services.Banners;
using Eshop.RazorPage.Services.Categories;
using Eshop.RazorPage.Services.Comments;
using Eshop.RazorPage.Services.MainPage;
using Eshop.RazorPage.Services.Orders;
using Eshop.RazorPage.Services.Products;
using Eshop.RazorPage.Services.Roles;
using Eshop.RazorPage.Services.Sellers;
using Eshop.RazorPage.Services.Sliders;
using Eshop.RazorPage.Services.UserAddress;
using Eshop.RazorPage.Services.Users;

namespace Eshop.RazorPage.Infrastructure
{
    public static class RegisterDependencyServices
    {
        public static IServiceCollection RegisterApiServices(this IServiceCollection services)
        {
            var baseAddress = "https://localhost:7051/api";//domain address of the site like www.ariyan.com

            services.AddHttpContextAccessor();
            services.AddScoped<HttpClientAuthorizationDelegatingHandler>();
            services.AddTransient<IRenderViewToString, RenderViewToString>();
            services.AddAutoMapper(typeof(RegisterDependencyServices).Assembly);
            services.AddScoped<IMainPageService, MainPageService>();

            services.AddHttpClient<IAuthService, AuthService>(httpclient =>
            {
                httpclient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            services.AddHttpClient<IBannerService, BannerService>(httpclient =>
            {
                httpclient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            services.AddHttpClient<ICategoryService, CategoryService>(httpclient =>
            {
                httpclient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            services.AddHttpClient<ICommentService, CommentService>(httpclient =>
            {
                httpclient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            services.AddHttpClient<IOrderService, OrderService>(httpclient =>
            {
                httpclient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            services.AddHttpClient<IProductService, ProductService>(httpclient =>
            {
                httpclient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            services.AddHttpClient<IRoleService, RoleService>(httpclient =>
            {
                httpclient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            services.AddHttpClient<ISellerService, SellerService>(httpclient =>
            {
                httpclient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            services.AddHttpClient<ISliderService, SliderService>(httpclient =>
            {
                httpclient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            services.AddHttpClient<IUserAddressService, UserAddressService>(httpclient =>
            {
                httpclient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            services.AddHttpClient<IUserService, UserService>(httpclient =>
            {
                httpclient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            return services;
        }
    }
}
