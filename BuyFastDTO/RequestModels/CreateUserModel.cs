namespace BuyFastDTO.RequestModels
{
    public class CreateUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; } // Plain password, will be hashed before saving
        public string Username { get; set; }
        public string Role { get; set; } // "Admin" or "Customer"
    }

}
