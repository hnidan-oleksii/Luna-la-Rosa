using DAL.Context.Configuration;
using DAL.Entities;
using DAL.Seeding;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public class LunaContext : DbContext
{
    public LunaContext(DbContextOptions<LunaContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
	public DbSet<FlowerType> FlowerTypes { get; set; }
    public DbSet<Flower> Flowers { get; set; }
    public DbSet<Bouquet> Bouquets { get; set; }
    public DbSet<BouquetCategory> BouquetCategories { get; set; }
    public DbSet<BouquetCategoryBouquet> BouquetCategoryBouquets { get; set; }
    public DbSet<BouquetFlower> BouquetFlowers { get; set; }
    public DbSet<CustomBouquet> CustomBouquets { get; set; }
    public DbSet<CustomBouquetFlower> CustomBouquetFlowers { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<CartItemAddOn> CartItemAddOns { get; set; }
	public DbSet<AddOnType> AddOnTypes { get; set; }
    public DbSet<AddOn> AddOns { get; set; }
	public DbSet<BouquetAddOn> BouquetAddOns { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderBouquet> OrderBouquets { get; set; }
    public DbSet<OrderAddOn> OrderAddOns { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
		modelBuilder.ApplyConfiguration(new FlowerTypeConfiguration());
        modelBuilder.ApplyConfiguration(new FlowerConfiguration());
        modelBuilder.ApplyConfiguration(new BouquetConfiguration());
        modelBuilder.ApplyConfiguration(new BouquetCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new BouquetCategoryBouquetConfiguration());
        modelBuilder.ApplyConfiguration(new BouquetFlowerConfiguration());
        modelBuilder.ApplyConfiguration(new CustomBouquetConfiguration());
        modelBuilder.ApplyConfiguration(new CustomBouquetFlowerConfiguration());
        modelBuilder.ApplyConfiguration(new ShoppingCartConfiguration());
        modelBuilder.ApplyConfiguration(new CartItemConfiguration());
        modelBuilder.ApplyConfiguration(new CartItemAddOnConfiguration());
		modelBuilder.ApplyConfiguration(new AddOnTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AddOnConfiguration());
		modelBuilder.ApplyConfiguration(new BouquetAddOnConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderBouquetConfiguration());
        modelBuilder.ApplyConfiguration(new OrderAddOnConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());

        var seeder = new DataSeeder();

        modelBuilder.Entity<User>().HasData(seeder.Users);
		modelBuilder.Entity<FlowerType>().HasData(seeder.FlowerTypes);
        modelBuilder.Entity<Flower>().HasData(seeder.Flowers);
        modelBuilder.Entity<Bouquet>().HasData(seeder.Bouquets);
        modelBuilder.Entity<BouquetCategory>().HasData(seeder.BouquetCategories);
        modelBuilder.Entity<BouquetCategoryBouquet>().HasData(seeder.BouquetCategoryBouquets);
        modelBuilder.Entity<BouquetFlower>().HasData(seeder.BouquetFlowers);
        modelBuilder.Entity<CustomBouquet>().HasData(seeder.CustomBouquets);
        modelBuilder.Entity<CustomBouquetFlower>().HasData(seeder.CustomBouquetFlowers);
        modelBuilder.Entity<ShoppingCart>().HasData(seeder.ShoppingCarts);
        modelBuilder.Entity<CartItem>().HasData(seeder.CartItems);
		modelBuilder.Entity<AddOnType>().HasData(seeder.AddOnTypes);
        modelBuilder.Entity<AddOn>().HasData(seeder.AddOns);
        modelBuilder.Entity<CartItemAddOn>().HasData(seeder.CartItemAddOn);
		modelBuilder.Entity<BouquetAddOn>().HasData(seeder.BouquetAddOns);
        modelBuilder.Entity<Order>().HasData(seeder.Orders);
        modelBuilder.Entity<OrderBouquet>().HasData(seeder.OrderBouquets);
        modelBuilder.Entity<OrderAddOn>().HasData(seeder.OrderAddOns);
        modelBuilder.Entity<Payment>().HasData(seeder.Payments);
    }
}
