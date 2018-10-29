using iCalendarAPI.Helpers;
using System;
using System.Text;

namespace iCalendarAPI
{
	public abstract class OldCalendarComponent
	{

		public string Code { get; set; }
		public int LCID { get; set; }

		protected OldCalendarComponent() : this(Guid.NewGuid().ToString(), 1033) { }

		protected OldCalendarComponent(string code, int lcid)
		{
			Code = code;
			LCID = lcid;
		}

		public override string ToString()
		{
			StringBuilder output = new StringBuilder();
			output.AppendLine($"DTSTAMP:{DateTime.Now.ToCalendarDateTime(true)}");
			output.AppendLine($"UID:{Code}@icalendar-API");
			return output.ToString();
		}
	}
}
