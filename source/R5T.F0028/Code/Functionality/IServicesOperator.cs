using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;


namespace R5T.F0028
{
	[FunctionalityMarker]
	public partial interface IServicesOperator : IFunctionalityMarker
	{
		public ServiceProvider BuildServiceProvider(IServiceCollection services)
        {
			var serviceProvider = services.BuildServiceProvider();
			return serviceProvider;
        }

		public async Task<ServiceProvider> BuildServiceProvider(Func<ServiceCollection, Task> configureServicesAction)
		{
			var serviceCollection = this.GetEmptyServiceCollection();

			await configureServicesAction(serviceCollection);

			var serviceProvider = serviceCollection.BuildServiceProvider();
			return serviceProvider;
		}

		public ServiceProvider BuildServiceProvider(Action<ServiceCollection> configureServicesAction)
        {
			var serviceCollection = this.GetEmptyServiceCollection();

			configureServicesAction(serviceCollection);

			var serviceProvider = serviceCollection.BuildServiceProvider();
			return serviceProvider;
        }

		public TService Get_DefaultServiceValue<TService>()
			// All services are reference types.
			where TService : class
		{
			var output = Instances.DefaultOperator.Get_Default<TService>();
			return output;
		}

		public ServiceCollection GetEmptyServiceCollection()
        {
			ServiceCollection output = new ServiceCollection();
			return output;
        }

		public ServiceProvider GetEmptyServiceProvider()
        {
			var services = this.GetEmptyServiceCollection();

			var serviceProvider = this.BuildServiceProvider(services);
			return serviceProvider;
        }

		public async Task InServicesContext(
			Action<ServiceCollection> configureServicesAction,
			Func<IServiceProvider, Task> servicesContextAction)
		{
			using var serviceProvider = this.BuildServiceProvider(configureServicesAction);

			await servicesContextAction(serviceProvider);
		}

		public void InServicesContext_Synchronous(
			Action<ServiceCollection> configureServicesAction,
			Action<IServiceProvider> servicesContextAction)
		{
			using var serviceProvider = this.BuildServiceProvider(configureServicesAction);

			servicesContextAction(serviceProvider);
		}

		public async Task InServicesContext(
			Func<ServiceCollection, Task> configureServicesAction,
			Func<IServiceProvider, Task> servicesContextAction)
        {
			using var serviceProvider = await this.BuildServiceProvider(configureServicesAction);

			await servicesContextAction(serviceProvider);
        }

		public bool Was_Found<TService>(TService serviceInstanceFromProvider)
		{
			var output = Instances.DefaultOperator.Is_NotDefault<TService>(serviceInstanceFromProvider);
			return output;
		}
	}
}