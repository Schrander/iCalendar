using HelperTools;
using HelperTools.Extensions;
using HelperTools.Helpers;
using ICalendarAPI.Enumerations;
using ICalendarAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

//http://www.kanzaki.com/docs/ical/recur.html

namespace ICalendarAPI.Elements
{

    public class RecurrenceRuleElement : BaseElement
    {

        public RecurrenceFrequency Frequency { get; set; }
        public int? Interval { get; set; }
        public List<RecurranceValue> Values { get; set; }
        public int? BySetPos { get; set; }
        public List<RecurrenceWeekday> Weekday { get; set; }
        public int? Count { get; set; }
        public DateTime? Until { get; set; }
        public RecurrenceDayOfWeek? WeekStart { get; set; } // default Monday

        #region Constructors

        public RecurrenceRuleElement(RecurrenceFrequency frequency, List<RecurranceValue> values) :
          this(frequency, values, null, null, null, null)
        { }

        public RecurrenceRuleElement(RecurrenceFrequency frequency, List<RecurranceValue> values, DateTime? until) :
          this(frequency, values, until, null, null, null)
        { }

        public RecurrenceRuleElement(RecurrenceFrequency frequency, List<RecurranceValue> values, int? count) :
          this(frequency, values, null, count, null, null)
        { }

        public RecurrenceRuleElement(RecurrenceFrequency frequency, List<RecurranceValue> values, DateTime? until, int? bySetPos) :
          this(frequency, values, until, null, bySetPos, null)
        { }

        public RecurrenceRuleElement(RecurrenceFrequency frequency, List<RecurranceValue> values, int? count, int? bySetPos) :
          this(frequency, values, null, count, bySetPos, null)
        { }


        public RecurrenceRuleElement(RecurrenceFrequency frequency, List<RecurranceValue> values, DateTime? until, int? count, int? bySetPos, RecurrenceDayOfWeek? weekStart)
        {
            Frequency = frequency;
            Values = values;
            Until = until;
            WeekStart = weekStart;
            Count = count;
            BySetPos = bySetPos;
            WeekStart = weekStart;
        }
        #endregion

        // RRULE:FREQ=YEARLY;BYWEEKNO=20;BYDAY=MO

        public override ComponentLine BuildLine()
        {
            var grouped = Values.ToLookupList(x => x.Prefix);

            List<ElementPart> parts = new List<ElementPart>
            {
                new ElementPart("FREQ", Frequency ),
                new ElementPart("INTERVAL", Interval)
            };

            parts.AddRange(grouped.Select(g => new ElementPart(g[0].Prefix.GetDescription(), g.Select(t => t.ToString()).Join(","))));

            parts.Add(new ElementPart("WKST", WeekStart));
            parts.Add(new ElementPart("BYSETPOS", BySetPos));
            parts.Add(new ElementPart("UNTIL", Until, true));
            parts.Add(new ElementPart("COUNT", Count.ParseAs(1)));


            return parts.SetComponentLine("RRULE:", false);
        }

    }

}
