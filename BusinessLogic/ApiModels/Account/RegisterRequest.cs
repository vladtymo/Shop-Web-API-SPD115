namespace BusinessLogic.ApiModels.Account
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
