using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{
	public enum UserType
	{
		[Description("CUTYPE=INDIVIDUAL")]
		Individual,

		[Description("CUTYPE=GROUP")]
		Group,

		[Description("CUTYPE=RESOURCE")]
		Resource,

		[Description("CUTYPE=ROOM")]
		Room,

		[Description("CUTYPE=UNKNOWN")]
		Unknown,

	}
}
