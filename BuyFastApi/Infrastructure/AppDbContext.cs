using BuyFastApi.Abstracts;
using BuyFastApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BuyFastApi.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }
    public DbSet<WishlistItem> WishlistItems { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Ignore<BaseEntity>();

    // --- User ↔ UserProfile (1:1)
    modelBuilder.Entity<User>()
        .HasOne(u => u.Profile)
        .WithOne(p => p.User)
        .HasForeignKey<UserProfile>(p => p.UserId);

    // --- User ↔ Cart (1:1)
    modelBuilder.Entity<User>()
        .HasOne(u => u.Cart)
        .WithOne(c => c.User)
        .HasForeignKey<Cart>(c => c.UserId);

    // --- User ↔ Wishlist (1:1)
    modelBuilder.Entity<User>()
        .HasOne(u => u.Wishlist)
        .WithOne(w => w.User)
        .HasForeignKey<Wishlist>(w => w.UserId);

    // --- Cart → CartItems (1:M)
    modelBuilder.Entity<Cart>()
        .HasMany(c => c.Items)
        .WithOne(i => i.Cart)
        .HasForeignKey(i => i.CartId);

    // --- Wishlist → WishlistItems (1:M)
    modelBuilder.Entity<Wishlist>()
        .HasMany(w => w.Items)
        .WithOne(wi => wi.Wishlist)
        .HasForeignKey(wi => wi.WishlistId);

    // --- CartItem → Product (M:1)
    modelBuilder.Entity<CartItem>()
        .HasOne(ci => ci.Product)
        .WithMany()
        .HasForeignKey(ci => ci.ProductId);

    // --- WishlistItem → Product (M:1)
    modelBuilder.Entity<WishlistItem>()
        .HasOne(wi => wi.Product)
        .WithMany()
        .HasForeignKey(wi => wi.ProductId);

    // --- Product → Reviews (1:M)
    modelBuilder.Entity<Product>()
        .HasMany(p => p.Reviews)
        .WithOne(r => r.Product)
        .HasForeignKey(r => r.ProductId);

    // --- User → Reviews (1:M)
    modelBuilder.Entity<User>()
        .HasMany(u => u.Reviews)
        .WithOne(r => r.User)
        .HasForeignKey(r => r.UserId);

    // --- Category → Products (1:M)
    modelBuilder.Entity<Category>()
        .HasMany(c => c.Products)
        .WithOne(p => p.Category)
        .HasForeignKey(p => p.CategoryId);

    // --- Category → Category (self-referencing)
    modelBuilder.Entity<Category>()
        .HasOne(c => c.ParentCategory)
        .WithMany()
        .HasForeignKey(c => c.ParentCategoryId)
        .OnDelete(DeleteBehavior.Restrict);

    // --- Order → OrderItems (1:M)
    modelBuilder.Entity<Order>()
        .HasMany(o => o.OrderItems)
        .WithOne(oi => oi.Order)
        .HasForeignKey(oi => oi.OrderId);

    // --- OrderItem → Product (M:1)
    modelBuilder.Entity<OrderItem>()
        .HasOne(oi => oi.Product)
        .WithMany()
        .HasForeignKey(oi => oi.ProductId);

    // --- Order ↔ Payment (1:1)
    modelBuilder.Entity<Order>()
        .HasOne(o => o.Payment)
        .WithOne(p => p.Order)
        .HasForeignKey<Payment>(p => p.OrderId);
}
}