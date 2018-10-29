using ICalendarAPI.Components;
using System;
using System.Globalization;
using System.Text;

namespace ICalendarAPI
{
	public class ICalendar
	{
		public CalendarComponent Calendar { get; set; }

		public ICalendar CreateCalendar(TimeZoneInfo timeZone, CultureInfo culture, string title)
		{
			return new ICalendar { Calendar = new CalendarComponent(timeZone, title, culture) };
		}

		public string RenderCalendar()
		{
			StringBuilder s = new StringBuilder();
			foreach (var item in Calendar.BuildLines())
				s.AppendLine($"{item.Name}{item.Value}");

			return s.ToString();
		}

	}
}
