using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{

	public enum CalendarValueType
	{
		[Description("VALUE=BINARY")]
		Binary,

		[Description("VALUE=BOOLEAN")]
		Boolean,

		[Description("VALUE=CAL-ADDRESS")]
		Address,

		[Description("VALUE=DATE")]
		Date,

		[Description("VALUE=DATE-TIME")]
		DateTime,

		[Description("VALUE=DURATION")]
		Duration,

		[Description("VALUE=FLOAT")]
		Float,

		[Description("VALUE=INTEGER")]
		Integer,

		[Description("VALUE=PERIOD")]
		Period,

		[Description("VALUE=RECUR")]
		Recurrance,

		[Description("VALUE=TEXT")]
		Text,

		[Description("VALUE=TIME")]
		Time,

		[Description("VALUE=URI")]
		Url,

		[Description("VALUE=UTC-OFFSET")]
		UtcOffset,
	}

}
