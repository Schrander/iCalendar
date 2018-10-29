using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{

	public enum ComponentType {
	 [Description("VCALENDAR")]
	 Calendar,

	 [Description("VEVENT")]
	 Event,

	 [Description("VTODO")]
	 Todo,

	 [Description("VJOURNAL")]
	 Journal,

	 [Description("VFREEBUSY")]
	 FreeBusy,

	 [Description("VTIMEZONE")]
	 TimeZone,

	 [Description("VALARM")]
	 Alarm,
  }
}
