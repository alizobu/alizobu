using Sube1.HelloMvc.Models.Relationships;

namespace Sube1.HelloMvc.Models
{
    public class Ders
    {
        public int dersid { get; set; }

        public string? dersad { get; set; }

        public string? derskodu { get; set; }

        public int kKredi { get; set; }

        public ICollection<OgrenciDers>? OgrenciDersler { get; set; }
    }
}