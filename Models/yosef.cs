using System.ComponentModel.DataAnnotations;

namespace postgres_docker.Models
{
    public class yosef
    {
        [Key]
        public string name { get; set; }

        public int age { get; set; }

        public string designation { get; set; }
        
        public int salary { get; set; }
    }
}