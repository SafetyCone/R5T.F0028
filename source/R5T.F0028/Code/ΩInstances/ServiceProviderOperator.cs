using System;


namespace R5T.F0028
{
    public class ServiceProviderOperator : IServiceProviderOperator
    {
        #region Infrastructure

        public static IServiceProviderOperator Instance { get; } = new ServiceProviderOperator();


        private ServiceProviderOperator()
        {
        }

        #endregion
    }
}
