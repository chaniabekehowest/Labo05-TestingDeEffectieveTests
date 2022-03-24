namespace Testing.Fakes;

public class FakeSneakerRepository : ISneakerRepository
{
    public static List<Sneaker> _sneakers = new List<Sneaker>();
    public Task<Sneaker> AddSneaker(Sneaker newSneaker)
    {
        _sneakers.Add(newSneaker);
        return Task.FromResult(newSneaker);
    }

    public Task<Sneaker> GetSneaker(string id)
    {
        var result = _sneakers.Find(s => s.SneakerId == id);
        return Task.FromResult(result);
    }

    public async Task<Sneaker> UpdateStock(string sneakerId, int stock)
    {
        try
        {
            var item = _sneakers.Where(s => s.SneakerId == sneakerId).SingleOrDefault();
            if (item != null)
                item.Stock = stock;

            return await Task.FromResult(item);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }

    }

}