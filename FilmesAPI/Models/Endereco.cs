using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models {

    public class Endereco {

        [Key]
        [Required]
        public int Id { get; set; }

        public string Logradouro { get; set; } = string.Empty;
        public int Numero { get; set; }

        public virtual Cinema cinema { get; set; }
    }

}