using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models.Profiles {

    public class CreateCinemaDTO {

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Nome { get; set; }=string.Empty;

        public int EnderecoID { get; set; }
    }
}