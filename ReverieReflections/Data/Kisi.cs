using Microsoft.AspNetCore.Identity;

namespace ReverieReflections.Data
{
    public class Kisi : IdentityUser
    {
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public string? Aciklama { get; set; }
        public string? ImageName { get; set; }

        public List<Makale> Makaleler { get; set; } = new();
    }
}
