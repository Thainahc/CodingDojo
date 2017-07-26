using Sommus.CodingDojo.Application.AutoMapper;
using Sommus.CodingDojo.Application.DependencyInjection.Services;

namespace Sommus.CodingDojo.ApplicationTest.Application
{

    public class BaseApplicationTest
    {
        public BaseApplicationTest()
        {
            DependencyInjectionService.Inicializa(Container.GetContainer());
            AutoMapperConfig.RegisterMappings();
        }
    }
}
