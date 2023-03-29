using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Proxies;

namespace FilmesAPI.Models.Profiles {
    public class ReadCinemaDTO {

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Nome { get; set; }=string.Empty;

        public ReadCinemaDTO readEnderecoDTO { get; set; }
    }
}