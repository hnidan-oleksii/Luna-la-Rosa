using DAL.Entities;
using Bogus;

namespace DAL.Seeding;

public class DataSeeder
{
    public IReadOnlyCollection<User> Users { get; }
    public IReadOnlyCollection<FlowerType> FlowerTypes { get; }
    public IReadOnlyCollection<Flower> Flowers { get; }
    public IReadOnlyCollection<Bouquet> Bouquets { get; }
    public IReadOnlyCollection<BouquetCategory> BouquetCategories { get; }
    public IReadOnlyCollection<BouquetCategoryBouquet> BouquetCategoryBouquets { get; }
    public IReadOnlyCollection<BouquetFlower> BouquetFlowers { get; }
    public IReadOnlyCollection<CustomBouquet> CustomBouquets { get; }
    public IReadOnlyCollection<CustomBouquetFlower> CustomBouquetFlowers { get; }
    public IReadOnlyCollection<ShoppingCart> ShoppingCarts { get; }
    public IReadOnlyCollection<CartItem> CartItems { get; }
    public IReadOnlyCollection<CartItemAddOn> CartItemAddOns { get; }
    public IReadOnlyCollection<AddOnType> AddOnTypes { get; }
    public IReadOnlyCollection<AddOn> AddOns { get; }
    public IReadOnlyCollection<BouquetAddOn> BouquetAddOns { get; }
    public IReadOnlyCollection<Order> Orders { get; }
    public IReadOnlyCollection<OrderBouquet> OrderBouquets { get; }
    public IReadOnlyCollection<OrderAddOn> OrderAddOns { get; }
    public IReadOnlyCollection<Payment> Payments { get; }

    public DataSeeder(int rows = 30)
    {
        Users = GenerateUsers(rows);

        FlowerTypes = GenerateFlowerTypes();
        Flowers = GenerateFlowers(rows);

        AddOnTypes = GenerateAddOnTypes();
        AddOns = GenerateAddOns(rows);

        Bouquets = GenerateBouquets(rows);
        BouquetCategories = GenerateBouquetCategories();
        BouquetCategoryBouquets = GenerateBouquetCategoryBouquets(10);
        BouquetFlowers = GenerateBouquetFlowers(rows);

        CustomBouquets = GenerateCustomBouquets(rows);
        CustomBouquetFlowers = GenerateCustomBouquetFlowers(rows);

        BouquetAddOns = GenerateBouquetAddOns(rows);
        UpdateBouquetPrices();
        UpdateCustomBouquetPrices();

        ShoppingCarts = GenerateShoppingCarts(10);
        CartItems = GenerateCartItems(rows);
        CartItemAddOns = GenerateCartItemAddOns(rows);
        UpdateCardItemPrices();

        Orders = GenerateOrders(rows);
        OrderBouquets = GenerateOrderBouquets(rows);
        OrderAddOns = GenerateOrderAddOns(rows);
        UpdateOrderPrices();
        Payments = GeneratePayments(Orders.Count(o => o.PaymentMethod == "Card"));
    }

    private IReadOnlyCollection<User> GenerateUsers(int count)
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

    private IReadOnlyCollection<FlowerType> GenerateFlowerTypes()
    {
        return
        [
            new FlowerType { Id = 1, Name = "Rose" },
            new FlowerType { Id = 2, Name = "Tulip" },
            new FlowerType { Id = 3, Name = "Orchid" }
        ];
    }

    private IReadOnlyCollection<Flower> GenerateFlowers(int count)
    {
        var faker = new Faker<Flower>()
            .RuleFor(f => f.Id, f => f.IndexFaker + 1)
            .RuleFor(f => f.TypeId, f => f.PickRandom<FlowerType>(FlowerTypes).Id)
            .RuleFor(f => f.Color, f => f.Commerce.Color())
            .RuleFor(f => f.Name, (_, f) => FlowerTypes.First(ft => ft.Id == f.TypeId).Name + " " + f.Color)
            .RuleFor(f => f.Price, f => f.Random.Decimal(1, 50))
            .RuleFor(f => f.AvailableQuantity, f => f.Random.Int(0, 100))
            .RuleFor(f => f.Image, f => f.Random.Bytes(100))
            .RuleFor(f => f.CreatedAt, f => f.Date.Past())
            .RuleFor(f => f.UpdatedAt, f => f.Date.Recent(14));

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<AddOnType> GenerateAddOnTypes()
    {
        return
        [
            new AddOnType { Id = 1, Name = "Balloon" },
            new AddOnType { Id = 2, Name = "PostCard" },
            new AddOnType { Id = 3, Name = "Sweets" },
            new AddOnType { Id = 4, Name = "Wrapping" },
            new AddOnType { Id = 5, Name = "Ribbon" }
        ];
    }

    private IReadOnlyCollection<AddOn> GenerateAddOns(int count)
    {
        var faker = new Faker<AddOn>()
            .RuleFor(ao => ao.Id, f => f.IndexFaker + 1)
            .RuleFor(ao => ao.TypeId, f => f.PickRandom<AddOnType>(AddOnTypes).Id)
            .RuleFor(ao => ao.Name, f => f.Commerce.ProductName())
            .RuleFor(ao => ao.Price, f => f.Random.Decimal(1, 20))
            .RuleFor(ao => ao.Image, f => f.Random.Bytes(100))
            .RuleFor(ao => ao.CreatedAt, f => f.Date.Past());

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<BouquetCategory> GenerateBouquetCategories()
    {
        return
        [
            new BouquetCategory { Id = 1, CategoryName = "Wedding" },
        ];
    }

    private IReadOnlyCollection<Bouquet> GenerateBouquets(int count)
    {
        var faker = new Faker<Bouquet>()
            .RuleFor(b => b.Id, f => f.IndexFaker + 1)
            .RuleFor(b => b.Name, f => f.Commerce.ProductName())
            .RuleFor(b => b.MainColor, f => f.Commerce.Color())
            .RuleFor(b => b.Size, f => f.PickRandom("Small", "Medium", "Large"))
            .RuleFor(b => b.Image, f => f.Random.Bytes(100))
            .RuleFor(b => b.Description, f => f.Lorem.Sentence(wordCount: 3))
            .RuleFor(b => b.PopularityScore, f => f.Random.Int(0, 100))
            .RuleFor(b => b.CreatedAt, f => f.Date.Past())
            .RuleFor(b => b.UpdatedAt, f => f.Date.Recent(14));

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<BouquetCategoryBouquet> GenerateBouquetCategoryBouquets(int count)
    {
        var faker = new Faker<BouquetCategoryBouquet>()
            .RuleFor(bca => bca.BouquetId, f => f.PickRandom<Bouquet>(Bouquets).Id)
            .RuleFor(bca => bca.CategoryId, f => f.PickRandom<BouquetCategory>(BouquetCategories).Id);

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<BouquetFlower> GenerateBouquetFlowers(int count)
    {
        var faker = new Faker<BouquetFlower>()
            .RuleFor(bf => bf.BouquetId, f => f.PickRandom<Bouquet>(Bouquets).Id)
            .RuleFor(bf => bf.FlowerId, f => f.PickRandom<Flower>(Flowers).Id)
            .RuleFor(bf => bf.Quantity, f => f.Random.Int(1, 10));

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<CustomBouquet> GenerateCustomBouquets(int count)
    {
        var faker = new Faker<CustomBouquet>()
            .RuleFor(cb => cb.Id, f => f.IndexFaker + 1)
            .RuleFor(cb => cb.UserId, f => f.PickRandom<User>(Users).Id)
            .RuleFor(cb => cb.CreatedAt, f => f.Date.Recent(30));

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<CustomBouquetFlower> GenerateCustomBouquetFlowers(int count)
    {
        var faker = new Faker<CustomBouquetFlower>()
            .RuleFor(cbf => cbf.CustomBouquetId, f => f.PickRandom<CustomBouquet>(CustomBouquets).Id)
            .RuleFor(cbf => cbf.FlowerId, f => f.PickRandom<Flower>(Flowers).Id)
            .RuleFor(cbf => cbf.Quantity, f => f.Random.Int(1, 10));

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<BouquetAddOn> GenerateBouquetAddOns(int count)
    {
        var faker = new Faker<BouquetAddOn>()
            .RuleFor(bao => bao.Id, f => f.IndexFaker + 1)
            .RuleFor(bao => bao.BouquetId, f => f.Random.Bool() ? f.PickRandom<Bouquet>(Bouquets).Id : null)
            .RuleFor(bao => bao.CustomBouquetId,
                (f, bao) => bao.BouquetId == null ? f.PickRandom<CustomBouquet>(CustomBouquets).Id : null)
            .RuleFor(bao => bao.AddOnId, f => f.PickRandom<AddOn>(AddOns).Id)
            .RuleFor(bao => bao.Quantity, f => f.Random.Int(1, 5));

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<ShoppingCart> GenerateShoppingCarts(int count)
    {
        var uniqueUsers = Users.OrderBy(_ => Guid.NewGuid()).Take(count).ToList();
        var faker = new Faker<ShoppingCart>()
            .RuleFor(sc => sc.UserId, f => uniqueUsers[f.IndexFaker].Id)
            .RuleFor(sc => sc.CreatedAt, f => f.Date.Past())
            .RuleFor(sc => sc.UpdatedAt, f => f.Date.Recent(14));

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<CartItem> GenerateCartItems(int count)
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

    private IReadOnlyCollection<CartItemAddOn> GenerateCartItemAddOns(int count)
    {
        var faker = new Faker<CartItemAddOn>()
            .RuleFor(ciaa => ciaa.CardNote, f => f.Lorem.Sentence())
            .RuleFor(ciaa => ciaa.CartItemId, f => f.PickRandom<CartItem>(CartItems).Id)
            .RuleFor(ciaa => ciaa.AddOnId, f => f.PickRandom<AddOn>(AddOns).Id);

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<Order> GenerateOrders(int count)
    {
        var faker = new Faker<Order>()
            .RuleFor(o => o.Id, f => f.IndexFaker + 1)
            .RuleFor(o => o.UserId, f => f.PickRandom<User>(Users).Id)
            .RuleFor(o => o.Status, f => f.PickRandom("Pending", "Processing", "Shipped", "Delivered"))
            .RuleFor(o => o.DeliveryPrice, f => f.Random.Decimal(20, 500))
            .RuleFor(o => o.DeliveryAddress, f => f.Address.FullAddress())
            .RuleFor(o => o.DeliveryDate, f => f.Date.Future(30))
            .RuleFor(o => o.PaymentMethod, f => f.PickRandom("Card", "Cash on Delivery"))
            .RuleFor(o => o.Comment, f => f.Lorem.Sentence())
            .RuleFor(o => o.CreatedAt, f => f.Date.Past())
            .RuleFor(o => o.UpdatedAt, f => f.Date.Recent(14));

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<OrderBouquet> GenerateOrderBouquets(int count)
    {
        var faker = new Faker<OrderBouquet>()
            .RuleFor(ob => ob.Id, f => f.IndexFaker + 1)
            .RuleFor(ob => ob.OrderId, f => f.PickRandom<Order>(Orders).Id)
            .RuleFor(ob => ob.BouquetId, f => f.Random.Bool() ? f.PickRandom<Bouquet>(Bouquets).Id : null)
            .RuleFor(ob => ob.CustomBouquetId,
                (f, ob) => ob.BouquetId == null ? f.PickRandom<CustomBouquet>(CustomBouquets).Id : null)
            .RuleFor(ob => ob.Quantity, f => f.Random.Int(1, 5));

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<OrderAddOn> GenerateOrderAddOns(int count)
    {
        var faker = new Faker<OrderAddOn>()
            .RuleFor(oao => oao.CardNote, f => f.Lorem.Sentence())
            .RuleFor(oao => oao.OrderBouquetId, f => f.PickRandom<OrderBouquet>(OrderBouquets).Id)
            .RuleFor(oao => oao.AddOnId, f => f.PickRandom<AddOn>(AddOns).Id);

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<Payment> GeneratePayments(int count)
    {
        var uniqueOrders = Orders.Where(o => o.PaymentMethod == "Card").OrderBy(_ => Guid.NewGuid()).Take(count)
            .ToList();
        var faker = new Faker<Payment>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.OrderId, f => uniqueOrders[f.IndexFaker].Id)
            .RuleFor(p => p.Amount, f => f.Random.Decimal(20, 500))
            .RuleFor(p => p.PaymentMethod, f => f.PickRandom("Card", "Cash on Delivery"))
            .RuleFor(p => p.Status, f => f.PickRandom("Pending", "Completed", "Failed"))
            .RuleFor(p => p.TransactionDate, f => f.Date.Recent(30));

        return GenerateRows(faker, count);
    }

    private void UpdateBouquetPrices()
    {
        foreach (var bouquet in Bouquets)
        {
            var bouquetPrice = BouquetFlowers
                .Where(bf => bf.BouquetId == bouquet.Id)
                .Sum(bf => Flowers.First(fl => fl.Id == bf.FlowerId).Price * bf.Quantity);
            var addOnPrice = BouquetAddOns
                .Where(bao => bao.BouquetId != null && bao.BouquetId == bouquet.Id)
                .Sum(bao => AddOns.First(ao => ao.Id == bao.AddOnId).Price * bao.Quantity);
            bouquet.Price = bouquetPrice + addOnPrice;
        }
    }

    private void UpdateCustomBouquetPrices()
    {
        foreach (var customBouquet in CustomBouquets)
        {
            var flowersPrice = CustomBouquetFlowers
                .Where(cbf => cbf.CustomBouquetId == customBouquet.Id)
                .Sum(cbf => Flowers.First(fl => fl.Id == cbf.FlowerId).Price * cbf.Quantity);
            var addOnPrice = BouquetAddOns
                .Where(bao => bao.CustomBouquetId != null && bao.CustomBouquetId == customBouquet.Id)
                .Sum(bao => AddOns.First(ao => ao.Id == bao.AddOnId).Price * bao.Quantity);

            customBouquet.TotalPrice = flowersPrice + addOnPrice;
        }
    }

    private void UpdateCardItemPrices()
    {
        foreach (var cartItem in CartItems)
        {
            var basePrice = cartItem.BouquetId.HasValue
                ? Bouquets.First(bq => bq.Id == cartItem.BouquetId.Value).Price
                : CustomBouquets.First(cb => cb.Id == cartItem.CustomBouquetId!.Value).TotalPrice;

            if (!cartItem.AddOns.Any())
            {
                continue;
            }

            var cartItemAddons = CartItemAddOns.Where(cao => cao.CartItemId == cartItem.Id);
            var addOnPrice = cartItemAddons.Sum(cao => AddOns.First(ao => ao.Id == cao.AddOnId).Price);

            cartItem.Price = basePrice * cartItem.Quantity + addOnPrice;
        }
    }

    private void UpdateOrderPrices()
    {
        foreach (var order in Orders)
        {
            var orderBouquets = OrderBouquets.Where(ob => ob.OrderId == order.Id);
            var bouquetPrice = orderBouquets.Sum(ob =>
            {
                if (ob.BouquetId.HasValue)
                    return Bouquets.First(bq => bq.Id == ob.BouquetId.Value).Price * ob.Quantity;
                return CustomBouquets.First(cb => cb.Id == ob.CustomBouquetId!.Value).TotalPrice * ob.Quantity;
            });

            var addOnPrice = OrderAddOns.Where(oa => oa.OrderBouquetId == order.Id)
                .Sum(oa => AddOns.First(ao => ao.Id == oa.AddOnId).Price);

            order.TotalPrice = bouquetPrice + addOnPrice + order.DeliveryPrice;
        }
    }

    private IReadOnlyCollection<T> GenerateRows<T>(Faker<T> faker, int count) where T : class
    {
        return Enumerable.Range(1, count).Select(rowId => SeedRow(faker, rowId)).ToList();
    }

    private T SeedRow<T>(Faker<T> faker, int rowId) where T : class
    {
        return faker.UseSeed(rowId).Generate();
    }
}