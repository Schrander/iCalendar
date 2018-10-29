using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{

	public enum RelatedType
	{
		[Description("RELATED=START")]
		Start,

		[Description("RELATED=END")]
		End,
	}

}
