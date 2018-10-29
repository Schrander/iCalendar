using HelperTools;
using ICalendarAPI.Helpers;
using System;

namespace ICalendarAPI.Elements
{
	public class PresetElementPart
	{

		public DateTime? DateTimePreset { get; set; }
		public int? Week { get; set; }
		public int? Day { get; set; }
		public int? Hour { get; set; }
		public int? Minute { get; set; }
		public int? Second { get; set; }

		#region Constructors

		public PresetElementPart(int? week)
		  : this(week, null, null, null, null)
		{ }

		public PresetElementPart(int? week, int? day)
		  : this(week, day, null, null, null)
		{ }

		public PresetElementPart(DateTime date)
		{
			DateTimePreset = date;
		}

		public PresetElementPart(int? week, int? day, int? hour)
		  : this(week, day, hour, null, null)
		{ }

		public PresetElementPart(int? week, int? day, int? hour, int? minute)
		  : this(week, day, hour, minute, null)
		{ }

		public PresetElementPart(int? week, int? day, int? hour, int? minute, int? second)
		{
			Week = week;
			Day = day;
			Hour = hour;
			Minute = minute;
			Second = second;
		}

		#endregion

		public override string ToString()
		{
			if (DateTimePreset.HasValue)
				return DateTimePreset.Value.ToCalendarDateTimeUTC();
			
			if (NullableHelper.AllAreNull(DateTimePreset, Week, Day, Hour, Minute, Second))
				return "PT15M";

			string output = "P";
			output += Week.HasValue ? $"{Week}W" : null;
			output += Day.HasValue ? $"{Day}D" : null;
			output += NullableHelper.AnyHasValue(Hour, Minute, Second) ? "T" : null;
			output += Hour.HasValue ? $"{Hour}H" : null;
			output += Minute.HasValue && Minute.Value > 0 ? $"{Minute}M" : null;
			output += Second.HasValue && Second.Value > 0 ? $"{Second}S" : null;

			return output;
		}
	}
}
