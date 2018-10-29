using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{

	public enum RangeType
	{
		[Description("RANGE=THISANDPRIOR")]
		Prior,

		[Description("RANGE=THISANDFUTURE")]
		Future,
	}

}
