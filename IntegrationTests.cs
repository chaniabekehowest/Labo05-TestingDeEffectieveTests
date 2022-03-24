namespace Testing;

public class IntegrationTests
{
    [Fact]
    public async Task Should_Return_Brands()
    {
        var application = Helper.CreateApi();
        var client = application.CreateClient();
        var result = await client.GetAsync("/brands");
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        var brands = await result.Content.ReadFromJsonAsync<List<Brand>>();
        Assert.NotNull(brands);
        Assert.IsType<List<Brand>>(brands);
        //Assert.True(brands.Count > 0);
    }

    [Fact]
    public async Task Should_Return_Occasions()
    {
        var application = Helper.CreateApi();
        var client = application.CreateClient();
        var result = await client.GetAsync("/occasions");
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        var occasions = await result.Content.ReadFromJsonAsync<List<Occasion>>();
        Assert.NotNull(occasions);
        Assert.IsType<List<Occasion>>(occasions);
        //Assert.True(brands.Count > 0);
    }


    /**[Fact]
    public async Task Should_Return_Sneakers()
    {
        var application = Helper.CreateApi();
        var client = application.CreateClient();
        var result = await client.GetAsync("/sneakers");
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        var sneakers = await result.Content.ReadFromJsonAsync<List<Sneaker>>();
        Assert.NotNull(sneakers);
        Assert.IsType<List<Sneaker>>(sneakers);
        //Assert.True(brands.Count > 0);
    }
**/
    [Fact]
    public async Task Should_Add_Sneaker_Created()
    {
        var occasions = new List<Occasion>();
        occasions.Add(new Occasion() { Description = "Formal" });
        var sneaker = new Sneaker()
        {
            Name = "sneaker 01",
            Price = (decimal)50.5,
            Stock = 5,
            Brand = new Brand(),
            Occasions = occasions
        };

        var application = Helper.CreateApi();
        var client = application.CreateClient();
        var result = await client.PostAsJsonAsync("/sneaker", sneaker);
        Assert.NotNull(result.Headers.Location);
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task Should_Add_Sneaker_No_Name_BadRequest()
    {
        var occasions = new List<Occasion>();
        occasions.Add(new Occasion());
        var sneaker = new Sneaker()
        {
            Name = "",
            Price = (decimal)50.5,
            Stock = 5,
            Brand = new Brand(),
            Occasions = occasions
        };

        var application = Helper.CreateApi();
        var client = application.CreateClient();
        var result = await client.PostAsJsonAsync("/sneaker", sneaker);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

}