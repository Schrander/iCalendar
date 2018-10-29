using HelperTools;
using HelperTools.Helpers;
using ICalendarAPI.Elements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICalendarAPI.Helpers
{
    public static class ComponentLineHelper
    {
        public static string SetName(string name)
        {
            name = name.ToUpper();
            return name.EndsWith(":") ? name : $"{name}:";
        }

        public static ComponentLine SetComponentLine(this Enum value, string name)
        {
            return new ComponentLine(name, value);
        }

        public static ComponentLine SetComponentLine(this string value, string name)
        {
            return new ComponentLine(name, value);
        }

        public static ComponentLine SetComponentLine(this int? value, string name, int? defaultValue = default(int?))
        {
            return new ComponentLine(name, MathExt.Max<int>(value, defaultValue));
        }

        public static ComponentLine SetComponentLine(this DateTime? value, string name, bool useUTC)
        {
            return new ComponentLine(name, value, useUTC);
        }

        public static ComponentLine SetComponentLine(this List<ElementPart> parts, string name, bool toCalendarString)
        {
            var filtered = parts.Where(w => !string.IsNullOrEmpty(w.Value)).Select(h => h.ToString()).Join(";");
            return new ComponentLine(name, filtered, toCalendarString);
        }

    }
}
