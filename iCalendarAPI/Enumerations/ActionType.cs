using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{

	public enum ActionType
	{

		[Description("DISPLAY")]
		Display,

		[Description("AUDIO")]
		Audio,

		[Description("EMAIL")]
		Email,

		[Description("PROCEDURE")]
		Procedure,
	}

}
