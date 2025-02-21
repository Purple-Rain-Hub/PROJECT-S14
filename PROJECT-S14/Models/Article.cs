using System.ComponentModel.DataAnnotations;

namespace PROJECT_S14.Models
{
    public class Article
    {
        public Guid Id { get; set; }
        [Display (Name="Nome Articolo")]
        [Required(ErrorMessage ="il nome è obbligatorio")]
        public string? Name { get; set; }
        [Display(Name = "Prezzo Articolo")]
        [Required(ErrorMessage = "il prezzo è obbligatorio")]
        public decimal Price { get; set; }
        [Display(Name = "Descrizione Articolo")]
        [Required(ErrorMessage = "la descrizione è obbligatoria")]
        public string? Description { get; set; }
        [Display(Name = "Copertina Articolo")]
        [Required(ErrorMessage = "la copertina è obbligatoria")]
        [Url(ErrorMessage ="L'elemento inserito deve essere un Url")]
        public string? Thumbnail { get; set; }
        [Display(Name = "Immagini Aggiuntive")]
        public List<string>? Images { get; set; }
    }
}
