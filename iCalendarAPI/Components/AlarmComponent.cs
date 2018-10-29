using ICalendarAPI.Elements;
using ICalendarAPI.Enumerations;
using ICalendarAPI.Helpers;
using System;
using System.Collections.Generic;

//BEGIN:VALARM
//TRIGGER:-PT30M
//REPEAT:2
//DURATION:PT15M
//ACTION:DISPLAY
//DESCRIPTION:Breakfast meeting with executive\n
// team at 8:30 AM EST.
//END:VALARM

namespace ICalendarAPI.Components
{

    public class AlarmComponent : BaseComponent
    {
        public int? Repeat { get; set; }
        public ActionType ActionType { get; set; }
        public string Description { get; set; }
        public PresetElementPart TriggerPreset { get; set; }
        public PresetElementPart Duration { get; set; }
        public DateTime? TriggerDate { get; set; }
        public string Summary { get; set; }
        public AttachmentElement AttachmentElement { get; set; }

        public AlarmComponent() : this("reminder") { }

        public AlarmComponent(string desc) : this(desc, new PresetElementPart(null, null, null, 15)) { }

        public AlarmComponent(string desc, DateTime triggerDate)
         : base(ComponentType.Alarm)
        {
            TriggerDate = triggerDate;
            Description = desc;
        }

        public AlarmComponent(string desc, PresetElementPart preset)
            : base(ComponentType.Alarm)
        {
            TriggerPreset = preset;
            Description = desc;
        }

        internal override List<ComponentLine> BuildLines()
        {
            List<ComponentLine> lines = new List<ComponentLine>();

            lines.Add(TriggerDate.HasValue
                ? new ComponentLine("TRIGGER;VALUE=DATE-TIME:", TriggerDate, true)
                : new ComponentLine("TRIGGER:", $"-{TriggerPreset}"));                       //TRIGGER:-PT30M
            lines.Add(new ComponentLine("DESCRIPTION:", Description.ToDescriptionString())); //DESCRIPTION:Breakfast meeting with executive\n

            lines.Add(new ComponentLine("ACTION:", ActionType));                             //ACTION:DISPLAY
                                                                                             //lines.Add(new ComponentLine("REPEAT:", MathExt.Max<int>(Repeat, 1)));            //REPEAT:2
                                                                                             //lines.Add(new ComponentLine("DURATION:", Duration?.ToString()));                 //DURATION:PT15M

            if (AttachmentElement != null)
                lines.Add(AttachmentElement.BuildLine());

            //lines.Add(new ComponentLine("SUMMARY:", Summary.Coalesce(Description).ToSummary()));

            return BuildComponent(lines);
        }
    }
}
