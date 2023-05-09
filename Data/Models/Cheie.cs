// See https://aka.ms/new-console-template for more information

namespace CarParkDbAPI.Models
{
    public class Cheie
    {
        public int Id { get; set; }
        public Guid CodAcces { get; set; }
        public int? AutovehiculId { get; set; }
    }
}