using ICalendarAPI.Enumerations;

namespace ICalendarAPI.Helpers
{
	public class RecurranceValue
	{
		public RecurrencePrefix Prefix { get; set; }
		public int? Value { get; set; }
		public string Name { get; set; }

		public RecurranceValue(RecurrencePrefix prefix, int? value, string name = null)
		{
			Prefix = prefix;
			Value = value;
			Name = name;
		}

		public override string ToString()
		{
			return string.IsNullOrEmpty(Name) ? Value.ToString() : $"{Value}{Name}";
		}
	}
}
