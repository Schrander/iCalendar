using HelperTools;
using ICalendarAPI.Helpers;
using System;
using System.Net.Mail;

namespace ICalendarAPI.Elements
{

    public static class ElementHelper
    {
        public static string SetName(string name)
        {
            return name.ToUpper();
        }


        public static ElementPart SetElementPart(this Enum value, string name)
        {
            return new ElementPart(SetName(name), value);
        }

        public static ElementPart SetElementPart(this string value, string name)
        {
            return new ElementPart(SetName(name), value);
        }

        public static ElementPart SetElementPart(this int? value, string name, int? defaultValue = default(int?))
        {
            return new ElementPart(SetName(name), MathExt.Max<int>(value, defaultValue));
        }

        public static ElementPart SetElementPart(this bool? value, string name)
        {
            return new ElementPart(SetName(name), value);
        }

        public static ElementPart SetElementPart(this DateTime? value, string name, bool useUTC)
        {
            return new ElementPart(SetName(name), value, useUTC);
        }

        public static ElementPart SetElementPart(this MailAddress value, string name, bool useUTC)
        {
            return new ElementPart(SetName(name), value, useUTC);
        }

    }

    public class ElementPart
    {
        public string Name { get; set; }
        public string Value { get; set; }

        #region Constructors
        public ElementPart(string name, string value)
        {
            Name = name;
            Value = value.ToCalendarString();
        }

        public ElementPart(string name, int? value)
        {
            Name = name;
            Value = value.ToCalendarString();
        }

        public ElementPart(string name, Enum value)
        {
            Name = name;
            Value = value.ToCalendarString();
        }

        public ElementPart(string name, DateTime? value, bool useUTC)
        {
            Name = name;
            Value = useUTC ? value.ToCalendarDateTimeUTC() : value.ToCalendarDateTime();
        }

        public ElementPart(string name, bool? value)
        {
            Name = name;
            Value = value.HasValue ? value.Value.ToCalendarString() : null;
        }

        public ElementPart(string name, MailAddress address, bool useName = false)
        {
            Name = name;
            string emailUserName = address.DisplayName;

            Value = useName ? new ElementPart("CN", emailUserName) + ":" : null;
            Value += $"mailto:{address.Address}";

        }
        #endregion

        public override string ToString()
        {
            return string.IsNullOrEmpty(Value) ? null : $"{Name}={Value}";
        }
    }
}
