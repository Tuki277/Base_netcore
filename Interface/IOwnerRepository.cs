using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_base.Models;

namespace api_base.Interface
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();

        Owner GetOwner(int ownerId);

        ICollection<Owner> GetOwnerOfAPokemon(int pokeId);

        ICollection<Pokemon> GetPokemonByOwner(int ownerId);

        bool OwnerExists(int ownerId);
    }
}