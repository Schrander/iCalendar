using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{
	public enum CalendarClassType
	{
		[Description("PUBLIC")]
		Public,

		[Description("PRIVATE")]
		Private,

		[Description("CONFIDENTIAL")]
		Confidential
	}

}