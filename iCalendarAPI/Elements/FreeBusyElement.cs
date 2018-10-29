using ICalendarAPI.Helpers;
using System;
using System.Text;

namespace ICalendarAPI.Elements
{

	// FREEBUSY:19980316T153000Z/19980316T163000Z
	public class FreeBusyElement : BaseElement
	{
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public PresetElementPart Preset { get; set; }

		public FreeBusyElement(DateTime startDate, DateTime? endDate, PresetElementPart preset)
		{
			StartDate = startDate;
			EndDate = endDate;
			Preset = preset;
		}
		
		public override ComponentLine BuildLine()
		{
			StringBuilder output = new StringBuilder();
			output.Append(StartDate.ToCalendarDateTimeUTC());
			output.Append("/");
			output.Append(EndDate.HasValue ? EndDate.ToCalendarDateTimeUTC() : Preset.ToString());

			return new ComponentLine("FREEBUSY:", output.ToString());
		}

	}
}
