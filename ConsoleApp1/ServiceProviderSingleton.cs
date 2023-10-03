#region

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace ConsoleApp1;

public static class ServiceProviderSingleton
{
    private static IServiceProvider? _instance;

    public static IServiceProvider GetInstance()
    {
        if (_instance is null)
            _instance = BatchHelper.ConfigureServices(new ServiceCollection());

        return _instance;
    }
}