using System.ComponentModel.DataAnnotations;

namespace MyEticketApplication.Models
{
    public class RouteFrom
    {
        [Key]
        public int RouteFromId { get; set; }
        public string RouteFromName { get; set; } = "";
        public RouteTo RouteTo { get; set; }
    }
}
