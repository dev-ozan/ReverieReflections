using System.ComponentModel.DataAnnotations;

namespace ReverieReflections.Areas.Models
{
    public class NewPostViewModel
    {

        public string MakaleAdi { get; set; } = null!;

        public string? Content { get; set; }

    }
}
