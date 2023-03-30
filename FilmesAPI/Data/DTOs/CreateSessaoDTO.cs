using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs {

    public class CreateSessaoDTO {

        public int filmeId { get; set; }
        public int cinemaId { get; set; }

    }

}