namespace Eshop.RazorPage.Models.Roles
{
    public class RoleDto:BaseDto
    {
        public string Title { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
