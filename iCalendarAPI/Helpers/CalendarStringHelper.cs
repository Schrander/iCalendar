using HelperTools;
using HelperTools.Helpers;
using HelperTools.Text;
using ICalendarAPI.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

//http://ical-validator.herokuapp.com/

namespace ICalendarAPI.Helpers
{

    public static class CalendarStringHelper
    {

        public static string ToCalendarString<T>(this T? value) where T : struct
        {
            return value?.ToString();
        }

        public static string ToCalendarString(this DateTime date, bool useUTC = false, bool useTime = true)
        {
            date = useUTC ? date.ToUniversalTime() : date;

            string dateString = $"{date.Year:0000}{date.Month:00}{date.Day:00}";
            string timeString = $"T{date.Hour:00}{date.Minute:00}{date.Second:00}";

            return dateString + (useTime ? timeString + (useUTC ? "Z" : null) : null);
        }

        public static string ToCalendarDateTime(this DateTime? date, bool useUTC = false)
        {
            return date.HasValue ? ToCalendarString(date.Value, useUTC, true) : null;
        }

        public static string ToCalendarDateTime(this DateTime date, bool useUTC = false)
        {
            return ToCalendarString(date, useUTC, true);
        }

        public static string ToCalendarDateTimeUTC(this DateTime? date)
        {
            return date.HasValue ? ToCalendarString(date.Value, true, true) : null;
        }

        public static string ToCalendarDateTimeUTC(this DateTime date)
        {
            return ToCalendarString(date, true, true);
        }

        public static string ToCalendarDateUTC(this DateTime? date, bool useUTC = false)
        {
            return date.HasValue ? ToCalendarString(date.Value, true, false) : null;
        }

        public static string ToCalendarDateUTC(this DateTime date, bool useUTC = false)
        {
            return ToCalendarString(date, true, false);
        }

        public static string ToCalendarDate(this DateTime? date, bool useUTC = false)
        {
            return date.HasValue ? ToCalendarString(date.Value, useUTC, false) : null;
        }

        public static string ToCalendarDate(this DateTime date, bool useUTC = false)
        {
            return ToCalendarString(date, useUTC, false);
        }

        public static string ToCalendarString(this StringBuilder value)
        {
            return ToCalendarString(value.ToString());
        }

        public static StringBuilder AppendCalendarLine(this StringBuilder builder, string value)
        {
            return builder.Append(value + "\\n");
        }

        private static StringBuilder AppendCalendarLineHTML(this StringBuilder builder, string value)
        {
            return builder.Append(value + "<BR>\\n");
        }

        public static StringBuilder Append(this StringBuilder builder, StringBuilder value)
        {
            return builder.Append(value);
        }

        public static string ToSummary(this string summary)
        {
            return ToCalendarString(summary, true, true, 0);
        }

        public static string ToSummary(this string summary, int lcid)
        {
            string language = new LanguageElement(lcid).ToString();
            summary = ToCalendarString(summary, true, true, 0);
            return $"{language}{summary}";
        }

        public static string ToDescriptionString(this string desc)
        {
            return ToCalendarString(desc, true, true, "DESCRIPTION:".Length);
        }

        public static string ToDescriptionString(this string desc, int offset)
        {
            return ToCalendarString(desc, true, true, offset);
        }

        public static string ToCalendarString(this string value, bool isDesc = false, bool doFold = true, int offset = 0)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            value = value.Replace("\r\n", "\\n").Trim();

            string pattern = @"[^\\][;,]|[\\]?[\\][^;,ntNT]";
            Regex r = new Regex(pattern);

            string output = Regex.Replace(value, pattern, delegate (Match match)
            {
                if (match.Groups[0].Value.Substring(0, 2) != @"\\")
                    return match.Groups[0].Value.Substring(0, 1) + "\\" + match.Groups[0].Value.Substring(1);
                return match.Groups[0].Value;
            });

            bool specialChars = HasSpecialChars(output, 0x3040, 0x309F)
              || HasSpecialChars(output, 0x30A0, 0x30FF)
              || HasSpecialChars(output, 0x4E00, 0x9FBF)
              || HasSpecialChars(output, 0x2980, 0x29FF);



            if (!specialChars && doFold)
                output = output.FoldLines(75, (75 - Math.Max(0, offset)));

            return output;
        }

        public static string ToHtmlString(this string input, bool doFold = true, int offset = 0)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string output = string.Empty;

            input = ToCalendarString(input, true, false);

            string pattern = @"([\\][nN])";
            Regex r = new Regex(pattern);
            if (r.IsMatch(input)) input = r.Replace(input, match => "<BR>\\n");


            output += input;

            output = output.Replace("&", "&amp\\;");
            output = output.Replace("\"", "&quot\\;");

            bool specialChars = HasSpecialChars(output, 0x3040, 0x309F)
              || HasSpecialChars(output, 0x30A0, 0x30FF)
              || HasSpecialChars(output, 0x4E00, 0x9FBF)
              || HasSpecialChars(output, 0x2980, 0x29FF);



            if (!specialChars && doFold)
                output = output.FoldLines(75, 75 - Math.Max(0, offset));

            return output;
        }

        public static string ToMailAddress(this string email)
        {
            return ":mailto:" + email;
        }

        public static string ToCalendarString(this MailAddress email)
        {
            string output = !string.IsNullOrEmpty(email.DisplayName) ? $";CN=\'{email.DisplayName.ToCalendarString()}\'" : null;
            output += ":mailto:" + email.Address;

            return output;
        }

        public static string ToCalendarString(this bool value)
        {
            return value ? "TRUE" : "FALSE";
        }

        public static string ToCalendarString(this Enum value)
        {
            return value == null ? null : value.GetDescription().ToCalendarString();
        }

        public static string ToCalendarString(this TimeSpan timespan)
        {
            return $"+{timespan.Hours:00}{timespan.Minutes:00}";
        }

        public static string ToCalendarString<T>(this IEnumerable<T> list) where T : struct
        {
            return ToCalendarString(list.OfType<string>(), ",");
        }

        public static ElementPart BuildElementPart(this Enum value)
        {
            if (value == null)
                return null;

            var splitted = value.GetDescription().Split('=');
            return splitted.Length == 2 ? new ElementPart(splitted[0], splitted[1]) : new ElementPart(splitted[0], string.Empty);
        }

        public static string ToCalendarString(this IEnumerable<string> list, string separator)
        {
            return list.Select(item => item.ToCalendarString()).ToList().JoinDistinct(separator);
        }

        public static string ToHtml(this string input, bool doFold = false, int offset = 0)
        {
            if (string.IsNullOrEmpty(input))
                return null;

            StringBuilder output = new StringBuilder();

            output.AppendCalendarLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 3.2//EN\">");
            output.AppendCalendarLine("<HTML>");
            output.AppendCalendarLine("<HEAD>");
            output.AppendCalendarLine("<META NAME=\"Generator\" CONTENT=\"Text generated\">");
            output.AppendCalendarLine("<TITLE></TITLE>");
            output.AppendCalendarLine("</HEAD>");
            output.AppendCalendarLine("<BODY>");
            output.AppendCalendarLine("<P><FONT SIZE=2>");

            output.Append(input.ToHtmlString(false));

            output.AppendCalendarLine("</FONT></P>");
            output.AppendCalendarLine("</BODY>");
            output.AppendCalendarLine("</HTML>");

            string s = output.ToString();

            bool specialChars = HasSpecialChars(s, 0x3040, 0x309F)
              || HasSpecialChars(s, 0x30A0, 0x30FF)
              || HasSpecialChars(s, 0x4E00, 0x9FBF)
              || HasSpecialChars(s, 0x2980, 0x29FF);

            //if (!specialChars && doFold)
            s = s.FoldLines(75, (75 - Math.Max(0, offset)));

            return s;
        }

        public static bool HasSpecialChars(this string text, int min, int max)
        {
            return text.Any(e => e >= min && e <= max);
        }

    }

}
