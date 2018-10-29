using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{
	public enum EventStatus
	{
		[Description("TENTATIVE")]
		Tentative,

		[Description("CONFIRMED")]
		Confirmed,

		[Description("CANCELLED")]
		Cancelled,
	}
}
