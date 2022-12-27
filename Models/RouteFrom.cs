using System.ComponentModel.DataAnnotations;

namespace MyEticketApplication.Models
{
    public class RouteFrom
    {
        [Key]
        public int RouteFromId { get; set; }
        public string RouteFromName { get; set; } = "";
        public int RouteToId { get; set; }
        public virtual RouteTo RouteTo { get; set; } 
    }
}
