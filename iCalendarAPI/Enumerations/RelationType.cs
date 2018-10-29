using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{

	public enum RelationType
	{
		[Description("RELTYPE=PARENT")]
		Parent,

		[Description("RELTYPE=CHILD")]
		Child,

		[Description("RELTYPE=SIBLING")]
		Sibling,
	}

}
