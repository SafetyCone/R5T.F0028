using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;


namespace R5T.F0028
{
	[FunctionalityMarker]
	public partial interface IServicesOperator : IFunctionalityMarker
	{
		public async Task<ServiceProvider> BuildServiceProvider(Func<ServiceCollection, Task> configureServicesAction)
		{
			var serviceCollection = this.GetEmptyServiceCollection();

			await configureServicesAction(serviceCollection);

			var serviceProvider = serviceCollection.BuildServiceProvider();
			return serviceProvider;
		}

		public ServiceProvider BuildServiceProvider_Synchronous(Action<ServiceCollection> configureServicesAction)
        {
			var serviceCollection = this.GetEmptyServiceCollection();

			configureServicesAction(serviceCollection);

			var serviceProvider = serviceCollection.BuildServiceProvider();
			return serviceProvider;
        }

		public ServiceCollection GetEmptyServiceCollection()
        {
			ServiceCollection output = new();
			return output;
        }

		public async Task InServicesContext(
			Func<ServiceCollection, Task> configureServicesAction,
			Func<IServiceProvider, Task> servicesContextAction)
        {
			using var serviceProvider = await this.BuildServiceProvider(configureServicesAction);

			await servicesContextAction(serviceProvider);
        }

		public void InServicesContext_Synchronous(
			Action<ServiceCollection> configureServicesAction,
			Action<IServiceProvider> servicesContextAction)
		{
			using var serviceProvider = this.BuildServiceProvider_Synchronous(configureServicesAction);

			servicesContextAction(serviceProvider);
		}
	}
}