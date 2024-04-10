namespace DI_Playground.Services.SomeTaskManagement
{
    public class SomeClassFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SomeClassFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ISomeClass Create(string key)
        {
            switch (key)
            {
                case "A":
                    return _serviceProvider.GetRequiredService<SomeClassA>();
                case "B":
                    return _serviceProvider.GetRequiredService<SomeClassB>();
                default:
                    throw new ArgumentException("Invalid key", nameof(key));
            }
        }
    }

}
