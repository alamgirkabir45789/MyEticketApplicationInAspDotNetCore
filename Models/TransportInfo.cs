using System.ComponentModel.DataAnnotations;

namespace MyEticketApplication.Models
{
    public class TransportInfo
    {
        [Key]
        public int TransportId { get; set; }
        public string TransportName { get; set; }
        public string TransportType { get; set; }
        public string TransportOwnerName { get; set; }
        public string TransportDescription { get; set; }
        public int SeatNo { get; set; }
        public int TransportTypeId { get; set; }
        public virtual TransportType TransportTypes { get;set; }
    }
}
