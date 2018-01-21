using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BooksXMLEg
{
    [XmlRoot("catalog")]
    public class catalog
    {
        [XmlElement("book")]
        public List<book> books { get; set; }
    }
    public class book
    {
        [XmlElement("author")]
        public string author { get; set; }

        [XmlElement("title")]
        public string title { get; set; }

        [XmlElement("genre")]
        public string genre { get; set; }

        [XmlElement("price")]
        public double price { get; set; }

        [XmlElement("publish_date")]
        public DateTime publish_date { get; set; }

        [XmlElement("description")]
        public string description { get; set; }
    }
}
