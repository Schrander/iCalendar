using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{
	public enum JournalStatus
	{
		[Description("STATUS:DRAFT")]
		Draft,

		[Description("STATUS:FINAL")]
		Final,

		[Description("STATUS:CANCELLED")]
		Cancelled
	}
}