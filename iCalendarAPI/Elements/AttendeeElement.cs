using HelperTools.Helpers;
using ICalendarAPI.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using ICalendarAPI.Enumerations;
using VisualReality.Calendar.Enumerations;

//https://tools.ietf.org/html/rfc5545#section-3.8.4.1

namespace ICalendarAPI.Elements
{
	public class AttendeeElement : BaseElement
	{

		public UserType? UserType { get; set; }
		public MailAddress MemberGroup { get; set; }
		public MailAddress AttendeeMailAddress { get; set; }
		public MailAddress SendBy { get; set; }
		public MailAddress DelegatedFrom { get; set; }
		public ParticipationRole? Role { get; set; }
		public PartStatEvent? PartStat { get; set; }
		//public byte[] AttachmentBody { get; set; }
		public bool? ReplyRequested { get; set; }
		public string DirUrl { get; set; }

		//ATTENDEE;MEMBER="mailto:DEV-GROUP@example.com":mailto:joecool@example.com
		//ATTENDEE;DELEGATED-FROM="mailto:immud@example.com":mailto:ildoit@example.com
		//ATTENDEE;ROLE=REQ-PARTICIPANT;PARTSTAT=TENTATIVE;CN=Henry Cabot:mailto:hcabot@example.com
		//ATTENDEE;ROLE=REQ-PARTICIPANT;DELEGATED-FROM="mailto:bob@example.com";PARTSTAT=ACCEPTED;CN=Jane Doe:mailto:jdoe@example.com
		//ATTENDEE;CN=John Smith;DIR="ldap://example.com:6666/o=ABC%20Industries,c=US???(cn=Jim%20Dolittle)"(cn=Jim%20Dolittle)":mailto:jimdo@example.com
		//ATTENDEE;ROLE=REQ-PARTICIPANT;PARTSTAT=TENTATIVE;DELEGATED-FROM="mailto:iamboss@example.com";CN=Henry Cabot:mailto:hcabot@example.com
		//ATTENDEE;ROLE=NON-PARTICIPANT;PARTSTAT=DELEGATED;DELEGATED-TO="mailto:hcabot@example.com";CN=The Big Cheese:mailto:iamboss@example.com
		//ATTENDEE;ROLE=REQ-PARTICIPANT;PARTSTAT=ACCEPTED;CN=Jane Doe:mailto:jdoe@example.com
		//ATTENDEE;SENT-BY=mailto:jan_doe@example.com;CN=John Smith:mailto:jsmith@example.com

		public override ComponentLine BuildLine()
		{
			List<ElementPart> parts = new List<ElementPart>();

			parts.Add(UserType.BuildElementPart());
			parts.Add(UserType.BuildElementPart());
			parts.Add(Role.BuildElementPart());
			parts.Add(PartStat.BuildElementPart());
			if (MemberGroup == null)
				parts.Add(new ElementPart("MEMBER", @"""" + MemberGroup + @""""));
			parts.Add(new ElementPart("SENT-BY", SendBy));
			parts.Add(new ElementPart("DELEGATED-FROM", DelegatedFrom));
			parts.Add(new ElementPart("RSVP", ReplyRequested));
			parts.Add(new ElementPart("DIR", @""""  + DirUrl + @""""));
			parts.Add(new ElementPart("", AttendeeMailAddress, true));
			
			var filtered = parts.Where(w => !string.IsNullOrEmpty(w.Value)).Select(h => h.ToString()).Join(";");


			return new ComponentLine("ATTENDEE;", filtered);
		}
	}
}
