using FilmesAPI.Models;
using FilmesAPI.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Proxies;

namespace FilmesAPI.Data;

public class FilmeContext : DbContext {

    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts) {

    }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas  { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
}