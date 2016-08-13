using System;
using System.Xml;
using System.Xml.Serialization;

namespace PjBaySite.Models
{
    [Serializable]
    public class RssEntry
    {
        [XmlAttribute("title")]
        public string id { get; set; }

        [XmlAttribute("title")]
        public string title { get; set; }

        [XmlAttribute("link")]
        public string link { get; set; }

        [XmlAttribute("updated")]
        public string updated { get; set; }

        [XmlAttribute("summary")]
        public string summary { get; set; }

    }
}
