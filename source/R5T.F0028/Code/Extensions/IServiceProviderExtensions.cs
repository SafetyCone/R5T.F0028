using System;

using Instances = R5T.F0028.Instances;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceProviderExtensions
    {
        public static bool Try_Get_Service<TService>(this IServiceProvider serviceProvider,
            out TService service_OrDefault)
        {
            var output = Instances.ServiceProviderOperator.Try_Get_Service(
                serviceProvider,
                out service_OrDefault);

            return output;
        }
    }
}
