using System;

namespace ICalendarAPI.Attributes
{
	public class CalenderOutputAttribute : Attribute
	{
		private readonly string _output;

		public CalenderOutputAttribute(string output)
		{
			_output = output;
		}
	}
}
