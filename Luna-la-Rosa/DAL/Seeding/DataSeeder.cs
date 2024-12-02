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

    private static readonly string[] Colors = ["Red", "Pink", "White", "Yellow", "Orange", "Purple", "Black"];

    public DataSeeder(int rows = 20)
    {
        Users = GenerateUsers();

        FlowerTypes = GenerateFlowerTypes();
        Flowers = GenerateFlowers(rows * 3);

        AddOnTypes = GenerateAddOnTypes();
        AddOns = GenerateAddOns(rows * 2);

        Bouquets = GenerateBouquets(rows * 2);
        BouquetCategories = GenerateBouquetCategories();
        BouquetCategoryBouquets = GenerateBouquetCategoryBouquets(rows);
        BouquetFlowers = GenerateBouquetFlowers();

        CustomBouquets = GenerateCustomBouquets(rows * 3);
        CustomBouquetFlowers = GenerateCustomBouquetFlowers();

        BouquetAddOns = GenerateBouquetAddOns(rows * 2);
        UpdateBouquetPrices();
        UpdateCustomBouquetPrices();

        ShoppingCarts = GenerateShoppingCarts();
        CartItems = GenerateCartItems();
        CartItemAddOns = GenerateCartItemAddOns(rows);
        UpdateCardItemPrices();

        Orders = GenerateOrders(rows);
        OrderBouquets = GenerateOrderBouquets();
        OrderAddOns = GenerateOrderAddOns(rows);
        UpdateOrderPrices();
        Payments = GeneratePayments();
    }

    private IReadOnlyCollection<User> GenerateUsers()
    {
        return new List<User>
        {
            new()
            {
                Id = 1,
                Email = "alice@gmail.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("alice"),
                FirstName = "Alice",
                LastName = "Admin",
                Role = "Admin",
                PhoneNumber = "123-456-7890"
            },
            new()
            {
                Id = 2,
                Email = "bob@gmail.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("bob"),
                FirstName = "Bob",
                LastName = "User",
                Role = "User",
                PhoneNumber = "987-654-3210"
            }
        };
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
        var images = GetImagesFromDirectoryInBase64("./Images/Flowers");
        var faker = new Faker<Flower>()
            .RuleFor(f => f.Id, f => f.IndexFaker + 1)
            .RuleFor(f => f.TypeId, f => f.PickRandom<FlowerType>(FlowerTypes).Id)
            .RuleFor(f => f.Color, f => f.PickRandom(Colors))
            .RuleFor(f => f.Name, (_, fl) =>
            {
                var flowerType = FlowerTypes.First(ft => ft.Id == fl.TypeId).Name;
                return $"{fl.Color} {flowerType}";
            })
            .RuleFor(f => f.Image, f => f.PickRandom(images))
            .RuleFor(f => f.Price, f => f.Random.Decimal(10, 100))
            .RuleFor(f => f.AvailableQuantity, f => f.Random.Int(1, 50));

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
        var images = GetImagesFromDirectoryInBase64("./Images/AddOns");
        var faker = new Faker<AddOn>()
            .RuleFor(ao => ao.Id, f => f.IndexFaker + 1)
            .RuleFor(ao => ao.TypeId, f => f.PickRandom<AddOnType>(AddOnTypes).Id)
            .RuleFor(ao => ao.Name,
                (f, ao) => AddOnTypes.First(aot => aot.Id == ao.TypeId).Name + $"\"{f.Commerce.ProductName()}\"")
            .RuleFor(ao => ao.Price, f => f.Random.Decimal(1, 20))
            .RuleFor(ao => ao.Image, f => f.PickRandom(images))
            .RuleFor(ao => ao.CreatedAt, f => f.Date.Past().ToUniversalTime());

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<BouquetCategory> GenerateBouquetCategories()
    {
        return
        [
            new BouquetCategory { Id = 1, CategoryName = "Wedding" }
        ];
    }

    private IReadOnlyCollection<Bouquet> GenerateBouquets(int count)
    {
        var images = GetImagesFromDirectoryInBase64("./Images/Bouquets");
        var faker = new Faker<Bouquet>()
            .RuleFor(b => b.Id, f => f.IndexFaker + 1)
            .RuleFor(b => b.Name, f => f.Commerce.ProductName())
            .RuleFor(b => b.MainColor, f => f.PickRandom(Colors))
            .RuleFor(b => b.Size, f => f.PickRandom("Small", "Medium", "Large"))
            .RuleFor(b => b.Image, f => f.PickRandom(images))
            .RuleFor(b => b.Description, f => f.Lorem.Sentence(3))
            .RuleFor(b => b.PopularityScore, f => f.Random.Int(0, 100))
            .RuleFor(b => b.CreatedAt, f => f.Date.Past().ToUniversalTime())
            .RuleFor(b => b.UpdatedAt, f => f.Date.Recent(14).ToUniversalTime());

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<BouquetCategoryBouquet> GenerateBouquetCategoryBouquets(int count)
    {
        var faker = new Faker<BouquetCategoryBouquet>()
            .RuleFor(bca => bca.BouquetId, f => f.PickRandom<Bouquet>(Bouquets).Id)
            .RuleFor(bca => bca.CategoryId, f => f.PickRandom<BouquetCategory>(BouquetCategories).Id);

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<BouquetFlower> GenerateBouquetFlowers()
    {
        var bouquets = Bouquets.OrderBy(_ => Guid.NewGuid()).ToList();
        var random = new Random();
        var bouquetFlowers = new List<BouquetFlower>();

        foreach (var bouquet in bouquets)
        {
            var faker = new Faker<BouquetFlower>()
                .RuleFor(bf => bf.BouquetId, _ => bouquet.Id)
                .RuleFor(bf => bf.FlowerId, (f, bf) =>
                {
                    var bouquetById = Bouquets.First(b => b.Id == bf.BouquetId);
                    var matchingFlowers = Flowers.Where(fl => fl.Color == bouquetById.MainColor).ToList();
                    var flowersNotInBouquet = matchingFlowers.Where(fl =>
                        !bouquetFlowers
                            .Where(lbf => lbf.BouquetId == bf.BouquetId)
                            .Select(lbf => lbf.FlowerId)
                            .Contains(fl.Id)
                    );
                    return f.PickRandom(flowersNotInBouquet).Id;
                })
                .RuleFor(bf => bf.Quantity, f => f.Random.Int(1, 30));

            var itemCount = random.Next(1, 3);
            bouquetFlowers.AddRange(GenerateRows(faker, itemCount));
        }

        return bouquetFlowers;
    }

    private IReadOnlyCollection<CustomBouquet> GenerateCustomBouquets(int count)
    {
        var faker = new Faker<CustomBouquet>()
            .RuleFor(cb => cb.Id, f => f.IndexFaker + 1)
            .RuleFor(cb => cb.UserId, f => f.PickRandom<User>(Users).Id)
            .RuleFor(cb => cb.CreatedAt, f => f.Date.Recent(30).ToUniversalTime());

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<CustomBouquetFlower> GenerateCustomBouquetFlowers()
    {
        var customBouquets = CustomBouquets.OrderBy(_ => Guid.NewGuid()).ToList();
        var random = new Random();
        var customBouquetFlowers = new List<CustomBouquetFlower>();

        foreach (var customBouquet in customBouquets)
        {
            var faker = new Faker<CustomBouquetFlower>()
                .RuleFor(cbf => cbf.CustomBouquetId, _ => customBouquet.Id)
                .RuleFor(cbf => cbf.FlowerId, f => f.PickRandom<Flower>(Flowers).Id)
                .RuleFor(cbf => cbf.Quantity, f => f.Random.Int(1, 10));

            var itemCount = random.Next(1, 4);
            customBouquetFlowers.AddRange(GenerateRows(faker, itemCount));
        }

        return customBouquetFlowers;
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

    private IReadOnlyCollection<ShoppingCart> GenerateShoppingCarts()
    {
        var users = Users.OrderBy(_ => Guid.NewGuid()).ToList();
        var faker = new Faker<ShoppingCart>()
            .RuleFor(sc => sc.UserId, f => users[f.IndexFaker].Id)
            .RuleFor(sc => sc.CreatedAt, f => f.Date.Past().ToUniversalTime())
            .RuleFor(sc => sc.UpdatedAt, f => f.Date.Recent(14).ToUniversalTime());

        return GenerateRows(faker, users.Count);
    }

    private IReadOnlyCollection<CartItem> GenerateCartItems()
    {
        var shoppingCarts = ShoppingCarts.OrderBy(_ => Guid.NewGuid()).ToList();
        var random = new Random();
        var cartItems = new List<CartItem>();

        foreach (var shoppingCart in shoppingCarts)
        {
            var faker = new Faker<CartItem>()
                .RuleFor(ci => ci.Id, f => f.IndexFaker + 1 + cartItems.Count)
                .RuleFor(ci => ci.CartId, _ => shoppingCart.UserId)
                .RuleFor(ci => ci.BouquetId, f => f.Random.Bool() ? f.PickRandom<Bouquet>(Bouquets).Id : null)
                .RuleFor(ci => ci.CustomBouquetId,
                    (f, ci) => ci.BouquetId == null ? f.PickRandom<CustomBouquet>(CustomBouquets).Id : null)
                .RuleFor(ci => ci.Quantity, f => f.Random.Int(1, 5));

            var itemsCount = random.Next(1, 5);
            cartItems.AddRange(GenerateRows(faker, itemsCount));
        }

        return cartItems;
    }

    private IReadOnlyCollection<CartItemAddOn> GenerateCartItemAddOns(int count)
    {
        var cartItemsAddOns = new List<CartItemAddOn>();
        var random = new Random();

        for (var i = 0; i < count; i++)
        {
            var faker = new Faker<CartItemAddOn>()
                .RuleFor(ciao => ciao.CartItemId, f => f.PickRandom<CartItem>(CartItems).Id)
                .RuleFor(ciao => ciao.AddOnId, (f, ciao) =>
                {
                    var addOnsNotWithCartItem = AddOns.Where(aol =>
                        !cartItemsAddOns
                            .Where(lciao => lciao.CartItemId == ciao.CartItemId)
                            .Select(lciao => lciao.AddOnId)
                            .Contains(aol.Id));

                    return f.PickRandom<AddOn>(addOnsNotWithCartItem).Id;
                })
                .RuleFor(ciao => ciao.Quantity, f => f.Random.Int(1, 5))
                .RuleFor(ciao => ciao.CardNote, (f, ciao) =>
                {
                    var addOnTypeName = AddOnTypes
                        .First(aot => aot.Id == AddOns.First(ao => ao.Id == ciao.AddOnId).TypeId).Name;
                    return addOnTypeName == "PostCard" ? f.Lorem.Sentence() : null;
                });

            var itemsCount = random.Next(1, 5);
            cartItemsAddOns.AddRange(GenerateRows<CartItemAddOn>(faker, itemsCount));
        }

        return cartItemsAddOns;
    }

    private IReadOnlyCollection<Order> GenerateOrders(int count)
    {
        var faker = new Faker<Order>()
            .RuleFor(o => o.Id, f => f.IndexFaker + 1)
            .RuleFor(o => o.UserId, f => f.PickRandom<User>(Users).Id)
            .RuleFor(o => o.Status, f => f.PickRandom("Pending", "Processing", "Shipped"))
            .RuleFor(o => o.DeliveryPrice, f => f.Random.Decimal(20, 500))
            .RuleFor(o => o.DeliveryAddress, f => f.Address.FullAddress())
            .RuleFor(o => o.DeliveryDate, f => f.Date.Future(30).ToUniversalTime())
            .RuleFor(o => o.PaymentMethod, f => f.PickRandom("Card", "Cash"))
            .RuleFor(o => o.Comment, f => f.Lorem.Sentence())
            .RuleFor(o => o.CreatedAt, f => f.Date.Past().ToUniversalTime())
            .RuleFor(o => o.UpdatedAt, f => f.Date.Recent(14).ToUniversalTime());

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<OrderBouquet> GenerateOrderBouquets()
    {
        var orders = Orders.OrderBy(_ => Guid.NewGuid()).ToList();
        var random = new Random();
        var orderBouquets = new List<OrderBouquet>();

        foreach (var order in orders)
        {
            var faker = new Faker<OrderBouquet>()
                .RuleFor(ob => ob.Id, f => f.IndexFaker + 1 + orderBouquets.Count)
                .RuleFor(ob => ob.OrderId, _ => order.Id)
                .RuleFor(ob => ob.BouquetId, f => f.Random.Bool() ? f.PickRandom<Bouquet>(Bouquets).Id : null)
                .RuleFor(ob => ob.CustomBouquetId,
                    (f, ob) => ob.BouquetId == null ? f.PickRandom<CustomBouquet>(CustomBouquets).Id : null)
                .RuleFor(ob => ob.Quantity, f => f.Random.Int(1, 5));

            var itemCount = random.Next(1, 3);
            orderBouquets.AddRange(GenerateRows(faker, itemCount));
        }

        return orderBouquets;
    }

    private IReadOnlyCollection<OrderAddOn> GenerateOrderAddOns(int count)
    {
        var orderAddOns = new List<OrderAddOn>();
        var random = new Random();

        for (var i = 0; i < count; i++)
        {
            var faker = new Faker<OrderAddOn>()
                .RuleFor(oao => oao.OrderBouquetId, f => f.PickRandom<OrderBouquet>(OrderBouquets).Id)
                .RuleFor(oao => oao.AddOnId, (f, oao) =>
                {
                    var addOnsNotWithOrderBouquet = AddOns.Where(aol =>
                        !orderAddOns
                            .Where(loao => loao.OrderBouquetId == oao.OrderBouquetId)
                            .Select(loao => loao.AddOnId)
                            .Contains(aol.Id));

                    return f.PickRandom<AddOn>(addOnsNotWithOrderBouquet).Id;
                })
                .RuleFor(oao => oao.CardNote, (f, oao) =>
                {
                    var addOnTypeName = AddOnTypes
                        .First(aot => aot.Id == AddOns.First(ao => ao.Id == oao.AddOnId).TypeId).Name;
                    return addOnTypeName == "PostCard" ? f.Lorem.Sentence() : null;
                });

            var itemCount = random.Next(1, 4);
            orderAddOns.AddRange(GenerateRows(faker, itemCount));
        }

        return orderAddOns;
    }

    private IReadOnlyCollection<Payment> GeneratePayments()
    {
        var ordersPayedByCard = Orders.Where(o => o.PaymentMethod == "Card").OrderBy(_ => Guid.NewGuid()).ToList();
        var faker = new Faker<Payment>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.OrderId, f => ordersPayedByCard[f.IndexFaker].Id)
            .RuleFor(p => p.Amount, f => f.Random.Decimal(20, 500))
            .RuleFor(p => p.PaymentMethod, f => f.PickRandom("Card", "Cash"))
            .RuleFor(p => p.Status, f => f.PickRandom("Pending", "Completed", "Failed"))
            .RuleFor(p => p.TransactionDate, f => f.Date.Recent(30).ToUniversalTime());

        return GenerateRows(faker, ordersPayedByCard.Count);
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

            if (!cartItem.AddOns.Any()) continue;

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

    private List<byte[]> GetImagesFromDirectoryInBase64(string pathToImages)
    {
        var fileNames = Directory.GetFiles(pathToImages).ToList();
        var imagesAsBase64Strings = fileNames
            .Select(File.ReadAllBytes)
            .ToList();
        return imagesAsBase64Strings;
    }
}