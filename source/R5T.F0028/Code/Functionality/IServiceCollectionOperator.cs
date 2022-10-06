using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;


namespace R5T.F0028
{
	[DraftFunctionalityMarker]
	public partial interface IServiceCollectionOperator : IDraftFunctionalityMarker
	{
		public ServiceCollection New()
        {
			var services = new ServiceCollection();
			return services;
        }
	}
}