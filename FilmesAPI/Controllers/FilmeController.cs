using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Linq.Expressions;
using FilmesAPI.Data.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase {

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto"></param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Inserção bem sucedida</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDto) {

        Filme filme= _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        Console.WriteLine(filme.titulo);
        Console.WriteLine(filme.duracao);
        return CreatedAtAction(nameof(RecuperaFilmePorID), new { id = filme.id }, filme);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDTO> RecuperaFilmes([FromQuery] int skip = 0,
            [FromQuery] int take = 50, [FromQuery] string? nomeCinema=null){

        if (nomeCinema == null) {
            return _mapper.Map<List<ReadFilmeDTO>>(_context.Filmes.Skip(skip).Take(take).ToList());
        }

        return _mapper.Map<List<ReadFilmeDTO>>(_context.Filmes.
            Skip(skip).Take(take).
                Where(filme => filme.sessoes.Any(sessao => sessao.Cinema.Nome == nomeCinema)).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorID(int id) {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);
        if(filme == null) {
            return NotFound();
        }
        var filmeDto=_mapper.Map<ReadFilmeDTO>(filme);
        return Ok(filmeDto);        
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody]UpdateFilmeDTO filmeDTO) {

        var filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);
        if(filme == null) {
            return NotFound(filmeDTO);
        }
        _mapper.Map(filmeDTO, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchFilme(int id, JsonPatchDocument<UpdateFilmeDTO> patch) {

        var filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);
        if (filme == null) {
            return NotFound();
        }

        var filmeParaAtualizar=_mapper.Map<UpdateFilmeDTO>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar)) {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id) {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);
        if(filme== null) {
            return NotFound();
        }

        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}