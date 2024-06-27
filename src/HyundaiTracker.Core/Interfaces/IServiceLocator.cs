using Microsoft.Extensions.DependencyInjection;

namespace HyundaiTracker.Core.Interfaces;

public interface IServiceLocator : IDisposable
{
    IServiceScope CreateScope();
    T? Get<T>();
}
