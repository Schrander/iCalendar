using HelperTools;
using ICalendarAPI.Elements;
using ICalendarAPI.Enumerations;
using System.Collections.Generic;
using System.Linq;

namespace ICalendarAPI.Components
{
    public abstract class BaseComponent
    {
        public ComponentType ComponentType { get; set; }
        public string ComponentName { get; set; }

        protected BaseComponent(ComponentType componentType)
        {
            ComponentType = componentType;
            ComponentName = componentType.GetDescription();
        }

        protected BaseComponent(ComponentType componentType, string componentName)
        {
            ComponentType = componentType;
            ComponentName = componentName;
        }

        protected List<ComponentLine> BuildComponent(List<ComponentLine> lines)
        {
            List<ComponentLine> items = new List<ComponentLine>();
            items.AddRange(lines.Where(w => !string.IsNullOrEmpty(w.Value)));

            items.Insert(0, new ComponentLine("BEGIN:", ComponentName));
            items.Add(new ComponentLine("END:", ComponentName));

            return items;
        }

        internal abstract List<ComponentLine> BuildLines();
    }
}
