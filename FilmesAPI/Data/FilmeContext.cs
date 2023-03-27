using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FilmesAPI.Data;

public class FilmeContext : DbContext {

    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts) {

    }

    public DbSet<Filme> Filmes { get; set; }
}