using System.ComponentModel.DataAnnotations;

namespace _05Services_Interfaces.Models
{
    public class Article
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
