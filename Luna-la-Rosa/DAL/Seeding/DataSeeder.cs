using DAL.Entities;
using Bogus;

namespace DAL.Seeding;

public class DataSeeder
{
    public IReadOnlyCollection<User> Users { get; private set; }
    public IReadOnlyCollection<Flower> Flowers { get; private set; }
    public IReadOnlyCollection<BouquetCategory> BouquetCategories { get; private set; }
    public IReadOnlyCollection<Bouquet> Bouquets { get; private set; }
    public IReadOnlyCollection<BouquetCategoryAssociation> BouquetCategoryAssociations { get; private set; }
    public IReadOnlyCollection<CustomBouquet> CustomBouquets { get; private set; }
    public IReadOnlyCollection<ShoppingCart> ShoppingCarts { get; private set; }
    public IReadOnlyCollection<Order> Orders { get; private set; }
    public IReadOnlyCollection<Payment> Payments { get; private set; }
    public IReadOnlyCollection<AddOn> AddOns { get; private set; }
    public IReadOnlyCollection<BouquetFlower> BouquetFlowers { get; private set; }
    public IReadOnlyCollection<CustomBouquetFlower> CustomBouquetFlowers { get; private set; }
    public IReadOnlyCollection<CartItem> CartItems { get; private set; }
    public IReadOnlyCollection<OrderBouquet> OrderBouquets { get; private set; }
    public IReadOnlyCollection<OrderAddOn> OrderAddOns { get; private set; }

    public DataSeeder(int rows=20)
    {
        Users = GenerateUsers(rows);
        Flowers = GenerateFlowers(rows);
        BouquetCategories = GenerateBouquetCategories(rows);
        Bouquets = GenerateBouquets(rows);
        BouquetCategoryAssociations = GenerateBouquetCategoryAssociations(rows);
        CustomBouquets = GenerateCustomBouquets(rows);
        ShoppingCarts = GenerateShoppingCarts(rows);
        Orders = GenerateOrders(rows);
        Payments = GeneratePayments(rows);
        AddOns = GenerateAddOns(rows);
        BouquetFlowers = GenerateBouquetFlowers(rows);
        CustomBouquetFlowers = GenerateCustomBouquetFlowers(rows);
        CartItems = GenerateCartItems(rows);
        OrderBouquets = GenerateOrderBouquets(rows);
        OrderAddOns = GenerateOrderAddOns(rows);
    }

    private IReadOnlyCollection<User> GenerateUsers(int count)
    {
        var faker = new Faker<User>()
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.PasswordHash, f => f.Internet.Password())
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.ContactInformation, f => f.Phone.PhoneNumber())
            .RuleFor(u => u.Role, f => f.PickRandom("User", "Admin"));

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<Flower> GenerateFlowers(int count)
    {
        var faker = new Faker<Flower>()
            .RuleFor(f => f.Name, f => f.Commerce.ProductName())
            .RuleFor(f => f.Type, f => f.Commerce.Categories(1).First())
            .RuleFor(f => f.Color, f => f.Commerce.Color())
            .RuleFor(f => f.Price, f => f.Finance.Amount(1, 20))
            .RuleFor(f => f.AvailableQuantity, f => f.Random.Int(0, 50));

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<BouquetCategory> GenerateBouquetCategories(int count)
    {
        var faker = new Faker<BouquetCategory>()
            .RuleFor(bc => bc.CategoryName, f => f.Commerce.Department())
            .RuleFor(bc => bc.Description, f => f.Lorem.Paragraph());

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<Bouquet> GenerateBouquets(int count)
    {
        var faker = new Faker<Bouquet>()
            .RuleFor(b => b.MainColor, f => f.Commerce.Color())
            .RuleFor(b => b.Size, f => f.PickRandom("Classic", "Premium", "Deluxe"));

        var bouquets = GenerateRows(faker, count);
        
        foreach (var bouquet in bouquets)
        {
            bouquet.Price = BouquetFlowers.Where(bf => bf.BouquetId == bouquet.Id)
                .Sum(bf => Flowers.First(f => f.Id == bf.FlowerId).Price);
        }

        return bouquets;
    }
    
    private IReadOnlyCollection<BouquetCategoryAssociation> GenerateBouquetCategoryAssociations(int count)
    {
        var associations = new List<BouquetCategoryAssociation>();
        for (int i = 0; i < count; i++)
        {
            associations.Add(new BouquetCategoryAssociation
            {
                BouquetId = i % Bouquets.Count + 1,
                CategoryId = i % Bouquets.Count + 1
            });
        }
        return associations;
    } 

    private IReadOnlyCollection<CustomBouquet> GenerateCustomBouquets(int count)
    {
        var faker = new Faker<CustomBouquet>()
            .RuleFor(cb => cb.TotalPrice, f => f.Finance.Amount(10, 300))
            .RuleFor(cb => cb.Ribbon, f => f.Commerce.Color())
            .RuleFor(cb => cb.Wrapping, f => f.Commerce.Color())
            .RuleFor(cb => cb.UserId, f => f.PickRandom(Users.Select(u => u.Id)));

        var customBouquets = GenerateRows(faker, count);

        foreach (var customBouquet in customBouquets)
        {
            customBouquet.TotalPrice = CustomBouquetFlowers.Where(cbf => cbf.CustomBouquetId == customBouquet.Id)
                .Sum(cbf => Flowers.First(f => f.Id == cbf.FlowerId).Price);
        }

        return customBouquets;
    }

    private IReadOnlyCollection<ShoppingCart> GenerateShoppingCarts(int count)
    {
        var faker = new Faker<ShoppingCart>()
            .RuleFor(sc => sc.UserId, f => f.PickRandom(Users.Select(u => u.Id)));

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<Order> GenerateOrders(int count)
    {
        var faker = new Faker<Order>()
            .RuleFor(o => o.UserId, f => f.PickRandom(Users.Select(u => u.Id)))
            .RuleFor(o => o.Status, f => f.PickRandom("Pending", "Completed", "Cancelled"))
            .RuleFor(o => o.DeliveryAddress, f => f.Address.FullAddress())
            .RuleFor(o => o.DeliveryDate, f => f.Date.Future())
            .RuleFor(o => o.PaymentMethod, f => f.PickRandom("Credit Card", "PayPal", "Cash"))
            .RuleFor(o => o.Comment, f => f.Lorem.Sentence());

        var orders = GenerateRows(faker, count);
        
        foreach (var order in orders)
        {
            order.TotalPrice = OrderBouquets.Where(ob => ob.OrderId == order.Id)
                .Sum(ob => Bouquets.First(b => b.Id == ob.BouquetId).Price) +
                OrderAddOns.Where(oa => oa.OrderBouquetId == order.Id)
                .Sum(oa => AddOns.First(a => a.Id == oa.AddOnId).Price);
        }

        return orders;
    }

    private IReadOnlyCollection<Payment> GeneratePayments(int count)
    {
        var faker = new Faker<Payment>()
            .RuleFor(p => p.OrderId, f => f.PickRandom(Orders.Select(o => o.Id)))
            .RuleFor(p => p.Amount, f => f.Finance.Amount(10, 500))
            .RuleFor(p => p.PaymentMethod, f => f.PickRandom("Credit Card", "PayPal", "Cash"))
            .RuleFor(p => p.Status, f => f.PickRandom("Pending", "Completed"))
            .RuleFor(p => p.TransactionDate, f => f.Date.Recent());

        var payments = GenerateRows(faker, count);

        foreach (var payment in payments)
        {
            var order = Orders.First(o => o.Id == payment.OrderId);
            payment.Amount = order.TotalPrice;
        }

        return payments;
    }

    private IReadOnlyCollection<AddOn> GenerateAddOns(int count)
    {
        var faker = new Faker<AddOn>()
            .RuleFor(a => a.Type, f => f.PickRandom("Vase", "Card", "Sweets"))
            .RuleFor(a => a.Name, f => f.Commerce.ProductName())
            .RuleFor(a => a.Price, f => f.Finance.Amount(1, 50));

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<BouquetFlower> GenerateBouquetFlowers(int count)
    {
        var bouquetFlowerList = new List<BouquetFlower>();
        for (int i = 0; i < count; i++)
        {
            bouquetFlowerList.Add(new BouquetFlower
            {
                BouquetId = (i % Bouquets.Count) + 1,
                FlowerId = (i % Flowers.Count) + 1,
                Quantity = new Faker().Random.Int(1, 30)
            });
        }
        return bouquetFlowerList;
    }

    private IReadOnlyCollection<CustomBouquetFlower> GenerateCustomBouquetFlowers(int count)
    {
        var customBouquetFlowerList = new List<CustomBouquetFlower>();
        for (int i = 0; i < count; i++)
        {
            customBouquetFlowerList.Add(new CustomBouquetFlower
            {
                CustomBouquetId = (i % CustomBouquets.Count) + 1,
                FlowerId = (i % Flowers.Count) + 1,
                Quantity = new Faker().Random.Int(1, 30)
            });
        }
        return customBouquetFlowerList;
    }

    private IReadOnlyCollection<CartItem> GenerateCartItems(int count)
    {
        var cartItemList = new List<CartItem>();
        for (int i = 0; i < count; i++)
        {
            cartItemList.Add(new CartItem
            {
                CartId = (i % ShoppingCarts.Count) + 1,
                BouquetId = (i % Bouquets.Count) + 1,
                CustomBouquetId = (i % CustomBouquets.Count) < 5 ? (int?)null : (i % CustomBouquets.Count + 1),
                Quantity = new Faker().Random.Int(1, 10)
            });
        }
        return cartItemList;
    }

    private IReadOnlyCollection<OrderBouquet> GenerateOrderBouquets(int count)
    {
        var orderBouquetList = new List<OrderBouquet>();
        for (int i = 0; i < count; i++)
        {
            orderBouquetList.Add(new OrderBouquet
            {
                OrderId = i + 1,
                BouquetId = (i % Bouquets.Count) + 1,
                CustomBouquetId = (i % CustomBouquets.Count) < 5 ? (int?)null : (i % CustomBouquets.Count + 1),
                Quantity = new Faker().Random.Int(1, 10),
                Price = Bouquets.First(b => b.Id == (i % Bouquets.Count) + 1).Price
            });
        }
        return orderBouquetList;
    }

    private IReadOnlyCollection<OrderAddOn> GenerateOrderAddOns(int count)
    {
        var orderAddOnList = new List<OrderAddOn>();
        for (int i = 0; i < count; i++)
        {
            orderAddOnList.Add(new OrderAddOn
            {
                OrderBouquetId = (i % OrderBouquets.Count) + 1,
                AddOnId = (i % AddOns.Count) + 1
            });
        }
        return orderAddOnList;
    }

    private static IReadOnlyCollection<T> GenerateRows<T>(Faker<T> faker, int count) where T : class
    {
        return Enumerable.Range(1, count).Select(rowId => SeedRow(faker, rowId)).ToList();
    }

    private static T SeedRow<T>(Faker<T> faker, int rowId) where T : class
    {
        return faker.UseSeed(rowId).Generate();
    }
}
