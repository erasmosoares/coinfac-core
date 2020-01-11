namespace CoinFac.Service.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string Locale { get; set; }
        public string UpdatedAt { get; set; }
        public string Email { get; set; }
        public string EmailVerified { get; set; }
        public string Sub { get; set; }
    }
}
