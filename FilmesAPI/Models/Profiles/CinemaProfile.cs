using AutoMapper;

namespace FilmesAPI.Models.Profiles;

public class CinemaProfile : Profile {

    public CinemaProfile() {
        CreateMap<CreateCinemaDTO, Cinema>();
        CreateMap<Cinema, ReadCinemaDTO>().
            ForMember(cinemaDto=>cinemaDto.readEnderecoDTO,
                opt=>opt.MapFrom(cinema=>cinema.endereco));
        CreateMap<UpdateCinemaDTO, Cinema>();
        //CreateMap<Cinema, UpdateCinemaDTO>();
    }
}