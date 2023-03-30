using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs {
    public class ReadSessaoDTO {

        public int filmeId { get; set; }
        public int cinemaId { get; set; }

    }
}