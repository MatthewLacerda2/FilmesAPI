using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using FilmesAPI.Models.Profiles;

namespace FilmesAPI.Profiles;

public class CinemaProfile : Profile {

    public CinemaProfile() {

        CreateMap<CreateCinemaDTO, Cinema>();

        CreateMap<Cinema, ReadCinemaDTO>()
            .ForMember(cinemaDto => cinemaDto.readEnderecoDTO,
                opt => opt.MapFrom(cinema => cinema.endereco))
            .ForMember(cinemadto=>cinemadto.sessoes, opt=>opt.MapFrom(cinema=>cinema.sessoes));
        CreateMap<UpdateCinemaDTO, Cinema>();
    }
}