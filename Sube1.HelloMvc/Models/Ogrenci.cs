using Sube1.HelloMvc.Models.Relationships;

namespace Sube1.HelloMvc.Models
{
    public class Ogrenci
    {
        public int ogrid { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public int Numara { get; set; }

        public ICollection<OgrenciDers>? OgrenciDersler { get; set; }

        public override string ToString() => $"Ad:{this.Ad} Soyad:{this.Soyad} Numara:{this.Numara}";
    }
}