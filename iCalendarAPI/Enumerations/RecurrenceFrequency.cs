using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{
	public enum RecurrenceFrequency {
		[Description("SECONDLY")]
		Secondly,

		[Description("MINUTELY")]
		Minutely,

		[Description("HOURLY")]
		Hourly,

		[Description("DAILY")]
		Daily,

		[Description("WEEKLY")]
		Weekly,

		[Description("MONTHLY")]
		Monthly,

		[Description("YEARLY")]
		Yearly
	}
}