using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models.Profiles {
    public class UpdateCinemaDTO {

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;
    }
}