using ICalendarAPI.Helpers;

//https://tools.ietf.org/html/rfc5545#section-3.8.4.2

namespace ICalendarAPI.Elements
{
	public class ContactElement : BaseElement
	{

		public string Information { get; set; }
		public string Alternative { get; set; }


		public ContactElement(string info, string alternative)
		{
			Information = info;
			Alternative = alternative;
		}

		public override ComponentLine BuildLine()
		{
			string s = new ElementPart("ALTREP", Alternative) + ":" + Information.ToCalendarString();
			return new ComponentLine("CONTACT;", s);
		}
	}
}
