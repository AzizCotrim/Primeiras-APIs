using ApiRestPokemon.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiRestPokemon.Data
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options) {

        }

        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
