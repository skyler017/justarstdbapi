using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace rsntdb.Models
{
    [Table("cuisine", Schema = "rsnt")]
    public class Cuisine
    {
        [XmlAttribute]
        [Key, Column("cuisineid")]
        public int id { get; set; }
        public string name { get; set; }

        public Cuisine() { }

        public Cuisine(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}