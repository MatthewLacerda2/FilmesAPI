using System.ComponentModel.DataAnnotations;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data.DTOs;
using Microsoft.EntityFrameworkCore.Proxies;

namespace FilmesAPI.Models.Profiles {

    public class ReadCinemaDTO {

        public int Id { get; set; }

        //[Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Nome { get; set; }

        public ReadEnderecoDTO readEnderecoDTO { get; set; }
        public ICollection<ReadSessaoDTO> sessoes { get; set; }
    }
}