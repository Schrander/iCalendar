using HelperTools;
using HelperTools.Web;
using ICalendarAPI.Enumerations;
using System.Text;

namespace ICalendarAPI.Elements
{
    // ATTACH;FMTTYPE=audio/basic:http://example.com/pub/audio-
    //  files/ssbanner.aud

    public class AttachmentElement : BaseElement
    {

        public string FileLocation { get; set; }
        public FileMimeType FileMimeType { get; set; }
        public byte[] AttachmentBody { get; set; }

        public AttachmentElement(string fileLocation, FileMimeType mime, byte[] body)
        {
            FileLocation = fileLocation;
            FileMimeType = mime;
            AttachmentBody = body;
        }

        public override ComponentLine BuildLine()
        {
            StringBuilder output = new StringBuilder();

            output.Append(FileMimeType.GetDescription());

            if (!string.IsNullOrEmpty(FileLocation))
            {
                output.Append(";" + CalendarValueType.Url.GetDescription());
                output.Append(":" + UrlNormalization.Instance.Normalize(FileLocation));
            }
            else
            {
                output.Append(";" + EncodingType.Base64.GetDescription());
                output.Append(";" + CalendarValueType.Binary.GetDescription());
                output.Append(":");
                output.Append(AttachmentBody);
            }

            return new ComponentLine("ATTACH;", output.ToString());
        }

    }
}
