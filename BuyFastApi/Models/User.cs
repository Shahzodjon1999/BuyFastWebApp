using System.ComponentModel.DataAnnotations;
using BuyFastApi.Abstracts;

namespace BuyFastApi.Models;

// User
public class User : BaseEntity
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Username { get; set; }
    public string Role { get; set; } // Admin or Customer
    public virtual UserProfile Profile { get; set; }
    public virtual Cart Cart { get; set; }
    public virtual Wishlist Wishlist { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
}