using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{
	public enum PartStatJournalElement
	{
		[Description("PARTSTAT=NEEDS-ACTION")]
		NeedsAction,

		[Description("PARTSTAT=ACCEPTED")]
		Accepted,

		[Description("PARTSTAT=DECLINED")]
		Declined
	}
}