using System;


namespace R5T.F0028
{
	public class ServicesOperator : IServicesOperator
	{
		#region Infrastructure

	    public static ServicesOperator Instance { get; } = new();

	    private ServicesOperator()
	    {
        }

	    #endregion
	}
}