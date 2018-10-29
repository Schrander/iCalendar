using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{

	public enum MicrosoftBusyStatus
	{
		[Description("FREE")]
		Free = 1,

		[Description("TENTATIVE")]
		Tentative,

		[Description("BUSY")]
		Busy,

		[Description("OOF")]
		OutOfOffice,

	}

	public enum MS_CDO_Importance
	{
		Low = 0,
		Normal = 1,
		High = 2,

	}

}
