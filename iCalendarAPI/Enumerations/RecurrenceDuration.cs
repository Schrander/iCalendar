using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{
	public enum RecurrenceDuration
	{
		[Description("D")]
		Day,

		[Description("W")]
		Week,

		[Description("H")]
		Hour,

		[Description("M")]
		Minute,

		[Description("S")]
		Second
	}
}