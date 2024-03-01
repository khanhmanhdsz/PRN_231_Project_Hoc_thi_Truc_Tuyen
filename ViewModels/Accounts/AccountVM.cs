namespace ViewModels.Accounts
{
    public class AccountVM
    {
        public string Fullname { get; set; }
        public string? Email { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsAccountActive { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<string> Roles { get; set; }

    }
}
