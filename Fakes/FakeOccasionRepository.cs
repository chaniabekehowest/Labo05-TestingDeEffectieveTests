namespace Testing.Fakes;

public class FakeOccasionRepository : IOccasionRepository
{
    public static List<Occasion> _occasions = new List<Occasion>();
    public Task<List<Occasion>> AddOccasions(List<Occasion> occasions)
    {
        _occasions.AddRange(occasions);
        return Task.FromResult(occasions);
    }

    public Task<List<Occasion>> GetAllOccassions()
    {
        return Task.FromResult(_occasions);
    }
}