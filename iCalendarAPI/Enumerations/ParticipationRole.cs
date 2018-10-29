using System.ComponentModel;

namespace VisualReality.Calendar.Enumerations
{
	public enum ParticipationRole
	{

		// Default
		[Description("ROLE=REQ-PARTICIPANT")]
		Required,

		[Description("ROLE=CHAIR")]
		Chair,

		[Description("ROLE=OPT-PARTICIPANT")]
		Optional,

		[Description("ROLE=NON-PARTICIPANT")]
		InformationOnly,
	}

}
