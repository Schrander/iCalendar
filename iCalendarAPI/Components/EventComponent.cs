using HelperTools.Helpers;
using HelperTools.Text;
using ICalendarAPI.Elements;
using ICalendarAPI.Enumerations;
using ICalendarAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

// BEGIN:VEVENT
// DTSTART;TZID=Europe/Amsterdam:20150328T140000
// DTEND;TZID=Europe/Amsterdam:20150328T160000
// URL:http://www.volleybal.nl
// DTSTAMP:20150327T144300
// UID:b79adbdf8eeaa9e18785b55b303ab8b6@volleybal.nl
// CREATED:20150328T140000
// DESCRIPTION:Wedstrijd":" 7000D1E   IF\, Datum":" zaterdag 28 maart - 14.00
// LAST-MODIFIED:20150327T144300
// SEQUENCE:0
// STATUS:CONFIRMED
// SUMMARY:Particolare/DS DS 3 - Flamingo's'56 DS 3
// CLASS:PUBLIC
// TRANSP:OPAQUE
// LOCATION:De Misse\, Jacobskamp 25\, 5275BJ Den Dungen
// END:VEVENT

namespace ICalendarAPI.Components
{

    public class EventComponent : BaseComponent
    {

        #region Fields

        public string Code { get; set; }
        public int LCID { get; set; }
        public DateTime StartEvent { get; set; }
        public DateTime EndEvent { get; set; }
        public string Description { get; set; }
        public string HtmlDescription { get; set; }
        public DateTime? LastModified { get; set; } // optional
        public Uri Url { get; set; } // optional
        public int Sequence { get; set; }
        public EventStatus Status { get; set; }
        public string Summary { get; set; }
        public CalendarClassType Class { get; set; }
        public string Location { get; set; }
        public TransparencyType Transparancy { get; set; }
        public string Categories { get; set; }
        public int? Priority { get; set; }
        public List<string> Resources { get; set; }
        public List<AttachmentElement> Attachments { get; set; }
        public List<string> RequestStatus { get; set; }
        public MailAddress Organizer { get; set; }
        public bool IsAllDayEvent { get; set; }
        public AlarmComponent Alarm { get; set; }

        internal TimeZoneInfo TimeZone { get; set; }

        #endregion

        #region Constructors
        public EventComponent(string code, int lcid) : this(code, lcid, true) { }

        public EventComponent(string code, int lcid, bool useReminder) : base(ComponentType.Event)
        {
            Code = code;
            Status = EventStatus.Confirmed;
            Class = CalendarClassType.Public;
            Transparancy = TransparencyType.Transparent;
            LCID = lcid;
            RequestStatus = new List<string>();
            Attachments = new List<AttachmentElement>();
            Resources = new List<string>();

            if (useReminder)
                Alarm = new AlarmComponent("Reminder", new PresetElementPart(null, null, 3, null, null));

        }

        public EventComponent(string code, int lcid, string location, DateTime eventDate, bool useReminder, bool isAllDayEvent = false)
          : this(code, lcid, location, eventDate, null, useReminder, isAllDayEvent)
        {
        }

        public EventComponent(string code, int lcid, string location, DateTime startDate, DateTime? endDate, bool useReminder, bool isAllDayEvent = false)
          : this(code, lcid, location, startDate, endDate, useReminder, new PresetElementPart(null, null, 3, null, null), isAllDayEvent)
        { }

        public EventComponent(string code, int lcid, string location, DateTime startDate, DateTime? endDate, bool useReminder, PresetElementPart alarmPreset, bool isAllDayEvent = false)
            : base(ComponentType.Event)
        {
            Code = code;
            LCID = lcid;
            Status = EventStatus.Confirmed;
            Class = CalendarClassType.Public;
            Transparancy = TransparencyType.Transparent;
            Location = location;
            RequestStatus = new List<string>();
            Attachments = new List<AttachmentElement>();
            Resources = new List<string>();
            IsAllDayEvent = isAllDayEvent;
            Sequence = 3;
            StartEvent = IsAllDayEvent ? new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0) : startDate;
            EndEvent = IsAllDayEvent ? startDate.AddDays(1) : (endDate ?? startDate.AddMinutes(60));
            if (useReminder)
                Alarm = new AlarmComponent("Reminder", alarmPreset);
        }
        #endregion

        internal override List<ComponentLine> BuildLines()
        {
            List<ComponentLine> lines = new List<ComponentLine>();

            lines.Add(new ComponentLine("SUMMARY:", Summary.Coalesce(Description.ToDescriptionString(), "Onbekend").ToSummary()));


            if (IsAllDayEvent)
            {
                lines.Add(new ComponentLine("DTSTART;VALUE=DATE:", StartEvent.ToCalendarDateUTC()));
                lines.Add(new ComponentLine("DTEND;VALUE=DATE:", EndEvent.ToCalendarDateUTC()));
            }
            else
            {
                var tz = new ComponentPart("TZID", TimeZone.ToOlsonName());

                lines.Add(new ComponentLine($"DTSTART;{tz}:", StartEvent, false));
                lines.Add(new ComponentLine($"DTEND;{tz}:", EndEvent, false));
            }

            DateTime now = DateTime.Now;

            //lines.Add(new ComponentLine("DTSTAMP:", now, true));
            lines.Add(new ComponentLine("UID:", $"{Code}@icalendarAPI"));
            //lines.Add(new ComponentLine("CLASS:", Class));
            //lines.Add(new ComponentLine("CATEGORIES:", Categories));
            lines.Add(new ComponentLine("STATUS:", Status));
            //lines.Add(new ComponentLine("TRANSP:", Transparancy));
            lines.Add(new ComponentLine("LOCATION:", Location.ToPascalCase()));
            //lines.Add(new ComponentLine("URL:", UrlNormalization.Instance.Normalize(Url))); 
            //lines.Add(new ComponentLine("LAST-MODIFIED:", LastModified.Coalesce(now), true));
            //lines.Add(new ComponentLine("CREATED:", now, true));
            lines.Add(new ComponentLine("SEQUENCE:", Sequence));
            //lines.Add(new ComponentLine("DESCRIPTION:", Description.ToDescriptionString()));
            //lines.Add(new ComponentLine("PRIORITY:", Priority.ForceToRange<int>(0, 9)));
            //lines.Add(new ComponentLine("RESOURCES:", Resources));
            //lines.Add(new ComponentLine("REQUEST-STATUS:", RequestStatus));
            //lines.Add(new ComponentLine("X-ALT-DESC;FMTTYPE=text/html:", string.Empty)); //Description.ToHtml(true, 30)
            //lines.Add(new ComponentLine("X-MICROSOFT-CDO-BUSYSTATUS:", MicrosoftBusyStatus.Busy));
            //lines.Add(new ComponentLine("X-MICROSOFT-CDO-IMPORTANCE:", (int)MS_CDO_Importance.Normal));
            lines.AddRange(Attachments.Select(attachment => attachment.BuildLine()));

            //if (!string.IsNullOrEmpty(Description) || !string.IsNullOrEmpty(HtmlDescription))
            // output.AppendLine("X-ALT-DESC;" + FileMimeType.Html.ToCalendarString() + ";" + HtmlDescription.ToHtmlString(true).Coalesce(Description.ToHtml()));

            if (Alarm != null)
                lines.AddRange(Alarm.BuildLines());

            return BuildComponent(lines);
        }
    }
}
