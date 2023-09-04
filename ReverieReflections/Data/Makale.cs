using Microsoft.AspNetCore.Identity;

namespace ReverieReflections.Data
{
    
    public class Makale
    {
        public int Id { get; set; }

    
        public string YazarId { get; set; } = null!;
        public string MakaleAdi { get; set; } = null!;
        public string Content { get; set; } = null!;

        public Kisi? Yazar { get; set; } 


    }
}
