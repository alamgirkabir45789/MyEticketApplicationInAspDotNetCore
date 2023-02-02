using System.ComponentModel.DataAnnotations;

namespace MyEticketApplication.Models
{
    public class RouteFrom
    {
        [Key]
        public int RouteFromId { get; set; }
        [Required]
        public string RouteFromName { get; set; } = "";

        [Required]
        public int RouteToId { get; set; }
        public virtual RouteTo RouteTo { get; set; }
    }
}
