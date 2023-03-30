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

    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<Sessao>().HasKey(sessao=>new {sessao.filmeID,sessao.cinemaID});

        builder.Entity<Sessao>().HasOne(sessao => sessao.Cinema).WithMany(cinema => cinema.sessoes).
            HasForeignKey(sessao => sessao.cinemaID);

        builder.Entity<Sessao>().HasOne(sessao => sessao.filme).WithMany(filme => filme.sessoes).
            HasForeignKey(sessao => sessao.filmeID);

        builder.Entity<Endereco>().
            HasOne(endereco => endereco.cinema).
            WithOne(cinema => cinema.endereco).
            OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas  { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
}