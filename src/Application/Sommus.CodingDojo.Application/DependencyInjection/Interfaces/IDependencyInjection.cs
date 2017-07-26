using System;

namespace Sommus.CodingDojo.Application.DependencyInjection.Interfaces
{
    public interface IDependencyInjection
    {
        T Resolve<T>();
        T Resolve<T>(Type type);
    }
}