using ICalendarAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace ICalendarAPI.Elements
{


    public class ComponentLine
    {
        public string Name { get; set; }
        public string Value { get; set; }

        internal ComponentLine(string name, string value, bool toCalendarString = true)
        {
            Name = name;
            Value = toCalendarString ? value.ToCalendarString() : value;
        }

        internal ComponentLine(string name, IEnumerable<string> values)
        {
            Name = name;
            Value = values.ToCalendarString(",");
        }

        public ComponentLine(string name, int? value)
        {
            Name = name;
            Value = value.ToCalendarString();
        }

        public ComponentLine(string name, Enum value)
        {
            Name = name;
            Value = value.ToCalendarString();
        }

        public ComponentLine(string name, DateTime? value, bool useUTC)
        {
            Name = name;
            Value = useUTC ? value.ToCalendarDateTimeUTC() : value.ToCalendarDateTime();
        }

        public ComponentLine(string name, bool value)
        {
            Name = name;
            Value = value.ToCalendarString();
        }

        public ComponentLine(string name, MailAddress address)
        {
            Name = name;
            Value = $"mailto:{address.Address}";

        }
    }
}
