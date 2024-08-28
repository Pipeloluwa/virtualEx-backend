namespace virtual_ex.ResponseForms
{
    public class RefreshTokenResponse
    {
        public required string JWTToken { get; set; }

        public required string RefreshToken { get; set; }

    }
}
