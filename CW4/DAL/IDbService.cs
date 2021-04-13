using System.Collections.Generic;
using CW4.Models;

namespace CW4.DAL
{
    public interface IDbService
    {
        public IEnumerable<Animal> GetAnimals();
        public Animal GetAnimal(int id);
    }
}