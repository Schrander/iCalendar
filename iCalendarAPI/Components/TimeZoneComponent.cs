using ICalendarAPI.Elements;
using ICalendarAPI.Enumerations;
using ICalendarAPI.Helpers;
using System;
using System.Collections.Generic;

namespace ICalendarAPI.Components
{

    public class TimeZoneComponent : BaseComponent

    {

        public string TimeZoneOlsonName { get; set; }
        public List<TimeZoneOffsetComponent> TimeZoneSets = new List<TimeZoneOffsetComponent>();

        public TimeZoneComponent(TimeZoneInfo timeZone) : base(ComponentType.TimeZone)
        {
            TimeZoneOlsonName = timeZone.ToOlsonName();
            TimeZoneSets.Add(new TimeZoneOffsetComponent(TimeZoneOffsetType.Standard, timeZone));

            if (timeZone.SupportsDaylightSavingTime)
                TimeZoneSets.Add(new TimeZoneOffsetComponent(TimeZoneOffsetType.Daylight, timeZone));
        }



        // BEGIN:VTIMEZONE
        // TZID:Europe/Amsterdam
        // X-LIC-LOCATION:Europe/Amsterdam
        // BEGIN:STANDARD
        // TZOFFSETFROM:+0200
        // TZOFFSETTO:+0100
        // TZNAME:CET
        // DTSTART:19701025T030000
        // RRULE:FREQ=YEARLY;BYMONTH=10;BYDAY=-1SU
        // END:STANDARD 

        // BEGIN:DAYLIGHT 
        // TZOFFSETFROM:+0100
        // TZOFFSETTO:+0200 
        // TZNAME:CET
        // DTSTART:19701025T030000
        // RRULE:FREQ=YEARLY;BYMONTH=3;BYDAY=-1SU
        // END:DAYLIGHT

        // END:VTIMEZONE


        internal override List<ComponentLine> BuildLines()
        {
            List<ComponentLine> lines = new List<ComponentLine>
            {
                new ComponentLine("TZID:", TimeZoneOlsonName),
                new ComponentLine("X-LIC-LOCATION:", TimeZoneOlsonName)
            };

            foreach (TimeZoneOffsetComponent offset in TimeZoneSets)
                lines.AddRange(offset.BuildLines());

            return BuildComponent(lines);
        }
    }
}
