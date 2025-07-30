using ApiRestPokemon.Data;
using ApiRestPokemon.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestPokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase {
        private readonly PokemonContext _context;

        public PokemonController(PokemonContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemons(){
            var pokemons = await _context.Pokemons.ToListAsync();
            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(int id) {
            var pokemon = await _context.Pokemons.FindAsync(id);

            if (pokemon == null)
                return NotFound("Não existe esse Id");

            return Ok(pokemon);
        }

        [HttpPost]
        public async Task<ActionResult<Pokemon>> PostPokemon(Pokemon pokemon) {
            try {
                _context.Pokemons.Add(pokemon);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPokemon), new { id = pokemon.Id }, pokemon);
            }catch(DbUpdateException ex) {
                return BadRequest($"Erro ao salvar: {ex.Message}");
            }catch(Exception ex) {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPokemon(int id, Pokemon pokemonAtualizado) {
            if (id != pokemonAtualizado.Id) {
                return BadRequest();
            }

            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null) {
                return NotFound();
            }

            pokemon.Geracao = pokemonAtualizado.Geracao;
            pokemon.Nome = pokemonAtualizado.Nome;
            pokemon.Tipo = pokemonAtualizado.Tipo;

            try {
                
                await _context.SaveChangesAsync();
                return NoContent();
            }catch(DbUpdateException ex) {
                return BadRequest($"Erro ao salvar: {ex.Message}");
            }catch(Exception ex) {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemon(int id) {
            var pokemon = await _context.Pokemons.FindAsync(id);

            if(pokemon == null) {
                return NotFound();
            }

            _context.Pokemons.Remove(pokemon);
            await _context.SaveChangesAsync();
            return NoContent();

        }

    }
}
