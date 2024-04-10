using DI_Playground.Services.SomeTaskManagement;

namespace DI_Playground
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register your services as singletons
            builder.Services.AddSingleton<SomeClassA>();
            builder.Services.AddSingleton<SomeClassB>();

            // Register the generic factory for ISomeClass with the specific factory method
            builder.Services.AddSingleton<DITypeFactoryBase<string, ISomeClass>>(
                serviceProvider => new DITypeFactoryBase<string, ISomeClass>(
                    serviceProvider,
                    (sp, key) => key switch
                    {
                        "A" => sp.GetRequiredService<SomeClassA>(),
                        "B" => sp.GetRequiredService<SomeClassB>(),
                        _ => throw new KeyNotFoundException($"No service found for key: {key}")
                    }
                ));
            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
