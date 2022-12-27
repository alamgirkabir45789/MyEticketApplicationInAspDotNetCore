using System.ComponentModel.DataAnnotations;

namespace MyEticketApplication.Models
{
    public class RouteTo
    {
        [Key]
        public int RouteToId { get; set; }
        public string RouteToName { get; set; } = "";
        public ICollection<RouteFrom> RouteFroms { get; set; }   
    }
}
