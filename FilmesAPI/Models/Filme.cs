using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models; 

public class Filme {

    [Key]
    [Required]
    public int id { get; set; }

    [Required(ErrorMessage ="Titulo obrigatorio")] public string titulo { get; set; } = string.Empty;
    [Required(ErrorMessage = "Genero obrigatorio")] public string genero { get; set; } = string.Empty;
    [Required]
    [Range(70, 600,ErrorMessage ="Duracao < 70min")] public int duracao { get; set; }

    public virtual ICollection<Sessao> sessoes { get; set; }

}