using System;
using Autofac;
using Sommus.CodingDojo.Application.DependencyInjection.Interfaces;
using Sommus.CodingDojo.Data.ADO.Context;
using Sommus.CodingDojo.Data.ADO.Repositories;
using Sommus.CodingDojo.Domain.Interfaces.Repositories;

namespace Sommus.CodingDojo.Application.DependencyInjection.Services
{
    public class Container : IDependencyInjection
    {
        private static Container _container;
        private readonly ContainerBuilder _containerBuilder;
        private static IContainer _autofacContainer;

        private Container()
        {
            _containerBuilder = new ContainerBuilder();
            RegisterTypes();
        }

        public static Container GetContainer()
        {
            return _container ?? (_container ?? new Container());
        }

        public T Resolve<T>()
        {
            return _autofacContainer.BeginLifetimeScope().Resolve<T>();
        }

        public T Resolve<T>(Type type)
        {
            return (T)_autofacContainer.BeginLifetimeScope().Resolve(type);
        }

        private void RegisterTypes()
        {
            // Repositories
            _containerBuilder.RegisterType<PessoaRepository>().As<IPessoaRepository>();
            _containerBuilder.RegisterType<DataContext>().As<IDataContext>();

            _autofacContainer = _containerBuilder.Build();
        }
    }
}