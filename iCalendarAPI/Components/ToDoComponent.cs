using HelperTools;
using HelperTools.Helpers;
using ICalendarAPI.Elements;
using ICalendarAPI.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

// BEGIN:VTODO
// DTSTAMP:19980130T134500Z
// SEQUENCE:2
// UID:uid4@example.com
// ACTION:AUDIO
// TRIGGER:19980403T120000
// ATTACH;FMTTYPE=audio/basic:http://example.com/pub/audio-
//  files/ssbanner.aud
// REPEAT:4
// DURATION:PT1H
// END:VTODO


namespace ICalendarAPI.Components
{

    public class ToDoComponent : BaseComponent
    {
        public string Code { get; set; }
        public int LCID { get; set; }

        public int? Sequence { get; set; }
        public ActionType? ActionType { get; set; }
        public DateTime? TriggerDate { get; set; }
        public int? Repeat { get; set; }
        public PresetElementPart Duration { get; set; }
        public DateTime? DueDate { get; set; }
        public int? PercentageComplete { get; set; }
        public int? Priority { get; set; }
        public DateTime? Completed { get; set; }
        public List<AttachmentElement> Attachments = new List<AttachmentElement>();
        public List<string> Categories { get; set; }

        public ToDoComponent(string code, int lcid)
            : base(ComponentType.Todo)
        {
            Code = code;
            LCID = lcid;
        }



        internal override List<ComponentLine> BuildLines()
        {
            List<ComponentLine> lines = new List<ComponentLine>
            {
                new ComponentLine("DTSTAMP:", DateTime.Now, true),
                new ComponentLine("SEQUENCE:", Sequence),
                new ComponentLine("UID:", $"{Code}@icalendar-API"),
                new ComponentLine("TRIGGER:", TriggerDate, true),
                new ComponentLine("ACTION:", ActionType),
                new ComponentLine("REPEAT:", MathExt.Max<int>(Repeat, 1)),
                new ComponentLine("DURATION:", Duration.ToString()),
                new ComponentLine("DUE:", DueDate, true),
                new ComponentLine("PERCENT-COMPLETE:", PercentageComplete.ForceToRange(0, 100)),
                new ComponentLine("PRIORITY:", Priority.ForceToRange(0, 9)),
                new ComponentLine("COMPLETED:", Completed.Coalesce(DateTime.Today.AddDays(1)), true)
            };

            lines.AddRange(Attachments.Select(a => a.BuildLine()));

            return BuildComponent(lines);
        }
    }
}

