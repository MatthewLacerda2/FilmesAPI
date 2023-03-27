using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs;

public class CreateFilmeDTO {

    [Required(ErrorMessage = "Titulo obrigatorio")] public string titulo { get; set; } = string.Empty;
    [Required(ErrorMessage = "Genero obrigatorio")] public string genero { get; set; } = string.Empty;
    [Required]
    [Range(70, 600, ErrorMessage = "Duracao < 70min")] public int duracao { get; set; }

}