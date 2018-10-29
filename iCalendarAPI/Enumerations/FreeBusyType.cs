using System.ComponentModel;

namespace VisualReality.Calendar.Enumerations
{

	public enum FreeBusyType
	{
		[Description("FBTYPE=FREE")]
		Free,

		[Description("FBTYPE=BUSY")]
		Busy,

		[Description("FBTYPE=BUSY-UNAVAILABLE")]
		Unavailable,

		[Description("FBTYPE=BUSY-TENTATIVE")]
		Tentative,
	}

}
