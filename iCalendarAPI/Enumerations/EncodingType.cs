using System.ComponentModel;

namespace ICalendarAPI.Enumerations
{
	public enum EncodingType
	{
		// Default
		[Description("ENCODING=8BIT")]
		EightBit,

		[Description("ENCODING=BASE64")]
		Base64,
	}
}
