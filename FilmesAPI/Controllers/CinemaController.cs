using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using FilmesAPI.Models.Profiles;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase {

    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    
    [HttpPost]
    public IActionResult AdicionaCinema([FromBody] CreateCinemaDTO cinemaDTO) {

        Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaCinemaPorID), new { id = cinema.Id }, cinemaDTO);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDTO> RecuperaCinemas([FromQuery] int? enderecoId=null) {
        if (enderecoId == null) {
            return _mapper.Map<List<ReadCinemaDTO>>(_context.Cinemas.ToList());
        }

        return _mapper.Map<List<ReadCinemaDTO>>(_context.Cinemas.FromSqlRaw($"SELECT Id, Nome, EnderecoID from cinemas where cinemas.EnderecoId = {enderecoId}").ToList());

    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCinemaPorID(int id) {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema=>cinema.Id == id);
        if(cinema!=null) {
            ReadCinemaDTO cinemaDTO=_mapper.Map<ReadCinemaDTO>(cinema);
            return Ok(cinemaDTO);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDTO cinemaDTO) {

        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null) {
            return NotFound(cinemaDTO);
        }
        _mapper.Map(cinemaDTO, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchCinema(int id, JsonPatchDocument<UpdateCinemaDTO> patch) {

        var cinema = _context.Filmes.FirstOrDefault(cinema => cinema.id == id);
        if (cinema == null) {
            return NotFound();
        }

        var cinemaParaAtualizar = _mapper.Map<UpdateCinemaDTO>(cinema);

        patch.ApplyTo(cinemaParaAtualizar, ModelState);

        if (!TryValidateModel(cinemaParaAtualizar)) {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(cinemaParaAtualizar, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaCinema(int id) {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null) {
            return NotFound();
        }

        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }
}