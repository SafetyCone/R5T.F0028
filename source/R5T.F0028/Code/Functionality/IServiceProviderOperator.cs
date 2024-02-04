using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;


namespace R5T.F0028
{
    [FunctionalityMarker]
    public partial interface IServiceProviderOperator : IFunctionalityMarker
    {
        public TService Get_Service_OrDefault<TService>(IServiceProvider serviceProvider)
        {
            var service_OrDefault = serviceProvider.GetService<TService>();
            return service_OrDefault;
        }

        public bool Try_Get_Service<TService>(
            IServiceProvider serviceProvider,
            out TService service_OrDefault)
        {
            service_OrDefault = this.Get_Service_OrDefault<TService>(serviceProvider);

            var serviceExists = Instances.ServicesOperator.Was_Found(service_OrDefault);

            return serviceExists;
        }
    }
}
