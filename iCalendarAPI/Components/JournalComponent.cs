using ICalendarAPI.Elements;
using ICalendarAPI.Enumerations;
using ICalendarAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

// BEGIN:VJOURNAL
// DTSTAMP:19970324T120000Z
// UID:uid5@example.com
// ORGANIZER:MAILTO:jsmith@example.com
// STATUS:DRAFT
// CLASS:PUBLIC
// CATEGORIES:Project Report, XYZ, Weekly Meeting
// DESCRIPTION:Project xyz Review Meeting Minutes\n
//  Agenda\n1. Review of project version 1.0 requirements.\n2.
//  Definition
//  of project processes.\n3. Review of project schedule.\n
//  Participants: John Smith, Jane Doe, Jim Dandy\n-It was
//   decided that the requirements need to be signed off by
//   product marketing.\n-Project processes were accepted.\n
//  -Project schedule needs to account for scheduled holidays
//   and employee vacation time. Check with HR for specific
//   dates.\n-New schedule will be distributed by Friday.\n-
//  Next weeks meeting is cancelled. No meeting until 3/23.
// END:VJOURNAL

// ORGANIZER;CN=John Smith:MAILTO:jsmith@host.com

namespace ICalendarAPI.Components
{

	public class JournalComponent : BaseComponent
	{
		public string Code { get; set; }
		public int LCID { get; set; }
		public MailAddress Organizer { get; set; }
		public JournalStatus? Status { get; set; }
		public CalendarClassType? Class { get; set; }
		public List<string> Categories { get; set; }
		public string Description { get; set; }
		public string Summary { get; set; }
		public List<AttachmentElement> Attachments { get; set; }

		public JournalComponent(string code, int lcid)
			: base(ComponentType.Journal)
		{
			Code = code;
			LCID = lcid;
			Attachments = new List<AttachmentElement>();
			Categories = new List<string>();
		}

		internal override List<ComponentLine> BuildLines()
		{
			List<ComponentLine> lines = new List<ComponentLine>
			{
				new ComponentLine("DTSTAMP:", DateTime.Now, true),
				new ComponentLine("UID:", $"{Code}@icalendarAPI"),
				new ComponentLine("STATUS:", Status),
				new ComponentLine("ORGANIZER:", Organizer),
				new ComponentLine("STATUS:", Status),
				new ComponentLine("CLASS:", Class),
				new ComponentLine("CATEGORIES:", Categories),
				new ComponentLine("DESCRIPTION:", Description.ToDescriptionString()),
				new ComponentLine("SUMMARY:", Summary.ToSummary(LCID))
			};

			lines.AddRange(Attachments.Select(a => a.BuildLine()));
			
			return BuildComponent(lines);
		}
	}
}