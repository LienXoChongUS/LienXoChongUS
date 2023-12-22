using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LXxUS.Models
{
    public class Request
    {
        [Key]
        public int ID { get; set; }
        public DateTime Request_Date { get; set; } = DateTime.UtcNow;
        public string Request_Name { get; set; }
        public string Request_Description { get; set; }

        public string Status { get; set; }

        public string UserId { get; set; }
    }
}