using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{
	public enum RecurrenceDayOfWeek
	{
		[Description("SU")]
		Sunday = 0,

		[Description("MO")]
		Monday = 1,

		[Description("TU")]
		Tuesday = 2,

		[Description("WE")]
		Wednesday = 3,

		[Description("TH")]
		Thursday = 4,

		[Description("FR")]
		Friday = 5,

		[Description("SA")]
		Saturday = 6,
	}
}