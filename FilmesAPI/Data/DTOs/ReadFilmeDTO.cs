using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs;

public class ReadFilmeDTO {

    public string titulo { get; set; }
    public string genero { get; set; }
    public int duracao { get; set; }
    public DateTime HoraConsulta { get; set; } = DateTime.Now;

}