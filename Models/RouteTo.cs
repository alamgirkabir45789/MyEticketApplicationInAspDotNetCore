using System.ComponentModel.DataAnnotations;

namespace MyEticketApplication.Models
{
    public class RouteTo
    {
        [Key]
        public int RouteToId { get; set; }
        
        [Required(ErrorMessage ="Route to name is required")]
        public string RouteToName { get; set; } = "";
        public ICollection<RouteFrom> RouteFroms { get; set; }
    }
}
