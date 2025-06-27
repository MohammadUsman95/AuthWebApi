namespace AuthWebApi.Model
{
    public class RefreshTokenRequestDto
    {
        public Guid UserId { get; set; }  // This is the user id.
        public string RefreshToken { get; set; } = string.Empty; // This is the refresh token.
    }
}
