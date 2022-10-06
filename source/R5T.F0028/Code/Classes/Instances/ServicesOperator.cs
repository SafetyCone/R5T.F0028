using System;


namespace R5T.F0028
{
	public class ServicesOperator : IServicesOperator
	{
		#region Infrastructure

	    public static IServicesOperator Instance { get; } = new ServicesOperator();

	    private ServicesOperator()
	    {
        }

	    #endregion
	}
}