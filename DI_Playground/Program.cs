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

            // Register the factory as a singleton too
            builder.Services.AddSingleton<SomeClassFactory>();
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
