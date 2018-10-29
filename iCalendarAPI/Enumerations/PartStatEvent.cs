using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{

	public enum PartStatEvent
	{
		[Description("PARTSTAT=NEEDS-ACTION")]
		NeedsAction,

		[Description("PARTSTAT=ACCEPTED")]
		Accepted,

		[Description("PARTSTAT=DECLINED")]
		Declined,

		[Description("PARTSTAT=TENTATIVE")]
		Tentative,

		[Description("PARTSTAT=DELEGATED")]
		Delegated
	}
}
