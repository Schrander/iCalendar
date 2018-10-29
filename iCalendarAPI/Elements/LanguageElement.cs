namespace ICalendarAPI.Elements
{
	public class LanguageElement
	{

		public int LCID { get; set; }

		public LanguageElement(int lcid)
		{
			LCID = lcid;
		}

		public override string ToString()
		{
			return $"LANGUAGE={LanguageCode}:";
		}

		private string LanguageCode
		{
			get
			{
				switch (LCID)
				{
					case 1030: return "da"; // deens
					case 1031: return "de"; // duits
					case 1032: return "el"; // grieks
					case 1033: return "en-US"; // amerikaans
					case 1034: return "es-ES"; // spaans
					case 1035: return "fi"; // fins
					case 1036: return "fr"; // frans
					case 1041: return "ja"; // japans
					case 1043: return "nl"; // nederlands
					case 1044: return "no"; // noors
					case 1045: return "pl"; // pools
					case 1049: return "ru"; //russisch
					case 1053: return "sv-SE"; // zweeds
					case 1055: return "tr"; // turks
					case 2057: return "en-GB"; // engels
					default: return "en-US"; //amerikaans
				}
			}
		}
	}
}
