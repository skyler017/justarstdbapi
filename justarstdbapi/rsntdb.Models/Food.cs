using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace rsntdb.Models
{
    [Table("food", Schema = "rsnt")]
    public class Food
    {
        [XmlAttribute]
        [Key, Column("foodid")]
        public int id { get; set; }
        public string name { get; set; }
        public int cuisineid { get; set; }

        public Food() { }

        public Food(int id, string name, int cuisineid)
        {
            this.id = id;
            this.name = name;
            this.cuisineid = cuisineid;
        }
    }
}