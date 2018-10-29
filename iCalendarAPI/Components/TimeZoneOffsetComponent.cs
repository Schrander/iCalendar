using HelperTools;
using ICalendarAPI.Elements;
using ICalendarAPI.Enumerations;
using ICalendarAPI.Helpers;
using System;
using System.Collections.Generic;

namespace ICalendarAPI.Components
{
    public class TimeZoneOffsetComponent : BaseComponent
    {

        public string TimeZoneName { get; set; }
        public string TZUrl { get; set; }
        public RecurrenceRuleElement RecurrenceRule { get; set; }
        public TimeZoneOffsetType TimeZoneType { get; set; }
        public DateTime StartDate { get; set; }
        public TimeZoneInfo TimeZoneInfo { get; set; }
        public TimeSpan OffsetWinter { get; set; }
        public TimeSpan OffsetSummer { get; set; }
        public TimeSpan OffsetFrom { get; set; }
        public TimeSpan OffsetTo { get; set; }

        public TimeZoneOffsetComponent(TimeZoneOffsetType timeZoneType, TimeZoneInfo timeZone)
            : base(ComponentType.TimeZone, timeZoneType.GetDescription())
        {
            StartDate = new DateTime(1970, 1, 1, 0, 0, 0);
            TimeZoneInfo = timeZone;
            TimeZoneType = timeZoneType;

            OffsetWinter = TimeZoneInfo.GetUtcOffset(new DateTime(DateTime.Today.Year, 1, 1));
            OffsetSummer = TimeZoneInfo.GetUtcOffset(new DateTime(DateTime.Today.Year, 6, 1));
            OffsetFrom = TimeZoneType == TimeZoneOffsetType.Standard ? OffsetSummer : OffsetWinter;
            OffsetTo = TimeZoneType == TimeZoneOffsetType.Standard ? OffsetWinter : OffsetSummer;

            if (!timeZone.SupportsDaylightSavingTime)
                return;

            List<RecurranceValue> items = new List<RecurranceValue>();

            foreach (var rule in timeZone.GetAdjustmentRules())
            {
                if (DateTime.Today.Year < rule.DateStart.Year || DateTime.Today.Year > rule.DateEnd.Year)
                    continue;

                TimeZoneInfo.TransitionTime transition = timeZoneType == TimeZoneOffsetType.Daylight
                    ? rule.DaylightTransitionStart
                    : rule.DaylightTransitionEnd;
                items.Add(new RecurranceValue(RecurrencePrefix.Month, transition.Month));

                if (transition.IsFixedDateRule)
                {
                    items.Add(new RecurranceValue(RecurrencePrefix.MonthDay, transition.Day));
                }
                else
                {
                    int weekNumber = (WeekOfMonth)transition.Week == WeekOfMonth.Last ? -1 : transition.Week;
                    RecurrenceDayOfWeek recurrenceDay = (RecurrenceDayOfWeek)(int)transition.DayOfWeek;

                    items.Add(new RecurranceValue(RecurrencePrefix.Day, weekNumber, recurrenceDay.GetDescription()));
                }

                RecurrenceRule = new RecurrenceRuleElement(RecurrenceFrequency.Yearly, items);
                StartDate = new DateTime(rule.DateStart.Year <= 1970 ? 1970 : rule.DateStart.Year, rule.DateStart.Month,
                    rule.DateStart.Day, transition.TimeOfDay.Hour, transition.TimeOfDay.Minute, transition.TimeOfDay.Second);

            }
        }

        // BEGIN:STANDARD (BEGIN:DAYLIGHT)
        // TZOFFSETFROM:+0200 (+0100)
        // TZOFFSETTO:+0100  (+0200)
        // TZNAME:CET
        // DTSTART:19701025T030000
        // RRULE:FREQ=YEARLY;BYMONTH=10;BYDAY=-1SU
        // END:STANDARD (END:DAYLIGHT)

        internal override List<ComponentLine> BuildLines()
        {
            List<ComponentLine> lines = new List<ComponentLine>
            {
                new ComponentLine("TZOFFSETFROM:" , OffsetFrom.ToCalendarString()),
                new ComponentLine("TZOFFSETTO:" , OffsetTo.ToCalendarString()),
                new ComponentLine("DTSTART:" , StartDate.ToCalendarDateTime())
            };

            if (RecurrenceRule != null)
                lines.Add(RecurrenceRule.BuildLine());

            return BuildComponent(lines);
        }
    }
}