using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{
	public enum ToDoStatus
	{
		[Description("STATUS:NEEDS-ACTION")]
		NeedsAction,

		[Description("STATUS:COMPLETED")]
		Completed,

		[Description("STATUS:IN-PROCESS")]
		InProcess,

		[Description("STATUS:CANCELLED")]
		Cancelled,
	}
}