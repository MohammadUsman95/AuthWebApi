namespace AuthWebApi.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }=string.Empty;
        public string PasswordHash { get; set; }=string.Empty;

        // Roles.
        public string? Roles { get; set; } // now run migration for this property. Add-Migration Added-roles, than Update-database. than new claim in AuthService.cs.
        //Refreshtoken.
        public string? RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiry { get; set; }

        // Add migration Add-Migration Added-refreshtoken, than Update-database.
    }
}
