using DI_Playground.Services.SomeTaskManagement;

namespace DI_Playground
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddKeyedSingleton<ISomeClass, SomeClassA>("A");
            builder.Services.AddKeyedSingleton<ISomeClass, SomeClassB>("B");
            
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
