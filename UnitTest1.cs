using Xunit;

namespace Labo05_TestingDeEffectieveTests;

public class UnitTest1
{
    [Fact]
    public async Task Add_Order_ArgumentException()
    {
        var sneakerService = Helper.CreateSneakerService();

        Assert.ThrowsAsync<ArgumentException>(async () => sneakerService.AddOrder(null));

    }

    [Fact]
    public async Task Add_Order_And_Update_Stock()
    {
        var sneakerService = Helper.CreateSneakerService();

        FakeSneakerRepository._sneakers.Add(new Sneaker() { Name = "Sneaker 1", SneakerId = "1", Brand = new Brand() { Name = "Nike" }, Stock = 10 });
        var newOrder = new Order()
        {
            SneakerId = "1",
            Email = "xxx@gmail.com"
        };

        var createdOrder = await sneakerService.AddOrder(newOrder);
        Assert.NotNull(createdOrder);

        var sneaker = await sneakerService.GetSneakerById("1");
        Assert.Equal<int>(9, sneaker.Stock);
    }
}