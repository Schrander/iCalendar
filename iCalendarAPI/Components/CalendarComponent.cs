using HelperTools.Helpers.DateTimeHelpers;
using ICalendarAPI.Elements;
using ICalendarAPI.Enumerations;
using ICalendarAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;

// BEGIN:VCALENDAR
// VERSION:2.0
// PRODID:-//Visual Reality
// CALSCALE:GREGORIAN
// X-WR-CALNAME;VALUE=TEXT:Programma
// X-WR-TIMEZONE:CEST
// METHOD:PUBLISH


//https://tools.ietf.org/html/rfc5545
namespace ICalendarAPI.Components
{
    public class CalendarComponent : BaseComponent
    {
        private CultureInfo Culture { get; }
        private TimeZoneInfo TimeZone { get; }
        public string Title { get; set; }
        private List<BaseComponent> Components { get; }
        public List<EventComponent> Events = new List<EventComponent>();

        public CalendarComponent(TimeZoneInfo timeZone, string title, CultureInfo culture)
            : base(ComponentType.Calendar)
        {
            Culture = culture;
            Title = title;
            TimeZone = timeZone;
            Components = new List<BaseComponent> { new TimeZoneComponent(timeZone) };
        }


        public EventComponent CreateEvent(DateTime startDate, TimeSpan duration, string location)
        {
            TimeSpan t = startDate.TimeOfDay + duration;
            DateTime endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, t.Hours, t.Minutes, t.Seconds);

            return new EventComponent(Guid.NewGuid().ToString(), Culture.LCID, location, startDate, endDate, false);
        }

        public EventComponent CreateEvent(DateTime startDate, DateTime endDate, string location)
        {
            return new EventComponent(Guid.NewGuid().ToString(), Culture.LCID, location, startDate, endDate, false);
        }

        public EventComponent CreateEvent(DateTime startDate, TimeSpan duration, string location, int alarmHour)
        {
            TimeSpan end = startDate.TimeOfDay + duration;
            DateTime endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, end.Hours, end.Minutes, end.Seconds);


            DateTime d = startDate.AddDays(-1).SetTime(20);
            var t = startDate - d;
            return new EventComponent(Guid.NewGuid().ToString(), Culture.LCID, location, startDate, endDate, true, new PresetElementPart(null, null, t.Hours, t.Minutes));
        }

        public EventComponent CreateEvent(DateTime startDate, DateTime endDate, string location, int alarmHour)
        {
            DateTime aDate = startDate.AddDays(-1);

            int h = startDate.Hour + (24 - alarmHour);
            int? m = startDate.Minute;

            DateTime alarmDate = new DateTime(aDate.Year, aDate.Month, aDate.Day, alarmHour, 0, 0);

            return new EventComponent(Guid.NewGuid().ToString(), Culture.LCID, location, startDate, endDate, true, new PresetElementPart(null, null, h, m));
        }



        internal override List<ComponentLine> BuildLines()
        {
            List<ComponentLine> lines = new List<ComponentLine>
            {
                new ComponentLine("PRODID:", "-//TCAV/Calendar v1.0/NL".ToCalendarString()),
                new ComponentLine("VERSION:", "2.0"),
                new ComponentLine("CALSCALE:", "GREGORIAN"),
                //new ComponentLine("X-WR-CALNAME;VALUE=TEXT:", Title.ToCalendarString()),
                //new ComponentLine("METHOD:", "PUBLISH"),
                //new ComponentLine("X-MS-OLK-FORCEINSPECTOROPEN:", true)
            };

            foreach (var e in Events)
                e.TimeZone = TimeZone;

            Components.AddRange(Events);

            //render the calendar components
            foreach (BaseComponent item in Components)
                lines.AddRange(item.BuildLines());

            return BuildComponent(lines);
        }
    }
}
