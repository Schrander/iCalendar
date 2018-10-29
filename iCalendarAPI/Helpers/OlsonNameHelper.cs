using System;
using System.Collections.Generic;
using System.Linq;

namespace ICalendarAPI.Helpers
{
	public static class OlsonNameHelper
	{
		public static string ToOlsonName(this TimeZoneInfo zone)
		{
			Dictionary<string, string> list = new Dictionary<string, string>
			{
				{"Afghanistan Standard Time", "Asia/Kabul"},
				{"Alaskan Standard Time", "America/Anchorage"},
				{"Arab Standard Time", "Asia/Kuwait"},
				{"Arabian Standard Time", "Asia/Dubai"},
				{"Arabic Standard Time", "Asia/Baghdad"},
				{"Argentina Standard Time", "America/Argentina/Buenos_Aires"},
				{"Atlantic Standard Time", "America/Halifax"},
				{"AUS Eastern Standard Time", "Australia/Sydney"},
				{"Azores Standard Time", "Atlantic/Azores"},
				{"Bangladesh Standard Time", "Asia/Dhaka"},
				{"Cape Verde Standard Time", "Atlantic/Cape_Verde"},
				{"Caucasus Standard Time", "Asia/Baku"},
				{"Cen. Australia Standard Time", "Australia/Adelaide"},
				{"Central America Standard Time", "Pacific/Galapagos"},
				{"Central Asia Standard Time", "Asia/Qyzylorda"},
				{"Central Brazilian Standard Time", "America/Curacao"},
				{"Central Europe Standard Time", "Europe/Prague"},
				{"Central Pacific Standard Time", "Pacific/Norfolk"},
				{"Central Standard Time (Mexico)", "America/Mexico_City"},
				{"Central Standard Time", "America/Chicago"},
				{"China Standard Time", "Asia/Hong_Kong"},
				{"E. Africa Standard Time", "Africa/Nairobi"},
				{"E. Australia Standard Time", "Australia/Brisbane"},
				{"E. Europe Standard Time", "Europe/Kiev"},
				{"E. South America Standard Time", "America/Sao_Paulo"},
				{"Eastern Standard Time", "America/Detroit"},
				{"Egypt Standard Time", "Africa/Cairo"},
				{"Ekaterinburg Standard Time", "Asia/Yekaterinburg"},
				{"Fiji Standard Time", "Pacific/Fiji"},
				{"FLE Standard Time", "Europe/Helsinki"},
				{"Georgian Standard Time", "Asia/Tbilisi"},
				{"GMT Standard Time", "Europe/London"},
				{"Greenwich Standard Time", "Atlantic/Reykjavik"},
				{"GTB Standard Time", "Europe/Bucharest"},
				{"Hawaiian Standard Time", "Pacific/Honolulu"},
				{"India Standard Time", "Asia/Kolkata"},
				{"Iran Standard Time", "Asia/Tehran"},
				{"Israel Standard Time", "Asia/Jerusalem"},
				{"Jordan Standard Time", "Asia/Amman"},
				{"Kaliningrad Standard Time", "Europe/Kaliningrad"},
				{"Korea Standard Time", "Asia/Seoul"},
				{"Magadan Standard Time", "Asia/Magadan"},
				{"Mauritius Standard Time", "Indian/Mauritius"},
				{"Mid-Atlantic Standard Time", "Atlantic/South_Georgia"},
				{"Middle East Standard Time", "Asia/Beirut"},
				{"Montevideo Standard Time", "America/Montevideo"},
				{"Morocco Standard Time", "Africa/Casablanca"},
				{"Mountain Standard Time (Mexico)", "America/Chihuahua"},
				{"Mountain Standard Time", "America/Denver"},
				{"Myanmar Standard Time", "Asia/Rangoon"},
				{"N. Central Asia Standard Time", "Asia/Omsk"},
				{"Namibia Standard Time", "Africa/Windhoek"},
				{"Nepal Standard Time", "Asia/Kathmandu"},
				{"New Zealand Standard Time", "Pacific/Auckland"},
				{"Newfoundland Standard Time", "America/St_Johns"},
				{"North Asia East Standard Time", "Asia/Dili"},
				{"North Asia Standard Time", "Asia/Manila"},
				{"Pacific SA Standard Time", "America/Santiago"},
				{"Pacific Standard Time (Mexico)", "America/Tijuana"},
				{"Pacific Standard Time", "America/Los_Angeles"},
				{"Pakistan Standard Time", "Asia/Karachi"},
				{"Paraguay Standard Time", "America/Asuncion"},
				{"Romance Standard Time", "Europe/Brussels"},
				{"Russian Standard Time", "Europe/Moscow"},
				{"SA Pacific Standard Time", "America/Lima"},
				{"SA Western Standard Time", "America/La_Paz"},
				{"Samoa Standard Time", "Pacific/Pago_Pago"},
				{"SE Asia Standard Time", "Asia/Jakarta"},
				{"Singapore Standard Time", "Asia/Singapore"},
				{"South Africa Standard Time", "Africa/Johannesburg"},
				{"Sri Lanka Standard Time", "Asia/Colombo"},
				{"Syria Standard Time", "Asia/Damascus"},
				{"Taipei Standard Time", "Asia/Taipei"},
				{"Tasmania Standard Time", "Australia/Hobart"},
				{"Tokyo Standard Time", "Asia/Tokyo"},
				{"Tonga Standard Time", "Pacific/Kiritimati"},
				{"Turkey Standard Time", "Europe/Istanbul"},
				{"Ulaanbaatar Standard Time", "Asia/Ulaanbaatar"},
				{"US Eastern Standard Time", "America/Indiana/Indianapolis"},
				{"US Mountain Standard Time", "America/Phoenix"},
				{"UTC", "UTC"},
				{"UTC+12", "Antarctica/South_Pole"},
				{"Venezuela Standard Time", "America/Caracas"},
				{"Vladivostok Standard Time", "Asia/Vladivostok"},
				{"W. Australia Standard Time", "Australia/Perth"},
				{"W. Central Africa Standard Time", "Africa/Tunis"},
				{"W. Europe Standard Time", "Europe/Amsterdam"},
				{"West Asia Standard Time", "Asia/Aqtau"},
				{"West Pacific Standard Time", "Pacific/Guam"},
				{"Yakutsk Standard Time", "Asia/Yakutsk"}
			};

			#region listing

			#endregion

			return (from item in list where item.Key.Equals(zone.Id) select item.Value).FirstOrDefault();
		}
	}
}
