using AutoMapper;
using FilmesAPI.Data.DTOs;

namespace FilmesAPI.Models.Profiles {
    public class SessaoProfile : Profile {
        public SessaoProfile() {
            CreateMap<CreateSessaoDTO, Sessao>();
            CreateMap<Sessao,ReadSessaoDTO>();
        }
    }
}
