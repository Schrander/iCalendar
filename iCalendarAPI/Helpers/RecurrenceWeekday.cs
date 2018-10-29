using System;
using ICalendarAPI.Enumerations;

namespace ICalendarAPI.Helpers
{
	public class RecurrenceWeekday
	{
		public int? Number { get; set; }
		public RecurrenceDayOfWeek Day { get; set; }

		public RecurrenceWeekday(int? number, DayOfWeek day)
		{
			Number = number;
			Day = (RecurrenceDayOfWeek)day;
		}
	}
}
