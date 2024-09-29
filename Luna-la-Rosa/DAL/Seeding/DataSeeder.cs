using DAL.Entities;
using Bogus;

namespace DAL.Seeding;

public class DataSeeder
{
    public IReadOnlyCollection<User> Users { get; }
    public IReadOnlyCollection<Flower> Flowers { get; }
    public IReadOnlyCollection<Bouquet> Bouquets { get; }
    public IReadOnlyCollection<BouquetCategory> BouquetCategories { get; }
    public IReadOnlyCollection<BouquetCategoryBouquet> BouquetCategoryBouquets { get; }
    public IReadOnlyCollection<BouquetFlower> BouquetFlowers { get; }
    public IReadOnlyCollection<CustomBouquet> CustomBouquets { get; }
    public IReadOnlyCollection<CustomBouquetFlower> CustomBouquetFlowers { get; }
    public IReadOnlyCollection<ShoppingCart> ShoppingCarts { get; }
    public IReadOnlyCollection<CartItem> CartItems { get; }
    public IReadOnlyCollection<CartItemAddOn> CartItemAddOn { get; }
    public IReadOnlyCollection<AddOn> AddOns { get; }
    public IReadOnlyCollection<Order> Orders { get; }
    public IReadOnlyCollection<OrderBouquet> OrderBouquets { get; }
    public IReadOnlyCollection<OrderAddOn> OrderAddOns { get; }
    public IReadOnlyCollection<Payment> Payments { get; }

    public DataSeeder(int rows = 30)
    {
        Users = GenerateUsers(rows);
        Flowers = GenerateFlowers(rows);
        Bouquets = GenerateBouquets(rows);
        BouquetCategories = GenerateBouquetCategories(rows);
        BouquetCategoryBouquets = GenerateBouquetCategoryBouquets(rows);
        BouquetFlowers = GenerateBouquetFlowers(rows);
        CustomBouquets = GenerateCustomBouquets(rows);
        CustomBouquetFlowers = GenerateCustomBouquetFlowers(rows);
        ShoppingCarts = GenerateShoppingCarts(rows);
        CartItems = GenerateCartItems(rows);
        AddOns = GenerateAddOns(rows);
        CartItemAddOn = GenerateCartItemAddOn(rows);
        Orders = GenerateOrders(rows);
        OrderBouquets = GenerateOrderBouquets(rows);
        OrderAddOns = GenerateOrderAddOns(rows);
        Payments = GeneratePayments(rows);
    }

    public IReadOnlyCollection<User> GenerateUsers(int count)
    {
        var faker = new Faker<User>()
            .RuleFor(u => u.Id, f => f.IndexFaker + 1)
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.PasswordHash, f => f.Internet.Password())
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(u => u.Role, f => f.PickRandom("User", "Admin"))
            .RuleFor(u => u.CreatedAt, f => f.Date.Past())
            .RuleFor(u => u.UpdatedAt, f => f.Date.Recent(14));

        return GenerateRows(faker, count);
    }

    public IReadOnlyCollection<Flower> GenerateFlowers(int count)
    {
        var faker = new Faker<Flower>()
            .RuleFor(f => f.Id, f => f.IndexFaker + 1)
            .RuleFor(f => f.Name, f => f.Commerce.ProductName())
            .RuleFor(f => f.Type, f => f.PickRandom("Rose", "Tulip", "Lily", "Daisy", "Sunflower"))
            .RuleFor(f => f.Color, f => f.Commerce.Color())
            .RuleFor(f => f.Price, f => f.Random.Decimal(1, 50))
            .RuleFor(f => f.AvailableQuantity, f => f.Random.Int(0, 100))
            .RuleFor(f => f.Image, f => f.Random.Bytes(100))
            .RuleFor(f => f.CreatedAt, f => f.Date.Past())
            .RuleFor(f => f.UpdatedAt, f => f.Date.Recent(14));

        return GenerateRows(faker, count);
    }

    public IReadOnlyCollection<Bouquet> GenerateBouquets(int count)
    {
        var faker = new Faker<Bouquet>()
            .RuleFor(b => b.Id, f => f.IndexFaker + 1)
            .RuleFor(b => b.Name, f => f.Commerce.ProductName())
            .RuleFor(b => b.Price, (_, b) =>
            {
                var bouquetFlowers = BouquetFlowers.Where(bf => bf.BouquetId == b.Id);
                var bouquetPrice =
                    bouquetFlowers.Sum(bf => Flowers.First(fl => fl.Id == bf.FlowerId).Price * bf.Quantity);
                return bouquetPrice;
            })
            .RuleFor(b => b.MainColor, f => f.Commerce.Color())
            .RuleFor(b => b.Size, f => f.PickRandom("Small", "Medium", "Large"))
            .RuleFor(b => b.Image1, f => f.Random.Bytes(100))
            .RuleFor(b => b.Image2, f => f.Random.Bytes(100))
            .RuleFor(b => b.Image3, f => f.Random.Bytes(100))
            .RuleFor(b => b.Description, f => f.Lorem.Sentence())
            .RuleFor(b => b.PopularityScore, f => f.Random.Int(0, 100))
            .RuleFor(b => b.CreatedAt, f => f.Date.Past())
            .RuleFor(b => b.UpdatedAt, f => f.Date.Recent(14));

        return GenerateRows(faker, count);
    }

    public IReadOnlyCollection<BouquetCategory> GenerateBouquetCategories(int count)
    {
        var faker = new Faker<BouquetCategory>()
            .RuleFor(bc => bc.Id, f => f.IndexFaker + 1)
            .RuleFor(bc => bc.CategoryName, f => f.Commerce.Categories(1)[0]);

        return GenerateRows(faker, count);
    }

    public IReadOnlyCollection<BouquetCategoryBouquet> GenerateBouquetCategoryBouquets(int count)
    {
        var faker = new Faker<BouquetCategoryBouquet>()
            .RuleFor(bca => bca.BouquetId, f => f.PickRandom<Bouquet>(Bouquets).Id)
            .RuleFor(bca => bca.CategoryId, f => f.PickRandom<BouquetCategory>(BouquetCategories).Id);

        return GenerateRows(faker, count);
    }

    public IReadOnlyCollection<BouquetFlower> GenerateBouquetFlowers(int count)
    {
        var faker = new Faker<BouquetFlower>()
            .RuleFor(bf => bf.BouquetId, f => f.PickRandom<Bouquet>(Bouquets).Id)
            .RuleFor(bf => bf.FlowerId, f => f.PickRandom<Flower>(Flowers).Id)
            .RuleFor(bf => bf.Quantity, f => f.Random.Int(1, 10));

        return GenerateRows(faker, count);
    }

    public IReadOnlyCollection<CustomBouquet> GenerateCustomBouquets(int count)
    {
        var faker = new Faker<CustomBouquet>()
            .RuleFor(cb => cb.Id, f => f.IndexFaker + 1)
            .RuleFor(cb => cb.UserId, f => f.PickRandom<User>(Users).Id)
            .RuleFor(cb => cb.TotalPrice, (_, cb) =>
            {
                var bouquetFlowers = CustomBouquetFlowers.Where(cbf => cbf.CustomBouquetId == cb.Id);
                var flowersPrice =
                    bouquetFlowers.Sum(cbf => Flowers.First(fl => fl.Id == cbf.FlowerId).Price * cbf.Quantity);
                return flowersPrice;
            })
            .RuleFor(cb => cb.CreatedAt, f => f.Date.Recent(30));

        return GenerateRows(faker, count);
    }

    public IReadOnlyCollection<CustomBouquetFlower> GenerateCustomBouquetFlowers(int count)
    {
        var faker = new Faker<CustomBouquetFlower>()
            .RuleFor(cbf => cbf.CustomBouquetId, f => f.PickRandom<CustomBouquet>(CustomBouquets).Id)
            .RuleFor(cbf => cbf.FlowerId, f => f.PickRandom<Flower>(Flowers).Id)
            .RuleFor(cbf => cbf.Quantity, f => f.Random.Int(1, 10));

        return GenerateRows(faker, count);
    }

    public IReadOnlyCollection<ShoppingCart> GenerateShoppingCarts(int count)
    {
        var faker = new Faker<ShoppingCart>()
            .RuleFor(sc => sc.UserId, f => f.PickRandom<User>(Users).Id)
            .RuleFor(sc => sc.CreatedAt, f => f.Date.Past())
            .RuleFor(sc => sc.UpdatedAt, f => f.Date.Recent(14));

        return GenerateRows(faker, count);
    }

    public IReadOnlyCollection<CartItem> GenerateCartItems(int count)
    {
        var faker = new Faker<CartItem>()
            .RuleFor(ci => ci.Id, f => f.IndexFaker + 1)
            .RuleFor(ci => ci.CartId, f => f.PickRandom<ShoppingCart>(ShoppingCarts).UserId)
            .RuleFor(ci => ci.BouquetId, f => f.Random.Bool() ? f.PickRandom<Bouquet>(Bouquets).Id : null)
            .RuleFor(ci => ci.CustomBouquetId,
                (f, ci) => ci.BouquetId == null ? f.PickRandom<CustomBouquet>(CustomBouquets).Id : null)
            .RuleFor(ci => ci.Quantity, f => f.Random.Int(1, 5));

        return GenerateRows(faker, count);
    }

    public IReadOnlyCollection<AddOn> GenerateAddOns(int count)
    {
        var faker = new Faker<AddOn>()
            .RuleFor(ao => ao.Id, f => f.IndexFaker + 1)
            .RuleFor(ao => ao.Type, f => f.PickRandom("Balloons", "Card", "Sweets", "Wrapping", "Ribbon"))
            .RuleFor(ao => ao.Name, f => f.Commerce.ProductName())
            .RuleFor(ao => ao.Price, f => f.Random.Decimal(1, 20))
            .RuleFor(ao => ao.Image, f => f.Random.Bytes(100))
            .RuleFor(ao => ao.CreatedAt, f => f.Date.Past());

        return GenerateRows(faker, count);
    }

    public IReadOnlyCollection<CartItemAddOn> GenerateCartItemAddOn(int count)
    {
        var faker = new Faker<CartItemAddOn>()
            .RuleFor(ciaa => ciaa.CardNote, f => f.Lorem.Sentence())
            .RuleFor(ciaa => ciaa.CartItemId, f => f.PickRandom<CartItem>(CartItems).Id)
            .RuleFor(ciaa => ciaa.AddOnId, f => f.PickRandom<AddOn>(AddOns).Id);

        return GenerateRows(faker, count);
    }

    public IReadOnlyCollection<Order> GenerateOrders(int count)
    {
        var faker = new Faker<Order>()
            .RuleFor(o => o.Id, f => f.IndexFaker + 1)
            .RuleFor(o => o.UserId, f => f.PickRandom<User>(Users).Id)
            .RuleFor(o => o.Status, f => f.PickRandom("Pending", "Processing", "Shipped", "Delivered"))
            .RuleFor(o => o.DeliveryPrice, f => f.Random.Decimal(20, 500))
            .RuleFor(o => o.TotalPrice, (_, o) =>
            {
                var orderBouquets = OrderBouquets.Where(ob => ob.OrderId == o.Id);
                var bouquetPrice = orderBouquets.Sum(ob =>
                {
                    if (ob.BouquetId.HasValue)
                        return Bouquets.First(bq => bq.Id == ob.BouquetId.Value).Price * ob.Quantity;
                    else
                        return CustomBouquets.First(cb => cb.Id == ob.CustomBouquetId.Value).TotalPrice * ob.Quantity;
                });

                var addOnPrice = OrderAddOns.Where(oa => oa.OrderBouquetId == o.Id)
                    .Sum(oa => AddOns.First(ao => ao.Id == oa.AddOnId).Price);

                return bouquetPrice + addOnPrice + o.DeliveryPrice;
            })
            .RuleFor(o => o.DeliveryAddress, f => f.Address.FullAddress())
            .RuleFor(o => o.DeliveryDate, f => f.Date.Future(30))
            .RuleFor(o => o.PaymentMethod, f => f.PickRandom("Card", "Cash on Delivery"))
            .RuleFor(o => o.Comment, f => f.Lorem.Sentence())
            .RuleFor(o => o.CreatedAt, f => f.Date.Past())
            .RuleFor(o => o.UpdatedAt, f => f.Date.Recent(14));

        return GenerateRows(faker, count);
    }

    public IReadOnlyCollection<OrderBouquet> GenerateOrderBouquets(int count)
    {
        var faker = new Faker<OrderBouquet>()
            .RuleFor(ob => ob.Id, f => f.IndexFaker + 1)
            .RuleFor(ob => ob.OrderId, f => f.PickRandom<Order>(Orders).Id)
            .RuleFor(ob => ob.BouquetId, f => f.Random.Bool() ? f.PickRandom<Bouquet>(Bouquets).Id : null)
            .RuleFor(ob => ob.CustomBouquetId,
                (f, ob) => ob.BouquetId == null ? f.PickRandom<CustomBouquet>(CustomBouquets).Id : null)
            .RuleFor(ob => ob.Quantity, f => f.Random.Int(1, 5))
            .RuleFor(ob => ob.Price, f => f.Random.Decimal(10, 200));

        return GenerateRows(faker, count);
    }

    public IReadOnlyCollection<OrderAddOn> GenerateOrderAddOns(int count)
    {
        var faker = new Faker<OrderAddOn>()
            .RuleFor(oao => oao.CardNote, f => f.Lorem.Sentence())
            .RuleFor(oao => oao.OrderBouquetId, f => f.PickRandom<OrderBouquet>(OrderBouquets).Id)
            .RuleFor(oao => oao.AddOnId, f => f.PickRandom<AddOn>(AddOns).Id);

        return GenerateRows(faker, count);
    }

    public IReadOnlyCollection<Payment> GeneratePayments(int count)
    {
        var faker = new Faker<Payment>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.OrderId, f => f.PickRandom<Order>(Orders).Id)
            .RuleFor(p => p.Amount, f => f.Random.Decimal(20, 500))
            .RuleFor(p => p.PaymentMethod, f => f.PickRandom("Card", "Cash on Delivery"))
            .RuleFor(p => p.Status, f => f.PickRandom("Pending", "Completed", "Failed"))
            .RuleFor(p => p.TransactionDate, f => f.Date.Recent(30));

        return GenerateRows(faker, count);
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