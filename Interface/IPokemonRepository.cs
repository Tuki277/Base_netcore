using api_base.Dto;
using api_base.Models;

namespace api_base.Interface
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();

        Pokemon GetPokemon(int id);

        Pokemon GetPokemon(string name);

        decimal GetPokemonRating(int pokeId);

        Pokemon GetPokemonTrimToUpper(PokemonDto pokemonCreate);

        bool PokemonExists(int pokeId);

        bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);

        bool Save();
    }
}