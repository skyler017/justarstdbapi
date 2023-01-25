using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace rsntdb.Models
{
    [Table("city", Schema = "rsnt")]
    public class City
    {
        [XmlAttribute]
        [Key, Column("cityid")]
        public int id { get; set; }
        public string name { get; set; }

        public City() { }

        public City(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}