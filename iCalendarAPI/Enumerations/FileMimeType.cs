using System.ComponentModel;

//http://www.sitepoint.com/web-foundations/mime-types-complete-list/

namespace ICalendarAPI.Enumerations
{
	public enum FileMimeType
	{

		// Default
		[Description("FMTTYPE=application/octet-stream")]
		OctetStream,

		[Description("FMTTYPE=image/basic")]
		Image,

		[Description("FMTTYPE=image/jpeg")]
		Jpeg,

		[Description("FMTTYPE=image/png")]
		Png,

		[Description("FMTTYPE=image/gif")]
		Gif,

		[Description("FMTTYPE=application/binary")]
		Binary,

		[Description("FMTTYPE=audio/basic")]
		Audio,

		[Description("FMTTYPE=audio/mpeg3")]
		MP3,

		[Description("FMTTYPE=text/html")]
		Html,

		[Description("FMTTYPE=text/css")]
		Css,

		[Description("FMTTYPE=application/postscript")]
		PostScript,

		[Description("FMTTYPE=text/plain")]
		PlainText,

		[Description("FMTTYPE=image/vnd.microsoft.icon")]
		Icon,

		[Description("FMTTYPE=application/msword")]
		Word,

		[Description("FMTTYPE=application/vnd.ms-excel")]
		Excel,

		[Description("FMTTYPE=application/vnd.ms-powerpoint")]
		Powerpoint,

		[Description("FMTTYPE=video/mpeg")]
		MPeg,

		[Description("FMTTYPE=application/pdf")]
		PDF,

		[Description("FMTTYPE=text/xml")]
		XML,

		[Description("FMTTYPE=application/zip")]
		Zip,

		[Description("FMTTYPE=message/rfc822")]
		MHTML
	}
}
