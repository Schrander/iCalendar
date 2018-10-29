using ICalendarAPI.Elements;
using ICalendarAPI.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

// BEGIN:VFREEBUSY
// ORGANIZER:MAILTO:jsmith@example.com
// DTSTART:19980313T141711Z
// DTEND:19980410T141711Z
// FREEBUSY:19980314T233000Z/19980315T003000Z
// FREEBUSY:19980316T153000Z/19980316T163000Z
// FREEBUSY:19980318T030000Z/19980318T040000Z
// URL:http://www.example.com/calendar/busytime/jsmith.ifb 
// END:VFREEBUSY

namespace ICalendarAPI.Components
{

	public class FreeBusyComponent : BaseComponent
	{

		private DateTime _datetimeEnd;

		public MailAddress Organizer { get; set; }
		public DateTime DateTimeStart { get; set; }

		public DateTime DateTimeEnd
		{
			get { return _datetimeEnd;	}
			set { _datetimeEnd = value > DateTimeStart ? value : DateTimeStart.AddDays(1); }
		}

		public List<FreeBusyElement> FreeBusyList = new List<FreeBusyElement>();
		public string Url { get; set; }

		public FreeBusyComponent() : base(ComponentType.FreeBusy)
		{ }

		internal override List<ComponentLine> BuildLines()
		{
			List<ComponentLine> lines = new List<ComponentLine>
			{
				new ComponentLine("ORGANIZER:", Organizer),				// ORGANIZER:MAILTO:jsmith@example.com
				new ComponentLine("DTSTART:", DateTimeStart, true),	// DTSTART:19980313T141711Z
				new ComponentLine("DTEND:", DateTimeEnd, true),			// DTSTART:19980313T141711Z
			};

			lines.AddRange(FreeBusyList.Select(f => f.BuildLine()));

			lines.Add(new ComponentLine("URL:", Url));               // URL:http://www.example.com/calendar/busytime/jsmith.ifb 

			return BuildComponent(lines);
		}
	}
}
