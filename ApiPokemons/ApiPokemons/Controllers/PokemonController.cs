using ApiPokemons.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller {
        List<Pokemon> _pokemon = new List<Pokemon> {
            new Pokemon { Id = 1, Geracao = 1, Nome = "Bulbasaur", Tipo = "Grass" },
            new Pokemon { Id = 2, Geracao = 1, Nome = "Ivysaur", Tipo = "Grass" },
            new Pokemon { Id = 3, Geracao = 1, Nome = "Venusaur", Tipo = "Grass" },
            new Pokemon { Id = 4, Geracao = 1, Nome = "Charmander", Tipo = "Fire" },
            new Pokemon { Id = 5, Geracao = 1, Nome = "Charmeleon", Tipo = "Fire" },
            new Pokemon { Id = 6, Geracao = 1, Nome = "Charizard", Tipo = "Fire" },
            new Pokemon { Id = 7, Geracao = 1, Nome = "Squirtle", Tipo = "Water" },
            new Pokemon { Id = 8, Geracao = 1, Nome = "Wartortle", Tipo = "Water" },
            new Pokemon { Id = 9, Geracao = 1, Nome = "Blastoise", Tipo = "Water" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Pokemon>> GetPokemons() {
            return Ok(_pokemon);
        }

        [HttpGet("{id}")]
        public ActionResult<Pokemon> GetPokemon(int id) {

            var pokemon = _pokemon.FirstOrDefault(x => x.Id == id);

            return pokemon == null ? NotFound() : Ok(pokemon);
        }

        [HttpPost]
        public IActionResult PostPokemon(Pokemon pokemon) {
            if (pokemon == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            pokemon.Id = _pokemon.Max(p => p.Id) + 1;
            _pokemon.Add(pokemon);
            return Ok(pokemon);

        }

        [HttpPut("{id}")]
        public IActionResult PutPokemon(int id, Pokemon pokemonAtualizado) {
            var pokemonExistente = _pokemon.FirstOrDefault(c => c.Id == id);
            if (pokemonExistente == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            pokemonExistente.Geracao = pokemonAtualizado.Geracao;
            pokemonExistente.Nome = pokemonAtualizado.Nome;
            pokemonExistente.Tipo = pokemonAtualizado.Tipo;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePokemon(int id) {
            var pokemon = _pokemon.FirstOrDefault(x => x.Id == id);
            if (pokemon == null)
                return NotFound();
            _pokemon.Remove(pokemon);

            return NoContent();
            
        }
    }
}
