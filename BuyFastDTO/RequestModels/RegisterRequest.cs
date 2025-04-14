namespace BuyFastDTO.RequestModels;

public class RegisterRequest
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}