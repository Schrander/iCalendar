using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{

	public enum RecurrencePrefix
	{
		[Description("BYSECOND")]
		Second,

		[Description("BYMINUTE")]
		Minute,

		[Description("BYHOUR")]
		Hour,

		[Description("BYMONTH")]
		Month,
		
		[Description("BYDAY")]
		Day,

		[Description("BYMONTHDAY")]
		MonthDay,

		[Description("BYYEARDAY")]
		YearDay,

		[Description("BYWEEKNO")]
		WeekNumber
	}

}
