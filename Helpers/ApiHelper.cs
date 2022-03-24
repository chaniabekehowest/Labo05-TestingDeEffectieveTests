namespace Testing.Helpers;

public class Helper
{
    public static ISneakerService CreateSneakerService()
    {
        return CreateApi().Services.GetService<ISneakerService>();
    }
    public static WebApplicationFactory<Program> CreateApi()
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IBrandRepository));
                services.Remove(descriptor);

                var fakeBrandRepository = new ServiceDescriptor(typeof(IBrandRepository), typeof(FakeBrandRepository), ServiceLifetime.Transient);
                services.Add(fakeBrandRepository);

                var descriptor2 = services.SingleOrDefault(d => d.ServiceType == typeof(IOccasionRepository));
                services.Remove(descriptor2);

                var fakeOccasionRepository = new ServiceDescriptor(typeof(IOccasionRepository), typeof(FakeOccasionRepository), ServiceLifetime.Transient);
                services.Add(fakeOccasionRepository);

                var descriptor3 = services.SingleOrDefault(d => d.ServiceType == typeof(ISneakerRepository));
                services.Remove(descriptor3);

                var fakeSneakerRepository = new ServiceDescriptor(typeof(ISneakerRepository), typeof(FakeSneakerRepository), ServiceLifetime.Transient);
                services.Add(fakeSneakerRepository);

            });
        });

        return application;

    }
}