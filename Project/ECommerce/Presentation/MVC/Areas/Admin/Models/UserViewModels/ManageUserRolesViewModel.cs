namespace MVC.Areas.Admin.Models.UserViewModels
{
    public class ManageUserRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<RoleSelectionViewModel> UserRoles { get; set; } = new List<RoleSelectionViewModel>();
    }
}
