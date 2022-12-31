using System.ComponentModel.DataAnnotations;

namespace MyEticketApplication.Models
{
    public class TransportType
    {
        [Key]
        public int TransportTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<TransportInfo> TransportInfos { get; set; }
    }
}
