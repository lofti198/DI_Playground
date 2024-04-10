using System.Collections.Concurrent;

namespace DI_Playground.Services.SomeTaskManagement
{
    public class SomeClassFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ConcurrentDictionary<string, ISomeClass> _instances = new ConcurrentDictionary<string, ISomeClass>();

        public SomeClassFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ISomeClass GetOrCreate(string key)
        {
            return _instances.GetOrAdd(key, k => CreateInstanceForKey(k));
        }

        private ISomeClass CreateInstanceForKey(string key)
        {
            // Logic to create the service based on the key.
            return key switch
            {
                "A" => _serviceProvider.GetRequiredService<SomeClassA>(),
                "B" => _serviceProvider.GetRequiredService<SomeClassB>(),
                _ => throw new KeyNotFoundException($"No service found for key: {key}")
            };
        }
    }


}
