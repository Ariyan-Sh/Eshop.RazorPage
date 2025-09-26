namespace Eshop.RazorPage.Models.Users
{
    public class UserFilterParams:BaseFilterParam
    {
        public long? Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
